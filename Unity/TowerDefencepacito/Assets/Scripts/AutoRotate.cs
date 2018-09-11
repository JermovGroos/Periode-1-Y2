using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {

public Vector3 rotVector = Vector3.zero;
	
	void Update () {
		transform.eulerAngles += rotVector * Time.deltaTime;
	}
}
