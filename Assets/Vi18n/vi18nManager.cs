using System.Collections;
using System.Collections.Generic;
using System.Globalization; 
using System.Text.RegularExpressions;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class vi18nManager : MonoBehaviour {

	private const string PersistanceKeyName = "vi18n.current.lng";

	private static vi18nManager m_instance;
	// singleton to v18n system
	public static vi18nManager instance {
		get {
			return m_instance;
		}
	}

	private readonly Regex keyvalreg = new Regex(@"^\s*([^#][^=\s]+)\s*=\s*(.+)\s*$");

	private Dictionary<string, Dictionary<string,string> > data = new Dictionary<string, Dictionary<string, string>> ();	// all translation, key == 2digit lng code
	private Dictionary<string,string> data_c;						// ref to current language set (or default)
	private Dictionary<string,string> data_d;						// ref to current default language set

	private UnityEvent lngChangedEvent;										// list of object to send langage change to
	private List<UnityAction> listenerList = new List<UnityAction>();		// list of objct registered for lng changed FIXME : Does UnityEvent.addListener do it itself already ?

	// list of locale, name must be a 2 digits, en ,fr, de, fi, it, etc...
	public TextAsset[] sources;

	// the default language code ; must be in sources
	public string defaultLanguage = "en";

	// if true save lng value on local storage and retrieve it the next time the app start
	public bool persistSetting = false;

	// this is a debug / dev property, vi18n will load this language whatever user setting and saving is
	// obviously let it empty for production / normal use
	public string debugForceLanguage = "";

	// current defined language ; def to system one
	// if doesn't exist in "sources", will fall back to default
	private string lng;
	public string currentLanguage {
		get {
			return lng;
		}
		set {
			lng = value.ToLower();
			print ("vi18n : using language " + lng);
			PlayerPrefs.SetString(PersistanceKeyName, lng);

			if (data.ContainsKey(lng)==false ) {
				// current lng not defined, init with an empty struct
				data.Add (lng, new Dictionary<string, string> ());
			}

			data_c = data [lng];

			// inform any listener for changes
			lngChangedEvent.Invoke();
		}
	}
	
	/**
	 * 
	 */
	void Awake ()
	{
		if (m_instance != null) {
			return;
		}
		m_instance = this;

		lngChangedEvent = new UnityEvent ();

		defaultLanguage = defaultLanguage.ToLower ();

		if(sources.Length==0) {
			Debug.LogError ("Vi18n : no translation !!! abort. Drag text file to the sources property first.");
			data_d=new Dictionary<string, string>(); // prevent exception
			data_c=new Dictionary<string, string>();
			return;
		}

		// load locale
		foreach (TextAsset a in sources) {
			data.Add(a.name.Substring(0,2).ToLower(),LoadTranslation (a.text));
		}

		// init default
		if (data.ContainsKey(defaultLanguage) ) {
			data_d = data[defaultLanguage];
		} else {
			Debug.LogError ("Vi18n : translation set for default \"" + defaultLanguage + "\" not defined, use first source available");
			data_d = data.GetEnumerator().Current.Value;
		}

	//	currentLanguage = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

		// init current lng
		if (debugForceLanguage.Length > 0) {
			currentLanguage = debugForceLanguage;
		} else {
			if (persistSetting && PlayerPrefs.HasKey (PersistanceKeyName)) {
				currentLanguage = PlayerPrefs.GetString (PersistanceKeyName);
			} else {
				currentLanguage = getSystemLngCode ();
			}
		}
		Debug.Log ("Starting Vi18n with language : " + lng);
	}

	/**
	 * return the string corresponding to "key" in current language
	 * same as vi18nManager.Get(key,vi18nManager.instance.currentLanguage)
	 */
	public static string Get(string key) {
		return instance.GetImp(key, instance.lng);
	}

	/**
	 * return the string corresponding to "key" in "bcp47" language
	 */
	public static string Get(string key, string bcp47) {
		return instance.GetImp(key, bcp47);
	}

	/**
	 * internal use
	 */
	private string GetImp(string key, string bcp47) {

		// try in current
		if (data_c.ContainsKey(key)) {
			return data_c[key];
		}

		// try in default
		if (data_d.ContainsKey(key)) {

			// insert in current for further ref
			data_c.Add(key, data_d[key]);

			return data_d[key];
		}

		// nope, just return the key
		return key;
	}

	/**
	 * parse asset and add it to data list
	 * can be empty but never null
	 */
	private Dictionary<string,string> LoadTranslation(string src ) {

		Dictionary<string,string> d = new Dictionary<string, string> ();

		StreamReader reader = new StreamReader(vi18nManager.GenerateStreamFromString(src));

		string key="";
		string val="";
		bool wait = false;
			
		while (reader.EndOfStream == false) {

			if(wait) {
				val = val + reader.ReadLine().Trim();
				if(val[val.Length-1] == '\\') {
					// still
					continue;
				}
				
				wait=false;
				d.Add(key, val.Replace("\\n", "\n").Replace("\\", ""));
				continue;
			}

			Match m=keyvalreg.Match(reader.ReadLine());
			if(m.Success) {
				key = m.Groups[1].Value;
				val = m .Groups[2].Value;

				if(val[val.Length-1] == '\\') {
					// found multiline key
					wait=true;
					continue;
				}

				d.Add(key, val.Replace("\\n", "\n"));
			}
		}

		reader.Close ();

		return d;
	}

	/**
	 * Register an action for language changes
	 */
	public void StartListening(UnityAction action) {

		if(listenerList.Contains(action)) {
			return;
		}

		lngChangedEvent.AddListener (action);
		listenerList.Add (action);
	}

	/**
	 * remove an action from language changes
	 */
	public void StopListening(UnityAction action) {
		lngChangedEvent.RemoveListener (action);
		listenerList.Remove (action);
	}

	/**
	 * 
	 */
	public static Stream GenerateStreamFromString(string s)	{
		MemoryStream stream = new MemoryStream();
		StreamWriter writer = new StreamWriter(stream);
		writer.Write(s);
		writer.Flush();
		stream.Position = 0;
		return stream;
	}

	/**
	 * Culture return irelevant code for mobile device
	 */
	private static string getSystemLngCode() {

		switch (Application.systemLanguage) {
			case SystemLanguage.Afrikaans :
				return "af";
			case SystemLanguage.Arabic :
				return "ar";
			case SystemLanguage.Basque :
				return "eu";
			case SystemLanguage.Belarusian :
				return "be";
			case SystemLanguage.Bulgarian :
				return "bg";
			case SystemLanguage.Catalan :
				return "ca";
			case SystemLanguage.Chinese :
				return "zh";
			case SystemLanguage.Czech :
				return "cs";
			case SystemLanguage.Danish :
				return "da";
			case SystemLanguage.Dutch :
				return "nl";
			case SystemLanguage.English :
				return "en";
			case SystemLanguage.Estonian :
				return "et";
			case SystemLanguage.Faroese :
				return "fo";
			case SystemLanguage.Finnish :
				return "fi";
			case SystemLanguage.French :
				return "fr";
			case SystemLanguage.German :
				return "de";
			case SystemLanguage.Greek :
				return "el";
			case SystemLanguage.Hebrew :
				return "he";
			case SystemLanguage.Hungarian :
				return "hu";
			case SystemLanguage.Icelandic :
				return "is";
			case SystemLanguage.Indonesian :
				return "id";
			case SystemLanguage.Italian :
				return "it";
			case SystemLanguage.Japanese :
				return "ja";
			case SystemLanguage.Korean :
				return "ko";
			case SystemLanguage.Latvian :
				return "lv";
			case SystemLanguage.Lithuanian :
				return "lt";
			case SystemLanguage.Norwegian :
				return "no";
			case SystemLanguage.Polish :
				return "pl";
			case SystemLanguage.Portuguese :
				return "pt";
			case SystemLanguage.Romanian :
				return "ro";
			case SystemLanguage.Russian :
				return "ru";
			case SystemLanguage.SerboCroatian :
				return "sh";
			case SystemLanguage.Slovak :
				return "sk";
			case SystemLanguage.Slovenian :
				return "sl";
			case SystemLanguage.Spanish :
				return "es";
			case SystemLanguage.Swedish :
				return "sv";
			case SystemLanguage.Thai :
				return "th";
			case SystemLanguage.Turkish :
				return "tr";
			case SystemLanguage.Ukrainian :
				return "uk";
			case SystemLanguage.Vietnamese :
				return "vi";
		}

		return "iv";
	}

}
