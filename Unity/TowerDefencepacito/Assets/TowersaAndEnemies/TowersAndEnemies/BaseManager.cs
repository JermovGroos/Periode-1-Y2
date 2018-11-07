using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseManager : MonoBehaviour {

    [Range(0,100)]
    public float health;
    public GameObject waveManager;
    private bool enemiesHasWon;
    private bool hasWon;
    public WaveSpawner anyWaveSpawner;
    public TowerHealth healthbar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthbar.health = health;
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
        SceneManager.LoadScene(2);
    }
    
    public void YouWin()
    {
        //do winning things
        print("U has won much");
        //doe iets pls
    }
}
