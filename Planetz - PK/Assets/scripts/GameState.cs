using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

	public int dust = 0;
	// Use this for initialization    
	public Text text;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dust > 0) {
			text.text = "Score: " + dust;
		} else {
			text.text = "New Game";
		}
	}
}
