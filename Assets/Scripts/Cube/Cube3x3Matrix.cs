using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Cube3x3Matrix : AbstractMatrix {

	public Cube3x3Matrix() {
		type = "Cube3x3";

		data = new short[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26};

		briques = new Brique[] {
			new Brique ("C3/c3-00", "c3-00", 0, 1, 1, 1, -90, 0, 0),
			new Brique ("C3/c3-01", "c3-01", 1, 1, 1, 0, -90, 0, 0),
			new Brique ("C3/c3-02", "c3-02", 2, 1, 1, -1, -90, 0, 0),
			new Brique ("C3/c3-03", "c3-03", 3, 0, 1, 1, -90, 0, 0),
			new Brique ("C3/c3-04", "c3-04", 4, 0, 1, 0, -90, 0, 0),
			new Brique ("C3/c3-05", "c3-05", 5, 0, 1, -1, -90, 0, 0),
			new Brique ("C3/c3-06", "c3-06", 6, -1, 1, 1, -90, 0, 0),
			new Brique ("C3/c3-07", "c3-07", 7, -1, 1, 0, -90, 0, 0),
			new Brique ("C3/c3-08", "c3-08", 8, -1, 1, -1, -90, 0, 0),
			
			new Brique ("C3/c3-09", "c3-09", 9, 1, 0, 1, -90, 0, 0),
			new Brique ("C3/c3-10", "c3-10", 10, 1, 0, 0, -90, 0, 0),
			new Brique ("C3/c3-11", "c3-11", 11, 1, 0, -1, -90, 0, 0),
			new Brique ("C3/c3-12", "c3-12", 12, 0, 0, 1, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-13", 13, 0, 0, 0, -90, 0, 0),
			new Brique ("C3/c3-14", "c3-14", 14, 0, 0, -1, -90, 0, 0),
			new Brique ("C3/c3-15", "c3-15", 15, -1, 0, 1, -90, 0, 0),
			new Brique ("C3/c3-16", "c3-16", 16, -1, 0, 0, -90, 0, 0),
			new Brique ("C3/c3-17", "c3-17", 17, -1, 0, -1, -90, 0, 0),
			
			new Brique ("C3/c3-18", "c3-18", 18, 1, -1, 1, -90, 0, 0),
			new Brique ("C3/c3-19", "c3-19", 19, 1, -1, 0, -90, 0, 0),
			new Brique ("C3/c3-20", "c3-20", 20, 1, -1, -1, -90, 0, 0),
			new Brique ("C3/c3-21", "c3-21", 21, 0, -1, 1, -90, 0, 0),
			new Brique ("C3/c3-22", "c3-22", 22, 0, -1, 0, -90, 0, 0),
			new Brique ("C3/c3-23", "c3-23", 23, 0, -1, -1, -90, 0, 0),
			new Brique ("C3/c3-24", "c3-24", 24, -1, -1, 1, -90, 0, 0),
			new Brique ("C3/c3-25", "c3-25", 25, -1, -1, 0, -90, 0, 0),
			new Brique ("C3/c3-26", "c3-26", 26, -1, -1, -1, -90, 0, 0)
		};

		bandeX = new short[] {0,0,0,1,1,1,2,2,2,0,0,0,1,1,1,2,2,2,0,0,0,1,1,1,2,2,2};
		bandeY = new short[] {0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2};
		bandeZ = new short[] {0,1,2,0,1,2,0,1,2,0,1,2,0,1,2,0,1,2,0,1,2,0,1,2,0,1,2};
	}

	/**
	 * effectue une rotation de la matrice selon axe et sens ; la matrice esr orienté -z, -x, -y
	 */
	public override void RotationCube(AXES axe, bool sens) {

		short[]  tmp = new short[data.Length];
		Array.Copy (data, tmp, data.Length);

		switch (axe) {
		case AXES.X:
			if(sens) {
				rotationX(ref tmp);
				break;
			}
			rotationInvX(ref tmp);
			break;

		case AXES.Y:
			if(sens) {
				rotationY(ref tmp);
				break;
			}
			rotationInvY(ref tmp);
			break;

		case AXES.Z:
			if(sens) {
				rotationZ(ref tmp);
				break;
			}
			rotationInvZ(ref tmp);
			break;
		}

		data = tmp;

	//	debug ();
	}
	
	/**
	 * fiat une rotation de la bande bandeId
	 * les bande vont sur chaque axe de positif vers negatif, donc sur repere original, sur x, de gauche à droite, y de haut en bas
	 */
	public override void RotationBande(AXES axe, bool sens, short bandeId) {
		short[]  tmp = new short[data.Length];
		Array.Copy (data, tmp, data.Length);

		switch (axe) {
		case AXES.X:
			if(sens) {
				rotationBandeX(ref tmp, bandeId);
				break;
			}
			rotationBandeInvX(ref tmp, bandeId);
			break;
			
		case AXES.Y:
			if(sens) {
				rotationBandeY(ref tmp, bandeId);
				break;
			}
			rotationBandeInvY(ref tmp, bandeId);
			break;
			
		case AXES.Z:
			if(sens) {
				rotationBandeZ(ref tmp, bandeId);
				break;
			}
			rotationBandeInvZ(ref tmp, bandeId);
			break;
		}

		data = tmp;
	}

	/**
	 * retourne les id des briques qui corresponde à la bande demandé
	 */
	public override short[] TrouverBriqueSur(AXES axe, short bandeId) {

		switch (axe) {
		case AXES.X :
			switch(bandeId) {
			case 0:
				return new short[]{data[0],data[1],data[2],data[9],data[10],data[11],data[18],data[19],data[20] };
			case 1 :
				return new short[]{data[3],data[4],data[5],data[12],data[13],data[14],data[21],data[22],data[23] };
			case 2 :
				return new short[]{data[6],data[7],data[8],data[15],data[16],data[17],data[24],data[25],data[26] };
			}
			break;

		case AXES.Y :
			switch(bandeId) {
			case 0:
				return new short[]{data[0],data[1],data[2],data[3],data[4],data[5],data[6],data[7],data[8] };
			case 1 :
				return new short[]{data[9],data[10],data[11],data[12],data[13],data[14],data[15],data[16],data[17] };
			case 2 :
				return new short[]{data[18],data[19],data[20],data[21],data[22],data[23],data[24],data[25],data[26] };
			}

			break;
		case AXES.Z :
			switch(bandeId) {
			case 0:
				return new short[]{data[0],data[3],data[6],data[9],data[12],data[15],data[18],data[21],data[24] };
			case 1 :
				return new short[]{data[1],data[4],data[7],data[10],data[13],data[16],data[19],data[22],data[25] };
			case 2 :
				return new short[]{data[2],data[5],data[8],data[11],data[14],data[17],data[20],data[23],data[26] };
			}
			break;
		}

		return new short[0];
	}

	/**
	 *
	 */
	private void rotationX(ref short[] dest) {
		rotationBandeX (ref dest,0);
		rotationBandeX (ref dest,1);
		rotationBandeX (ref dest,2);
	}

	/**
	 *
	 */
	private void rotationInvX(ref short[] dest) {
		rotationBandeInvX (ref dest,0);
		rotationBandeInvX (ref dest,1);
		rotationBandeInvX (ref dest,2);
	}

	/**
	 *
	 */
	private void rotationY(ref short[] dest) {
		rotationBandeY (ref dest,0);
		rotationBandeY (ref dest,1);
		rotationBandeY (ref dest,2);
	}
	
	/**
	 *
	 */
	private void rotationInvY(ref short[] dest) {
		rotationBandeInvY (ref dest,0);
		rotationBandeInvY (ref dest,1);
		rotationBandeInvY (ref dest,2);
	}

	/**
	 *
	 */
	private void rotationZ(ref short[] dest) {
		rotationBandeZ (ref dest,0);
		rotationBandeZ (ref dest,1);
		rotationBandeZ (ref dest,2);
	}
	
	/**
	 *
	 */
	private void rotationInvZ(ref short[] dest) {
		rotationBandeInvZ (ref dest,0);
		rotationBandeInvZ (ref dest,1);
		rotationBandeInvZ (ref dest,2);
	}

	/**
	 * 
	 */
	private void rotationBandeX(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [18];
			dest [1] = data [9];
			dest [2] = data [0];
			dest [9] = data [19];
			dest [11] = data [1];
			dest [18] = data [20];
			dest [19] = data [11];
			dest [20] = data [2];
			break;
		case 1:
			dest [3] = data [21];
			dest [4] = data [12];
			dest [5] = data [3];
			dest [12] = data [22];
			dest [14] = data [4];
			dest [21] = data [23];
			dest [22] = data [14];
			dest [23] = data [5];
			break;
		case 2:
			dest [6] = data [24];
			dest [7] = data [15];
			dest [8] = data [6];
			dest [15] = data [25];
			dest [17] = data [7];
			dest [24] = data [26];
			dest [25] = data [17];
			dest [26] = data [8];
			break;
		}
	}

	/**
	 * 
	 */
	private void rotationBandeInvX(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [2];
			dest [1] = data [11];
			dest [2] = data [20];
			dest [9] = data [1];
			dest [11] = data [19];
			dest [18] = data [0];
			dest [19] = data [9];
			dest [20] = data [18];
			break;
		case 1:
			dest [3] = data [5];
			dest [4] = data [14];
			dest [5] = data [23];
			dest [12] = data [4];
			dest [14] = data [22];
			dest [21] = data [3];
			dest [22] = data [12];
			dest [23] = data [21];
			break;
		case 2:
			dest [6] = data [8];
			dest [7] = data [17];
			dest [8] = data [26];
			dest [15] = data [7];
			dest [17] = data [25];
			dest [24] = data [6];
			dest [25] = data [15];
			dest [26] = data [24];
			break;
		}
	}

	/**
	 * 
	 */
	private void rotationBandeY(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [2];
			dest [1] = data [5];
			dest [2] = data [8];
			dest [3] = data [1];
			dest [5] = data [7];
			dest [6] = data [0];
			dest [7] = data [3];
			dest [8] = data [6];
			break;
		case 1:
			dest [9] = data [11];
			dest [10] = data [14];
			dest [11] = data [17];	
			dest [12] = data [10];	
			dest [14] = data [16];	
			dest [15] = data [9];	
			dest [16] = data [12];	
			dest [17] = data [15];	
			break;
		case 2:
			dest [18] = data [20];
			dest [19] = data [23];
			dest [20] = data [26];
			dest [21] = data [19];
			dest [23] = data [25];
			dest [24] = data [18];
			dest [25] = data [21];
			dest [26] = data [24];
			break;
		}
	}

	/**
	 * 
	 */
	private void rotationBandeInvY(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest[0]=data[6];
			dest[1]=data[3];
			dest[2]=data[0];
			dest[3]=data[7];
			dest[5]=data[1];
			dest[6]=data[8];
			dest[7]=data[5];
			dest[8]=data[2];
			break;
		case 1:
			dest[9]=data[15];
			dest[10]=data[12];
			dest[11]=data[9];
			dest[12]=data[16];
			dest[14]=data[10];
			dest[15]=data[17];
			dest[16]=data[14];
			dest[17]=data[11];
			break;
		case 2: 
			dest[18]=data[24];
			dest[19]=data[21];
			dest[20]=data[18];
			dest[21]=data[25];
			dest[23]=data[19];
			dest[24]=data[26];
			dest[25]=data[23];
			dest[26]=data[20];
			break;
		}
	}

	/**
	 * 
	 */
	private void rotationBandeZ(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [6];
			dest [3] = data [15];
			dest [6] = data [24];
			dest [9] = data [3];
			dest [15] = data [21];
			dest [18] = data [0];
			dest [21] = data [9];
			dest [24] = data [18];
			break;
		case 1:
			dest [1] = data [7];
			dest [4] = data [16];
			dest [7] = data [25];
			dest [10] = data [4];
			dest [16] = data [22];
			dest [19] = data [1];
			dest [22] = data [10];
			dest [25] = data [19];
			break;
		case 2:
			dest [2] = data [8];
			dest [5] = data [17];
			dest [8] = data [26];
			dest [11] = data [5];
			dest [17] = data [23];
			dest [20] = data [2];
			dest [23] = data [11];
			dest [26] = data [20];
			break;
		}
	}

	/**
	 * 
	 */
	private void rotationBandeInvZ(ref short[] dest, short id) {

		switch (id) {
		case 0:
			dest [0] = data [18];
			dest [3] = data [9];
			dest [6] = data [0];
			dest [9] = data [21];
			dest [15] = data [3];
			dest [18] = data [24];
			dest [21] = data [15];
			dest [24] = data [6];
			break;
		case 1:
			dest [1] = data [19];
			dest [4] = data [10];
			dest [7] = data [1];
			dest [10] = data [22];
			dest [16] = data [4];
			dest [19] = data [25];
			dest [22] = data [16];
			dest [25] = data [7];
			break;
		case 2:
			dest [2] = data [20];
			dest [5] = data [11];
			dest [8] = data [2];
			dest [11] = data [23];
			dest [17] = data [5];
			dest [20] = data [26];
			dest [23] = data [17];
			dest [26] = data [8];
			break;
		}
	}

}
