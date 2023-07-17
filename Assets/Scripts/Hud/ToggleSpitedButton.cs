using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ToggleSpitedButton : MonoBehaviour {

	Toggle m_toggle;
	Image m_on;
	Image m_off;

	// Use this for initialization
	void Start () {

		m_toggle = GetComponent<Toggle> ();

		Image[] imgs = m_toggle.GetComponentsInChildren<Image> ();

		if (imgs.Length < 2) {
			Debug.LogError("Toggle button must have On and Off image type");
			return;
		}

		foreach (Image img in imgs) {
			if (img.name.ToLower ().CompareTo ("on")==0) {
				m_on = img;			
			}
			if (img.name.ToLower ().CompareTo ("off")==0) {
				m_off = img;			
			}
		}

		if (m_on == null || m_off == null) {
			Debug.LogError("Toggle button must have On and Off image type " + m_on + " " + m_off);
			return;
		}

		IsOnChanged (m_toggle.isOn); // set default

		m_toggle.onValueChanged.AddListener(IsOnChanged);
	}

	void IsOnChanged(bool on) {
		m_on.enabled=on;
		m_off.enabled=(on==false);
	}
}
