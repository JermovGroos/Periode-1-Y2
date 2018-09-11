using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInfo : MonoBehaviour
{

    RectTransform rect;
    public Vector3 offset = Vector3.zero;
	[HideInInspector]
    public bool visible = true;
    public GameObject[] rend;

    void Start()
    {
        rect = transform.GetComponent<RectTransform>();
    }

    void Update()
    {
        rect.anchoredPosition = Input.mousePosition + offset;
        if(visible == false){
			rect.anchoredPosition = new Vector3(100000,0,0);
		}
    }
}
