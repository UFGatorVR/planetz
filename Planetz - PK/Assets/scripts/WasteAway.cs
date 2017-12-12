using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteAway : MonoBehaviour {

	public float life = 100.0f;

	// Use this for initialization
	void Start () {
		
	}

	void OnParticleCollision(GameObject o){
		life -= 1f;
	}

	// Update is called once per frame
	void Update () {
		GameObject fireEffect = transform.Find ("FlamesParticleEffect").gameObject;
		fireEffect.transform.localScale = (3f - 2 * (100f - life)/100f) * (new Vector3(1f,1f,1f));
//		print (life.ToString("F2"));
		if (life < 0) {
			GameObject state = GameObject.Find ("GameState");
			state.GetComponent<GameState> ().dust += 1;
			life = 100f;
			GameObject player = GameObject.Find ("Player");
			transform.position = -player.transform.position;

		}
	}
}
