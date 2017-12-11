
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent (typeof (AudioSource))]
public class collectable : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip clip;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.name == "Player") 
		{
			gameState gS = GameObject.Find ("State").GetComponent<gameState> ();
			audioSource.PlayOneShot (clip);
			gS.dust += 1;
			print (gS.dust);
			Destroy(gameObject);
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
