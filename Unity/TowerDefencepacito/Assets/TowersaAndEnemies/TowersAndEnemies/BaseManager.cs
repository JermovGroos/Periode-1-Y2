using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseManager : MonoBehaviour {

    public float health;
    public GameObject waveManager;
    private bool enemiesHasWon;
    private bool hasWon;
    public WaveSpawner anyWaveSpawner;
    public Slider healthbar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthbar.value = Mathf.Clamp(health, 0, 100);
		if(health <= 0)
        {
            if (!enemiesHasWon)
            {
                enemiesHasWon = true;
                EnemiesWin();
            }
        }
        if (anyWaveSpawner.won && !hasWon)
        {
            hasWon = true;
            YouWin();
        }

	}

    public void EnemiesWin()
    {
        //do losing things
        print("U did losey");
    }
    
    public void YouWin()
    {
        //do winning things
        print("U has won much");
    }
}
