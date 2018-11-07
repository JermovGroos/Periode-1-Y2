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
    [HideInInspector]
    public GameObject[] allEnemies;
    public bool waveInProgress;

    public List<GameObject> tires;
    public List<GameObject> boxes;
    public List<GameObject> diggers;
    [Space]
    public Text tiresOfWave;
    public Text boxesOfWave;
    public Text diggersOfWave;
    public GameObject mainWaveManager;
    public bool nextWaveBool;
    [HideInInspector]
    public bool won;

	void Start ()
    {
        StartCoroutine("SpawnEnemies");
        waveInProgress = true;
	}

    public void Winny()
    {
        if (!won)
        {
            won = true;
            GameObject.FindGameObjectWithTag("Base").GetComponent<BaseManager>().YouWin();
        }
    }
	
	void Update ()
    {
        if (won)
        {
            return;
        }

        waveShower.text = "Wave " + wave.ToString();
        tires.TrimExcess();
        boxes.TrimExcess();
        diggers.TrimExcess();
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (allEnemies.Length == 0)
        {
            waveInProgress = false;
            mainWaveManager.GetComponent<WaveManager>().waveInProgress = false;
            if(wave == ePW.Count-1)
            {
                //youwin
                //print("Won");
                Winny();
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
                waveInProgress = true;
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
                tiresOfWave.text = (ePW[wave + 1].tires * spawnLocations.Length).ToString();
                boxesOfWave.text = (ePW[wave + 1].booms * spawnLocations.Length).ToString();
                diggersOfWave.text = (ePW[wave + 1].diggers * spawnLocations.Length).ToString();
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
        for (int times = 0; times < (tireAmount+boomBoxAmount+diggerAmount); times++)
        {
            for (int i = 0; i < tireAmount; i++)
            {
                for (int ii = 0; ii < spawnLocations.Length; ii++)
                {
                    GameObject g = Instantiate(tireEnemy, spawnLocations[ii].transform, false);
                    g.GetComponent<Enemy>().SetTarget(targetLocations[ii]);
                    g.GetComponent<Enemy>().kindOfEnemy = 0;
                    g.GetComponent<Enemy>().waveManager = gameObject;
                    tires.Capacity++;
                    tires.Add(g);
                    yield return new WaitForSeconds(timeBetweenEnemySpawns);
                }
            }

            yield return new WaitForSeconds(timeBetweenEnemySpawns);

            for (int io = 0; io < boomBoxAmount; io++)
            {
                for (int ii = 0; ii < spawnLocations.Length; ii++)
                {
                    GameObject ge = Instantiate(boomBoxEnemy, spawnLocations[ii].transform, false);
                    ge.GetComponent<Enemy>().SetTarget(targetLocations[ii]);
                    ge.GetComponent<Enemy>().kindOfEnemy = 1;
                    ge.GetComponent<Enemy>().waveManager = gameObject;
                    boxes.Capacity++;
                    boxes.Add(ge);
                    yield return new WaitForSeconds(timeBetweenEnemySpawns);
                }
            }

            yield return new WaitForSeconds(timeBetweenEnemySpawns);

            for (int ioo = 0; ioo < diggerAmount; ioo++)
            {
                for (int ii = 0; ii < spawnLocations.Length; ii++)
                {
                    GameObject go = Instantiate(diggerEnemy, spawnLocations[ii].transform, false);
                    go.GetComponent<Enemy>().SetTarget(targetLocations[ii]);
                    go.GetComponent<Enemy>().kindOfEnemy = 2;
                    go.GetComponent<Enemy>().waveManager = gameObject;
                    diggers.Capacity++;
                    diggers.Add(go);
                    yield return new WaitForSeconds(timeBetweenEnemySpawns);
                }
            }

            yield return new WaitForSeconds(timeBetweenEnemySpawns);
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
