using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceTower : MonoBehaviour {

public float waitTime = 1;
public float range = 10;

	void Start () {
		StartCoroutine(Wait());
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(waitTime);
		Destroy(EnemyClose());
		StartCoroutine(Wait());
	}

	GameObject EnemyClose(){
		GameObject toReturn = null;
		Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
		for (int i = 0; i < enemies.Length; i++)
		{
			if(Vector3.Distance(transform.position, enemies[i].transform.position) < range){
				toReturn = enemies[i].gameObject;
			}
		}
		if(toReturn != null){
			FindObjectOfType<Manager>().PlayAudio(2);
		}
		return toReturn;
	}

}
