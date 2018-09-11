using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPosSetter : MonoBehaviour {

Camera mainCam;
Cam cam;
Collider col;
[Range(0,4)]
public int camPos = 1;
Manager manager;
	void Start () {
		mainCam = Camera.main;
		cam = mainCam.GetComponent<Cam>();
		col = transform.GetComponent<Collider>();
		manager = FindObjectOfType<Manager>();
	}
	
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			if(IsMouseOver() == true){
				if(manager.SetMouseState(Manager.MouseState.Used) == true){
					cam.curCamPos = camPos;
				}
			}
		}

		if(cam.curCamPos == camPos){
			col.enabled = false;
		} else {
			col.enabled = true;
		}
	}

	bool IsMouseOver(){
		bool toReturn = false;
		RaycastHit hit;
		if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition),out hit)){
			if(hit.transform == transform){
				toReturn = true;
			}			
		}
		return toReturn;
	}
}
