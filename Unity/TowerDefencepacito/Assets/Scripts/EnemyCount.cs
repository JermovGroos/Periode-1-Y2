using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour {

Cam cam;
public Text[] txt;
public string[] name;

	void Start () {
		cam = FindObjectOfType<Cam>();
	}
	
	void Update () {
		if(cam.curCamPos != 0){
			transform.GetChild(0).gameObject.SetActive(true);
		} else {
			transform.GetChild(0).gameObject.SetActive(false);
		}


		for (int i = 0; i < txt.Length; i++)
		{
			txt[i].text = name[i] + "	" + i;
		}
	}
}
