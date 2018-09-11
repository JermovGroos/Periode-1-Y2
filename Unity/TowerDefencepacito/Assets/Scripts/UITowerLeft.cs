using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITowerLeft : MonoBehaviour {

//RectTransform rect;
//Vector3 startPos;
[HideInInspector]
public int towersLeft = 4;
Text txt;

	void Start () {
	//	rect = transform.GetComponent<RectTransform>();
	//	startPos = rect.position;
		txt = transform.GetComponent<Text>();
	}
	
	void Update () {
		//rect.position = startPos + new Vector3(0, Mathf.PingPong(Time.time * 10,10),0);
		//towersLeft = 4 - FindObjectsOfType<DefenceTower>().Length;
		txt.text = towersLeft + " Towers left";
	}
}
