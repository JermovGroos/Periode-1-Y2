using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour {

public int health = 7;
public GameObject[] hearts;

	void Start () {
		
	}
	
	void Update () {
		for (int i = 0; i < hearts.Length; i++)
		{
			if(health < i){
				hearts[i].SetActive(false);
			} else {
				hearts[i].SetActive(true);
			}
		}
	}
}
