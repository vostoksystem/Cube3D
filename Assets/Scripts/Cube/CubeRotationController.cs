using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeRotationController : MonoBehaviour {

	public float m_vitesseRotation = 5.0f; 		// vitesse de rotation du cube en degrees/seconde
	public Camera m_camera; 					// ref sur la camera pour obtenir l'orientation
	private CameraController m_cameraController;
	
	private Quaternion m_originalRotationValue;
	private bool m_animationRotation = false; 	// true si en train de faire tourner le cube
	private Coroutine m_CoroutineRotation;

	private AudioSource clip;					// le clip pour la rotation

	/**
	 * 
	 */
	void Start ()
	{
		m_cameraController = m_camera.GetComponent<CameraController> ();
		m_originalRotationValue = transform.rotation;

		AudioSource[] liste = GetComponentsInChildren<AudioSource> ();

		foreach (AudioSource s in liste) {
			if(s.name.CompareTo("rotationSnd") ==0 ) {
				clip=s;
				break;
			}
		}
	}

	/**
	 * 
	 */
	void OnEnable ()
	{
		EventManager.StartListening (GameEventTrigger.CUBEGAUCHE, TournerAGauche);
		EventManager.StartListening (GameEventTrigger.CUBEDROITE, TournerADroite);
		EventManager.StartListening (GameEventTrigger.CUBEHAUT, TournerVersLeBas);
		EventManager.StartListening (GameEventTrigger.CUBEBAS, TournerVersLeHaut);
	}

	/**
	 * 
	 */
	void OnDisable ()
	{
		EventManager.StopListening (GameEventTrigger.CUBEGAUCHE, TournerAGauche);
		EventManager.StopListening (GameEventTrigger.CUBEDROITE, TournerADroite);
		EventManager.StopListening (GameEventTrigger.CUBEHAUT, TournerVersLeBas);
		EventManager.StopListening (GameEventTrigger.CUBEBAS, TournerVersLeHaut);
	}

	/**
	 * 
	 */
	void TournerAGauche() {
		if (m_animationRotation) {
			return;
		}

		m_CoroutineRotation= StartCoroutine (animerCube (CubeController.DirectionMouvement.Gauche));
	}

	/**
	 * 
	 */
	void TournerADroite() {
		if (m_animationRotation) {
			return;
		}
		
		m_CoroutineRotation= StartCoroutine (animerCube (CubeController.DirectionMouvement.Droite));
	}
	/**
	 * 
	 */
	void TournerVersLeBas() {
		if (m_animationRotation) {
			return;
		}
		
		m_CoroutineRotation= StartCoroutine (animerCube (CubeController.DirectionMouvement.Bas));
	}
	/**
	 * 
	 */
	void TournerVersLeHaut() {
		if (m_animationRotation) {
			return;
		}
		
		m_CoroutineRotation= StartCoroutine (animerCube (CubeController.DirectionMouvement.Haut));
	}

	/**
	* Reset to default values.
	*/
	void Reset ()
	{
		if (m_CoroutineRotation != default(Coroutine)) {
			StopCoroutine(m_CoroutineRotation);
		}

		transform.rotation = Quaternion.Slerp (transform.rotation, m_originalRotationValue, 1.0f);
	}

	/**
	 * retourne true si en cours d'animation / rotation du cube
	 */
	public bool GetEnRotation() {
		return m_animationRotation;
	}

	/**
	 * 
	 */
	private IEnumerator animerCube (CubeController.DirectionMouvement direction)
	{
		float x = 0.0f;
		float y = 0.0f;
		float z = 0.0f;

		m_animationRotation = true;
		float m_animationAngleTarget = 90.0f; // on travaille en absolue
		float m_animationAngleActuel = 0.0f;

		StateManager.Action(StateManager.Message.ROTATION);

	//	if (SoundController.instance.SoundEnabled && clip != null) {
			clip.Play();
	//	}

		while (true) {

			float delta = m_animationAngleTarget * m_vitesseRotation * Time.deltaTime;
			if (m_animationAngleActuel + delta >= m_animationAngleTarget) {
				delta = m_animationAngleTarget - m_animationAngleActuel;
				m_animationRotation = false;
			}
			m_animationAngleActuel += delta;

			switch (direction) {
			case CubeController.DirectionMouvement.Droite:
				delta *= -1;
				y = 1.0f;
				break;
			
			case CubeController.DirectionMouvement.Gauche:
				y = 1.0f;
				break;
			
			case CubeController.DirectionMouvement.Bas:
				delta *= -1;
				if (m_cameraController.getPosition () == CameraController.PositionCamera.Gauche) {
					x = 1.0f;
					break;
				}
			
				z = 1.0f;
				break;
			
			case CubeController.DirectionMouvement.Haut:
				if (m_cameraController.getPosition () == CameraController.PositionCamera.Gauche) {
					x = 1.0f;
					break;
				}
			
				z = 1.0f;
				break;
			
			default:
				yield break;
			}
		
			transform.RotateAround (transform.position, new Vector3 (x, y, z), delta);

			if (m_animationRotation == false) {

				AbstractMatrix matrix = GetComponent<CubeController> ().getMatrix();

				switch (direction) {
				case CubeController.DirectionMouvement.Droite:
					matrix.RotationCube(AbstractMatrix.AXES.Y,true);
					break;
				case CubeController.DirectionMouvement.Gauche:
					matrix.RotationCube(AbstractMatrix.AXES.Y,false);
					break;
				case CubeController.DirectionMouvement.Bas:
					matrix.RotationCube(
						m_cameraController.getPosition() == CameraController.PositionCamera.Gauche ? 
						AbstractMatrix.AXES.X : AbstractMatrix.AXES.Z,true);
					break;
				case CubeController.DirectionMouvement.Haut:
					matrix.RotationCube(
						m_cameraController.getPosition() == CameraController.PositionCamera.Gauche ? 
						AbstractMatrix.AXES.X : AbstractMatrix.AXES.Z,false);
					break;
				}

			//	matrix.debug();

				StateManager.Action(StateManager.Message.FINROTATION);

				// pour le debug
				matrix.ASolution();


				yield break;
			}
			
			yield return null;
		}
	}

}
