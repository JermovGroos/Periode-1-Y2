using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]

public class UIColorManager : MonoBehaviour
{

    public List<Image> images = new List<Image>();
    List<GameObject> objects = new List<GameObject>();
    public Color curColor = Color.yellow;
	int curCol = 0;
	public Color[] allColors;
	public float changeSpeed = 5;

    void Start()
    {
    }

    void Update()
    {
		GetObjects();
		SetColor();
    }

    void SetColor()
    {
        if (curColor != allColors[curCol])
        {
            curColor = Color.LerpUnclamped(curColor, allColors[curCol], Time.deltaTime * changeSpeed);
        } else if(curCol < allColors.Length - 1){
			curCol++;
		} else {
			curCol = 0;
		}
       
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = curColor;
        }
    }

    void GetObjects()
    {
		if(objects.Count > 0){
			objects.Clear();
		}
		if(images.Count > 0){
		images.Clear();
		}
        objects.AddRange(GameObject.FindGameObjectsWithTag("UIColor"));
        for (int i = 0; i < objects.Count; i++)
        {
            images.Add(objects[i].GetComponent<Image>());
        }
    }
}
