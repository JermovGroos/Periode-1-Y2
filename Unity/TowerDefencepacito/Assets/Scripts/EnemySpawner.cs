using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject toSpawn;
    public float spawnTime = 1;
    public Enemy.Heading heading = Enemy.Heading.North;
    public int spawnAmount = 10;
    [HideInInspector]
    public bool busy = true;

    void Start()
    {
        StartCoroutine(SpawnTimer());
        Spawn();
        //	busy = true;
    }

    void Update()
    {
        if (spawnAmount > 0)
        {
            busy = true;
        }
        else
        {
            busy = false;
        }
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(spawnTime);
        Spawn();
        StartCoroutine(SpawnTimer());
    }

    void Spawn()
    {
        if (spawnAmount > 0)
        {
            //busy = true;
            Enemy t = Instantiate(toSpawn, transform.position, Quaternion.identity).GetComponent<Enemy>();
            t.heading = heading;
            spawnAmount--;
        }
        else
        {
            //	busy = false;
        }
    }

    public void NewWave()
    {
        Debug.Log("new wave");
        Spawn();
        StopCoroutine(SpawnTimer());
        StartCoroutine(SpawnTimer());
    }
}
