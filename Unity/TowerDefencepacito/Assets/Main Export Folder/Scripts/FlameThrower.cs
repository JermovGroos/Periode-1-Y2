using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlameThrower : MonoBehaviour {

    public ParticleSystem p;
    public GameObject player;
    public float damage;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        damage = gameObject.GetComponentInParent<Tower>().damage;
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnParticleCollision(GameObject col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject ta = col.gameObject;
            if (ta.GetComponent<SimpleMovement>()) //dit moet later natuurlijk vragen naar het health script van de het//
            {
                SimpleMovement sM = ta.GetComponent<SimpleMovement>();
                sM.HealthDown(damage);
            }
        }
    }
}
