using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    UITowerLeft ui;
    public GameObject toSpawn;
    bool used = false;
    Manager manager;
    bool wasOver = false;
    void Start()
    {
        ui = FindObjectOfType<UITowerLeft>();
        manager = FindObjectOfType<Manager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (used == false)
            {
                if (MouseOverField() == true)
                {
                    if (ui.towersLeft > 0)
                    {
                        SpawnTower();
                        used = true;
                    }
                }
            }
        }
        if (manager.mouseState == Manager.MouseState.Unused)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.tag == "TowerPlacer")
                {
                    if (hit.transform == transform)
                    {
                        if (used == false)
                        {
                            manager.mouseVisible = true;
                            manager.mouseInfo.text = "Place Tower";
                        }
                    }
                }
            }
        }
    }

    bool MouseOverField()
    {
        bool toReturn = false;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.transform.tag == "TowerPlacer")
            {
                if (hit.transform == transform)
                {
                    // Manager manager = FindObjectOfType<Manager>();
                    if (manager.SetMouseState(Manager.MouseState.Used) == true)
                    {
                        toReturn = true;
                    }
                }
            }
        }
        return toReturn;
    }

    void SpawnTower()
    {
        Instantiate(toSpawn, transform.position, Quaternion.identity);
        ui.towersLeft--;
        manager.PlayAudio(10);
    }
}
