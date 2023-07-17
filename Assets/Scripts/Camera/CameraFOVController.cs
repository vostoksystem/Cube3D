using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOVController : MonoBehaviour {
	
	public float Landscape_FOV = 19.0f;
	public float Portrait_FOV = 38.0f;
	public float m_echelleTempsAnimation = 0.2f; // en seconde

	Camera cam = null;
	Coroutine c = null;
	ScreenOrientation orientation;
	
	/**
	 * 
	 */
	void Awake() {
		cam = GetComponent<Camera> ();
	}
	
	/**
	 * 
	 */
	void OnEnable()
	{
		if (cam == null) {
			Debug.LogError("CameraFOVController must be attached to a Camera object");
			return;
		}

		c = StartCoroutine (CheckRotation ());
	}
	
	/**
	 * 
	 */
	void OnDisable()
	{
		if (c != null) {
			StopCoroutine(c);
			c=null;
		}
	}

	/**
	 * fixe dynamiquement les fov de la camera
	 */
	public void setFOV (float landscape, float portrait) {
		Landscape_FOV = landscape;
		Portrait_FOV = portrait;

		switch(orientation) {
		case ScreenOrientation.Landscape:
			StartCoroutine(AnimerCameraFOV(Landscape_FOV));
			break;
			
		case ScreenOrientation.Portrait:
			StartCoroutine(AnimerCameraFOV(Portrait_FOV));
			break;
		}

	}

	/**
	 * check for screen orientation changes
	 */
	private IEnumerator CheckRotation() {
		while (true) {

			ScreenOrientation o = Screen.width>Screen.height ? ScreenOrientation.Landscape : ScreenOrientation.Portrait;
			if(o != orientation) {
				orientation=o;

				switch(orientation) {
				case ScreenOrientation.Landscape:
					StartCoroutine(AnimerCameraFOV(Landscape_FOV));
					break;
					
				case ScreenOrientation.Portrait:
					StartCoroutine(AnimerCameraFOV(Portrait_FOV));
					break;
				}
			}
			
			yield return null;
		}
	}

	/**
	 * 
	 */
	private IEnumerator AnimerCameraFOV(float fov) {
		float t = 0.0f;
		float startFOV = cam.fieldOfView;

		while(t<=1.0f) {
			t += Time.deltaTime / m_echelleTempsAnimation;
			cam.fieldOfView = (int)Mathf.Lerp(startFOV, fov, t);
			yield return null;
		}
	}
}
