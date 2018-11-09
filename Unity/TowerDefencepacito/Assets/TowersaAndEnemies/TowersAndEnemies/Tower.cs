using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [Tooltip("The Damage output of this Tower")]
    public float damage;
    [Tooltip("The Cost of this Tower")]
    public float cost;
    [Tooltip("The Range of this Tower")]
    public float range;
    //Casper stuff
    float baseDamage;
    public int level = 1;

    public void DamageMultiplyStart(){
        baseDamage = damage;
        level = 2;
    }

    public void DamageMultiplyUpdate() {
        damage = baseDamage * level;
    }

}