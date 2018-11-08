using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour {

public float health = 100;
public float maxHealth = 100;
[Range(0,100)]
public float percent = 100;
RectTransform toScale;
float startScale;
	void Start () {
		toScale = GetComponent<RectTransform>();
		startScale = toScale.localScale.x;
	}
	
	void Update () {
		percent = GetPercent();
		toScale.localScale = new Vector3(startScale * (percent / 100),toScale.localScale.y,toScale.localScale.z);
	}

	float GetPercent(){
		return (health / maxHealth) * 100;
	}
}
