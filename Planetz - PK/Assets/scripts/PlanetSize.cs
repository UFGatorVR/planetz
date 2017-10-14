using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (GravityAttractor))]
public class PlanetSize : MonoBehaviour {
	public float radius = 50;
	// Use this for initialization

	void Start () {
		transform.localScale = new Vector3 (radius * 2, radius * 2, radius * 2);
	}

}
