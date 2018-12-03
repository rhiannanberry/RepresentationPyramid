using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {
	public States state;
	public GameObject characterController;

	private Resettable[] roomItems;

	void Start () {
		switch(state) {
			case States.Realistic:
				StateManager.realistic = this;
				break;
			case States.Abstract:
				StateManager.abstracted = this;
				break;
			case States.Iconic:
				StateManager.iconic = this;
				break;
		}
		roomItems = GetComponentsInChildren<Resettable>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetRoom() {
		Debug.Log("Resetting " + state.ToString() + " room.");
		foreach(Resettable i in roomItems) {
			i.ResetObject();
		}
	}

	public void DisableCharacterController() {
		characterController.transform.position = transform.position;
		characterController.SetActive(false);
	}
	
}
