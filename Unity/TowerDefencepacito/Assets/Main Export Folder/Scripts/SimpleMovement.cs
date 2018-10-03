using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleMovement : MonoBehaviour {

    public GameObject head;
    public GameObject body;
    public float speed;
    public float sensitivity;
    public Vector3 v;
    public Vector3 v2;
    //public Text money;

    public Text t;
    public float hits;

    public bool lockMouse;
    public float health;

	// Use this for initialization
	void Start () {
        if (lockMouse)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        t = GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if(health <= 0)
        {
            //commit deathpactio//
        }
        v.x = Input.GetAxis("Horizontal");
        v.z = Input.GetAxis("Vertical");

        transform.Translate(v * Time.deltaTime * speed);

        v2.x = -Input.GetAxis("Mouse Y") * 10;
        v2.y = Input.GetAxis("Mouse X") * 10;

        head.transform.Rotate(v2.x * Time.deltaTime * sensitivity,0,0);
        body.transform.Rotate(0, v2.y * Time.deltaTime * sensitivity, 0);

        t.text = "DMG taken:" + hits.ToString().Normalize();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fire")
        {
            print("haha yes");
        }
    }

    public void HealthDown(float damage)
    {
        health -= damage;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Fire")
        {
            hits += 0.1f;
        }
    }
}
