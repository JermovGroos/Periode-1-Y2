using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingParticle : MonoBehaviour {

	void Awake () {
        Destroy(gameObject, 2);
	}
}
