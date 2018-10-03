using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamToggle : MonoBehaviour {

    public GameObject enemy;
    public GameObject enemyCam;
    public GameObject freeCam;
    public bool isFreeCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isFreeCam = !isFreeCam;
        }

        if (isFreeCam)
        {
            freeCam.SetActive(true);
            enemyCam.SetActive(false);
            enemy.GetComponent<SimpleMovement>().enabled = false;
        }
        else
        {
            freeCam.SetActive(false);
            enemyCam.SetActive(true);
            enemy.GetComponent<SimpleMovement>().enabled = true;
        }
	}
}
