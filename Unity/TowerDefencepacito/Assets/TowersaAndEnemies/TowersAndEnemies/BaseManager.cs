using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseManager : MonoBehaviour
{

    [Range(0, 100)]
    public float health;
    public GameObject waveManager;
    private bool enemiesHasWon;
    private bool hasWon;
    public WaveSpawner anyWaveSpawner;
    public TowerHealth healthbar;
    public int nextLevel = 1;

    [Header("WinTransition")]
    public int newMusic = 0;
    public Image winImage;
    bool activateWinEveryFrame = false;

    // Use this for initialization
    void Start()
    {
        winImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.health = health;
        if (health <= 0)
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


        if (Input.GetKeyDown(KeyCode.M))
        {
            if (Application.isEditor == true)
            {
                YouWin();
            }
        }
        if (activateWinEveryFrame == true)
        {
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
        if (activateWinEveryFrame == false)
        {
            StartCoroutine(LoadNextLevel());
            activateWinEveryFrame = true;
            FindObjectOfType<Manager>().PlayAudio(15);
        }
        else if (winImage.color != Color.black)
        {
            winImage.color = Color.Lerp(winImage.color, Color.white, Time.unscaledDeltaTime * 2);
        }
    }

    IEnumerator LoadNextLevel()
    {
        winImage.gameObject.SetActive(true);
        winImage.color = new Color(1, 1, 1, 0);
        FindObjectOfType<Music>().ChangeMusic(newMusic);
        FindObjectOfType<Music>().GetComponent<AudioSource>().Pause();
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1.8f);
        winImage.color = Color.black;
        winImage.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        winImage.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3.5f);
        Time.timeScale = 1;
        FindObjectOfType<Music>().GetComponent<AudioSource>().UnPause();
        SceneManager.LoadScene(nextLevel);
    }
}
