using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Cube5x5Matrix : AbstractMatrix {

	public Cube5x5Matrix() {
		//taille = 3;
		type = "Cube5x5";

		data = new short[] {
			0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,
			25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,
			50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,
			75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,
			100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,121,122,123,124
		};

		briques = new Brique[] {
			new Brique ("C3/c3-00", "c3-00", 0, 2, 2, 2, -90, 0, 0),
			new Brique ("C3/c3-01", "c3-01", 1, 2, 2, 1, -90, 0, 0),
			new Brique ("C3/c3-01", "c3-02", 2, 2, 2, 0, -90, 0, 0),
			new Brique ("C3/c3-01", "c3-03", 3, 2, 2, -1, -90, 0, 0),
			new Brique ("C3/c3-02", "c3-04", 4, 2, 2, -2, -90, 0, 0),
			new Brique ("C3/c3-03", "c3-05", 5, 1, 2, 2, -90, 0, 0),
			new Brique ("C3/c3-04", "c3-06", 6, 1, 2, 1, -90, 0, 0),
			new Brique ("C3/c3-04", "c3-07", 7, 1, 2, 0, -90, 0, 0),
			new Brique ("C3/c3-04", "c3-08", 8, 1, 2, -1, -90, 0, 0),
			new Brique ("C3/c3-05", "c3-09", 9, 1, 2, -2, -90, 0, 0),
			new Brique ("C3/c3-03", "c3-10", 10, 0, 2, 2, -90, 0, 0),
			new Brique ("C3/c3-04", "c3-11", 11, 0, 2, 1, -90, 0, 0),
			new Brique ("C3/c3-04", "c3-12", 12, 0, 2, 0, -90, 0, 0),
			new Brique ("C3/c3-04", "c3-13", 13, 0, 2, -1, -90, 0, 0),
			new Brique ("C3/c3-05", "c3-14", 14, 0, 2, -2, -90, 0, 0),
			new Brique ("C3/c3-03", "c3-15", 15, -1, 2, 2, -90, 0, 0),
			new Brique ("C3/c3-04", "c3-16", 16, -1, 2, 1, -90, 0, 0),
			new Brique ("C3/c3-04", "c3-17", 17, -1, 2, 0, -90, 0, 0),
			new Brique ("C3/c3-04", "c3-18", 18, -1, 2, -1, -90, 0, 0),
			new Brique ("C3/c3-05", "c3-19", 19, -1, 2, -2, -90, 0, 0),
			new Brique ("C3/c3-06", "c3-20", 20, -2, 2, 2, -90, 0, 0),
			new Brique ("C3/c3-07", "c3-21", 21, -2, 2, 1, -90, 0, 0),
			new Brique ("C3/c3-07", "c3-22", 22, -2, 2, 0, -90, 0, 0),
			new Brique ("C3/c3-07", "c3-23", 23, -2, 2, -1, -90, 0, 0),
			new Brique ("C3/c3-08", "c3-24", 24, -2, 2, -2, -90, 0, 0),

			new Brique ("C3/c3-09", "c3-25", 25, 2, 1, 2, -90, 0, 0),
			new Brique ("C3/c3-10", "c3-26", 26, 2, 1, 1, -90, 0, 0),
			new Brique ("C3/c3-10", "c3-27", 27, 2, 1, 0, -90, 0, 0),
			new Brique ("C3/c3-10", "c3-28", 28, 2, 1, -1, -90, 0, 0),
			new Brique ("C3/c3-11", "c3-29", 29, 2, 1, -2, -90, 0, 0),
			new Brique ("C3/c3-12", "c3-30", 30, 1, 1, 2, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-31", 31, 1, 1, 1, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-32", 32, 1, 1, 0, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-33", 33, 1, 1, -1, -90, 0, 0),
			new Brique ("C3/c3-14", "c3-34", 34, 1, 1, -2, -90, 0, 0),
			new Brique ("C3/c3-12", "c3-35", 35, 0, 1, 2, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-36", 36, 0, 1, 1, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-37", 37, 0, 1, 0, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-38", 38, 0, 1, -1, -90, 0, 0),
			new Brique ("C3/c3-14", "c3-39", 39, 0, 1, -2, -90, 0, 0),
			new Brique ("C3/c3-12", "c3-40", 40, -1, 1, 2, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-41", 41, -1, 1, 1, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-42", 42, -1, 1, 0, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-43", 43, -1, 1, -1, -90, 0, 0),
			new Brique ("C3/c3-14", "c3-44", 44, -1, 1, -2, -90, 0, 0),
			new Brique ("C3/c3-15", "c3-45", 45, -2, 1, 2, -90, 0, 0),
			new Brique ("C3/c3-16", "c3-46", 46, -2, 1, 1, -90, 0, 0),
			new Brique ("C3/c3-16", "c3-47", 47, -2, 1, 0, -90, 0, 0),
			new Brique ("C3/c3-16", "c3-48", 48, -2, 1, -1, -90, 0, 0),
			new Brique ("C3/c3-17", "c3-49", 49, -2, 1, -2, -90, 0, 0),

			new Brique ("C3/c3-09", "c3-50", 50, 2, 0, 2, -90, 0, 0),
			new Brique ("C3/c3-10", "c3-51", 51, 2, 0, 1, -90, 0, 0),
			new Brique ("C3/c3-10", "c3-52", 52, 2, 0, 0, -90, 0, 0),
			new Brique ("C3/c3-10", "c3-53", 53, 2, 0, -1, -90, 0, 0),
			new Brique ("C3/c3-11", "c3-54", 54, 2, 0, -2, -90, 0, 0),
			new Brique ("C3/c3-12", "c3-55", 55, 1, 0, 2, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-56", 56, 1, 0, 1, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-57", 57, 1, 0, 0, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-58", 58, 1, 0, -1, -90, 0, 0),
			new Brique ("C3/c3-14", "c3-59", 59, 1, 0, -2, -90, 0, 0),
			new Brique ("C3/c3-12", "c3-60", 60, 0, 0, 2, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-61", 61, 0, 0, 1, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-62", 62, 0, 0, 0, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-63", 63, 0, 0, -1, -90, 0, 0),
			new Brique ("C3/c3-14", "c3-64", 64, 0, 0, -2, -90, 0, 0),
			new Brique ("C3/c3-12", "c3-65", 65, -1, 0, 2, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-66", 66, -1, 0, 1, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-67", 67, -1, 0, 0, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-68", 68, -1, 0, -1, -90, 0, 0),
			new Brique ("C3/c3-14", "c3-69", 69, -1, 0, -2, -90, 0, 0),
			new Brique ("C3/c3-15", "c3-70", 70, -2, 0, 2, -90, 0, 0),
			new Brique ("C3/c3-16", "c3-71", 71, -2, 0, 1, -90, 0, 0),
			new Brique ("C3/c3-16", "c3-72", 72, -2, 0, 0, -90, 0, 0),
			new Brique ("C3/c3-16", "c3-73", 73, -2, 0, -1, -90, 0, 0),
			new Brique ("C3/c3-17", "c3-74", 74, -2, 0, -2, -90, 0, 0),

			new Brique ("C3/c3-09", "c3-75", 75, 2, -1, 2, -90, 0, 0),
			new Brique ("C3/c3-10", "c3-76", 76, 2, -1, 1, -90, 0, 0),
			new Brique ("C3/c3-10", "c3-77", 77, 2, -1, 0, -90, 0, 0),
			new Brique ("C3/c3-10", "c3-78", 78, 2, -1, -1, -90, 0, 0),
			new Brique ("C3/c3-11", "c3-79", 79, 2, -1, -2, -90, 0, 0),
			new Brique ("C3/c3-12", "c3-80", 80, 1, -1, 2, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-81", 81, 1, -1, 1, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-82", 82, 1, -1, 0, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-83", 83, 1, -1, -1, -90, 0, 0),
			new Brique ("C3/c3-14", "c3-84", 84, 1, -1, -2, -90, 0, 0),
			new Brique ("C3/c3-12", "c3-85", 85, 0, -1, 2, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-86", 86, 0, -1, 1, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-87", 87, 0, -1, 0, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-88", 88, 0, -1, -1, -90, 0, 0),
			new Brique ("C3/c3-14", "c3-89", 89, 0, -1, -2, -90, 0, 0),
			new Brique ("C3/c3-12", "c3-90", 90, -1, -1, 2, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-91", 91, -1, -1, 1, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-92", 92, -1, -1, 0, -90, 0, 0),
			new Brique ("C3/c3-13", "c3-93", 93, -1, -1, -1, -90, 0, 0),
			new Brique ("C3/c3-14", "c3-94", 94, -1, -1, -2, -90, 0, 0),
			new Brique ("C3/c3-15", "c3-95", 95, -2, -1, 2, -90, 0, 0),
			new Brique ("C3/c3-16", "c3-96", 96, -2, -1, 1, -90, 0, 0),
			new Brique ("C3/c3-16", "c3-97", 97, -2, -1, 0, -90, 0, 0),
			new Brique ("C3/c3-16", "c3-98", 98, -2, -1, -1, -90, 0, 0),
			new Brique ("C3/c3-17", "c3-99", 99, -2, -1, -2, -90, 0, 0),

			new Brique ("C3/c3-18", "c3-100", 100, 2, -2, 2, -90, 0, 0),
			new Brique ("C3/c3-19", "c3-101", 101, 2, -2, 1, -90, 0, 0),
			new Brique ("C3/c3-19", "c3-102", 102, 2, -2, 0, -90, 0, 0),
			new Brique ("C3/c3-19", "c3-103", 103, 2, -2, -1, -90, 0, 0),
			new Brique ("C3/c3-20", "c3-104", 104, 2, -2, -2, -90, 0, 0),
			new Brique ("C3/c3-21", "c3-105", 105, 1, -2, 2, -90, 0, 0),
			new Brique ("C3/c3-22", "c3-106", 106, 1, -2, 1, -90, 0, 0),
			new Brique ("C3/c3-22", "c3-107", 107, 1, -2, 0, -90, 0, 0),
			new Brique ("C3/c3-22", "c3-108", 108, 1, -2, -1, -90, 0, 0),
			new Brique ("C3/c3-23", "c3-109", 109, 1, -2, -2, -90, 0, 0),
			new Brique ("C3/c3-21", "c3-110", 110, 0, -2, 2, -90, 0, 0),
			new Brique ("C3/c3-22", "c3-111", 111, 0, -2, 1, -90, 0, 0),
			new Brique ("C3/c3-22", "c3-112", 112, 0, -2, 0, -90, 0, 0),
			new Brique ("C3/c3-22", "c3-113", 113, 0, -2, -1, -90, 0, 0),
			new Brique ("C3/c3-23", "c3-114", 114, 0, -2, -2, -90, 0, 0),
			new Brique ("C3/c3-21", "c3-115", 115, -1, -2, 2, -90, 0, 0),
			new Brique ("C3/c3-22", "c3-116", 116, -1, -2, 1, -90, 0, 0),
			new Brique ("C3/c3-22", "c3-117", 117, -1, -2, 0, -90, 0, 0),
			new Brique ("C3/c3-22", "c3-118", 118, -1, -2, -1, -90, 0, 0),
			new Brique ("C3/c3-23", "c3-119", 119, -1, -2, -2, -90, 0, 0),
			new Brique ("C3/c3-24", "c3-120", 120, -2, -2, 2, -90, 0, 0),
			new Brique ("C3/c3-25", "c3-121", 121, -2, -2, 1, -90, 0, 0),
			new Brique ("C3/c3-25", "c3-122", 122, -2, -2, 0, -90, 0, 0),
			new Brique ("C3/c3-25", "c3-123", 123, -2, -2, -1, -90, 0, 0),
			new Brique ("C3/c3-26", "c3-124", 124, -2, -2, -2, -90, 0, 0)
		};

		bandeX = new short[] {
			0,0,0,0,0,1,1,1,1,1,2,2,2,2,2,3,3,3,3,3,4,4,4,4,4,
			0,0,0,0,0,1,1,1,1,1,2,2,2,2,2,3,3,3,3,3,4,4,4,4,4,
			0,0,0,0,0,1,1,1,1,1,2,2,2,2,2,3,3,3,3,3,4,4,4,4,4,
			0,0,0,0,0,1,1,1,1,1,2,2,2,2,2,3,3,3,3,3,4,4,4,4,4,
			0,0,0,0,0,1,1,1,1,1,2,2,2,2,2,3,3,3,3,3,4,4,4,4,4
		};
		bandeY = new short[] {
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
			1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
			2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,
			3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,
			4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4
		};
		bandeZ = new short[] {
			0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,
			0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,
			0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,
			0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,
			0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4,0,1,2,3,4
		};
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
			case 0 :
				return new short[]{data[0],data[1],data[2],data[3],data[4],data[25],data[26],data[27],data[28],data[29],data[50],data[51],data[52],data[53],data[54],data[75],data[76],data[77],data[78],data[79],data[100],data[101],data[102],data[103],data[104] };
			case 1 :
				return new short[]{data[5],data[6],data[7],data[8],data[9],data[30],data[31],data[32],data[33],data[34],data[55],data[56],data[57],data[58],data[59],data[80],data[81],data[82],data[83],data[84],data[105],data[106],data[107],data[108],data[109] };
			case 2 :
				return new short[]{data[10],data[11],data[12],data[13],data[14],data[35],data[36],data[37],data[38],data[39],data[60],data[61],data[62],data[63],data[64],data[85],data[86],data[87],data[88],data[89],data[110],data[111],data[112],data[113],data[114] };
			case 3 :
				return new short[]{data[15],data[16],data[17],data[18],data[19],data[40],data[41],data[42],data[43],data[44],data[65],data[66],data[67],data[68],data[69],data[90],data[91],data[92],data[93],data[94],data[115],data[116],data[117],data[118],data[119] };
			case 4 :
				return new short[]{data[20],data[21],data[22],data[23],data[24],data[45],data[46],data[47],data[48],data[49],data[70],data[71],data[72],data[73],data[74],data[95],data[96],data[97],data[98],data[99],data[120],data[121],data[122],data[123],data[124] };
			}
			break;

		case AXES.Y :
			switch(bandeId) {
			case 0:
				return new short[]{data[0],data[1],data[2],data[3],data[4],data[5],data[6],data[7],data[8],data[9],data[10],data[11],data[12],data[13],data[14],data[15],data[16],data[17],data[18],data[19],data[20],data[21],data[22],data[23],data[24]};
			case 1 :
				return new short[]{data[25],data[26],data[27],data[28],data[29],data[30],data[31],data[32],data[33],data[34],data[35],data[36],data[37],data[38],data[39],data[40],data[41],data[42],data[43],data[44],data[45],data[46],data[47],data[48],data[49]};
			case 2 :
				return new short[]{data[50],data[51],data[52],data[53],data[54],data[55],data[56],data[57],data[58],data[59],data[60],data[61],data[62],data[63],data[64],data[65],data[66],data[67],data[68],data[69],data[70],data[71],data[72],data[73],data[74]};
			case 3 :
				return new short[]{data[75],data[76],data[77],data[78],data[79],data[80],data[81],data[82],data[83],data[84],data[85],data[86],data[87],data[88],data[89],data[90],data[91],data[92],data[93],data[94],data[95],data[96],data[97],data[98],data[99]};
			case 4 :
				return new short[]{data[100],data[101],data[102],data[103],data[104],data[105],data[106],data[107],data[108],data[109],data[110],data[111],data[112],data[113],data[114],data[115],data[116],data[117],data[118],data[119],data[120],data[121],data[122],data[123],data[124]};
			}
			break;
			
		case AXES.Z :
			switch(bandeId) {
			case 0:
				return new short[]{data[0], data[5], data[10], data[15], data[20], data[25], data[30], data[35], data[40], data[45], data[50], data[55], data[60], data[65], data[70], data[75], data[80], data[85], data[90], data[95], data[100], data[105], data[110], data[115], data[120] };
			case 1:
				return new short[]{data[1], data[6], data[11], data[16], data[21], data[26], data[31], data[36], data[41], data[46], data[51], data[56], data[61], data[66], data[71], data[76], data[81], data[86], data[91], data[96], data[101], data[106], data[111], data[116], data[121] };
			case 2:
				return new short[]{data[2], data[7], data[12], data[17], data[22], data[27], data[32], data[37], data[42], data[47], data[52], data[57], data[62], data[67], data[72], data[77], data[82], data[87], data[92], data[97], data[102], data[107], data[112], data[117], data[122] };
			case 3:
				return new short[]{data[3], data[8], data[13], data[18], data[23], data[28], data[33], data[38], data[43], data[48], data[53], data[58], data[63], data[68], data[73], data[78], data[83], data[88], data[93], data[98], data[103], data[108], data[113], data[118], data[123] };
			case 4:
				return new short[]{data[4], data[9], data[14], data[19], data[24], data[29], data[34], data[39], data[44], data[49], data[54], data[59], data[64], data[69], data[74], data[79], data[84], data[89], data[94], data[99], data[104], data[109], data[114], data[119], data[124] };
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
		rotationBandeX (ref dest,4);
	}

	/**
	 *
	 */
	private void rotationInvX(ref short[] dest) {
		rotationBandeInvX (ref dest,0);
		rotationBandeInvX (ref dest,1);
		rotationBandeInvX (ref dest,2);
		rotationBandeInvX (ref dest,3);
		rotationBandeInvX (ref dest,4);
	}

	/**
	 *
	 */
	private void rotationY(ref short[] dest) {
		rotationBandeY (ref dest,0);
		rotationBandeY (ref dest,1);
		rotationBandeY (ref dest,2);
		rotationBandeY (ref dest,3);
		rotationBandeY (ref dest,4);
	}
	
	/**
	 *
	 */
	private void rotationInvY(ref short[] dest) {
		rotationBandeInvY (ref dest,0);
		rotationBandeInvY (ref dest,1);
		rotationBandeInvY (ref dest,2);
		rotationBandeInvY (ref dest,3);
		rotationBandeInvY (ref dest,4);
	}

	/**
	 *
	 */
	private void rotationZ(ref short[] dest) {
		rotationBandeZ (ref dest,0);
		rotationBandeZ (ref dest,1);
		rotationBandeZ (ref dest,2);
		rotationBandeZ (ref dest,3);
		rotationBandeZ (ref dest,4);
	}
	
	/**
	 *
	 */
	private void rotationInvZ(ref short[] dest) {
		rotationBandeInvZ (ref dest,0);
		rotationBandeInvZ (ref dest,1);
		rotationBandeInvZ (ref dest,2);
		rotationBandeInvZ (ref dest,3);
		rotationBandeInvZ (ref dest,4);
	}

	/**
	 * 
	 */
	private void rotationBandeX(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [100];
			dest [1] = data [75];
			dest [2] = data [50];
			dest [3] = data [25];
			dest [4] = data [0];
			dest [25] = data [101];
			dest [26] = data [76];
			dest [27] = data [51];
			dest [28] = data [26];
			dest [29] = data [1];
			dest [50] = data [102];
			dest [51] = data [77];
			dest [52] = data [52];
			dest [53] = data [27];
			dest [54] = data [2];
			dest [75] = data [103];
			dest [76] = data [78];
			dest [77] = data [53];
			dest [78] = data [28];
			dest [79] = data [3];
			dest [100] = data [104];
			dest [101] = data [79];
			dest [102] = data [54];
			dest [103] = data [29];
			dest [104] = data [4];
			break;
		case 1:
			dest [5] = data [105];
			dest [6] = data [80];
			dest [7] = data [55];
			dest [8] = data [30];
			dest [9] = data [5];
			dest [30] = data [106];
			dest [31] = data [81];
			dest [32] = data [56];
			dest [33] = data [31];
			dest [34] = data [6];
			dest [55] = data [107];
			dest [56] = data [82];
			dest [57] = data [57];
			dest [58] = data [32];
			dest [59] = data [7];
			dest [80] = data [108];
			dest [81] = data [83];
			dest [82] = data [58];
			dest [83] = data [33];
			dest [84] = data [8];
			dest [105] = data [109];
			dest [106] = data [84];
			dest [107] = data [59];
			dest [108] = data [34];
			dest [109] = data [9];
			break;
		case 2:
			dest [10] = data [110];
			dest [11] = data [85];
			dest [12] = data [60];
			dest [13] = data [35];
			dest [14] = data [10];
			dest [35] = data [111];
			dest [36] = data [86];
			dest [37] = data [61];
			dest [38] = data [36];
			dest [39] = data [11];
			dest [60] = data [112];
			dest [61] = data [87];
			dest [62] = data [62];
			dest [63] = data [37];
			dest [64] = data [12];
			dest [85] = data [113];
			dest [86] = data [88];
			dest [87] = data [63];
			dest [88] = data [38];
			dest [89] = data [13];
			dest [110] = data [114];
			dest [111] = data [89];
			dest [112] = data [64];
			dest [113] = data [39];
			dest [114] = data [14];
			break;
		case 3:
			dest [15] = data [115];
			dest [16] = data [90];
			dest [17] = data [65];
			dest [18] = data [40];
			dest [19] = data [15];
			dest [40] = data [116];
			dest [41] = data [91];
			dest [42] = data [66];
			dest [43] = data [41];
			dest [44] = data [16];
			dest [65] = data [117];
			dest [66] = data [92];
			dest [67] = data [67];
			dest [68] = data [42];
			dest [69] = data [17];
			dest [90] = data [118];
			dest [91] = data [93];
			dest [92] = data [68];
			dest [93] = data [43];
			dest [94] = data [18];
			dest [115] = data [119];
			dest [116] = data [94];
			dest [117] = data [69];
			dest [118] = data [44];
			dest [119] = data [19];
			break;
		case 4:
			dest [20] = data [120];
			dest [21] = data [95];
			dest [22] = data [70];
			dest [23] = data [45];
			dest [24] = data [20];
			dest [45] = data [121];
			dest [46] = data [96];
			dest [47] = data [71];
			dest [48] = data [46];
			dest [49] = data [21];
			dest [70] = data [122];
			dest [71] = data [97];
			dest [72] = data [72];
			dest [73] = data [47];
			dest [74] = data [22];
			dest [95] = data [123];
			dest [96] = data [98];
			dest [97] = data [73];
			dest [98] = data [48];
			dest [99] = data [23];
			dest [120] = data [124];
			dest [121] = data [99];
			dest [122] = data [74];
			dest [123] = data [49];
			dest [124] = data [24];
			break;
		}
	}

	/**
	 * 
	 */
	private void rotationBandeInvX(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [4];
			dest [1] = data [29];
			dest [2] = data [54];
			dest [3] = data [79];
			dest [4] = data [104];
			dest [25] = data [3];
			dest [26] = data [28];
			dest [27] = data [53];
			dest [28] = data [78];
			dest [29] = data [103];
			dest [50] = data [2];
			dest [51] = data [27];
			dest [52] = data [52];
			dest [53] = data [77];
			dest [54] = data [102];
			dest [75] = data [1];
			dest [76] = data [26];
			dest [77] = data [51];
			dest [78] = data [76];
			dest [79] = data [101];
			dest [100] = data [0];
			dest [101] = data [25];
			dest [102] = data [50];
			dest [103] = data [75];
			dest [104] = data [100];
			break;
		case 1:
			dest [5] = data [9];
			dest [6] = data [34];
			dest [7] = data [59];
			dest [8] = data [84];
			dest [9] = data [109];
			dest [30] = data [8];
			dest [31] = data [33];
			dest [32] = data [58];
			dest [33] = data [83];
			dest [34] = data [108];
			dest [55] = data [7];
			dest [56] = data [32];
			dest [57] = data [57];
			dest [58] = data [82];
			dest [59] = data [107];
			dest [80] = data [6];
			dest [81] = data [31];
			dest [82] = data [56];
			dest [83] = data [81];
			dest [84] = data [106];
			dest [105] = data [5];
			dest [106] = data [30];
			dest [107] = data [55];
			dest [108] = data [80];
			dest [109] = data [105];
			break;
		case 2:
			dest [10] = data [14];
			dest [11] = data [39];
			dest [12] = data [64];
			dest [13] = data [89];
			dest [14] = data [114];
			dest [35] = data [13];
			dest [36] = data [38];
			dest [37] = data [63];
			dest [38] = data [88];
			dest [39] = data [113];
			dest [60] = data [12];
			dest [61] = data [37];
			dest [62] = data [62];
			dest [63] = data [87];
			dest [64] = data [112];
			dest [85] = data [11];
			dest [86] = data [36];
			dest [87] = data [61];
			dest [88] = data [86];
			dest [89] = data [111];
			dest [110] = data [10];
			dest [111] = data [35];
			dest [112] = data [60];
			dest [113] = data [85];
			dest [114] = data [110];
			break;
		case 3:
			dest [15] = data [19];
			dest [16] = data [44];
			dest [17] = data [69];
			dest [18] = data [94];
			dest [19] = data [119];
			dest [40] = data [18];
			dest [41] = data [43];
			dest [42] = data [68];
			dest [43] = data [93];
			dest [44] = data [118];
			dest [65] = data [17];
			dest [66] = data [42];
			dest [67] = data [67];
			dest [68] = data [92];
			dest [69] = data [117];
			dest [90] = data [16];
			dest [91] = data [41];
			dest [92] = data [66];
			dest [93] = data [91];
			dest [94] = data [116];
			dest [115] = data [15];
			dest [116] = data [40];
			dest [117] = data [65];
			dest [118] = data [90];
			dest [119] = data [115];
			break;
		case 4:
			dest [20] = data [24];
			dest [21] = data [49];
			dest [22] = data [74];
			dest [23] = data [99];
			dest [24] = data [124];
			dest [45] = data [23];
			dest [46] = data [48];
			dest [47] = data [73];
			dest [48] = data [98];
			dest [49] = data [123];
			dest [70] = data [22];
			dest [71] = data [47];
			dest [72] = data [72];
			dest [73] = data [97];
			dest [74] = data [122];
			dest [95] = data [21];
			dest [96] = data [46];
			dest [97] = data [71];
			dest [98] = data [96];
			dest [99] = data [121];
			dest [120] = data [20];
			dest [121] = data [45];
			dest [122] = data [70];
			dest [123] = data [95];
			dest [124] = data [120];
			break;
		}
	}

	/**
	 * 
	 */
	private void rotationBandeY(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [4];
			dest [1] = data [9];
			dest [2] = data [14];
			dest [3] = data [19];
			dest [4] = data [24];
			dest [5] = data [3];
			dest [6] = data [8];
			dest [7] = data [13];
			dest [8] = data [18];
			dest [9] = data [23];
			dest [10] = data [2];
			dest [11] = data [7];
			dest [12] = data [12];
			dest [13] = data [17];
			dest [14] = data [22];
			dest [15] = data [1];
			dest [16] = data [6];
			dest [17] = data [11];
			dest [18] = data [16];
			dest [19] = data [21];
			dest [20] = data [0];
			dest [21] = data [5];
			dest [22] = data [10];
			dest [23] = data [15];
			dest [24] = data [20];
			break;
		case 1:
			dest [25] = data [29];
			dest [26] = data [34];
			dest [27] = data [39];
			dest [28] = data [44];
			dest [29] = data [49];
			dest [30] = data [28];
			dest [31] = data [33];
			dest [32] = data [38];
			dest [33] = data [43];
			dest [34] = data [48];
			dest [35] = data [27];
			dest [36] = data [32];
			dest [37] = data [37];
			dest [38] = data [42];
			dest [39] = data [47];
			dest [40] = data [26];
			dest [41] = data [31];
			dest [42] = data [36];
			dest [43] = data [41];
			dest [44] = data [46];
			dest [45] = data [25];
			dest [46] = data [30];
			dest [47] = data [35];
			dest [48] = data [40];
			dest [49] = data [45];
			break;
		case 2:
			dest [50] = data [54];
			dest [51] = data [59];
			dest [52] = data [64];
			dest [53] = data [69];
			dest [54] = data [74];
			dest [55] = data [53];
			dest [56] = data [58];
			dest [57] = data [63];
			dest [58] = data [68];
			dest [59] = data [73];
			dest [60] = data [52];
			dest [61] = data [57];
			dest [62] = data [62];
			dest [63] = data [67];
			dest [64] = data [72];
			dest [65] = data [51];
			dest [66] = data [56];
			dest [67] = data [61];
			dest [68] = data [66];
			dest [69] = data [71];
			dest [70] = data [50];
			dest [71] = data [55];
			dest [72] = data [60];
			dest [73] = data [65];
			dest [74] = data [70];
			break;
		case 3:
			dest [75] = data [79];
			dest [76] = data [84];
			dest [77] = data [89];
			dest [78] = data [94];
			dest [79] = data [99];
			dest [80] = data [78];
			dest [81] = data [83];
			dest [82] = data [88];
			dest [83] = data [93];
			dest [84] = data [98];
			dest [85] = data [77];
			dest [86] = data [82];
			dest [87] = data [87];
			dest [88] = data [92];
			dest [89] = data [97];
			dest [90] = data [76];
			dest [91] = data [81];
			dest [92] = data [86];
			dest [93] = data [91];
			dest [94] = data [96];
			dest [95] = data [75];
			dest [96] = data [80];
			dest [97] = data [85];
			dest [98] = data [90];
			dest [99] = data [95];
			break;
		case 4:
			dest [100] = data [104];
			dest [101] = data [109];
			dest [102] = data [114];
			dest [103] = data [119];
			dest [104] = data [124];
			dest [105] = data [103];
			dest [106] = data [108];
			dest [107] = data [113];
			dest [108] = data [118];
			dest [109] = data [123];
			dest [110] = data [102];
			dest [111] = data [107];
			dest [112] = data [112];
			dest [113] = data [117];
			dest [114] = data [122];
			dest [115] = data [101];
			dest [116] = data [106];
			dest [117] = data [111];
			dest [118] = data [116];
			dest [119] = data [121];
			dest [120] = data [100];
			dest [121] = data [105];
			dest [122] = data [110];
			dest [123] = data [115];
			dest [124] = data [120];
			break;
		}
	}

	
	/**
	 * 
	 */
	private void rotationBandeInvY(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [20];
			dest [1] = data [15];
			dest [2] = data [10];
			dest [3] = data [5];
			dest [4] = data [0];
			dest [5] = data [21];
			dest [6] = data [16];
			dest [7] = data [11];
			dest [8] = data [6];
			dest [9] = data [1];
			dest [10] = data [22];
			dest [11] = data [17];
			dest [12] = data [12];
			dest [13] = data [7];
			dest [14] = data [2];
			dest [15] = data [23];
			dest [16] = data [18];
			dest [17] = data [13];
			dest [18] = data [8];
			dest [19] = data [3];
			dest [20] = data [24];
			dest [21] = data [19];
			dest [22] = data [14];
			dest [23] = data [9];
			dest [24] = data [4];
			break;
		case 1:
			dest [25] = data [45];
			dest [26] = data [40];
			dest [27] = data [35];
			dest [28] = data [30];
			dest [29] = data [25];
			dest [30] = data [46];
			dest [31] = data [41];
			dest [32] = data [36];
			dest [33] = data [31];
			dest [34] = data [26];
			dest [35] = data [47];
			dest [36] = data [42];
			dest [37] = data [37];
			dest [38] = data [32];
			dest [39] = data [27];
			dest [40] = data [48];
			dest [41] = data [43];
			dest [42] = data [38];
			dest [43] = data [33];
			dest [44] = data [28];
			dest [45] = data [49];
			dest [46] = data [44];
			dest [47] = data [39];
			dest [48] = data [34];
			dest [49] = data [29];
			break;
		case 2:
			dest [50] = data [70];
			dest [51] = data [65];
			dest [52] = data [60];
			dest [53] = data [55];
			dest [54] = data [50];
			dest [55] = data [71];
			dest [56] = data [66];
			dest [57] = data [61];
			dest [58] = data [56];
			dest [59] = data [51];
			dest [60] = data [72];
			dest [61] = data [67];
			dest [62] = data [62];
			dest [63] = data [57];
			dest [64] = data [52];
			dest [65] = data [73];
			dest [66] = data [68];
			dest [67] = data [63];
			dest [68] = data [58];
			dest [69] = data [53];
			dest [70] = data [74];
			dest [71] = data [69];
			dest [72] = data [64];
			dest [73] = data [59];
			dest [74] = data [54];
			break;
		case 3:
			dest [75] = data [95];
			dest [76] = data [90];
			dest [77] = data [85];
			dest [78] = data [80];
			dest [79] = data [75];
			dest [80] = data [96];
			dest [81] = data [91];
			dest [82] = data [86];
			dest [83] = data [81];
			dest [84] = data [76];
			dest [85] = data [97];
			dest [86] = data [92];
			dest [87] = data [87];
			dest [88] = data [82];
			dest [89] = data [77];
			dest [90] = data [98];
			dest [91] = data [93];
			dest [92] = data [88];
			dest [93] = data [83];
			dest [94] = data [78];
			dest [95] = data [99];
			dest [96] = data [94];
			dest [97] = data [89];
			dest [98] = data [84];
			dest [99] = data [79];
			break;
		case 4:
			dest [100] = data [120];
			dest [101] = data [115];
			dest [102] = data [110];
			dest [103] = data [105];
			dest [104] = data [100];
			dest [105] = data [121];
			dest [106] = data [116];
			dest [107] = data [111];
			dest [108] = data [106];
			dest [109] = data [101];
			dest [110] = data [122];
			dest [111] = data [117];
			dest [112] = data [112];
			dest [113] = data [107];
			dest [114] = data [102];
			dest [115] = data [123];
			dest [116] = data [118];
			dest [117] = data [113];
			dest [118] = data [108];
			dest [119] = data [103];
			dest [120] = data [124];
			dest [121] = data [119];
			dest [122] = data [114];
			dest [123] = data [109];
			dest [124] = data [104];
			break;
		}
	}

	/**
	 * 
	 */
	private void rotationBandeZ(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [20];
			dest [5] = data [45];
			dest [10] = data [70];
			dest [15] = data [95];
			dest [20] = data [120];
			dest [25] = data [15];
			dest [30] = data [40];
			dest [35] = data [65];
			dest [40] = data [90];
			dest [45] = data [115];
			dest [50] = data [10];
			dest [55] = data [35];
			dest [60] = data [60];
			dest [65] = data [85];
			dest [70] = data [110];
			dest [75] = data [5];
			dest [80] = data [30];
			dest [85] = data [55];
			dest [90] = data [80];
			dest [95] = data [105];
			dest [100] = data [0];
			dest [105] = data [25];
			dest [110] = data [50];
			dest [115] = data [75];
			dest [120] = data [100];
			break;
		case 1:
			dest [1] = data [21];
			dest [6] = data [46];
			dest [11] = data [71];
			dest [16] = data [96];
			dest [21] = data [121];
			dest [26] = data [16];
			dest [31] = data [41];
			dest [36] = data [66];
			dest [41] = data [91];
			dest [46] = data [116];
			dest [51] = data [11];
			dest [56] = data [36];
			dest [61] = data [61];
			dest [66] = data [86];
			dest [71] = data [111];
			dest [76] = data [6];
			dest [81] = data [31];
			dest [86] = data [56];
			dest [91] = data [81];
			dest [96] = data [106];
			dest [101] = data [1];
			dest [106] = data [26];
			dest [111] = data [51];
			dest [116] = data [76];
			dest [121] = data [101];
			break;
		case 2:
			dest [2] = data [22];
			dest [7] = data [47];
			dest [12] = data [72];
			dest [17] = data [97];
			dest [22] = data [122];
			dest [27] = data [17];
			dest [32] = data [42];
			dest [37] = data [67];
			dest [42] = data [92];
			dest [47] = data [117];
			dest [52] = data [12];
			dest [57] = data [37];
			dest [62] = data [62];
			dest [67] = data [87];
			dest [72] = data [112];
			dest [77] = data [7];
			dest [82] = data [32];
			dest [87] = data [57];
			dest [92] = data [82];
			dest [97] = data [107];
			dest [102] = data [2];
			dest [107] = data [27];
			dest [112] = data [52];
			dest [117] = data [77];
			dest [122] = data [102];
			break;
		case 3:
			dest [3] = data [23];
			dest [8] = data [48];
			dest [13] = data [73];
			dest [18] = data [98];
			dest [23] = data [123];
			dest [28] = data [18];
			dest [33] = data [43];
			dest [38] = data [68];
			dest [43] = data [93];
			dest [48] = data [118];
			dest [53] = data [13];
			dest [58] = data [38];
			dest [63] = data [63];
			dest [68] = data [88];
			dest [73] = data [113];
			dest [78] = data [8];
			dest [83] = data [33];
			dest [88] = data [58];
			dest [93] = data [83];
			dest [98] = data [108];
			dest [103] = data [3];
			dest [108] = data [28];
			dest [113] = data [53];
			dest [118] = data [78];
			dest [123] = data [103];
			break;
		case 4:
			dest [4] = data [24];
			dest [9] = data [49];
			dest [14] = data [74];
			dest [19] = data [99];
			dest [24] = data [124];
			dest [29] = data [19];
			dest [34] = data [44];
			dest [39] = data [69];
			dest [44] = data [94];
			dest [49] = data [119];
			dest [54] = data [14];
			dest [59] = data [39];
			dest [64] = data [64];
			dest [69] = data [89];
			dest [74] = data [114];
			dest [79] = data [9];
			dest [84] = data [34];
			dest [89] = data [59];
			dest [94] = data [84];
			dest [99] = data [109];
			dest [104] = data [4];
			dest [109] = data [29];
			dest [114] = data [54];
			dest [119] = data [79];
			dest [124] = data [104];
			break;
		}
	}

	/**
	 * 
	 */
	private void rotationBandeInvZ(ref short[] dest, short id) {
		switch (id) {
		case 0:
			dest [0] = data [100];
			dest [5] = data [75];
			dest [10] = data [50];
			dest [15] = data [25];
			dest [20] = data [0];
			dest [25] = data [105];
			dest [30] = data [80];
			dest [35] = data [55];
			dest [40] = data [30];
			dest [45] = data [5];
			dest [50] = data [110];
			dest [55] = data [85];
			dest [60] = data [60];
			dest [65] = data [35];
			dest [70] = data [10];
			dest [75] = data [115];
			dest [80] = data [90];
			dest [85] = data [65];
			dest [90] = data [40];
			dest [95] = data [15];
			dest [100] = data [120];
			dest [105] = data [95];
			dest [110] = data [70];
			dest [115] = data [45];
			dest [120] = data [20];
			break;
		case 1:
			dest [1] = data [101];
			dest [6] = data [76];
			dest [11] = data [51];
			dest [16] = data [26];
			dest [21] = data [1];
			dest [26] = data [106];
			dest [31] = data [81];
			dest [36] = data [56];
			dest [41] = data [31];
			dest [46] = data [6];
			dest [51] = data [111];
			dest [56] = data [86];
			dest [61] = data [61];
			dest [66] = data [36];
			dest [71] = data [11];
			dest [76] = data [116];
			dest [81] = data [91];
			dest [86] = data [66];
			dest [91] = data [41];
			dest [96] = data [16];
			dest [101] = data [121];
			dest [106] = data [96];
			dest [111] = data [71];
			dest [116] = data [46];
			dest [121] = data [21];
			break;
		case 2:
			dest [2] = data [102];
			dest [7] = data [77];
			dest [12] = data [52];
			dest [17] = data [27];
			dest [22] = data [2];
			dest [27] = data [107];
			dest [32] = data [82];
			dest [37] = data [57];
			dest [42] = data [32];
			dest [47] = data [7];
			dest [52] = data [112];
			dest [57] = data [87];
			dest [62] = data [62];
			dest [67] = data [37];
			dest [72] = data [12];
			dest [77] = data [117];
			dest [82] = data [92];
			dest [87] = data [67];
			dest [92] = data [42];
			dest [97] = data [17];
			dest [102] = data [122];
			dest [107] = data [97];
			dest [112] = data [72];
			dest [117] = data [47];
			dest [122] = data [22];
			break;
		case 3:
			dest [3] = data [103];
			dest [8] = data [78];
			dest [13] = data [53];
			dest [18] = data [28];
			dest [23] = data [3];
			dest [28] = data [108];
			dest [33] = data [83];
			dest [38] = data [58];
			dest [43] = data [33];
			dest [48] = data [8];
			dest [53] = data [113];
			dest [58] = data [88];
			dest [63] = data [63];
			dest [68] = data [38];
			dest [73] = data [13];
			dest [78] = data [118];
			dest [83] = data [93];
			dest [88] = data [68];
			dest [93] = data [43];
			dest [98] = data [18];
			dest [103] = data [123];
			dest [108] = data [98];
			dest [113] = data [73];
			dest [118] = data [48];
			dest [123] = data [23];
			break;
		case 4:
			dest [4] = data [104];
			dest [9] = data [79];
			dest [14] = data [54];
			dest [19] = data [29];
			dest [24] = data [4];
			dest [29] = data [109];
			dest [34] = data [84];
			dest [39] = data [59];
			dest [44] = data [34];
			dest [49] = data [9];
			dest [54] = data [114];
			dest [59] = data [89];
			dest [64] = data [64];
			dest [69] = data [39];
			dest [74] = data [14];
			dest [79] = data [119];
			dest [84] = data [94];
			dest [89] = data [69];
			dest [94] = data [44];
			dest [99] = data [19];
			dest [104] = data [124];
			dest [109] = data [99];
			dest [114] = data [74];
			dest [119] = data [49];
			dest [124] = data [24];
			break;
		}
	}
}
