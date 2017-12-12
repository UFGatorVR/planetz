
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
			c.gameObject.GetComponent<FirstPerson> ().water += 0.1f;
			GameState gS = GameObject.Find ("GameState").GetComponent<GameState> ();
			audioSource.PlayOneShot (clip);
			gS.dust += 1;
//			print (gS.dust);
//			Destroy(gameObject);
			transform.position = -c.gameObject.transform.position;
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
