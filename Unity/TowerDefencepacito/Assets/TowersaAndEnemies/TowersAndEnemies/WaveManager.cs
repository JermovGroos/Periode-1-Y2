using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    public WaveSpawner waveSpawnerNorth;
    public WaveSpawner waveSpawnerEast;
    public WaveSpawner waveSpawnerSouth;
    public WaveSpawner waveSpawnerWest;
    [Space]
    public int enemiesNorth;
    public int enemiesEast;
    public int enemiesSouth;
    public int enemiesWest;

    [HideInInspector]
    public bool waveInProgress;
    public bool enemiesWon;

	// Use this for initialization
	void Start () {
		
	}

    public void EnemyNumbers()
    {
        if (waveInProgress)
        {
            enemiesNorth = waveSpawnerNorth.tires.Capacity + waveSpawnerNorth.boxes.Capacity + waveSpawnerNorth.diggers.Capacity;
            enemiesEast = waveSpawnerEast.tires.Capacity + waveSpawnerEast.boxes.Capacity + waveSpawnerEast.diggers.Capacity;
            enemiesSouth = waveSpawnerSouth.tires.Capacity + waveSpawnerSouth.boxes.Capacity + waveSpawnerSouth.diggers.Capacity;
            enemiesWest = waveSpawnerWest.tires.Capacity + waveSpawnerWest.boxes.Capacity + waveSpawnerWest.diggers.Capacity;
        }
        else
        {
            enemiesNorth = waveSpawnerNorth.tireAmount + waveSpawnerNorth.boomBoxAmount + waveSpawnerNorth.diggerAmount;
            enemiesEast = waveSpawnerEast.tires.Capacity + waveSpawnerEast.boxes.Capacity + waveSpawnerEast.diggers.Capacity;
            enemiesSouth = waveSpawnerSouth.tires.Capacity + waveSpawnerSouth.boxes.Capacity + waveSpawnerSouth.diggers.Capacity;
            enemiesWest = waveSpawnerWest.tires.Capacity + waveSpawnerWest.boxes.Capacity + waveSpawnerWest.diggers.Capacity;
        }
    }

    public void NextWavey()
    {
        waveInProgress = true;
        waveSpawnerNorth.NextWave();
        waveSpawnerNorth.nextWaveBool = false;
        waveSpawnerEast.NextWave();
        waveSpawnerEast.nextWaveBool = false;
        waveSpawnerSouth.NextWave();
        waveSpawnerSouth.nextWaveBool = false;
        waveSpawnerWest.NextWave();
        waveSpawnerWest.nextWaveBool = false;
    }
}
