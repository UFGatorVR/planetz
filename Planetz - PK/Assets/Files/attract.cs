using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attract : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void my_gravity () {
		GameObject[] planets = GameObject.FindGameObjectsWithTag ("planet");
		Vector3 p1 = transform.position;
		Rigidbody rb1 = GetComponent<Rigidbody>();
		foreach(GameObject p in planets){
			Vector3 p2 = p.transform.position;
			Vector3 dir = p2 - p1;
			float dist = dir.magnitude;
			float force_mag = rb1.mass * 0.001f / (dist * dist); 
			Vector3 force = dir.normalized * force_mag;
			Debug.DrawRay (transform.position, force*100);
			rb1.AddForce (force, ForceMode.Impulse);
		}
	}

	void FixedUpdate(){
		my_gravity ();
	}
	// Update is called once per frame
	void Update () {
	}
}
