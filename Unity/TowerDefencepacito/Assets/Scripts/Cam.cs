﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{

    Camera cam;
    float orthoSize = 10;
    public float scrollSpeed = 10;
    public float rotateSpeed = 10;
    public Transform camHelp;
    Vector3 rotValue = Vector3.zero;
    public Transform[] otherCamPosses;
    [HideInInspector]
    public int curCamPos = 0;
    Manager manager;

    void Start()
    {
        cam = transform.GetComponent<Camera>();
        manager = FindObjectOfType<Manager>();
    }

    void Update()
    {
        if (manager.talking == false)
        {
            Zoom();
            Rotate();
            SetCamPos();
        }
    }

    void SetCamPos()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            curCamPos++;
        }
        camHelp.position = Vector3.Lerp(camHelp.position, otherCamPosses[curCamPos].position, Time.deltaTime * 10);
    }

    void Zoom()
    {
        orthoSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Vector3.Distance(new Vector3(0, 0, orthoSize), new Vector3(0, 0, 0));
        orthoSize = Mathf.Clamp(orthoSize, 37, 67);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, orthoSize, Time.deltaTime * 20);
    }

    void Rotate()
    {
        //Vector3 rotValue;
        if (Input.GetAxis("Fire2") != 0)
        {
            rotValue += new Vector3(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);
        }
        if (rotValue.y < 0)
        {
            rotValue.y += 360;
        }
        if (rotValue.y > 360)
        {
            rotValue.y -= 360;
        }
        camHelp.rotation = Quaternion.Lerp(camHelp.rotation, Quaternion.Euler(rotValue), Time.deltaTime * 20);
    }
}
