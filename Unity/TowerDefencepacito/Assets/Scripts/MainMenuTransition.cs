using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTransition : MonoBehaviour {

	void Start () {
		transform.eulerAngles = new Vector3(0,0,71.12601f);
	}
	
	void Update () {
		transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0,0,0),Time.deltaTime * 2);
		if(Input.GetButtonDown("Fire1") == true){
			//transform.eulerAngles = new Vector3(0,0,71.12601f);
		}
	}
}
