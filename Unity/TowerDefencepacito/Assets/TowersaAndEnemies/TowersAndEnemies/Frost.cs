using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frost : Tower {

    public float speedMultiplier = 0.4f;

    void Awake(){
        DamageMultiplyStart();
    }

    void Update(){
        DamageMultiplyUpdate();
    }
}
