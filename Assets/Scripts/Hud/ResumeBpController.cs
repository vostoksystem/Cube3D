using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * le bp n'est actif que si on peut continuer un jeu (retour ou chargement)
 */
public class ResumeBpController : MonoBehaviour {

	private Button bp;

	// Use this for initialization
	void Start () {
		bp = GetComponent<Button> ();	
	}
	
	// Update is called once per frame
	void Update () {
		bp.interactable = StateManager.instance.canResume;
	}
}
