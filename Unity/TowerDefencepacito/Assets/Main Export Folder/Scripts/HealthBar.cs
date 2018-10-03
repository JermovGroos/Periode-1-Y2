using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public RectTransform rect;
    public GameObject p;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.localScale = new Vector3(1, 1, 1);
        p.transform.LookAt(Camera.main.transform);
        //p.transform.rotation = new Quaternion(0, transform.rotation.y, 0, 0);
        //rect.gameObject.transform.position = bar.transform.position;
        //rect.gameObject.transform.localRotation = bar.transform.localRotation;
	}
    
    public void SetBar(float currentHealth)
    {
        rect.right = new Vector3(0, 0, 0);
    }
}
