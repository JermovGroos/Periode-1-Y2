using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : Enemy {

    public float explodeDistance = 1;

    public ParticleSystem explosion;
    public float explosionRange;
    public LayerMask lM;
    private bool hasExploded;

    void Awake()
    {
        Awaken();
    }

    void Update () {
        IsDead();
        if (!waveManager.GetComponent<WaveSpawner>().mainWaveManager.GetComponent<WaveManager>().enemiesWon)
        {
            if (Vector3.Distance(gameObject.transform.position, targetLocation.transform.position) < explodeDistance && !hasExploded)
            {
                Explode();
                hasExploded = true;
            }
        }
        else
        {
            if (Vector3.Distance(gameObject.transform.position, targetLocation.transform.position) < explodeDistance)
            {
                print("Enemy Entered The Building");
                baseManager.EnemiesWin();
                Die();
            }
        }
	}

    public void Explode()
    {
        explosion.Play();

        Collider[] inRange = Physics.OverlapSphere(transform.position, explosionRange, lM);
        for (int i = 0; i < inRange.Length; i++)
        {
            GameObject g = inRange[i].gameObject;
            if (g.GetComponent<Enemy>())
            {
                g.GetComponent<Enemy>().Die();
            }
            if (g.GetComponent<BaseManager>())
            {
                g.GetComponent<BaseManager>().health -= damage;
            }
        }

        DoDamage(999);
    }
}
