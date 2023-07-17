using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random=UnityEngine.Random;

public class CubeController : MonoBehaviour
{

	public enum DirectionMouvement
	{
		Gauche,	// Axe Y, positif
		Droite,	// Axe Y, negatif
		Haut,	// Axe X si camera à gauche, Z si camera à droite, negatif
		Bas		// Axe X si camera à gauche, Z si camera à droite, positif

	}

	public float m_vitesseRotation = 5.0f;	// vitesse de rotation du cube en degrees/seconde
	public Camera m_camera; 				// ref sur la camera pour obtenir l'orientation
	private CameraController m_cameraController;
	public float m_echelleMin = 25.0f;
	public float m_echelleMax = 50.0f;
	public float m_echelleTempsAnimation = 0.05f; // en seconde

	public float Landscape_FOV = 19;			// FOV de la camera en fonction du type de cube
	public float Portrait_FOV = 38;

	
	// la liste et position des briques qui composent le cube
	private Brique[] m_briques;
	private AbstractMatrix m_matrix;
	private short[] m_selectBandes; 		// les bandes sur les 3 axes qui correspondent à la brique selectionné

	private bool m_enrotation = false; 		// si une rotation de bande en cours
	private AudioSource deplacementClip;	// le clip pour la rotation
	private AudioSource selectionClip;		// le clip la selection d'une bande
	private AudioSource gagnerClip;			// le clip à lancer quand le jour a gagné

	/**
	 * 
	 */
	public AbstractMatrix getMatrix() {
		return m_matrix;
	}

	/**
	 * si fait une rotation de bande : pas de selection possible
	 */
	public bool enRotationDeBande() {
		return m_enrotation;
	}

	void Awake() {
	
		if (gameObject.CompareTag ("Cube3")) {
			m_matrix = new Cube3x3Matrix();
			return;
		}

		if (gameObject.CompareTag ("Cube4")) {
			m_matrix = new Cube4x4Matrix();
			return;
		}

		if (gameObject.CompareTag ("Cube5")) {
			m_matrix = new Cube5x5Matrix();
			return;
		}

		throw new Exception ("GameObject tag and matrix mismatch, fix it");
	}

	void Start ()
	{
		m_cameraController = m_camera.GetComponent<CameraController> ();

		CameraFOVController cam_fov = m_camera.GetComponent<CameraFOVController> ();
		cam_fov.setFOV (Landscape_FOV, Portrait_FOV);

		m_briques = m_matrix.getBriques ();

		// creation des briques du cube
		foreach (Brique b in m_briques) {
	//		Debug.Log("??? " + b.x + " --- " + b.y + " --- " + b.z);
			b.obj = Instantiate (Resources.Load (b.type, typeof(GameObject)),
	                             new Vector3 (b.x, b.y, b.z), 
	                             Quaternion.Euler (b.rx, b.ry, b.rz),
			                     transform
			) as GameObject;
			b.obj.name = b.name;
		}

		AudioSource[] liste = GetComponentsInChildren<AudioSource> ();
		
		foreach (AudioSource s in liste) {
			if(s.name.CompareTo("deplacementSnd") ==0 ) {
				deplacementClip=s;
				continue;
			}
			if(s.name.CompareTo("selectionSnd") ==0 ) {
				selectionClip=s;
				continue;
			}
			if(s.name.CompareTo("gagnerSnd") ==0 ) {
				gagnerClip=s;
				continue;
			}
		}

		ScoreManager.instance.SetTour (0);
	}

	/**
	 * 
	 */
	void OnEnable ()
	{
		EventManager.StartListening (GameEventTrigger.BANDEGAUCHE, BandeAGauche);
		EventManager.StartListening (GameEventTrigger.BANDEDROITE, BandeADroite);
		EventManager.StartListening (GameEventTrigger.BANDEBAS, BandeVersLeBas);
		EventManager.StartListening (GameEventTrigger.BANDEHAUT, BandeVersLeHaut);
		EventManager.StartListening (GameEventTrigger.SELECTIONNEBRIQUE, SelectionnerBrique);
		EventManager.StartListening (GameEventTrigger.EFFACERSELECTION, EffacerSelection);

	}
	
	/**
	 * 
	 */
	void OnDisable ()
	{
		EventManager.StopListening (GameEventTrigger.BANDEGAUCHE, BandeAGauche);
		EventManager.StopListening (GameEventTrigger.BANDEDROITE, BandeADroite);
		EventManager.StopListening (GameEventTrigger.BANDEBAS, BandeVersLeBas);
		EventManager.StopListening (GameEventTrigger.BANDEHAUT, BandeVersLeHaut);
		EventManager.StopListening (GameEventTrigger.SELECTIONNEBRIQUE, SelectionnerBrique);
		EventManager.StopListening (GameEventTrigger.EFFACERSELECTION, EffacerSelection);
	}

	/**
	 * on lance le melange alleatoire du cube
	 */
	public void MelangerPour(int tour) {
		StartCoroutine (DoMelanger (tour));
	}

	/**
	 * fait la rotation aleatoire d'une bande
	 */
	private IEnumerator DoMelanger(int tour) {
		// FIX ne fonctionne que pour le cube 3
		int taille = 18;
		switch (m_matrix.type) {
		case "Cube4x4":
			taille = 24;
			break;
		case "Cube5x5":
			taille = 30;
			break;
		}

		while (true) {
			int val = Random.Range(0,taille-1);

			AbstractMatrix.AXES axe = AbstractMatrix.AXES.Z;
			// 3 axes possible avec 2 sens
			switch(val % 6) {
				case 0:
				case 1:
					axe = AbstractMatrix.AXES.X;
					break;
				case 2:
				case 3:
					axe = AbstractMatrix.AXES.Y;
					break;
			}

			TournerSansAnimation (axe, 
			                      val % 2 == 0 ? false : true,
			                     (short)( val / 6)
			                      );

			/*
			switch (Random.Range (1, taille)) {
			case 1:
				TournerSansAnimation (AbstractMatrix.AXES.X, false, 0);
				break;
			case 2:
				TournerSansAnimation (AbstractMatrix.AXES.X, false, 1);
				break;
			case 3:
				TournerSansAnimation (AbstractMatrix.AXES.X, false, 2);
				break;
			case 4:
				TournerSansAnimation (AbstractMatrix.AXES.X, true, 0);
				break;
			case 5:
				TournerSansAnimation (AbstractMatrix.AXES.X, true, 1);
				break;
			case 6:
				TournerSansAnimation (AbstractMatrix.AXES.X, true, 2);
				break;
			case 7:
				TournerSansAnimation (AbstractMatrix.AXES.Y, false, 0);
				break;
			case 8:
				TournerSansAnimation (AbstractMatrix.AXES.Y, false, 1);
				break;
			case 9:
				TournerSansAnimation (AbstractMatrix.AXES.Y, false, 2);
				break;
			case 10:
				TournerSansAnimation (AbstractMatrix.AXES.Y, true, 0);
				break;
			case 11:
				TournerSansAnimation (AbstractMatrix.AXES.Y, true, 1);
				break;
			case 12:
				TournerSansAnimation (AbstractMatrix.AXES.Y, true, 2);
				break;
			case 13:
				TournerSansAnimation (AbstractMatrix.AXES.Z, false, 0);
				break;
			case 14:
				TournerSansAnimation (AbstractMatrix.AXES.Z, false, 1);
				break;
			case 15:
				TournerSansAnimation (AbstractMatrix.AXES.Z, false, 2);
				break;
			case 16:
				TournerSansAnimation (AbstractMatrix.AXES.Z, true, 0);
				break;
			case 17:
				TournerSansAnimation (AbstractMatrix.AXES.Z, true, 1);
				break;
			case 18:
				TournerSansAnimation (AbstractMatrix.AXES.Z, true, 2);
				break;
			}
*/
			tour--;
			if(tour<=0) {
				StateManager.Action(StateManager.Message.FINMELANGE);
				yield break;
			}

			yield return null;
		}
	}

	/**
	 * 
	 */
	public void SelectionnerBrique() {
		switch(StateManager.instance.state) {
		case StateManager.State.ATTENTE :
		case StateManager.State.SELECTIONACTIVE :
			break;
		default:
			return;
		}

		Brique bri = TrouveBriqueParNom (StateManager.briqueSelectionne);
		if (bri == null) {
			return;
		}

		// ok, passe en selection
		StateManager.Action(StateManager.Message.SELECTION);

		// on a une brique, recherche les voisins
		m_selectBandes = m_matrix.TrouverBandePourBrique(bri.uuid);
		
		// selectionnne horizontal, c'est l'axe y
		short[] brique_h = m_matrix.TrouverBriqueSur(AbstractMatrix.AXES.Y,m_selectBandes[1]);
		short[] brique_v;
		if(m_cameraController.getPosition() == CameraController.PositionCamera.Gauche) {
			// c'est X
			brique_v = m_matrix.TrouverBriqueSur(AbstractMatrix.AXES.X,m_selectBandes[0]);
		} else {
			brique_v = m_matrix.TrouverBriqueSur(AbstractMatrix.AXES.Z,m_selectBandes[2]);
		}
		
		short[] liste = CombinerListe(brique_h,brique_v);

		List<short> activer = new List<short> ();
		foreach (Brique br in m_briques) {
			if(ContientUuid(liste, br.uuid)) {
				// on exclut les brique que lon peut faire tourner
				continue;
			}

			activer.Add(br.uuid);
		}

		// on scale down les autres briques, up celle qui font partie de la selection
		if (selectionClip != null) {
			selectionClip.Play ();
		}
		StartCoroutine (AfficherSelection (activer.ToArray()));
	}
	
	/**
	 * 
	 */
	public void BandeAGauche() {
		if (StateManager.instance.state != StateManager.State.SELECTIONACTIVE) {
			return;
		}

		StartCoroutine (tournerBande(AbstractMatrix.AXES.Y,false,m_selectBandes[1]));
	}

	/**
	 * 
	 */

	public void BandeADroite() {
		if (StateManager.instance.state != StateManager.State.SELECTIONACTIVE) {
			return;
		}

		StartCoroutine (tournerBande(AbstractMatrix.AXES.Y,true,m_selectBandes[1]));
	}

	/**
	 * 
	 */
	public void BandeVersLeBas() {
		if (StateManager.instance.state != StateManager.State.SELECTIONACTIVE) {
			return;
		}

		if(m_cameraController.getPosition() == CameraController.PositionCamera.Gauche) {
			StartCoroutine (tournerBande(AbstractMatrix.AXES.X,false, m_selectBandes[0]));
			return;
		}
		
		StartCoroutine (tournerBande( AbstractMatrix.AXES.Z, false,m_selectBandes[2]));
	}
	
	/**
	 * 
	 */
	public void BandeVersLeHaut() {
		if (StateManager.instance.state != StateManager.State.SELECTIONACTIVE) {
			return;
		}

		if(m_cameraController.getPosition() == CameraController.PositionCamera.Gauche) {
			StartCoroutine (tournerBande(AbstractMatrix.AXES.X,true, m_selectBandes[0]));
			return;
		}
		
		StartCoroutine (tournerBande( AbstractMatrix.AXES.Z, true,m_selectBandes[2]));
	}
	
	/**
	 * 
	 */
	private IEnumerator tournerBande(AbstractMatrix.AXES axe, bool sens, short bandeId) {

		StateManager.Action(StateManager.Message.MOUVEMENT);

		// reset l'etat visuel des briques avant de faire une rotation
		EffacerSelection ();
		
		m_enrotation = true;
		deplacementClip.Play ();

		// on le fait à la fin par trigger
		//ScoreManager.AjouterTour ();

		// calcule la matrice de rotation
		Vector3 matriceRotation;

		switch (axe) {
			case AbstractMatrix.AXES.X:
				matriceRotation = new Vector3(1.0f,0.0f, 0.0f);
				break;
			case AbstractMatrix.AXES.Y :
				matriceRotation = new Vector3(0.0f,1.0f, 0.0f);
				break;
			default :
				matriceRotation = new Vector3(0.0f,0.0f, 1.0f);
				break;
		}

		// les brique à faire tourner
		short[] liste = m_matrix.TrouverBriqueSur (axe, bandeId);

		float m_animationAngleTarget = 90.0f; // on travaille en absolue
		float m_animationAngleActuel = 0.0f;
		
		while (true) {
			float delta = m_animationAngleTarget * m_vitesseRotation * Time.deltaTime;
			if (m_animationAngleActuel + delta >= m_animationAngleTarget) {
				delta = m_animationAngleTarget - m_animationAngleActuel;
				m_enrotation = false;
			}
			m_animationAngleActuel += delta;
			
			if(sens) {
				delta *= -1;
			}

			foreach(short id in liste) {
				Brique br = TrouveBriqueParUuid(id);
				br.obj.transform.RotateAround (transform.position, matriceRotation, delta);
			}

			// fin rotation, fait la rotation des brique dans la matrice
			if (m_enrotation == false) {
				m_matrix.RotationBande(axe,sens,bandeId);

				if(m_matrix.ASolution() ){
					if(gagnerClip!=null) {
						gagnerClip.Play();
					}
					StateManager.Action(StateManager.Message.CUBECOMPLET);
				} else {
					StateManager.Action(StateManager.Message.FINMOUVEMENT);
				}
				yield break;
			}

			yield return null;
		}
	}

	/**
	 * fait une rotation d'une bande mais directement, sans animation
	 */
	private void TournerSansAnimation(AbstractMatrix.AXES axe, bool sens, short bandeId) {
		Vector3 matriceRotation;
		
		switch (axe) {
		case AbstractMatrix.AXES.X:
			matriceRotation = new Vector3(1.0f, 0.0f, 0.0f);
			break;
		case AbstractMatrix.AXES.Y :
			matriceRotation = new Vector3(0.0f, 1.0f, 0.0f);
			break;
		default :
			matriceRotation = new Vector3(0.0f, 0.0f, 1.0f);
			break;
		}
		
		// les brique à faire tourner
		short[] liste = m_matrix.TrouverBriqueSur (axe, bandeId);

		float m_animationAngleTarget = sens ? -90.0f : 90.0f; // on travaille en absolue

		foreach(short id in liste) {
			Brique br = TrouveBriqueParUuid(id);
			br.obj.transform.RotateAround (transform.position, matriceRotation, m_animationAngleTarget);
		}

		m_matrix.RotationBande(axe,sens,bandeId);
	}

	/**
	 * change et anime la taille d'une brique
	 */
	private IEnumerator AfficherSelection(short[] liste) {

		List<GameObject> reduire = new List<GameObject> ();
		List<GameObject> augmenter = new List<GameObject>();

		// on evite les pb d'arondi, on ce basse sur une moyenne
		float delta = (m_echelleMax + m_echelleMin) / 2.0f;

		// calcule les liste des briques à manipuler
		foreach (Brique br in m_briques) {
			bool dansliste = ContientUuid(liste,br.uuid);

			// a selectionner mais déjà au mini, rine à faire
			if( dansliste && br.obj.transform.localScale.x < delta)  {
				continue;
			}

			// dans la liste mais a taille max, on ajoute
			if(dansliste) {
				reduire.Add(br.obj);
			}

			// pas dans la liste et déjà à taille max, rien à faire
			if(br.obj.transform.localScale.x > delta) {
				continue;
			}
		
			// donc pas dans la liste mais taille au mini, on doit revenir à la taille max
			augmenter.Add(br.obj);
		}

		if (augmenter.Count == 0 && reduire.Count == 0) {
			yield break;
		}

		Vector3 min = new Vector3 (m_echelleMin, m_echelleMin, m_echelleMin);
		Vector3 max = new Vector3 (m_echelleMax, m_echelleMax, m_echelleMax);

		float t = 0.0f;
		while(t<=1.0f) {
			t += Time.deltaTime / m_echelleTempsAnimation;

			if(reduire.Count>0) {
				foreach(GameObject obj in reduire) {
					// transform change à chaque frame donc on doit utiliser la valeur de depart et pas obj.position.localScale
					obj.transform.localScale = Vector3.Lerp(max ,min ,t);
				}
			}

			if(augmenter.Count>0) {
				foreach(GameObject obj in augmenter) {
					obj.transform.localScale = Vector3.Lerp(min ,max ,t);
				}
			}

			yield return null;
		}
	}

	/**
	 * supprime la selection en cours
	 */
	public void EffacerSelection() {
		StartCoroutine (AfficherSelection(new short[0]));
	}

	/**
	 * retourne l'index dans le tableau briques de la brique ayant le nom name.
	 * @return index de la brique ou -1 si trouve pas
	 */
	private Brique TrouveBriqueParNom(string name) {

		foreach(Brique b in m_briques) {
			if(b.name == name) {
				return b;
			}
		}

		return null;
	}

	/**
	 *
	 **/
	private Brique TrouveBriqueParUuid(short uuid) {
		foreach(Brique b in m_briques) {
			if(b.uuid == uuid) {
				return b;
			}
		}

		return null;
	}

	/**
	 * combine 2 arrays et supprime les doublons
	 */
	private short[] CombinerListe(short[] a, short[] b) {

		List<short> l = new List<short> ();

		foreach (short item in a) {
			if(l.Contains(item)) {
				continue;
			}
			l.Add(item);
		}

		foreach (short item in b) {
			if(l.Contains(item)) {
				continue;
			}
			l.Add(item);
		}

		return l.ToArray ();
	}

	/**
	 * retourne true si uuid est dans liste
	 */
	private static bool ContientUuid(short[] liste, short uuid) {

		foreach (short id in liste) {
			if (id == uuid) {
				return true;
			}
		}
		return false;
	}
	
	/**
	 * change la couleur d'émission de la brique et de tous ces sub obj
	 */
	private void changerEmission(GameObject obj, float emission) {
		Renderer[] rend = obj.GetComponentsInChildren<Renderer>();
		foreach(Renderer r in rend) {
			r.material.SetColor("_EmissionColor", new Color(emission,emission,emission));
		}
	}

	/**
	 * 
	 */
	public GameObject TrouverObject(string name) {

		Transform[] liste = transform.GetComponentsInChildren<Transform>(true);
		foreach (Transform ts in liste) {
			if(ts.gameObject.name == name) {
				return ts.gameObject;
			}
		}

		return null;
	}
		
	/**
	 * initialise la matrise (et les obj) dans l"etat sauvé par bean
	 */
	public void Charger(GameProgressBean bean) {
		// FIX : la position du cube n'a pas d'importatnce cas on fait desrotation AUTOUR d'axe et on garde une matrice par rapport 
		// à la camera, on positionne déjà les briques (pos + rot) en fonction de la matrise
	//	transform.rotation = new Quaternion(bean.cube.rx, bean.cube.ry, bean.cube.rz, bean.cube.rw);

		m_matrix.Charger (bean);
	}
	
	/**
	 * sauvegarde l'etat de la matrise (et des obj)
	 */
	public GameProgressBean Sauver() {

		return m_matrix.Sauver ();
	}
}
