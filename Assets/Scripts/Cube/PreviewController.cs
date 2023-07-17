using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewController : MonoBehaviour {

	/*
	 * on a fini de faire la preview de l'obj
	 */
	public void FinPreviewEvent() {
		StateManager.Action (StateManager.Message.FINPREVIEW);
	}

}
