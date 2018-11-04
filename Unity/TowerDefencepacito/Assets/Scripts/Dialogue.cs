using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    Text txt;
    public List<string> dialogue;
    public int curDialogue = 0;
    Manager manager;
    public GameObject[] arrows;

    void Start()
    {
        txt = transform.GetComponent<Text>();
        manager = FindObjectOfType<Manager>();
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
         Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetButtonDown("Fire1") == true)
        {
            if (curDialogue < dialogue.Count - 1)
            {
                curDialogue++;
            }
            else
            {
                //no more text
                transform.parent.gameObject.SetActive(false);
                 Cursor.lockState = CursorLockMode.None;
            }
        }
        for (int i = 0; i < arrows.Length; i++)
        {
            if (i == curDialogue)
            {
                arrows[i].SetActive(true);
            }
            else
            {
                arrows[i].SetActive(false);
            }
        }
        txt.text = dialogue[curDialogue];
    }
}
