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

     //   if(MouseOverField() == true){
//            manager.mouseInfo.visible = true;
   //         wasOver = true;
    //    } else if(wasOver == true) {
   //         manager.mouseInfo.visible = false;
   //         wasOver = false;
     //   }
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
    }
}
