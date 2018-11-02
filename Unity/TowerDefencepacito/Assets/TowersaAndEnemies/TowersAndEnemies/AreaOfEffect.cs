using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect : Tower {

    public Collider[] enemiesInRange;
    public LayerMask lM;

    public Collider[] GetEnemies(Collider[] targetArray ,float range)
    {
        targetArray = Physics.OverlapSphere(transform.position, range, lM);
        return targetArray;
    }
}