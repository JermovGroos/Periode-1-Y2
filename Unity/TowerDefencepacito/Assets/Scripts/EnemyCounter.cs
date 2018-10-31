using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{

    public int[] typeCounter;
    public TextMesh[] text;
    Manager manager;
    void Start()
    {
        manager = FindObjectOfType<Manager>();
    }

    void Update()
    {
        GetEnemies();
        for (int i = 0; i < text.Length; i++)
        {
            if (manager.curWave < manager.allWaves.Count - 1)
            {
                text[i].text = "" + typeCounter[i];
            }
            else
            {
                text[i].text = "X";
            }
        }
    }

    void GetEnemies()
    {

        for (int i = 0; i < text.Length; i++)
        {
            typeCounter[i] = 0;
        }
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        for (int i = 0; i < enemies.Length; i++)
        {
            switch (enemies[i].type)
            {
                case Enemy.EnemyType.Boombox:
                    typeCounter[0]++;
                    break;
                case Enemy.EnemyType.Digger:
                    typeCounter[1]++;
                    break;
                case Enemy.EnemyType.Tire:
                    typeCounter[2]++;
                    break;
            }
        }



        //   for (int i = 0; i < 3; i++)
        //   {
        //		noswEnemies[i] = manager.allWaves[manager.curWave + 1].spawns[i];
        //  }
    }
}
