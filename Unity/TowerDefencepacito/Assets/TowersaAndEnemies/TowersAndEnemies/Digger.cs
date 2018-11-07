using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digger : Enemy {

    public float timeTillAscend;
    private bool underground = true;
    public ParticleSystem dustTrail;
    public ParticleSystem surfacingParticle;
    private float maxHealth;
    public Animation surfacingAni;
    public float minTimeTillAscend = 10f;
    public float maxTimeTillAscend = 20f;

	// Use this for initialization
	void Awake () {
        Awaken();
        maxHealth = health;
        timeTillAscend = Random.Range(minTimeTillAscend, maxTimeTillAscend);
        StartCoroutine("TillAscend");
	}
	
	// Update is called once per frame
	void Update () {
        IsDead();

        if (underground)
        {
            health = maxHealth;
        }

        if (!waveManager.GetComponent<WaveSpawner>().mainWaveManager.GetComponent<WaveManager>().enemiesWon)
        {
            if (Vector3.Distance(gameObject.transform.position, targetLocation.transform.position) < 1)
            {
                baseManager.health -= damage * Time.deltaTime;
            }
        }
        else
        {
            if (Vector3.Distance(gameObject.transform.position, targetLocation.transform.position) < 1)
            {
                print("Enemy Entered The Building");
                baseManager.EnemiesWin();
                Die();
            }
        }
    }

    public IEnumerator TillAscend()
    {
        yield return new WaitForSeconds(timeTillAscend);
        dustTrail.Stop();
        surfacingParticle.Play();
        underground = false;
        surfacingAni.Play();
    }
}
