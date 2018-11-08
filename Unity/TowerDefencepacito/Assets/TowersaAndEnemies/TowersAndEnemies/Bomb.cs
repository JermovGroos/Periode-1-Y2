using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Ranged {

    public bool canFire;
    public ParticleSystem bombParticle;

    void Awake()
    {
        InvokeRepeating("Shoot", 0, firingSpeed);
        DamageMultiplyStart();
    }

    void Update ()
    {
        DamageMultiplyUpdate();
        AimAtNearestEnemy(range);
    }

    public void Shoot()
    {
        if (CanShoot())
        {
            bombParticle.Play();
        }
    }
}
