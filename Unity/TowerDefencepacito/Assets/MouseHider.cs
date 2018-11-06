using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHider : MonoBehaviour {
	public UIMouseButtonText texts;
	public RectTransform parentMouse;
	public bool visible;
	Vector3 startPos;
	void Start () {
		startPos = parentMouse.anchoredPosition;
	}
	
	void Update () {
		
	}

	void SetVisible(){
		if(visible == true){
			parentMouse.anchoredPosition = startPos;
		} else {
			parentMouse.anchoredPosition = startPos - new Vector3(0,-100,0);
		}
	}
}
