using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chase : MonoBehaviour {

	// Use this for initialization
	public GameObject planet;
	public GameObject player;
	public float heightAboveGround = 0.4f;
	public float angularSpeed = -0.1f;

	// Update is called once per frame
	void FixedUpdate() {
//		float r = planet.GetComponent<SphereCollider>().radius;
		Vector3 o = planet.transform.position; //origin, center of planet
		Vector3 p = player.transform.position;
		Vector3 e = transform.position;

		float dist = Vector3.Distance (p, e);

		if (dist < 6f) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}

		//The vector from the sphere to the player and enemy
		Vector3 u = p - o;
		Vector3 v = e - o;
		//This is the axis that defines the plane spanned by u and v.
		Vector3 perp = Vector3.Cross (u, v);

//		Debug.DrawRay(o, v);
		RaycastHit hit;
		//  Layer mask can be used 
		//	Layer 8 = Planet, 9 = Player, 10 = Enemies
		//  LayerMask PlanetEnemies = 1 << 8 | 1 << 10
		//  LayerMask notPlanetEnemies = ~(1 << 8 | 1 << 10)
		//	LayerMask planet_layer = 1 << 8; //Planet Layer (must add layer)
		if (Physics.Raycast (e, -v, out hit, 1 << 8)) {
			//	if (Physics.Raycast (e, -v, out hit, r*2, 1 << 8)) { //max distance (not needed)
			Vector3 distFromCenter = hit.point + heightAboveGround * (v / v.magnitude);
			// Rotate an amount towards the player (about the axis perp)
			transform.position = Quaternion.AngleAxis (angularSpeed, perp) * distFromCenter;
		}
	}
}
