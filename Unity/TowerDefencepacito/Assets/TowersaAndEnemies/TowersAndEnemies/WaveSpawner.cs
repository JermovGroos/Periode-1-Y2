using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    [Header("Every spawn location must have the same index as their target counterpart")]
    public GameObject[] spawnLocations;
    public GameObject[] targetLocations;
    [Space]
    public GameObject tireEnemy;
    public int tireAmount;
    public GameObject boomBoxEnemy;
    public int boomBoxAmount;
    public GameObject diggerEnemy;
    public int diggerAmount;
    [Space]
    public float timeBetweenEnemySpawns = 1;
    public List<EnemiesPerWave> ePW = new List<EnemiesPerWave>();
    public int wave;
    public Text waveShower;

    private GameObject[] allEnemies;
    private bool waveInProgress = true;

    public List<GameObject> tires;
    public List<GameObject> boxes;
    public List<GameObject> diggers;
    [Space]
    public Text tiresOfWave;
    public Text boxesOfWave;
    public Text diggersOfWave;
    public GameObject mainWaveManager;
    public bool nextWaveBool;

	void Start ()
    {
        StartCoroutine("SpawnEnemies");
        waveInProgress = true;
	}
	
	void Update ()
    {
        waveShower.text = wave.ToString();
        tires.TrimExcess();
        boxes.TrimExcess();
        diggers.TrimExcess();
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (allEnemies.Length == 0 && waveInProgress)
        {
            waveInProgress = false;
            mainWaveManager.GetComponent<WaveManager>().waveInProgress = false;
            if(wave == ePW.Count-1)
            {
                //youwin
                print("Won");
                nextWaveBool = false;
            }
            else
            {
                nextWaveBool = true;
                tireAmount = ePW[wave + 1].tires;
                boomBoxAmount = ePW[wave + 1].booms;
                diggerAmount = ePW[wave + 1].diggers;
            }
        }
        else
        {
            if(allEnemies.Length > 0)
            {
                nextWaveBool = false;
            }
        }
        if (waveInProgress)
        {
            tiresOfWave.text = tires.Count.ToString();
            boxesOfWave.text = boxes.Count.ToString();
            diggersOfWave.text = diggers.Count.ToString();         
        }
        else
        {
            if (!waveInProgress)
            {
                tiresOfWave.text = (tireAmount * spawnLocations.Length).ToString();
                boxesOfWave.text = (boomBoxAmount * spawnLocations.Length).ToString();
                diggersOfWave.text = (diggerAmount * spawnLocations.Length).ToString();
            }
        }
    }

    public void NextWave() //access this with the ui button//
    {
        waveInProgress = true;
        wave++;
        tireAmount = ePW[wave].tires;
        boomBoxAmount = ePW[wave].booms;
        diggerAmount = ePW[wave].diggers;
        StartCoroutine("SpawnEnemies");
    }

    public IEnumerator SpawnEnemies()
    {
        print("It spawns");
        print(tireAmount);
        for (int i = 0; i < tireAmount; i++)
        {
            for (int ii = 0; ii < spawnLocations.Length; ii++)
            {
                print("Atleast I started");
                GameObject g = Instantiate(tireEnemy, spawnLocations[ii].transform, false);
                g.GetComponent<Enemy>().SetTarget(targetLocations[ii]);
                g.GetComponent<Enemy>().kindOfEnemy = 0;
                g.GetComponent<Enemy>().waveManager = gameObject;
                tires.Capacity++;
                tires.Add(g);
                print("Spawned a Tire");
            }
            yield return new WaitForSeconds(timeBetweenEnemySpawns);
            for (int io = 0; io < boomBoxAmount; io++)
            {
                for (int ii = 0; ii < spawnLocations.Length; ii++)
                {
                    print("Atleast I started");
                    GameObject ge = Instantiate(boomBoxEnemy, spawnLocations[ii].transform, false);
                    ge.GetComponent<Enemy>().SetTarget(targetLocations[ii]);
                    ge.GetComponent<Enemy>().kindOfEnemy = 1;
                    ge.GetComponent<Enemy>().waveManager = gameObject;
                    boxes.Capacity++;
                    boxes.Add(ge);
                    print("Spawned a Box");
                }
                yield return new WaitForSeconds(timeBetweenEnemySpawns);
                for (int ioo = 0; ioo < diggerAmount; ioo++)
                {
                    for (int ii = 0; ii < spawnLocations.Length; ii++)
                    {
                        print("Atleast I started");
                        GameObject go = Instantiate(diggerEnemy, spawnLocations[ii].transform, false);
                        go.GetComponent<Enemy>().SetTarget(targetLocations[ii]);
                        go.GetComponent<Enemy>().kindOfEnemy = 2;
                        go.GetComponent<Enemy>().waveManager = gameObject;
                        diggers.Capacity++;
                        diggers.Add(go);
                        print("Spawned a digger");
                    }
                    yield return new WaitForSeconds(timeBetweenEnemySpawns);
                }
            }
        }
    }
}
[System.Serializable]
public class EnemiesPerWave
{
    [SerializeField]
    public int tires;
    public int booms;
    public int diggers;
}
