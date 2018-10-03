using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour {

    public GameObject player;
    public Vector3 watcher;
    public float range;
    public float damage;
    public ParticleSystem pSys;
    public bool canSchiet;
    public GameObject body;

    public float health;
    public GameObject healthIndicator;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        watcher = body.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //healthIndicator.GetComponent<HealthBar>().SetBar(health);
        if (health <= 0)
        {
            //go commit deathpacito//
        }
        LookAtPlayer();
        CheckCanShoot(canSchiet);
        if (canSchiet)
        {
            pSys.Play();
        }
        else
        {
            pSys.Stop();
        }
	}

    public void LookAtPlayer()
    {
        if(Vector3.Distance(watcher ,player.transform.position) <= range)
        {
            body.transform.LookAt(player.transform.position);
        }
    }

    public void CheckCanShoot(bool canShoot)
    {
        if (Vector3.Distance(watcher, player.transform.position) <= range)
        {
            canSchiet = true;
        }
        else
        {
            canSchiet = false;
        }
    }

    public void OnParticleCollision(GameObject hitObject)
    {
        if(hitObject.gameObject.tag == "Player")
        {
            //subtract player health with damage
        }
    }
}
