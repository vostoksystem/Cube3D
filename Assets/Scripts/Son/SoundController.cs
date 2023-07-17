using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	private static SoundController m_instance;
	public static SoundController instance {
		get {
			return SoundController.m_instance;
		}
	}

	private int m_soundEnabled = 1;

	public bool SoundEnabled {
		get {
			return this.m_soundEnabled == 1 ? true : false;
		}
		set {
			this.m_soundEnabled = value ? 1:0;
			PlayerPrefs.SetInt("Sound", this.m_soundEnabled);
			AudioListener.volume = value ? 1.0f : 0.0f;
		}
	}

	void Awake () {
		if (m_instance != null) {
			return;
		}
		m_instance = this;

		if (PlayerPrefs.HasKey ("Sound") == false) {
			return;
		}

		m_soundEnabled = PlayerPrefs.GetInt ("Sound");
		AudioListener.volume = m_soundEnabled>0 ? 1.0f : 0.0f;
	}
}
