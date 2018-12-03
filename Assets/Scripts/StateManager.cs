using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class StateManager : MonoBehaviour {
	public States startState;
	public TextMeshProUGUI stateUI;

	public static States current; 
	public static State currentState;
	//public static States? leaving = null, entering = null;
	public static State realistic, iconic, abstracted;

	[HideInInspector]
	public static bool reset = false;

	// Use this for initialization
	void Start () {
		current = startState;
		
		UpdateStateUI();
	}
	
	
	// Update is called once per frame
	void Update () {
		UpdateStateUI();
	}

	public static void ResetStates() {
		if(!reset) {
			Debug.Log("RESETTING");
			currentState = EnumToState(current);
			reset = true;
			realistic.ResetRoom();
			iconic.ResetRoom();
			abstracted.ResetRoom();
		}
		
	}

	//fornow, just enter, enter collision 
	public static void Switch(States newSt) {
		currentState = EnumToState(current);
		CameraManager.camera = currentState.GetComponentInChildren<Camera>();
		if (reset) {
			Debug.Log(newSt);
			Vector3 position = currentState.characterController.transform.position;
			Quaternion rotationOuter = currentState.characterController.transform.rotation;
			Quaternion rotationInner = currentState.characterController.transform.GetChild(0).rotation;

			Debug.Log("OLD LOCAL ROT outer: " + currentState.characterController.transform.rotation.eulerAngles);
			Debug.Log("OLD LOCAL ROT Inner: " + currentState.characterController.transform.GetChild(0).rotation.eulerAngles);
			currentState.DisableCharacterController();
	
			current = newSt;
			currentState = EnumToState(newSt);

			currentState.characterController.SetActive(true);
			
			currentState.characterController.transform.position = position;
			currentState.characterController.transform.rotation = rotationOuter;
			currentState.characterController.transform.GetChild(0).rotation = rotationInner;

			currentState.characterController.GetComponent<FirstPersonController>().Start();
			Debug.Log("NEW LOCAL ROT outer: " + currentState.characterController.transform.rotation.eulerAngles);

			Debug.Log("NEW LOCAL ROT: " + currentState.characterController.transform.GetChild(0).rotation.eulerAngles);


			CameraManager.camera = currentState.GetComponentInChildren<Camera>();
			reset = false;
			
		}
		
	}

	void UpdateStateUI() {
		stateUI.text = current.ToString();
	}

	public static State EnumToState(States st) {
		switch(st) {
				case States.Realistic:
					return realistic;
				case States.Abstract:
					return abstracted;
				case States.Iconic:
					return iconic;
			}
		return null;
	}
}
