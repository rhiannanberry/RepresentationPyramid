using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resettable : MonoBehaviour {
	protected Vector3 startPosition;
	protected Quaternion startRotation;

	protected States state;


	// Use this for initialization
	public void Start () {
		startPosition = transform.position;
		startRotation = transform.rotation;
		state = GetComponentInParent<State>().state;
	}
	
	// Update is called once per frame
	public void Update () {
		if(!StateManager.reset && StateManager.current == state) {
			ResettableUpdate();
		}
	}

	public abstract void ResettableUpdate();

	public abstract void ResetObject();
}
