using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public GameObject Hud;	// reference vers le hud pour l'animator

	int m_tour = 0;
	// retourne le nb de tour actuel
	public int tour {
		get {
			return m_tour;
		}
	}

	private static ScoreManager m_instance;
	// singleton sur le score
	public static ScoreManager instance {
		get {
			return m_instance;
		}
	}

	private Text text;
	private Animator anim;

	void Awake ()
	{
		if (m_instance != null) {
			return;
		}
		m_instance = this;

		text = GetComponent <Text> ();
		anim = Hud.GetComponent<Animator>();
	}

	/**
	 * 
	 */
	void OnEnable ()
	{
		SetTour (m_tour);

		EventManager.StartListening (GameEventTrigger.AJOUTERTOUR, AjouterTour);
	}
	
	/**
	 * 
	 */
	void OnDisable ()
	{
		EventManager.StopListening (GameEventTrigger.AJOUTERTOUR, AjouterTour);
	}

	/**
	 * 
	 */
	public void AjouterTour() {
		SetTour (m_tour + 1);
		anim.SetTrigger("AjouterTour");
	}

	/**
	 * 
	 */
	public void SetTour(int value) {
		m_tour = value;
		text.text = vi18nManager.Get ("game.score").Replace("%1", m_tour.ToString());
	}
}
