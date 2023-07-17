using System.Collections;
using System.Collections.Generic;
using System;

/**
 * Bean pour sauvegarder l'état du cube pour la sauvegarde
 */
[Serializable]
public class GameProgressBean  {
	public string type = "";		// type de cube
	public int score=0;				// nombre de tour actuel

	//public PositionBean cube;		// l'etat du cube : FIX inutile
	public PositionBean[] briques;	// l'etat de chaque brique
	public short[] matrix;			// etat de la matrice
}

[Serializable]
public class PositionBean {
	public float x = 0.0f;
	public float y = 0.0f;
	public float z = 0.0f;
	public float rx = 0.0f;
	public float ry = 0.0f;
	public float rz = 0.0f;
	public float rw = 0.0f;
}
