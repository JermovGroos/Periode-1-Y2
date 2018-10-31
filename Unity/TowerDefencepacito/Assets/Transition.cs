using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

public Vector3 goal;
[HideInInspector]
public RectTransform rect;
	void Start () {
		rect = GetComponent<RectTransform>();
	}
	
	void Update () {
		rect.anchoredPosition = Vector3.MoveTowards(rect.anchoredPosition,goal,Time.deltaTime * 10000);
	}
}
