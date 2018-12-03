using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
	public static Camera camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (camera != null) {
			Debug.DrawRay(camera.transform.position, 5*camera.transform.forward, Color.black);
		}
	}
}
