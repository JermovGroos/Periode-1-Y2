using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawner : MonoBehaviour {

    public GameObject[] towerPrefabs;
    public GameObject healthBarPrefab;
    public Toggle[] towerSelected;
    public GameObject selectedTower;
    public GameObject selectedBuildspot;
    public List<GameObject> buildTowers;
    public GameObject spawnLocation;
    public int currentAmount;

    public Color notSelected;
    public Color selected;
    public bool isSelected;
    public Renderer rend;

    public bool isBuildUpon;

	// Use this for initialization
	void Start () {
        rend = gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < towerSelected.Length; i++)
        {
            if (towerSelected[i].isOn)
            {
                selectedTower = towerPrefabs[i];
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            OnChosen();
        }
        RayShizzle();
        if (isBuildUpon)
        {
            rend.material.color = Color.grey;
        }
        else
        {
            if (isSelected)
            {
                rend.material.color = selected;
            }
            else
            {
                if (!isSelected)
                {
                    rend.material.color = notSelected;
                }
            }
        }
	}

    public void RayShizzle()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.transform.gameObject == gameObject)
            {
                selectedBuildspot = hit.transform.gameObject;
                isSelected = true;
            }
            else
            {
                selectedBuildspot = null;
                isSelected = false;
            }
        }
        else
        {
            selectedBuildspot = null;
            isSelected = false;
        }
    }

    public void OnChosen()
    {
        if(selectedBuildspot == null)
        {
            return;
        }
        else
        {
            if (selectedTower == null)
            {
                return;
            }
        }
        if (isBuildUpon)
        {
            return;
        }
        if(selectedBuildspot == gameObject)
        {
            isBuildUpon = true;
        }
        //check whether the player has enough currency or not//
        GameObject buildTower =  Instantiate(selectedTower, spawnLocation.transform, false);
        buildTower.transform.parent = null;
        buildTower.transform.localScale = new Vector3(1, 1, 1);
        //GameObject healthbar = Instantiate(healthBarPrefab, buildTower.transform, false);
        //buildTower.GetComponent<Tower>().healthIndicator = healthbar;
        buildTower.name = "Tower" + currentAmount.ToString();
        buildTowers.Capacity += 1;
        buildTowers.Add(buildTower);
    }
}
