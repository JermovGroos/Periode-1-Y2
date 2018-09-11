using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

public class Manager : MonoBehaviour
{
    [Header("WaveStats")]
    public List<WaveStats> allWaves;
    public EnemySpawner[] spawner = new EnemySpawner[4];
    EnemyCounter enemyCounter;
    WaveIndicator waveIndicator;
    public int curWave = 1;
    [HideInInspector]
    public bool inBetweenWaves = false;
    [Header("InBetweenDialogue")]
    public int[] rounds;
    public DialogueStats[] dia;
    [HideInInspector]
    public bool talking = false;
    [HideInInspector]
    public bool justTalked = false;
    public RectTransform normalUIHider;
    public RectTransform diaHider;
    Dialogue diaScript;
    int diaNumber = 0;
    [Header("Other")]
    public PostProcessingBehaviour pp;
    public enum MouseState
    {
        Unused,
        OverUI,
        Used,
        Dialogue
    }
    public MouseState mouseState = MouseState.Unused;
    [HideInInspector]
    public MouseInfo mouseInfo;



    void Start()
    {
        enemyCounter = FindObjectOfType<EnemyCounter>();
        waveIndicator = FindObjectOfType<WaveIndicator>();
        mouseInfo = FindObjectOfType<MouseInfo>();
        waveIndicator.waveNumber = curWave + 1;
        waveIndicator.NewWave();
        diaScript = FindObjectOfType<Dialogue>();
        for (int i = 0; i < FindObjectsOfType<Enemy>().Length; i++)
        {
            spawner[i].spawnAmount = 0;
            spawner[i].spawnTime = allWaves[0].spawnSpeed[i];
            spawner[i].toSpawn = allWaves[0].enemyPrefab[i];
        }
        Enemy[] allEnemies = FindObjectsOfType<Enemy>();
        for (int i = 0; i < allEnemies.Length; i++)
        {
            Destroy(allEnemies[i]);
        }
        normalUIHider.anchoredPosition = new Vector3(0, 2239, 0);
        diaHider.anchoredPosition = new Vector3(380, -177, 0);
    }

    public bool SetMouseState(MouseState newMouseState)
    {
        bool toReturn = false;
        switch (mouseState)
        {
            case MouseState.Unused:
                // mouseState = newMouseState;
                toReturn = true;
                break;
            case MouseState.OverUI:
                switch (newMouseState)
                {
                    case MouseState.Used:
                        // mouseState = newMouseState;
                        toReturn = true;
                        break;
                    case MouseState.Dialogue:
                        //mouseState = newMouseState;
                        toReturn = true;
                        break;
                }
                break;

            case MouseState.Used:
                if (newMouseState == MouseState.Dialogue)
                {
                    //mouseState = newMouseState;
                    toReturn = true;
                }
                break;
        }
        if (toReturn == true)
        {
            mouseState = newMouseState;
        }
        return toReturn;
    }

    void Update()
    {
        if (talking == false)
        {
            if (mouseState == MouseState.Dialogue)
            {
                mouseState = MouseState.Unused;
            }
            if (Input.GetButtonUp("Fire1"))
            {
                if (mouseState == MouseState.Used)
                {
                    mouseState = MouseState.Unused;
                }
            }
            NormalStuff();
        }
        else
        {
            DialogueStuff();
            SetMouseState(MouseState.Dialogue);
        }
    }

    void NormalStuff()
    {

        pp.profile.depthOfField.enabled = false;
        normalUIHider.anchoredPosition = Vector3.MoveTowards(normalUIHider.anchoredPosition, new Vector3(-0, 0, 0), Time.deltaTime * 5000);
        diaHider.anchoredPosition = Vector3.MoveTowards(diaHider.anchoredPosition, new Vector3(380, -845, 0), Time.deltaTime * 5000);
        bool isSpawning = false;
        for (int i = 0; i < spawner.Length; i++)
        {
            if (spawner[i].busy == true)
            {
                isSpawning = true;
            }
        }
        if (isSpawning == false)
        {
            int total = 0;
            for (int i = 0; i < enemyCounter.noswEnemies.Length; i++)
            {
                total += enemyCounter.noswEnemies[i];
            }
            if (total == 0)
            {
                NoEnemiesLeft();
            }
        }

    }

    void DialogueStuff()
    {
        pp.profile.depthOfField.enabled = true;
        normalUIHider.anchoredPosition = Vector3.MoveTowards(normalUIHider.anchoredPosition, new Vector3(0, 2239, 0), Time.deltaTime * 5000);
        diaHider.anchoredPosition = Vector3.MoveTowards(diaHider.anchoredPosition, new Vector3(380, -177, 0), Time.deltaTime * 5000);

    }

    void ActivateText()
    {
        talking = true;
        diaScript.dialogue.Clear();
        diaScript.sprites.Clear();
        diaScript.dialogue.AddRange(dia[diaNumber].dialogue);
        diaScript.sprites.AddRange(dia[diaNumber].sprites);
        diaNumber++;
    }

    void NoEnemiesLeft()
    {

        bool newDia = false;
        for (int i = 0; i < rounds.Length; i++)
        {
            if (curWave == rounds[i])
            {
                newDia = true;
            }
        }
        if (justTalked == true)
        {
            newDia = false;
        }
        if (newDia == false)
        {
            if (curWave + 1 != allWaves.Count)
            {
                inBetweenWaves = true;
            }
            else
            {
                NewWave();
            }
        }
        else
        {
            ActivateText();
        }

    }

    public void NewWave()
    {
        justTalked = false;
        curWave++;
        if (allWaves.Count > curWave)
        {
            waveIndicator.waveNumber = curWave;
            waveIndicator.NewWave();
            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].spawnAmount = allWaves[curWave].spawns[i];
                spawner[i].spawnTime = allWaves[curWave].spawnSpeed[i];
                spawner[i].toSpawn = allWaves[curWave].enemyPrefab[i];
            }
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
