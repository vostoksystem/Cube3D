using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Cube4x4Matrix : AbstractMatrix {

	public Cube4x4Matrix() {
		type = "Cube4x4";

		data = new short[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,
			41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63
		};

		briques = new Brique[] {
			new Brique ("C3/c3-00", "c4-00", 0, 1.5f, 1.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-01", "c4-01", 1, 1.5f, 1.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-01", "c4-02", 2, 1.5f, 1.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-02", "c4-03", 3, 1.5f, 1.5f, -1.5f, -90, 0, 0),
			new Brique ("C3/c3-03", "c4-04", 4, 0.5f, 1.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-04", "c4-05", 5, 0.5f, 1.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-04", "c4-06", 6, 0.5f, 1.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-05", "c4-07", 7, 0.5f, 1.5f, -1.5f, -90, 0, 0),
			new Brique ("C3/c3-03", "c4-08", 8, -0.5f, 1.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-04", "c4-09", 9, -0.5f, 1.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-04", "c4-10", 10, -0.5f, 1.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-05", "c4-11", 11, -0.5f, 1.5f, -1.5f, -90, 0, 0),
			new Brique ("C3/c3-06", "c4-12", 12, -1.5f, 1.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-07", "c4-13", 13, -1.5f, 1.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-07", "c4-14", 14, -1.5f, 1.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-08", "c4-15", 15, -1.5f, 1.5f, -1.5f, -90, 0, 0),

			new Brique ("C3/c3-09", "c4-16", 16, 1.5f, 0.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-10", "c4-17", 17, 1.5f, 0.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-10", "c4-18", 18, 1.5f, 0.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-11", "c4-19", 19, 1.5f, 0.5f, -1.5f, -90, 0, 0),
			new Brique ("C3/c3-12", "c4-20", 20, 0.5f, 0.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-13", "c4-21", 21, 0.5f, 0.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-13", "c4-22", 22, 0.5f, 0.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-14", "c4-23", 23, 0.5f, 0.5f, -1.5f, -90, 0, 0),
			new Brique ("C3/c3-12", "c4-24", 24, -0.5f, 0.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-13", "c4-25", 25, -0.5f, 0.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-13", "c4-26", 26, -0.5f, 0.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-14", "c4-27", 27, -0.5f, 0.5f, -1.5f, -90, 0, 0),
			new Brique ("C3/c3-15", "c4-28", 28, -1.5f, 0.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-16", "c4-29", 29, -1.5f, 0.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-16", "c4-30", 30, -1.5f, 0.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-17", "c4-31", 31, -1.5f, 0.5f, -1.5f, -90, 0, 0),

			new Brique ("C3/c3-09", "c4-32", 32, 1.5f, -0.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-10", "c4-33", 33, 1.5f, -0.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-10", "c4-34", 34, 1.5f, -0.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-11", "c4-35", 35, 1.5f, -0.5f, -1.5f, -90, 0, 0),
			new Brique ("C3/c3-12", "c4-36", 36, 0.5f, -0.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-13", "c4-37", 37, 0.5f, -0.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-13", "c4-38", 38, 0.5f, -0.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-14", "c4-39", 39, 0.5f, -0.5f, -1.5f, -90, 0, 0),
			new Brique ("C3/c3-12", "c4-40", 40, -0.5f, -0.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-13", "c4-41", 41, -0.5f, -0.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-13", "c4-42", 42, -0.5f, -0.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-14", "c4-43", 43, -0.5f, -0.5f, -1.5f, -90, 0, 0),
			new Brique ("C3/c3-15", "c4-44", 44, -1.5f, -0.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-16", "c4-45", 45, -1.5f, -0.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-16", "c4-46", 46, -1.5f, -0.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-17", "c4-47", 47, -1.5f, -0.5f, -1.5f, -90, 0, 0),

			new Brique ("C3/c3-18", "c4-48", 48, 1.5f, -1.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-19", "c4-49", 49, 1.5f, -1.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-19", "c4-50", 50, 1.5f, -1.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-20", "c4-51", 51, 1.5f, -1.5f, -1.5f, -90, 0, 0),
			new Brique ("C3/c3-21", "c4-52", 52, 0.5f, -1.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-22", "c4-53", 53, 0.5f, -1.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-22", "c4-54", 54, 0.5f, -1.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-23", "c4-55", 55, 0.5f, -1.5f, -1.5f, -90, 0, 0),
			new Brique ("C3/c3-21", "c4-56", 56, -0.5f, -1.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-22", "c4-57", 57, -0.5f, -1.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-22", "c4-58", 58, -0.5f, -1.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-23", "c4-59", 59, -0.5f, -1.5f, -1.5f, -90, 0, 0),
			new Brique ("C3/c3-24", "c4-60", 60, -1.5f, -1.5f, 1.5f, -90, 0, 0),
			new Brique ("C3/c3-25", "c4-61", 61, -1.5f, -1.5f, 0.5f, -90, 0, 0),
			new Brique ("C3/c3-25", "c4-62", 62, -1.5f, -1.5f, -0.5f, -90, 0, 0),
			new Brique ("C3/c3-26", "c4-63", 63, -1.5f, -1.5f, -1.5f, -90, 0, 0)
		};

		bandeX = new short[] {0,0,0,0,1,1,1,1,2,2,2,2,3,3,3,3,0,0,0,0,1,1,1,1,2,2,2,2,3,3,3,3,0,0,0,0,1,1,1,1,2,2,2,2,3,3,3,3,0,0,0,0,1,1,1,1,2,2,2,2,3,3,3,3};
		bandeY = new short[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3};
		bandeZ = new short[] {0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3,0,1,2,3};
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
				return new short[]{data[0],data[1],data[2], data[3], data[16], data[17], data[18], data[19], data[32], data[33], data[34], data[35], data[48], data[49], data[50], data[51]};
			case 1 :
				return new short[]{data[4],data[5],data[6], data[7], data[20], data[21], data[22], data[23], data[36], data[37], data[38], data[39], data[52], data[53], data[54], data[55]};
			case 2 :
				return new short[]{data[8],data[9],data[10], data[11], data[24], data[25], data[26], data[27], data[40], data[41], data[42], data[43], data[56], data[57], data[58], data[59]};
			case 3 :
				return new short[]{data[12],data[13],data[14], data[15], data[28], data[29], data[30], data[31], data[44], data[45], data[46], data[47], data[60], data[61], data[62], data[63]};
			}
			break;

		case AXES.Y :
			switch(bandeId) {
			case 0:
				return new short[]{data[0],data[1],data[2], data[3], data[4], data[5], data[6], data[7], data[8], data[9], data[10], data[11], data[12], data[13], data[14], data[15]};
			case 1 :
				return new short[]{data[16],data[17],data[18], data[19], data[20], data[21], data[22], data[23], data[24], data[25], data[26], data[27], data[28], data[29], data[30], data[31]};
			case 2 :
				return new short[]{data[32],data[33],data[34], data[35], data[36], data[37], data[38], data[39], data[40], data[41], data[42], data[43], data[44], data[45], data[46], data[47]};
			case 3 :
				return new short[]{data[48],data[49],data[50], data[51], data[52], data[53], data[54], data[55], data[56], data[57], data[58], data[59], data[60], data[61], data[62], data[63]};

			}

			break;
		case AXES.Z :
			switch(bandeId) {
			case 0:
				return new short[]{data[0],data[4],data[8], data[12], data[16], data[20], data[24], data[28], data[32], data[36], data[40], data[44], data[48], data[52], data[56], data[60]};
			case 1 :
				return new short[]{data[1],data[5],data[9], data[13], data[17], data[21], data[25], data[29], data[33], data[37], data[41], data[45], data[49], data[53], data[57], data[61]};
			case 2 :
				return new short[]{data[2],data[6],data[10], data[14], data[18], data[22], data[26], data[30], data[34], data[38], data[42], data[46], data[50], data[54], data[58], data[62]};
			case 3 :
				return new short[]{data[3],data[7],data[11], data[15], data[19], data[23], data[27], data[31], data[35], data[39], data[43], data[47], data[51], data[55], data[59], data[63]};

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
		rotationBandeX (ref dest,3);
	}

	/**
	 *
	 */
	private void rotationInvX(ref short[] dest) {
		rotationBandeInvX (ref dest,0);
		rotationBandeInvX (ref dest,1);
		rotationBandeInvX (ref dest,2);
		rotationBandeInvX (ref dest,3);
	}

	/**
	 *
	 */
	private void rotationY(ref short[] dest) {
		rotationBandeY (ref dest,0);
		rotationBandeY (ref dest,1);
		rotationBandeY (ref dest,2);
		rotationBandeY (ref dest,3);
	}
	
	/**
	 *
	 */
	private void rotationInvY(ref short[] dest) {
		rotationBandeInvY (ref dest,0);
		rotationBandeInvY (ref dest,1);
		rotationBandeInvY (ref dest,2);
		rotationBandeInvY (ref dest,3);
	}

	/**
	 *
	 */
	private void rotationZ(ref short[] dest) {
		rotationBandeZ (ref dest,0);
		rotationBandeZ (ref dest,1);
		rotationBandeZ (ref dest,2);
		rotationBandeZ (ref dest,3);
	}
	
	/**
	 *
	 */
	private void rotationInvZ(ref short[] dest) {
		rotationBandeInvZ (ref dest,0);
		rotationBandeInvZ (ref dest,1);
		rotationBandeInvZ (ref dest,2);
		rotationBandeInvZ (ref dest,3);
	}

	/**
	 * 
	 */
	private void rotationBandeX(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [48];
			dest [1] = data [32];
			dest [2] = data [16];
			dest [3] = data [0];
			
			dest [16] = data [49];
			dest [17] = data [33];
			dest [18] = data [17];
			dest [19] = data [1];
			
			dest [32] = data [50];
			dest [33] = data [34];
			dest [34] = data [18];
			dest [35] = data [2];
			
			dest [48] = data [51];
			dest [49] = data [35];
			dest [50] = data [19];
			dest [51] = data [3];
			break;
		case 1:
			dest [4] = data [52];
			dest [5] = data [36];
			dest [6] = data [20];
			dest [7] = data [4];
			
			dest [20] = data [53];
			dest [21] = data [37];
			dest [22] = data [21];
			dest [23] = data [5];
			
			dest [36] = data [54];
			dest [37] = data [38];
			dest [38] = data [22];
			dest [39] = data [6];
			
			dest [52] = data [55];
			dest [53] = data [39];
			dest [54] = data [23];
			dest [55] = data [7];
			break;
		case 2:
			dest [8] = data [56];
			dest [9] = data [40];
			dest [10] = data [24];
			dest [11] = data [8];
			
			dest [24] = data [57];
			dest [25] = data [41];
			dest [26] = data [25];
			dest [27] = data [9];
			
			dest [40] = data [58];
			dest [41] = data [42];
			dest [42] = data [26];
			dest [43] = data [10];
			
			dest [56] = data [59];
			dest [57] = data [43];
			dest [58] = data [27];
			dest [59] = data [11];
			break;
		case 3:
			dest [12] = data [60];
			dest [13] = data [44];
			dest [14] = data [28];
			dest [15] = data [12];
			
			dest [28] = data [61];
			dest [29] = data [45];
			dest [30] = data [29];
			dest [31] = data [13];
			
			dest [44] = data [62];
			dest [45] = data [46];
			dest [46] = data [30];
			dest [47] = data [14];
			
			dest [60] = data [63];
			dest [61] = data [47];
			dest [62] = data [31];
			dest [63] = data [15];
			break;
		}
	}

	/**
	 * 
	 */
	private void rotationBandeInvX(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [3];
			dest [1] = data [19];
			dest [2] = data [35];
			dest [3] = data [51];
			
			dest [16] = data [2];
			dest [17] = data [18];
			dest [18] = data [34];
			dest [19] = data [50];
			
			dest [32] = data [1];
			dest [33] = data [17];
			dest [34] = data [33];
			dest [35] = data [49];
			
			dest [48] = data [0];
			dest [49] = data [16];
			dest [50] = data [32];
			dest [51] = data [48];
			break;
		case 1:
			dest [4] = data [7];
			dest [5] = data [23];
			dest [6] = data [39];
			dest [7] = data [55];
			
			dest [20] = data [6];
			dest [21] = data [22];
			dest [22] = data [38];
			dest [23] = data [54];
			
			dest [36] = data [5];
			dest [37] = data [21];
			dest [38] = data [37];
			dest [39] = data [53];
			
			dest [52] = data [4];
			dest [53] = data [20];
			dest [54] = data [36];
			dest [55] = data [52];
			break;
		case 2:
			dest [8] = data [11];
			dest [9] = data [27];
			dest [10] = data [43];
			dest [11] = data [59];
			
			dest [24] = data [10];
			dest [25] = data [26];
			dest [26] = data [42];
			dest [27] = data [58];
			
			dest [40] = data [9];
			dest [41] = data [25];
			dest [42] = data [41];
			dest [43] = data [57];
			
			dest [56] = data [8];
			dest [57] = data [24];
			dest [58] = data [40];
			dest [59] = data [56];
			break;
		case 3:
			dest [12] = data [15];
			dest [13] = data [31];
			dest [14] = data [47];
			dest [15] = data [63];
			
			dest [28] = data [14];
			dest [29] = data [30];
			dest [30] = data [46];
			dest [31] = data [62];
			
			dest [44] = data [13];
			dest [45] = data [29];
			dest [46] = data [45];
			dest [47] = data [61];
			
			dest [60] = data [12];
			dest [61] = data [28];
			dest [62] = data [44];
			dest [63] = data [60];
			break;
		}
	}

	/**
	 * 
	 */
	private void rotationBandeY(ref short[] dest, short id) {
		switch(id) {
		case 0:
			dest [0] = data [3];
			dest [1] = data [7];
			dest [2] = data [11];
			dest [3] = data [15];
			dest [4] = data [2];
			dest [5] = data [6];
			dest [6] = data [10];
			dest [7] = data [14];
			dest [8] = data [1];
			dest [9] = data [5];
			dest [10] = data [9];
			dest [11] = data [13];
			dest [12] = data [0];
			dest [13] = data [4];
			dest [14] = data [8];
			dest [15] = data [12];
			break;
		case 1:
			dest [16] = data [19];
			dest [17] = data [23];
			dest [18] = data [27];
			dest [19] = data [31];
			dest [20] = data [18];
			dest [21] = data [22];
			dest [22] = data [26];
			dest [23] = data [30];
			dest [24] = data [17];
			dest [25] = data [21];
			dest [26] = data [25];
			dest [27] = data [29];
			dest [28] = data [16];
			dest [29] = data [20];
			dest [30] = data [24];
			dest [31] = data [28];
			break;
		case 2:
			dest [32] = data [35];
			dest [33] = data [39];
			dest [34] = data [43];
			dest [35] = data [47];
			dest [36] = data [34];
			dest [37] = data [38];
			dest [38] = data [42];
			dest [39] = data [46];
			dest [40] = data [33];
			dest [41] = data [37];
			dest [42] = data [41];
			dest [43] = data [45];
			dest [44] = data [32];
			dest [45] = data [36];
			dest [46] = data [40];
			dest [47] = data [44];
			break;
		case 3:
			dest [48] = data [51];
			dest [49] = data [55];
			dest [50] = data [59];
			dest [51] = data [63];
			dest [52] = data [50];
			dest [53] = data [54];
			dest [54] = data [58];
			dest [55] = data [62];
			dest [56] = data [49];
			dest [57] = data [53];
			dest [58] = data [57];
			dest [59] = data [61];
			dest [60] = data [48];
			dest [61] = data [52];
			dest [62] = data [56];
			dest [63] = data [60];
			break;
		}
	}

	/**
	 * 
	 */
	private void rotationBandeInvY(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [12];
			dest [1] = data [8];
			dest [2] = data [4];
			dest [3] = data [0];
			dest [4] = data [13];
			dest [5] = data [9];
			dest [6] = data [5];
			dest [7] = data [1];
			dest [8] = data [14];
			dest [9] = data [10];
			dest [10] = data [6];
			dest [11] = data [2];
			dest [12] = data [15];
			dest [13] = data [11];
			dest [14] = data [7];
			dest [15] = data [3];
			break;
		case 1:
			dest [16] = data [28];
			dest [17] = data [24];
			dest [18] = data [20];
			dest [19] = data [16];
			dest [20] = data [29];
			dest [21] = data [25];
			dest [22] = data [21];
			dest [23] = data [17];
			dest [24] = data [30];
			dest [25] = data [26];
			dest [26] = data [22];
			dest [27] = data [18];
			dest [28] = data [31];
			dest [29] = data [27];
			dest [30] = data [23];
			dest [31] = data [19];
			break;
		case 2:
			dest [32] = data [44];
			dest [33] = data [40];
			dest [34] = data [36];
			dest [35] = data [32];
			dest [36] = data [45];
			dest [37] = data [41];
			dest [38] = data [37];
			dest [39] = data [33];
			dest [40] = data [46];
			dest [41] = data [42];
			dest [42] = data [38];
			dest [43] = data [34];
			dest [44] = data [47];
			dest [45] = data [43];
			dest [46] = data [39];
			dest [47] = data [35];
			break;
		case 3:
			dest [48] = data [60];
			dest [49] = data [56];
			dest [50] = data [52];
			dest [51] = data [48];
			dest [52] = data [61];
			dest [53] = data [57];
			dest [54] = data [53];
			dest [55] = data [49];
			dest [56] = data [62];
			dest [57] = data [58];
			dest [58] = data [54];
			dest [59] = data [50];
			dest [60] = data [63];
			dest [61] = data [59];
			dest [62] = data [55];
			dest [63] = data [51];
			break;
		}
	}

	/**
	 * 
	 */
	private void rotationBandeZ(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [12];
			dest [4] = data [28];
			dest [8] = data [44];
			dest [12] = data [60];
			dest [16] = data [8];
			dest [20] = data [24];
			dest [24] = data [40];
			dest [28] = data [56];
			dest [32] = data [4];
			dest [36] = data [20];
			dest [40] = data [36];
			dest [44] = data [52];
			dest [48] = data [0];
			dest [52] = data [16];
			dest [56] = data [32];
			dest [60] = data [48];
			break;
		case 1:
			dest [1] = data [13];
			dest [5] = data [29];
			dest [9] = data [45];
			dest [13] = data [61];
			dest [17] = data [9];
			dest [21] = data [25];
			dest [25] = data [41];
			dest [29] = data [57];
			dest [33] = data [5];
			dest [37] = data [21];
			dest [41] = data [37];
			dest [45] = data [53];
			dest [49] = data [1];
			dest [53] = data [17];
			dest [57] = data [33];
			dest [61] = data [49];
			break;
		case 2:
			dest [2] = data [14];
			dest [6] = data [30];
			dest [10] = data [46];
			dest [14] = data [62];
			dest [18] = data [10];
			dest [22] = data [26];
			dest [26] = data [42];
			dest [30] = data [58];
			dest [34] = data [6];
			dest [38] = data [22];
			dest [42] = data [38];
			dest [46] = data [54];
			dest [50] = data [2];
			dest [54] = data [18];
			dest [58] = data [34];
			dest [62] = data [50];
			break;
		case 3:
			dest [3] = data [15];
			dest [7] = data [31];
			dest [11] = data [47];
			dest [15] = data [63];
			dest [19] = data [11];
			dest [23] = data [27];
			dest [27] = data [43];
			dest [31] = data [59];
			dest [35] = data [7];
			dest [39] = data [23];
			dest [43] = data [39];
			dest [47] = data [55];
			dest [51] = data [3];
			dest [55] = data [19];
			dest [59] = data [35];
			dest [63] = data [51];
			break;
		}
	}

	/**
	 * 
	 */
	private void rotationBandeInvZ(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [48];
			dest [4] = data [32];
			dest [8] = data [16];
			dest [12] = data [0];
			dest [16] = data [52];
			dest [20] = data [36];
			dest [24] = data [20];
			dest [28] = data [4];
			dest [32] = data [56];
			dest [36] = data [40];
			dest [40] = data [24];
			dest [44] = data [8];
			dest [48] = data [60];
			dest [52] = data [44];
			dest [56] = data [28];
			dest [60] = data [12];
			break;
		case 1:
			dest [1] = data [49];
			dest [5] = data [33];
			dest [9] = data [17];
			dest [13] = data [1];
			dest [17] = data [53];
			dest [21] = data [37];
			dest [25] = data [21];
			dest [29] = data [5];
			dest [33] = data [57];
			dest [37] = data [41];
			dest [41] = data [25];
			dest [45] = data [9];
			dest [49] = data [61];
			dest [53] = data [45];
			dest [57] = data [29];
			dest [61] = data [13];
			break;
		case 2:
			dest [2] = data [50];
			dest [6] = data [34];
			dest [10] = data [18];
			dest [14] = data [2];
			dest [18] = data [54];
			dest [22] = data [38];
			dest [26] = data [22];
			dest [30] = data [6];
			dest [34] = data [58];
			dest [38] = data [42];
			dest [42] = data [26];
			dest [46] = data [10];
			dest [50] = data [62];
			dest [54] = data [46];
			dest [58] = data [30];
			dest [62] = data [14];
			break;
		case 3:
			dest [3] = data [51];
			dest [7] = data [35];
			dest [11] = data [19];
			dest [15] = data [3];
			dest [19] = data [55];
			dest [23] = data [39];
			dest [27] = data [23];
			dest [31] = data [7];
			dest [35] = data [59];
			dest [39] = data [43];
			dest [43] = data [27];
			dest [47] = data [11];
			dest [51] = data [63];
			dest [55] = data [47];
			dest [59] = data [31];
			dest [63] = data [15];
			break;
		}
	}
}
