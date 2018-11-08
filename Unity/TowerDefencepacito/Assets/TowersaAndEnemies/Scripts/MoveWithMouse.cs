using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{

    Cam cam;
    Vector3 smoothHelp;
    TowerSelection twrWheel;

    void Start()
    {
        cam = GetComponent<Cam>();
        smoothHelp = Vector3.zero;
        twrWheel = FindObjectOfType<TowerSelection>();
    }

    void LateUpdate()
    {
        if (cam != null)
        {
            if (Input.GetAxis("Fire2") < 0.5f)
            {
                if (twrWheel.canDoStuff == false)
                {
                    smoothHelp = Vector3.Lerp(smoothHelp, Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0), Time.deltaTime * 4);
                }
            }
            else if (cam.curCamPos == 0)
            {
                smoothHelp = Vector3.Lerp(smoothHelp, Vector3.zero, Time.deltaTime * 4);
            }
            else if (twrWheel.canDoStuff == false)
            {
                smoothHelp = Vector3.Lerp(smoothHelp, Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0), Time.deltaTime * 4);
            }
            cam.camHelp.position = cam.otherCamPosses[cam.curCamPos].position + transform.TransformDirection(smoothHelp / Screen.width * 10);
        }
    }
}
