using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : MonoBehaviour {

    public LineRenderer line;

    public int maxJumps;
    public float radius = 5;
    public LayerMask l;
    private List<Collider> updatedHits = new List<Collider>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //List<GameObject> ts = new List<GameObject>();
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, l);

        for (int i = 0; i < hits.Length; i++)
        {
            //updatedHits.;
            //updatedHits[i + 1] = hits[i];
            updatedHits.Add(hits[i]);
        }
        for (int i = 1; i < updatedHits.Capacity; i++)
        {
            if(i >= maxJumps)
            {
                break;
            }
            line.SetPosition(0, transform.position);
            line.positionCount = updatedHits.Capacity;
            line.SetPosition(i, updatedHits[i].gameObject.transform.position);
        }
    }
}
