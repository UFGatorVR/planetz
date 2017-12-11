using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rb1 = GetComponent<Rigidbody>();
		if (Input.GetKey (KeyCode.W)) {
			rb1.AddForce(transform.forward*0.01f, ForceMode.Impulse);
		}
		if (Input.GetKey (KeyCode.S)) {
			rb1.AddForce(transform.forward*-0.01f, ForceMode.Impulse);
		}
		if (Input.GetKey (KeyCode.A)) {
			rb1.AddForce(transform.right*-0.01f, ForceMode.Impulse);
		}
		if (Input.GetKey (KeyCode.D)) {
			rb1.AddForce(transform.right*0.01f, ForceMode.Impulse);
		}
		if (Input.GetKey (KeyCode.R)) {
			rb1.AddForce(transform.up*0.01f, ForceMode.Impulse);
		}
		if (Input.GetKey (KeyCode.F)) {
			rb1.AddForce(transform.up*-0.01f, ForceMode.Impulse);
		}
		if (Input.GetKey (KeyCode.Q)) {
			rb1.AddTorque (transform.forward * 0.005f);
		}
		if (Input.GetKey (KeyCode.E)) {
			rb1.AddTorque (transform.forward * -0.005f);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rb1.AddTorque (transform.up * -0.005f);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			rb1.AddTorque (transform.up * 0.005f);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			rb1.AddTorque (transform.right * -0.005f);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			rb1.AddTorque (transform.right * 0.005f);
		}
	}
}
