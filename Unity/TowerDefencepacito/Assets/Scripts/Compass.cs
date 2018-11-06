using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{

    Transform cam;
    public Text[] textToSet;
    public WaveSpawner[] noswWaveSpawner;
    Vector3 startPos;



    void Start()
    {
        cam = Camera.main.transform;
        startPos = transform.position;
    }

    void LateUpdate()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, cam.eulerAngles.y + 90);

        for (int i = 0; i < noswWaveSpawner.Length; i++)
        {
            textToSet[i].transform.eulerAngles = Vector3.zero;
            float totalEnemies = noswWaveSpawner[i].boomBoxAmount + noswWaveSpawner[i].diggerAmount + noswWaveSpawner[i].tireAmount;
            if (totalEnemies > 0)
            {
                textToSet[i].text = "!";

                if (noswWaveSpawner[i].waveInProgress == true)
                {
                    transform.position = new Vector3(Screen.width * 2, 0, 0);
                }
                else
                {
                    transform.position = startPos;
                }
            }
            else
            {
                textToSet[i].text = "";

                if (noswWaveSpawner[i].waveInProgress == true)
                {
                    transform.position = new Vector3(Screen.width * 2, 0, 0);
                }
                else
                {
                    transform.position = startPos;
                }
            }
        }
    }
}
