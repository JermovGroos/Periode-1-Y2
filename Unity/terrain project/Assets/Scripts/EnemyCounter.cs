using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{

    public int[] noswEnemies;
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
			if(manager.curWave < manager.allWaves.Count - 1){
            	text[i].text = "" + manager.allWaves[manager.curWave + 1].spawns[i];
			} else {
				text[i].text = "X";
			}
        }
    }

    void GetEnemies()
    {
        
		for (int i = 0; i < text.Length; i++)
		{
			noswEnemies[i] = 0;
		}
		Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
		
		for (int i = 0; i < enemies.Length; i++)
		{
			switch (enemies[i].heading)
			{
				case Enemy.Heading.East:
				noswEnemies[0]++;
				break;
				case Enemy.Heading.North:
				noswEnemies[1]++;
				break;
				case Enemy.Heading.South:
				noswEnemies[2]++;
				break;
				case Enemy.Heading.West:
				noswEnemies[3]++;
				break;
			}
		}
		 
	

     //   for (int i = 0; i < 3; i++)
     //   {
	//		noswEnemies[i] = manager.allWaves[manager.curWave + 1].spawns[i];
      //  }
    }
}
