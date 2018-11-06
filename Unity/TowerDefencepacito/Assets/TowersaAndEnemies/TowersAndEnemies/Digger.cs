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

	// Use this for initialization
	void Awake () {
        Awaken();
        maxHealth = health;
        timeTillAscend = Random.Range(10.0f, 20.0f);
        StartCoroutine("TillAscend");
	}
	
	// Update is called once per frame
	void Update () {
        IsDead();
        if (underground)
        {
            health = maxHealth;
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
