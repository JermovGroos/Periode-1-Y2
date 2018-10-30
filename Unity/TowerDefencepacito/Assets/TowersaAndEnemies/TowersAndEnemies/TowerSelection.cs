using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelection : MonoBehaviour {

    public GameObject rotatingObject;
    public Image pointy;
    public Text costOfTower;
    float target;
    public float timeToRotate;
    bool isRotatingRight;
    bool isRotatingLeft;
    float beginRot;
    float movement;
    float hasRotated;
    public float currencyAmount;
    GameObject buildspot;
    bool canDoStuff;
    public Text currencyShower;
    GameObject location;
    //72

    //now to actual selection of towers//
    public GameObject[] towers;
    int currentTowerSelected = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currencyShower.text = currencyAmount.ToString();
        RayShizzle();
        if (canDoStuff)
        {
            TheRotation();
            if (Input.GetButtonDown("Fire1"))
            {
                //BuySelected(currencyAmount, towers[currentTowerSelected], 
                BuySelected(currencyAmount, towers[currentTowerSelected], location.transform.position);
                gameObject.transform.localScale = new Vector3(0, 0, 0);
                canDoStuff = false;
                Cursor.lockState = CursorLockMode.None;
            }
            if (Input.GetButtonDown("Cancel"))
            {
                gameObject.transform.localScale = new Vector3(0, 0, 0);
                canDoStuff = false;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void BuySelected(float currency, GameObject tower, Vector3 loc)
    {
        if(loc == null)
        {
            return;
        }
        Tower t = tower.GetComponent<Tower>();
        if(currency > t.cost)
        {
            currencyAmount -= t.cost;
            location.GetComponent<TowerSpawnPlace>().isTaken = true;
            Instantiate(towers[currentTowerSelected], location.transform, false);
        }
        else
        {
            print("not enough money");
        }
    }

    public void RayShizzle()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.transform.gameObject.tag == "Platform" && hit.transform.gameObject.GetComponent<TowerSpawnPlace>().isTaken == false)
            {
                buildspot = hit.transform.gameObject;
                if (Input.GetButtonDown("Fire2"))
                {
                    gameObject.transform.position = Input.mousePosition;
                    gameObject.transform.localScale = new Vector3(3, 3, 3);
                    location = buildspot;
                    canDoStuff = true;
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
            else
            {
                buildspot = null;
            }
        }
        else
        {
            buildspot = null;
        }
        //print(buildspot);
    }

    public void TheRotation()
    {
        if (towers[currentTowerSelected].GetComponent<Tower>())
        {
            costOfTower.text = towers[currentTowerSelected].GetComponent<Tower>().cost.ToString();
        }
        if (!isRotatingLeft && !isRotatingRight)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                //rotatingObject.transform.Rotate(0, 0, 72);
                movement = 72;
                isRotatingRight = true;

                if (currentTowerSelected == 4)
                {
                    currentTowerSelected = 0;
                }
                else
                {
                    currentTowerSelected++;
                }
            }
            else
            {
                if (Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    //rotatingObject.transform.Rotate(0, 0, -72);
                    movement = -72;
                    isRotatingLeft = true;

                    if (currentTowerSelected == 0)
                    {
                        currentTowerSelected = 4;
                    }
                    else
                    {
                        currentTowerSelected--;
                    }
                }
            }
        }

        if (isRotatingRight)
        {
            if (hasRotated < 10)
            {
                hasRotated++;
                rotatingObject.transform.Rotate(0, 0, 7.2f);
            }
            else
            {
                if (hasRotated >= 10)
                {
                    isRotatingRight = false;
                    hasRotated = 0;
                }
            }
        }
        if (isRotatingLeft)
        {
            if (hasRotated < 10)
            {
                hasRotated++;
                rotatingObject.transform.Rotate(0, 0, -7.2f);
            }
            else
            {
                if (hasRotated >= 10)
                {
                    isRotatingLeft = false;
                    hasRotated = 0;
                }
            }
        }
        //print(towers[currentTowerSelected]);
    }
}
