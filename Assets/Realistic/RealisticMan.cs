using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof (AudioSource))]
public class RealisticMan : Resettable {
	
	UnityEngine.AI.NavMeshAgent navmAgent;
	AudioSource audioSource;

	Animator animator;
	public Transform destination;
	Vector3 startPos;

	float startDist;

	

	

	public AudioClip[] footstepSounds;
	public float stepTimeInterval=.5f;
	private float currentStepTime;


	// Use this for initialization
	void Start () {
		base.Start();
		Debug.Log("Start Man");
		audioSource = GetComponent<AudioSource>();
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
			//transform.rotation = Quaternion.LookRotation((path.GetPosition((int)currFrame+1)-path.GetPosition((int)currFrame)));
			float walkModifier = navmAgent.velocity.magnitude*.3f;
			animator.SetFloat("WalkSpeed", walkModifier);
			//animator.Play("Walk", 0,(dist/startDist));
			currentStepTime+=(Time.deltaTime*walkModifier);
			if (currentStepTime>=stepTimeInterval) {
				PlayFootStepAudio();
				currentStepTime=0;
			}
		}
	}

	public override void ResetObject() {
		transform.position = startPosition;
		transform.rotation = startRotation;
		Start();
	}

	void PlayFootStepAudio() {
		int n = Random.Range(1, footstepSounds.Length);
		audioSource.clip = footstepSounds[n];
		audioSource.PlayOneShot(audioSource.clip);
		// move picked sound to index 0 so it's not picked next time
		footstepSounds[n] = footstepSounds[0];
		footstepSounds[0] = audioSource.clip;
	}

}
