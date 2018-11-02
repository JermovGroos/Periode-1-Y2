using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digger : Enemy {

    public float timeTillAscend = 3;
    private bool underground = true;
    public ParticleSystem dustTrail;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
        IsDead();
    }

    public IEnumerator tillAscend()
    {
        yield return new WaitForSeconds(timeTillAscend);
        underground = false;
    }
}
