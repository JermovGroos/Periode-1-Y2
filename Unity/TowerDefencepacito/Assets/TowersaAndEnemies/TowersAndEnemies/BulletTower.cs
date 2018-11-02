using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTower : Ranged {

    public bool canFire;
    public ParticleSystem bulletParticle;

    void Awake()
    {
        InvokeRepeating("Shoot", 0, firingSpeed);
    }

    void Update ()
    {
        AimAtNearestEnemy(range);
	}

    public void Shoot()
    {
        if (CanShoot())
        {
            RaycastHit hit = new RaycastHit();
            if(Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit, range, lM))
            {
                //print(hit.transform.gameObject.ToString());
                hit.transform.gameObject.GetComponent<Enemy>().DoDamage(damage);
                bulletParticle.Play();
            }
            //Do the enemy damage//
            //print("enemy has taken " + damage + " damage");
        }
        else
        {
            Debug.DrawRay(barrel.transform.position, barrel.transform.forward, Color.red);
            return;
        }
    }
}
