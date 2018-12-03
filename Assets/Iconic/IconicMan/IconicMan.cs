using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof (Animator))]
public class IconicMan : Resettable {
	public Transform destination;
	public float stepTimeInterval=.5f;

	private float currentStepTime, startDist;
	private Vector3 startPos;
	NavMeshAgent navmAgent;
	Animator animator;
	
	// Use this for initialization
	public void Start () {
		base.Start();
		Debug.Log("Start Man");
		animator = GetComponent<Animator>();
		navmAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		navmAgent.destination = transform.position;

		animator.SetBool("Move", false);
		startPos = transform.position;
		startDist = Vector3.Distance(startPos, destination.position);

		currentStepTime=0;
	}
	
	// Update is called once per frame
	public override void ResettableUpdate () {
		navmAgent.destination = destination.position;
		float dist = Vector3.Distance(startPos, transform.position);
		
		if (dist/startDist > .99f) {
			animator.SetBool("Move", false);
		} else {
			animator.SetBool("Move", true);
			currentStepTime+=(Time.deltaTime);
			if (currentStepTime>=stepTimeInterval) {
				currentStepTime=0;
			}
		}
	}

	
	public override void ResetObject() {
		transform.position = startPosition;
		transform.rotation = startRotation;
		Start();
	}
}
