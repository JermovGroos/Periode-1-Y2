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
    Cam cam;
    Transition transition;
    public int[] camPosses;
    TowerSelection twrWheel;
    public int towerWheelTime = 10;
    public Transform towerSpawnLocation;
    bool towerPlaced = false;

    void Start()
    {
        txt = transform.GetComponent<Text>();
        manager = FindObjectOfType<Manager>();
        Cursor.lockState = CursorLockMode.None;
        cam = FindObjectOfType<Cam>();
        transition = FindObjectOfType<Transition>();
        twrWheel = FindObjectOfType<TowerSelection>();
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SetCurDia();
        SetArrow();
        SetTowerWheel();
        txt.text = dialogue[curDialogue];
    }

    void SetTowerWheel()
    {
        if (curDialogue == towerWheelTime)
        {
            twrWheel.canDoStuff = true;
        }
        else if (curDialogue == towerWheelTime + 1)
        {
            if (towerPlaced == false)
            {
                twrWheel.location = towerSpawnLocation.gameObject;
                twrWheel.BuySelected(twrWheel.currencyAmount, twrWheel.towers[0], towerSpawnLocation.position);
                //BuySelected(currencyAmount, towers[currentTowerSelected], location.transform.position);
                twrWheel.canDoStuff = false;
                towerPlaced = true;
            }
        }
    }

    void SetCurDia()
    {
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
            SetCamPerp();
        }
    }

    void SetArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (i == curDialogue)
            {
                if (arrows[i] != null)
                {
                    arrows[i].SetActive(true);
                }
            }
            else
            {
                if (arrows[i] != null)
                {
                    arrows[i].SetActive(false);
                }
            }
        }
    }

    void SetCamPerp()
    {
        if (cam.curCamPos != camPosses[curDialogue])
        {
            cam.curCamPos = camPosses[curDialogue];
            transition.rect.anchoredPosition = Vector3.zero;
            FindObjectOfType<Manager>().PlayAudio(4);
        }
    }
}
