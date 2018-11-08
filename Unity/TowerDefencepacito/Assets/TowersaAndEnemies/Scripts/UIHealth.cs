using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealth : MonoBehaviour {

Transform mainCam;
[HideInInspector]
public float size = 1f;
public Vector3 normalSize;
Transform barPivot;
float barStartScale;
[HideInInspector]
public float maxHealth = 100;
[HideInInspector]
public float curHealth = 100;
	void Start () {
		mainCam = Camera.main.transform;
		normalSize = transform.localScale;
		barPivot = transform.GetChild(0);
		barStartScale = barPivot.localScale.x;
	}
	
	void Update () {
		transform.LookAt(mainCam.position);
		float distance = Vector3.Distance(transform.position,mainCam.position) * (size / 100);
		transform.localScale = new Vector3(distance * normalSize.x,distance * normalSize.y,distance * normalSize.z);
		ScaleBar();
	}

	void ScaleBar(){
		float percent = 100;
		percent = curHealth / maxHealth;
		barPivot.localScale = new Vector3(barStartScale * percent,barPivot.localScale.y,barPivot.localScale.z);
	}

	public void SetHealth(float health,float healthLimit, float barScale){
		curHealth = health;
		maxHealth = healthLimit;
		size = barScale;
	}
}
