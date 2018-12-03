using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter(Collider col) {
		if (col.tag == "Player" || col.tag == "MainCamera") {
			StateManager.ResetStates();
		}
			
	}
}
