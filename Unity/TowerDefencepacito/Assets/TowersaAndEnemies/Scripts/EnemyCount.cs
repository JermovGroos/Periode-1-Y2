using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{

    Cam cam;
    public Text[] txt;
    public string[] name;
    public GameObject[] enemyCountParent;
    WaveManager waveManager;

    void Start()
    {
        cam = FindObjectOfType<Cam>();
        waveManager = FindObjectOfType<WaveManager>();
    }

    void Update()
    {
        if (cam.curCamPos != 0 && waveManager.waveInProgress == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
			transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
			 transform.GetChild(1).gameObject.SetActive(false);
        }

        for (int i = 0; i < enemyCountParent.Length; i++)
        {
            if (cam.curCamPos - 1 == i)
            {
                enemyCountParent[i].SetActive(true);
            }
            else
            {
                enemyCountParent[i].SetActive(false);
            }
        }


        for (int i = 0; i < txt.Length; i++)
        {
            txt[i].text = name[i];
        }
    }
}
