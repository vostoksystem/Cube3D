using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBP : MonoBehaviour {

	Toggle m_toggle;

	void Start() {
		m_toggle = GetComponent<Toggle> ();
		m_toggle.isOn = SoundController.instance.SoundEnabled;

		print ("on ????? " + m_toggle.isOn);
	}

}
