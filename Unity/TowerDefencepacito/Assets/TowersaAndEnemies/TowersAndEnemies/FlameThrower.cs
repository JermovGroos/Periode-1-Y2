using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : Ranged {

    public ParticleSystem flames;
    public bool canFire;
    private bool isFiring;

    void Awake(){
        DamageMultiplyStart();
    }

    void Update () {
        DamageMultiplyUpdate();
        canFire = CanShoot();
        AimAtNearestEnemy(range);

        if (canFire && !isFiring)
        {
            isFiring = true;
            flames.Play();
        }
        else
        {
            if (!canFire)
            {
                flames.Stop();
                isFiring = false;
            }
        }
    }
}
