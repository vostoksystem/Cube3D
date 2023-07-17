using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * this controller has to be attach along an UI.Text whom it will update the text property according to user language preference.
 * This is an helper script, you can create your own controller and use public method from Vi18nManager instead.
 */
public class vi18nTextController : MonoBehaviour {

	// the key into vi18n translation file to look for
	public string TextKey="";

	// the key to override the font type, if empty font type won't be managed
	// some language may require a different font
	public string FontKey="";

	// the key to override the font size (usefull when changing font type). Keep empty for no management
	// note the value associated must be a number, if not, it would be ignored
	public string FontSizeKey = "";

	// if not empty, will force display in this language (if available), else use Vi18nManager.instance.currentLanguage
	public string OverrideLng = "";

	// if true, will update the text according of a change in language setting
	public bool ListenForLngChange = false;

	private Text text;
	private bool valid = false;

	// Use this for initialization
	void Start () {
		
		text = GetComponent <Text> ();
		if (text == null) {
			Debug.LogError("vi18nTextController must be attached to an Text UI element");
			return;
		}

		TextKey = TextKey.Trim ();
	

		if (TextKey.Length == 0) {
			Debug.LogError("vi18nTextController must have a valid key");
			return;
		}

		OverrideLng = OverrideLng.Trim ();
		FontKey = FontKey.Trim ();
		FontSizeKey = FontSizeKey.Trim ();

		valid = true;
		SetValue ();	
	}

	/**
	 * 
	 */
	void OnEnable () {

		if (ListenForLngChange == false || valid == false) {
			return;
		}

		SetValue ();	// lng may have changed since last time this comonent was enable

		vi18nManager.instance.StartListening (SetValue);
	}

	/**
	 * 
	 */
	void OnDisable () {
		vi18nManager.instance.StopListening (SetValue);
	}

	/**
	 * Set text for component Text, using key and OverrideLng
	 */
	public void SetValue() {
		if (valid == false) {
			return;
		}

		string lng = vi18nManager.instance.currentLanguage;

		if (OverrideLng.Length > 0) {
			lng = OverrideLng;
		}

		text.text = vi18nManager.Get (TextKey, lng);

		if (FontKey.Length > 0) {
			text.font =  Resources.Load(vi18nManager.Get(FontKey, lng)) as Font;
		}

		if (FontSizeKey.Length > 0) {
			int size = -1;

			if (int.TryParse (vi18nManager.Get (FontSizeKey, lng), out size) == false) {
				text.fontSize = size;
			}
		}
	}
}
