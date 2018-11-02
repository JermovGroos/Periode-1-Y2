using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveIndicator : MonoBehaviour
{

    RectTransform rect;
    bool active = false;
    public Text txt;
    public int waveNumber = 1;
    public GameObject[] rend;
    void Start()
    {
        rect = transform.GetComponent<RectTransform>();
    }

    void Update()
    {
        //  if (Input.GetKeyDown(KeyCode.Space) == true)
        //   {
        //     if (active == false)
        //     {
        //        active = true;
        //         waveNumber++;
        //         txt.text = "Wave " + waveNumber;
        //    }
        //  }
        if (active == true)
        {
            Activate();
        }
        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].SetActive(active);
        }
    }

    public void NewWave()
    {
        if (active == false)
        {
            active = true;
            //waveNumber++;
            txt.text = "Wave " + waveNumber;
        }
    }

    void Activate()
    {
        //switch case doesnt work in this 'case'.

        if (rect.anchoredPosition.y < -100)
        {
            rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, new Vector2(0, -100), Time.deltaTime * 5000);
        }
        else if (rect.anchoredPosition.y < 100)
        {
            rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, new Vector2(0, 100), Time.deltaTime * 300);
        }
        else if (rect.anchoredPosition.y < 3000)
        {
            rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, new Vector2(0, 3000), Time.deltaTime * 5000);
        }
        else
        {
            rect.anchoredPosition = new Vector2(0, -974);
            active = false;
        }

    }
}
