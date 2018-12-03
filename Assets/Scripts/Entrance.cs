using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour {
	public States state;
	public void OnTriggerEnter(Collider col) {
		if (col.tag == "Player" || col.tag == "MainCamera") {
			StateManager.Switch(state);
		}
			
	}
}
