using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Tower {

    Collider[] enemiesInRange;
    GameObject closestEnemy;
    [Tooltip("The X axis")]
    public GameObject barrel;
    public LayerMask lM;
    public float firingSpeed;

    public void AimAtNearestEnemy(float range)
    {
        //This will get the closest Enemy//
        enemiesInRange = Physics.OverlapSphere(transform.position, range, lM);

        if(enemiesInRange.Length < 1)
        {
            return;
        }
        
        closestEnemy = enemiesInRange[0].gameObject;
        for (int i = 0; i < enemiesInRange.Length; i++)
        {
            if(enemiesInRange[i].transform.tag == "Enemy")
            {
                if (Vector3.Distance(transform.position, enemiesInRange[i].transform.position) < Vector3.Distance(transform.position, closestEnemy.transform.position))
                {
                    closestEnemy = enemiesInRange[i].gameObject;
                }
            }
        }

        //This well make the turret look at the enemy//
        barrel.transform.LookAt(closestEnemy.transform);
    }

    public bool CanShoot()
    {
        if(Physics.OverlapSphere(transform.position, range, lM).Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
