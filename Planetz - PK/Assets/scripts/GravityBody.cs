using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour {

	GravityAttractor planet;
	Rigidbody rb;

	void Awake(){
		planet = GameObject.FindWithTag("Planet").GetComponent<GravityAttractor>();
		rb = GetComponent<Rigidbody>();

		rb.useGravity = false;
		rb.freezeRotation = true;
	
	}
	void FixedUpdate(){
		planet.Attract(rb);
	}
}
