using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    Text txt;
    public List<string> dialogue;
    public List<Sprite> sprites;
    public Image[] talkerSprites;
    int curDialogue = 0;
    Manager manager;

    void Start()
    {
        txt = transform.GetComponent<Text>();
        manager = FindObjectOfType<Manager>();
    }

    void Update()
    {
        if (manager.talking == true)
        {
            if (Input.GetButtonDown("Fire1") == true)
            {
                if (curDialogue < dialogue.Count - 1)
                {
                    curDialogue++;
                }
                else
                {
                    curDialogue = 0;
                    manager.talking = false;
                    //manager.inBetweenWaves = true;
                    manager.justTalked = true;
                    //manager.NewWave();
                    //manager.inBetweenWaves = true;
                }
            }
        }

        txt.text = dialogue[curDialogue];
        for (int i = 0; i < talkerSprites.Length; i++)
        {
            talkerSprites[i].sprite = sprites[curDialogue];
        }
    }
}
