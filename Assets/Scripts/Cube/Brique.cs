using System;
using UnityEngine;

/**
 * identifie le type et la position d'une brique du cube
 */
[Serializable]
public class Brique {
	public readonly string name; // name of prefab
	public readonly string type; // type of prefab
	public readonly short uuid; // id of this element/gameobject to be refered to

	public readonly float x;
	public readonly float y;
	public readonly float z;
	public readonly float rx;
	public readonly float ry;
	public readonly float rz;

	public GameObject obj; // object instance

	public Brique(string type, string name, short uuid, float x, float y, float z, float rx, float ry, float rz ) {
		this.type = type;
		this.name = name;
		this.uuid = uuid;
		this.x = x;
		this.y = y;
		this.z = z;
		this.rx = rx;
		this.ry = ry;
		this.rz = rz;
	}
}
