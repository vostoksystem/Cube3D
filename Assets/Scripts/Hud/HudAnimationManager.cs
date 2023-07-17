using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * less calback des boutons sur le hud
 */
public class HudAnimationManager : MonoBehaviour {

	private AudioSource clipOuvertureMenu;

	void Awake() {
		AudioSource[] liste = GetComponentsInChildren<AudioSource> ();
		
		foreach (AudioSource s in liste) {
			if(s.name.CompareTo("MenuSnd") ==0 ) {
				clipOuvertureMenu=s;
				break;
			}
		}

	}



	/**
	 * retour en jeu / chargement de la partie sauvegardé
	 */
	public void Resume() {
		StateManager.Action(StateManager.Message.RESUME);
	}

	/**
	 * 
	 */
	public void BoutonRetour() {
		StateManager.Action(StateManager.Message.RETOUR);
	}

	/**
	 * lancement d'un nouveau jeu
	 */
	public void Classic() {
		StateManager.Action(StateManager.Message.CLASSIC);
	}

	public void Huge() {
		StateManager.Action(StateManager.Message.HUGE);
	}

	public void Insane() {
		StateManager.Action(StateManager.Message.INSANE);
	}

	// affichage du tutorial
	public void Tutorial() {
		StateManager.Action(StateManager.Message.TUTORIAL);
	}


	public void Tewter() {
		Application.OpenURL ("http://cube3d.vostoksystem.eu/twitter");
	}


	public void RateMe() {
#if UNITY_IOS
		Application.OpenURL ("http://cube3d.vostoksystem.eu/ios");
#elif UNITY_ANDROID
		Application.OpenURL ("http://cube3d.vostoksystem.eu/android");
#endif
	}

	public void MenuPrincipalLance() {
		if (clipOuvertureMenu != null) {
			clipOuvertureMenu.Play();
		}
	}
}
