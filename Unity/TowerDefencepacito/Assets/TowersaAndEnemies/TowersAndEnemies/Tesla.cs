using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesla : AreaOfEffect {

    public LineRenderer lR;
    public Collider[] enemies;
    public float firingSpeed;
    public GameObject outputter;

	// Use this for initialization
	void Awake () {
        //InvokeRepeating("Shoot", 0, firingSpeed);
    }
	
	// Update is called once per frame
	void Update () {
        enemies = GetEnemies(enemies, range);
        Shoot();
	}

    public void Shoot()
    {
        lR.positionCount = enemies.Length + 1;
        lR.SetPosition(0, outputter.transform.position);
        //lR.SetVertexCount(enemies.Length + 1);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().DoDamage(damage*Time.deltaTime);
            lR.SetPosition(i+1, enemies[i].transform.position);
        }
    }
}
