using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	
	GameObject planet;

	// Use this for initialization
	void Start () {
		planet = GameObject.FindWithTag("Planet");
		transform.position = new Vector3(planet.transform.position.x, 
										 planet.transform.position.y + 0.5f, 
										 planet.transform.position.z);
	}
	

}
