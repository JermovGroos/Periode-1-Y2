using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

Transform cam;

	void Start () {
		cam = Camera.main.transform;
	}
	
	void Update () {
		transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,cam.eulerAngles.y);
	}
}
