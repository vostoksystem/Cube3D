using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Lean.Touch;

public class GameEventTrigger : MonoBehaviour {

	public const string TOURNETCAMERA = "TournerCamera";
	public const string CUBEGAUCHE = "CubeGauche";
	public const string CUBEDROITE = "CubeDroite";
	public const string CUBEHAUT = "CubeHaut";
	public const string CUBEBAS = "CubeBas";
	public const string BANDEGAUCHE = "BandeGauche";
	public const string BANDEDROITE = "BandeDroite";
	public const string BANDEHAUT = "BandeHaut";
	public const string BANDEBAS = "BandeBas";
	public const string SELECTIONNEBRIQUE = "SelectionneBrique";
	public const string EFFACERSELECTION = "EffacerSelection";

	// les evenement pour la communication inter objet
	public const string AJOUTERTOUR = "AjouterTour";

	enum Action {
		AUCUNE,
		G,
		D,
		H,
		B,
		CLICK
	}

	private const float touchDelta = 50.0f;

	public Camera m_camera; // ref sur la camera pour obtenir l'orientation
	private CameraController m_cameraController;

	void Awake() {
		m_cameraController = m_camera.GetComponent<CameraController> ();
	}

	/**
	 * 
	 */
	void OnEnable()
	{
		LeanTouch.OnFingerTap += TouchAppEcran;
		LeanTouch.OnFingerSwipe += TouchSwipe;
	}

	/**
	 * 
	 */
	void OnDisable()
	{
		LeanTouch.OnFingerTap -= TouchAppEcran;
		LeanTouch.OnFingerSwipe -= TouchSwipe;

	}

	/**
	 * 
	 */
	void Update () {
		if (m_cameraController.GetEnDeplacement ()) {
			return;
		}

		Vector2 bp;
		Action b = ClavierSouris (out bp);

		switch (StateManager.instance.state) {
		case StateManager.State.ATTENTE :
			EnAttente(b, bp);
			break;
		case StateManager.State.SELECTIONACTIVE :
			EnSelection(b, bp);
			break;
		}
	}

	/**
	 * 
	 */
	private void EnAttente(Action action, Vector2 position) {

		// peut être un clic souris ?
		switch(action) {
		case Action.CLICK:
			// o verifie si sur une brique
			RaycastHit hitInfo = new RaycastHit ();
			Ray ray = m_camera.ScreenPointToRay (position);
			
			// si sur le cube fait une selection / deselection
			if (Physics.Raycast (ray, out hitInfo)) {
				if(hitInfo.transform.gameObject.CompareTag("Brique")) {
					// passe en selection

					StateManager.briqueSelectionne =hitInfo.transform.gameObject.name;
					EventManager.TriggerEvent(SELECTIONNEBRIQUE);
					break;
				}

				// on est quand même sur qq chose ; ne fait la rotation que si sur le sol
				if(hitInfo.transform.gameObject.CompareTag("Sol")) {
				//	print ("sur sol");
					EventManager.TriggerEvent(TOURNETCAMERA);
				}

				// pas une brique, pas le sol, doit être un bp du Hud
			//	return;

			}

			/*
			 if(EventSystem.current.IsPointerOverGameObject()) {
				print ("OOOOOOOOOOOOOOOOOOOO " + EventSystem.current.firstSelectedGameObject.name );
				return;
			}
*/
			// fail safe, si pas d'obj on peut tourner la camera
			EventManager.TriggerEvent(TOURNETCAMERA);
			break;

		case Action.G:
			EventManager.TriggerEvent(CUBEGAUCHE);
			break;
		
		case Action.D:
			EventManager.TriggerEvent(CUBEDROITE);
			break;

		case Action.B:
			EventManager.TriggerEvent(CUBEBAS);
			break; 
		
		case Action.H:
			EventManager.TriggerEvent(CUBEHAUT);
			break;
		}
	}

	/**
	 * 
	 */
	private void EnSelection(Action action, Vector2 position) {

		// peut être un clic souris ?
		switch(action) {
		case Action.CLICK:

			// o verifie si sur une brique
			RaycastHit hitInfo = new RaycastHit ();
			Ray ray = m_camera.ScreenPointToRay (position);
			
			// si sur le cube fait une selection / deselection
			if (Physics.Raycast (ray, out hitInfo)) {
				
				if(hitInfo.transform.gameObject.CompareTag("Brique")) {
					// nouvelle brique ??
					if(StateManager.briqueSelectionne.CompareTo(hitInfo.transform.gameObject.name) !=0 ) {
						StateManager.briqueSelectionne = hitInfo.transform.gameObject.name;
						EventManager.TriggerEvent(SELECTIONNEBRIQUE);
						return;
					}
					/*
					if(hitInfo.transform.gameObject.CompareTag("Sol")) {
						print ("sur sol en selection");
					}
					 */

				} 
			}

			// ben non on deselectionne
			StateManager.Action(StateManager.Message.FINSELECTION);
			StateManager.briqueSelectionne = "";
			EventManager.TriggerEvent(EFFACERSELECTION);
			break;
		
		case Action.G:
			EventManager.TriggerEvent(BANDEGAUCHE);
			break;
		
		case Action.D:
			// vers la droite
			EventManager.TriggerEvent(BANDEDROITE);
			break;
		
		case Action.B:
			// vers la bas
			EventManager.TriggerEvent(BANDEBAS);
			break;
		
		case Action.H:
			// vers la droite
			EventManager.TriggerEvent(BANDEHAUT);
			break;
		}
	}

	/**
	 * 
	 */
	private Action ClavierSouris(out Vector2 position) {
		position = new Vector2();
		/*
		if (Input.GetMouseButtonDown (0)) {
			position = Input.mousePosition;
			return Action.CLICK;
		}
*/
		if (Input.GetButtonDown ("Left")) {
			return Action.G;
		} 
		
		if (Input.GetButtonDown ("Right") ) {
			return Action.D;
		}
		
		if (Input.GetButtonDown ("Down")) {
			return Action.B;
		} 
		
		if (Input.GetButtonDown ("Up") ) {
			return Action.H;
		}

		return Action.AUCUNE;
	}

	/**
	 * 
	 */
	private void TouchAppEcran(Lean.Touch.LeanFinger info) {

		if (m_cameraController.GetEnDeplacement ()) {
			return;
		}

		switch (StateManager.instance.state) {
		case StateManager.State.ATTENTE :
			EnAttente(Action.CLICK, info.ScreenPosition);
			break;
		case StateManager.State.SELECTIONACTIVE :
			EnSelection(Action.CLICK, info.ScreenPosition);
			break;
		}
	}

	/**
	 * 
	 */
	private void TouchSwipe(Lean.Touch.LeanFinger info) {

		if (m_cameraController.GetEnDeplacement ()) {
			return;
		}

		Vector2 delta = info.SwipeScreenDelta;
		delta.Normalize ();

		Action action = Action.AUCUNE;
		if(Mathf.Abs(delta.x)>Mathf.Abs(delta.y)) {
			// swipe sur x
			action = delta.x < 0 ? Action.G : Action.D;

		} else {
			// sur Y
			action = delta.y < 0 ? Action.B : Action.H;
		}

		switch (StateManager.instance.state) {
		case StateManager.State.ATTENTE :
			EnAttente(action, info.ScreenPosition);
			break;
		case StateManager.State.SELECTIONACTIVE :
			EnSelection(action, info.ScreenPosition);
			break;
		}
	}
}
