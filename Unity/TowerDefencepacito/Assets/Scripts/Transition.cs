using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

public Vector3 goal;
[HideInInspector]
public RectTransform rect;
bool buffer = false;
	void Start () {
		rect = GetComponent<RectTransform>();
	}
	
	void Update () {
		if(rect.anchoredPosition3D != goal){
		rect.anchoredPosition = Vector3.MoveTowards(rect.anchoredPosition,goal,Time.deltaTime * 6000);
		Cursor.lockState = CursorLockMode.Locked;
		buffer = true;
		} else if (buffer == true){
			Cursor.lockState = CursorLockMode.None;
			buffer = false;
		}
	}
}
