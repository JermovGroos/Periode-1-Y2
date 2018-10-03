using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCam : MonoBehaviour {

    public GameObject head;
    public GameObject body;
    public float speed;
    public float sensitivity;
    public Vector3 v;
    public Vector3 v2;

    public bool lockMouse;

    // Use this for initialization
    void Start()
    {
        if (lockMouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    // Update is called once per frame
    void Update()
    {
        v.x = Input.GetAxis("Horizontal");
        v.z = Input.GetAxis("Vertical");

        if (Input.GetButton("Jump"))
        {
            v.y = 1;
        }
        else
        {
            if (Input.GetButton("Fire1"))
            {
                v.y = -1;
            }
            else
            {
                if (!Input.GetButton("Fire1") && !Input.GetButton("Jump"))
                {
                    v.y = 0;
                }
            }
        }
        

        transform.Translate(v * Time.deltaTime * speed);

        v2.x = -Input.GetAxis("Mouse Y") * 10;
        v2.y = Input.GetAxis("Mouse X") * 10;

        head.transform.Rotate(v2.x * Time.deltaTime * sensitivity, 0, 0);
        body.transform.Rotate(0, v2.y * Time.deltaTime * sensitivity, 0);
    }
}
