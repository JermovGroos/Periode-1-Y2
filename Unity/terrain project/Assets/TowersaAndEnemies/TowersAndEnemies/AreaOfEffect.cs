using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect : Tower {

    Collider[] enemiesInRange;
    public LayerMask lM;

    public Collider[] GetEnemies(float range)
    {
        enemiesInRange = Physics.OverlapSphere(transform.position, range, lM);
        return enemiesInRange;
    }
}