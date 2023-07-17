using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraController : MonoBehaviour {

	public enum PositionCamera {
		Gauche, // tourne sur l'axe des X
		Droite // tourne sur l'axe des Z
	}

	public float m_angleCamera = 15.0f; // l'angle de deviation gauche/droite sur l'axe des y (local) en degrees
	public float m_vitesseRotation = 15.0f; // vitesse de rotation en degrees / seconde
	public Transform m_regardeVers; // objet vers lequel la camera regarde

	private PositionCamera m_position; // direction vers laquelle regarde la camera
	private bool m_animationRotation=false; // true si en cours de déplacement de la camera
	private float m_angleTarget = 0.0f; // on travaille en absolue
	private float m_angleTargetActuel = 0.0f; // idem ; les 2 servent à savoir on on se trouve dans l'animation

	private Coroutine m_CoroutineDeplacement;
	/**
	 * direction vers laquelle regarde la camera
	 */
	public PositionCamera getPosition() {
		return m_position;
	}

	/**
	 * true si la camera est en train de bouger
	 */
	public bool GetEnDeplacement() {
		return m_animationRotation;
	}

	/**
	 * Awake is called when the script instance is being loaded.
	 */
	private void Awake()
	{
		m_angleCamera = Mathf.Abs (m_angleCamera); // pas de valeur negative
		m_vitesseRotation = Mathf.Abs (m_vitesseRotation); // pas de valeur negative

		tournerCamera (m_angleCamera); // positionne sur la gauche
	}

	/**
	 * Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	 */
	void Start () {
		Reset ();
	}

	/**
	 * Reset to default values.
	 */
	void Reset() {
		if (m_CoroutineDeplacement != default(Coroutine)) {
			StopCoroutine(m_CoroutineDeplacement);
		}

		if (m_position == PositionCamera.Gauche) {
			return;
		}

		// on est à droite
		m_position = PositionCamera.Gauche;
		tournerCamera (m_angleCamera*2);
	}

	/**
	 * 
	 */
	void OnEnable ()
	{
		EventManager.StartListening (GameEventTrigger.TOURNETCAMERA, pivoterCamera);
	}
	
	/**
	 * 
	 */
	void OnDisable ()
	{
		EventManager.StopListening (GameEventTrigger.TOURNETCAMERA, pivoterCamera);
	}

	/**
	 * pivote l'orientation de la camera gauche/droite
	 */
	public void pivoterCamera() {
		// déjà en déplacement de la camera
		if (m_animationRotation) {
			return;
		}

		m_position = m_position == PositionCamera.Droite ? PositionCamera.Gauche : PositionCamera.Droite;
		
		m_CoroutineDeplacement= StartCoroutine (deplacerCamera ());
	}

	/**
	 * deplace la camera vers la nouvelle position
	 */
	private IEnumerator deplacerCamera() {

		m_angleTarget = m_angleCamera * 2; // *2 car deja sur une limite
		m_angleTargetActuel = 0.0f;
		m_animationRotation = true;

		while(true) {
			// anime; verif qu'on dépasse pas
			float delta	 = m_angleTarget * m_vitesseRotation * Time.deltaTime;
			if (m_angleTargetActuel + delta >= m_angleTarget) {
				delta = m_angleTarget - m_angleTargetActuel;
				m_animationRotation = false;
			}
			m_angleTargetActuel += delta;
			
			// positif tourne vers la gauche
			if (m_position == PositionCamera.Droite) {
				// angle négatif autour de Y vers la droite
				delta = delta * -1;
			}

			tournerCamera (delta);

			if (m_animationRotation == false) {
				yield break;
			}

			yield return null;
		}
	}

	/**
	 * fait la rotation de la camera de "angle" degres sur l'axe local des Y
	 */
	private void tournerCamera(float angle) {
		transform.RotateAround (m_regardeVers.position, Vector3.up, angle);
	}

}
