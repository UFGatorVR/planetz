using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//FINISH
public class MoveCube : MonoBehaviour {
	public GravityBody player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player").GetComponent<GravityBody> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
