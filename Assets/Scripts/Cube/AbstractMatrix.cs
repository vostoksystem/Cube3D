using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMatrix {

	public enum AXES {
		X,
		Y,
		Z
	}

	public string type; // type d'obj / prefab

	// sur quelles bande chasue index de la matrice ce trouve sur chaque axe
	protected short[] bandeX;
	protected short[] bandeY;
	protected short[] bandeZ;

	// la matrice avec les id de cube, 3x3x3 elements, etc...
	protected short[] data;

	//
	protected Brique[] briques;

	public Brique[] getBriques () {
		return briques;
	}
	
	public short[] getData () {
		return data;
	}

	/**
	 * effectue une rotation de la matrice selon axe et sens ; la matrice esr orienté -z, -x, -y
	 * sens : true, sens trigo
	 */
	public abstract void RotationCube(AXES axe, bool sens);

	/**
	 * fait une rotation de la bande bandeId
	 * les bande vont sur chaque axe de positif vers negatif, donc sur repere original, sur x, de gauche à droite, y de haut en bas
	 * sens : true, sens trigo
	 */
	public abstract void RotationBande(AXES axe, bool sens, short bandeId);

	/**
	 * retourne les id des briques qui corresponde à la bande demandé
	 */
	public abstract short[] TrouverBriqueSur(AXES axe, short bandeId);

	/**
	 * retourne un tableau X,Y,Z avec l'index de la bande sur laquelle ce trouve la brique
	 */
	public short[] TrouverBandePourBrique(short briqueId) {
		short[] solution = new short[3];
		
		for (int i=0; i<data.Length; i++) {
			
			if (data [i] == briqueId) {
				solution [0] = bandeX [i];
				solution [1] = bandeY [i];
				solution [2] = bandeZ [i];
				break;
			}
		}

//		Debug.Log ("bande pour " + briqueId + " " + solution[0] + " " +solution[1] + " " +solution[2] + " " ) ;
		return solution;
	}

	/**
	 * true si la matrice des brique est une solution (cube complet)
	 */
	public bool ASolution() {
	
/*		int x = (int)Math.Round(briques [0].obj.transform.eulerAngles.x);
		int y =  (int)Math.Round(briques [0].obj.transform.eulerAngles.y);
		int z =  (int)Math.Round(briques [0].obj.transform.eulerAngles.z);

		x = x == 360 ? 0 : x;
		y = y == 360 ? 0 : y;
		z = z == 360 ? 0 : z;
*/

		Quaternion source = Quaternion.Euler( new Vector3((int)Math.Round(briques [0].obj.transform.eulerAngles.x),
		                               (int)Math.Round(briques [0].obj.transform.eulerAngles.y),
		                              (int)Math.Round(briques [0].obj.transform.eulerAngles.z)));



		foreach(Brique b in briques) {
			Quaternion dest =Quaternion.Euler( new Vector3((int)Math.Round(b.obj.transform.eulerAngles.x),
			                           (int)Math.Round(b.obj.transform.eulerAngles.y),
			                          (int)Math.Round(b.obj.transform.eulerAngles.z)));

			if(source.Equals(dest) == false ){
			//	Debug.Log("pas de sol" );

				return false;
			}

	/*		int x2 = (int)Math.Round(b.obj.transform.eulerAngles.x);
			int y2 = (int)Math.Round(b.obj.transform.eulerAngles.y);
			int z2 = (int)Math.Round(b.obj.transform.eulerAngles.z);
			x2 = x2 == 360 ? 0 : x2;
			y2 = y2 == 360 ? 0 : y2;
			z2 = z2 == 360 ? 0 : z2;

			if( ( x2 != x) || ( y2 != y) || ( z2 != z) 
			   ) {
				Debug.Log("pas de sol" + x + " " + y + " " +z + " -- " +x2 + " " + y2 + " " + z2 );
				return false;
			}
			*/
		}

		return true;
	}

	/**
	 * initialise la matrise (et les obj) dans l"etat sauvé par bean
	 */
	public void Charger(GameProgressBean bean) {

		for (int i = 0; i < bean.briques.Length; i++) {
			Transform b = briques[i].obj.transform;
			PositionBean p = bean.briques[i];

			b.position = new Vector3(p.x,p.y,p.z);
			b.rotation = new Quaternion(p.rx, p.ry, p.rz,p.rw);
		}

		Array.Copy (bean.matrix, data, bean.matrix.Length);
	}

	/**
	 * sauvegarde l'etat de la matrise (et des obj)
	 */
	public GameProgressBean Sauver() {

		GameProgressBean bean = new GameProgressBean ();

		bean.type = type;

		bean.briques = new PositionBean[briques.Length];
		for (int i = 0; i < briques.Length; i++) {
			PositionBean p = new PositionBean();
			Transform t = briques[i].obj.transform;
	
			p.x = t.position.x;
			p.y = t.position.y;
			p.z = t.position.z;
			p.rx = t.rotation.x;
			p.ry = t.rotation.y;
			p.rz = t.rotation.z;
			p.rw = t.rotation.w;

			bean.briques[i] = p;
		}

		bean.matrix = new short[data.Length];
		Array.Copy (data, bean.matrix, data.Length);

		return bean;
	}

	/**
	 * fait un dump de la matrice sur la console
	 */
	public void debug() {
	//	Debug.Log ( CalculSolution());

		string[] tmp = new string[briques.Length];
		
		int i = 0;
		foreach (Brique b in briques) {
			
			tmp[i]=Math.Round(b.obj.transform.eulerAngles.x).ToString();
			i++;
		}
		
		//Debug.Log("angle x : " + String.Join("  ", tmp));

		int x = (int)Math.Round(briques [0].obj.transform.eulerAngles.x);
		int y =  (int)Math.Round(briques [0].obj.transform.eulerAngles.y);
		int z =  (int)Math.Round(briques [0].obj.transform.eulerAngles.z);
		
		foreach(Brique b in briques) {
			
			if( ( (int)Math.Round(b.obj.transform.eulerAngles.x) != x) ||
			   ( (int)Math.Round(b.obj.transform.eulerAngles.y) != y) ||
			   ( (int)Math.Round(b.obj.transform.eulerAngles.z) != z) 
			   ) {
			//	Debug.Log("PAS DE SOLUTION");
				return;
			}
		}
		
		//Debug.Log ("SOLUTION");
	}
}
