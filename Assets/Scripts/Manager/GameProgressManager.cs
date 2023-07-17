using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameProgressManager : MonoBehaviour {

	
	private static GameProgressManager m_instance;
	public static GameProgressManager instance {
		get {
			return GameProgressManager.m_instance;
		}
	}

	private bool m_asauvegarde = false;
	public bool ASauvegarde {
		get {
			return m_asauvegarde;
		}
	}

	private string path;

	// Use this for initialization
	void Awake () {
		if (m_instance != null) {
			return;
		}
		m_instance = this;

		path = Application.persistentDataPath + "/save.dat";
		m_asauvegarde = File.Exists (path);
	}

	/**
	 * charge l'etat du jeu dans bean. Si pas de sauvegarde valide, bean est null et retourne false
	 */
	public bool Charger(out GameProgressBean bean) {
		if (m_asauvegarde == false) {
			bean=null;
			return false;
		}

		FileStream f = File.Open (path, FileMode.Open);
		bean = (GameProgressBean)(new BinaryFormatter ().Deserialize (f));
		f.Close ();

		return true;
	}

	/**
	 * Sauvegarde l'etat du jeu
	 */
	public void Sauvegarder(GameProgressBean bean) {
		FileStream f = File.Create (path);
		new BinaryFormatter ().Serialize (f, bean);
		f.Close ();
		m_asauvegarde = true;
	}

	/**
	 * efface la sauvegarde actuelle
	 */
	public void EffacerSauvegarde() {
		if (m_asauvegarde) {
			File.Delete (path);
			m_asauvegarde=false;
		}
	}

}
