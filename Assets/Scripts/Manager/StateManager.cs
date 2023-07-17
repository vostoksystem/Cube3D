using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * fsm : etat du jeu
 */
public class StateManager : MonoBehaviour {

	// les etat possible de la machine
	public enum State
	{
		INIT, // dans l'etat initial après chargement
		AUCUN, // un etat vide utilisé notament lors des aniamations
		MENU, // affiche le menu
		TUTORIAL, //
		PREVIEW, // on fait une preview du cube
		MELANGE, // melange les brique du cube ; message : "finmelange"
		CHARGEMENT, // charge une partie ; message : "finchargement"
		ATTENTE, // en jeux ; message : "selection", "menu", "quitter"
		ROTATION, // le cube est en cours de rotation
		MOUVEMENT, // une bande est en cours de rotation
		SELECTIONACTIVE, // si une selection est active ; message : "finselection", "menu", "quitter"
		GAGNER // le pour vien de gagne
	}

	// les message disponible
	public enum Message
	{
		DEMARRAGE,		// appelle une fois pour lancer le menu/hud
		RETOUR,			// retourne au menu ou exit app
		TUTORIAL,		// affiche le panneau du tutorial / aide
		CLASSIC,	 	// lance un nouveau jeu en 3x3x3x
		HUGE,			// cube 4x4x4
		INSANE, 		// cube 5x5x5
		CHARGER,		// charge une partie
		RESUME,			// resume l'affichage du jeu en cours
		SELECTION,		// passe en selection active
		MOUVEMENT,		// demarre la rotation d'une bande
		ROTATION,		// demarre la rotation du cube
		FINSELECTION,	// repasse en jeu
		FINMOUVEMENT,	// a fini de faire une rotation de bande
		FINROTATION,	// le cube a fini de tourner
		FINCHARGEMENT,	// les donnees du cube on étaient chanrgées
		FINPREVIEW,		// fin de l'animation de previsualisation du cube
		FINMELANGE,		// le cube est près pour le jeu
		CUBECOMPLET,	// si le jouer vient de completer le cube
		QUITTER			// on quite le jeux
	}

	State m_state = State.INIT;
	public State state {
		get {
			return m_state;
		}
	}

	// nom de la brique sur laquelle le jour a cliqué
	public static string briqueSelectionne = "";

	private static StateManager m_instance;
	public static StateManager instance {
		get {
			return StateManager.m_instance;
		}
		set {
			StateManager.m_instance = value;
		}
	}

	/**
	 * retourne true si peut continuer un jeu
	 */
	public bool canResume {
		get {
			return m_jeuExiste || GameProgressManager.instance.ASauvegarde;
		}
	}

	public Camera m_camera; // ref sur la camera pour obtenir l'orientation

	public GameObject Hud; // ref vers le hud

	private Animator m_anim; // ref vers la fsm des animation du hud

	// true si a déjà chargé un jeux
	private bool m_jeuExiste = false;

	// l'objet en cours
	private GameObject obj=null;

	void Awake() {
		if (m_instance != null) {
			return;
		}
		m_instance = this;
		m_anim = Hud.GetComponent<Animator> ();
	}

	void Start() {
		m_instance.DoAction (Message.DEMARRAGE);
	}

	/**
	 * 
	 */
	void OnApplicationQuit() {

		if (m_jeuExiste == false) {
			return;
		}

		if (obj == null) {
			return;
		}

		GameProgressBean bean = obj.GetComponent<CubeController> ().Sauver ();
		bean.score = ScoreManager.instance.tour;
		GameProgressManager.instance.Sauvegarder (bean);
	}
		
		/**
	 * 
	 */
	public static void Action(Message message) {
		//GameObject.FindWithTag ("GameManager").GetComponent<StateManager> ().DoAction (message);
		m_instance.DoAction (message);
	}

	/**
	 * lancement d'une nouvelle action
	 */	
	public  void DoAction(Message message) {

		switch (m_state) {
		//------------------------------------------
		case State.INIT:
			switch(message) {
			case Message.DEMARRAGE:
				m_state=State.MENU;
				m_anim.SetTrigger("LancerJeu");
				break;
			}
			break;

		//------------------------------------------
		case State.MENU:
			switch(message) {

				// on quite le jeux
			case Message.RETOUR :
				m_state = State.AUCUN;
				Application.Quit();
				break;

			case Message.RESUME :
				if (m_jeuExiste) {
					// on a déjà chargé un jeu, on continu
					m_state=State.ATTENTE;
					m_anim.SetTrigger ("QuitterMenu");
					m_anim.SetTrigger ("RetourEnJeu");
					break;
				}

				// non on regarde si qq chose en sauvegarde
				GameProgressBean bean;
				if(GameProgressManager.instance.Charger(out bean)==false) {
					// pas de sauvegarde, ne fait rien
					break;
				}

				m_state=State.CHARGEMENT;
				CreerCube(bean.type);
				m_anim.SetTrigger ("QuitterMenu");
				m_anim.SetTrigger ("FairePreview");
				obj.GetComponent<Animation>().Play();
//				StartCoroutine(AfficherCube(bean.type));
				break;

			case Message.CLASSIC:
				GameProgressManager.instance.EffacerSauvegarde ();
				m_state=State.PREVIEW;
				CreerCube("Cube3x3");
				m_anim.SetTrigger ("QuitterMenu");
				m_anim.SetTrigger ("FairePreview");
				obj.GetComponent<Animation>().Play();
//				StartCoroutine(AfficherCube("Cube3x3"));
				break;

			case Message.HUGE:
				GameProgressManager.instance.EffacerSauvegarde ();
				m_state=State.PREVIEW;
				CreerCube("Cube4x4");
				m_anim.SetTrigger ("QuitterMenu");
				m_anim.SetTrigger ("FairePreview");
				obj.GetComponent<Animation>().Play();
//				StartCoroutine(AfficherCube("Cube4x4"));
				break;

			case Message.INSANE:
				GameProgressManager.instance.EffacerSauvegarde ();
				m_state=State.PREVIEW;
				CreerCube("Cube5x5");
				m_anim.SetTrigger ("QuitterMenu");
				m_anim.SetTrigger ("FairePreview");
				obj.GetComponent<Animation>().Play();
//				StartCoroutine(AfficherCube("Cube5x5"));
				break;

			case Message.TUTORIAL:
				m_state=State.TUTORIAL;
				m_anim.SetTrigger ("QuitterMenu");
				m_anim.SetTrigger ("AllezTutorial");
				break;
			}

			break;

			//------------------------------------------
		case State.TUTORIAL:
			switch(message) {
			case Message.RETOUR :
				m_state = State.MENU;
				m_anim.SetTrigger ("RetourMenu");
				break;
			}
			break;

			//------------------------------------------
		case State.CHARGEMENT:
			switch(message) {
			case Message.FINPREVIEW:

				m_state= State.ATTENTE;
				m_jeuExiste=true;

				GameProgressBean bean;
				if(GameProgressManager.instance.Charger(out bean)==false) {
					// NE DOIT JAMAIS ARRIVER !!!!
					break;
				}

				ScoreManager.instance.SetTour(bean.score);
				obj.GetComponent<CubeController>().Charger(bean);
				break;
			}
			break;

			//------------------------------------------
		case State.PREVIEW :
			switch(message) {
			case Message.FINPREVIEW:
				m_state= State.MELANGE;
				obj.GetComponent<CubeController>().MelangerPour(30);
				break;
			}
			break;

			//------------------------------------------
		case State.MELANGE:
			switch(message) {
				// on a fini de melanger le cube, on afficher le hud de score et passe en attente (jeu)
			case Message.FINMELANGE:
				m_state = State.ATTENTE;
				m_jeuExiste=true;
				break;
			}
			break;

			//------------------------------------------
		case State.ATTENTE:
			switch (message) {
			case Message.SELECTION: // pase en brique selectionné
				m_state = State.SELECTIONACTIVE;
				break;
			case Message.ROTATION: // lance la roation du cube
				m_state = State.ROTATION;
				break;
			case Message.RETOUR: // retourne au menu
				m_state = State.MENU;
				m_anim.SetTrigger ("RetourMenu");
				break;
			}
			break;

			//------------------------------------------
		case State.ROTATION:
			switch (message) {
			case Message.FINROTATION: // cube dans sa nouvelle position
				m_state = State.ATTENTE;
				break;
			}
			break;

			//------------------------------------------
		case State.SELECTIONACTIVE:
			switch (message) {
			case Message.FINSELECTION: // annule selection 
				m_state = State.ATTENTE;
				break;
			case Message.MOUVEMENT: // fait la roation de la bande
				m_state = State.MOUVEMENT;
				break;
			}
			break;

			//------------------------------------------
		case State.MOUVEMENT:
			switch (message) {
			case Message.FINMOUVEMENT: // cube dans sa nouvelle position
				m_state = State.ATTENTE;
				EventManager.TriggerEvent(GameEventTrigger.AJOUTERTOUR);
				break;

			case Message.CUBECOMPLET :
				EventManager.TriggerEvent(GameEventTrigger.AJOUTERTOUR);
				m_state=State.GAGNER;
				m_anim.SetTrigger ("OnAGagner");

				// efface le jeu sauvegardé
				GameProgressManager.instance.EffacerSauvegarde();

				// et pas de jeu de chargé
				m_jeuExiste = false;
				break;
			}
			break;

			//------------------------------------------
		case State.GAGNER: 
			switch(message) {
			case Message.RETOUR:
				m_state = State.MENU;
				m_anim.SetTrigger ("RetourMenu");
				break;
			}
			break;
		}
	}

	/**
	 * utilise pour faire un delay pendant que le menu disparait avant d'afficher l'obj 
	 */
/*	IEnumerator AfficherCube(string type) {

		m_anim.SetTrigger ("AllezEnJeu");

		yield return new WaitForSecondsRealtime(1.0f); //Count is the amount of time in seconds that you want to wait.

		CreerCube(type);
		m_anim.SetBool("FairePreview",true);
		obj.GetComponent<Animation>().Play();

		yield return null;
	}
	*/
	
	/**
	 * Cree un nouveau obj de type "type"
	 */
	void CreerCube(string type) {
		if (obj != null) {
			Destroy(obj);
		}

		// on se sert  de la fonction pour creer le cube lors d'un resume, donc ne doit pas effacer le backup !
	//	GameProgressManager.instance.EffacerSauvegarde ();

		obj =  Instantiate (Resources.Load (type, typeof(GameObject)),
		                    Vector3.zero, 
		                    Quaternion.identity
		                    ) as GameObject;
		
		obj.GetComponent<CubeController> ().m_camera = m_camera;
		obj.GetComponent<CubeRotationController> ().m_camera = m_camera;
	}
}
