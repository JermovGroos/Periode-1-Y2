using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPosSetter : MonoBehaviour
{

    Camera mainCam;
    Cam cam;
    Collider col;
    [Range(0, 4)]
    public int camPos = 1;
    Manager manager;
    Transition transition;
    void Start()
    {
        mainCam = Camera.main;
        cam = mainCam.GetComponent<Cam>();
        col = transform.GetComponent<Collider>();
        manager = FindObjectOfType<Manager>();
        transition = FindObjectOfType<Transition>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (cam.curCamPos == 0)
            {
                if (IsMouseOver() == true)
                {
                    if (transition.rect.anchoredPosition3D == transition.goal)
                    {
                        if (manager.SetMouseState(Manager.MouseState.Used) == true)
                        {
                            cam.curCamPos = camPos;
                            transition.rect.anchoredPosition = Vector3.zero;
                        }
                    }
                }
            }
        }
        /*
                if (manager.mouseState == Manager.MouseState.Unused)
                {
                    if (IsMouseOver() == true)
                    {
                        manager.mouseVisible = true;
                        manager.mouseInfo.text = "Move Camera";
                    }
                }
        */
        if (cam.curCamPos == camPos)
        {
            col.enabled = false;
        }
        else
        {
            col.enabled = true;
        }
    }

    bool IsMouseOver()
    {
        bool toReturn = false;
        RaycastHit hit;
        if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.transform == transform)
            {
                toReturn = true;
            }
        }
        return toReturn;
    }
}
