using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

public Vector3 goal;
public float speed = 100;
RectTransform rect;
	void Start () {
		rect = GetComponent<RectTransform>();
		//FindObjectOfType<Music>().ChangeMusic(0);
	}
	
	void Update () {
		rect.anchoredPosition = Vector3.MoveTowards(rect.anchoredPosition,goal,Time.deltaTime * speed);
	}
}
