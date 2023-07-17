using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandAloneController : MonoBehaviour {

	// active state for standalone platform
	public bool mode=true;

	// Use this for initialization
	void Start () {
		#if UNITY_STANDALONE
		gameObject.SetActive(mode);
		#endif
	}

}
