using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSelection : MonoBehaviour
{

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
    [HideInInspector]
    public bool canDoStuff;
    public Text currencyShower;
    [HideInInspector]
    public GameObject location;
    //72

    //now to actual selection of towers//
    public GameObject[] towers;
    int currentTowerSelected = 0;

    //By Casper
    Cam cam;
    Manager manager;
    [Header("Casper editions")]
    public Light selectLight;
    public Text descriptionText;
    public string[] descriptions;
    public GameObject spawnParticle;
    public GameObject dieParticle;
    bool canClick = true;
    // Use this for initialization
    void Start()
    {
        cam = FindObjectOfType<Cam>();
        manager = FindObjectOfType<Manager>();
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        currencyShower.text = "$" + currencyAmount;

        if (cam.curCamPos == 0)
        {
            canClick = false;
        }

        if (canDoStuff)
        {
            descriptionText.text = descriptions[currentTowerSelected];
            gameObject.transform.localScale = gameObject.transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * 3, Time.deltaTime * 30);
            TheRotation();
            if (Input.GetButtonUp("Fire1"))
            {
                if (FindObjectOfType<Dialogue>() == null)
                {
                    //BuySelected(currencyAmount, towers[currentTowerSelected], 
                    canClick = false;
                    BuySelected(currencyAmount, towers[currentTowerSelected], location.transform.position);
                    canDoStuff = false;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
            if (Input.GetButtonUp("Fire2"))
            {
                if (FindObjectOfType<Dialogue>() == null)
                {
                    canDoStuff = false;
                    Cursor.lockState = CursorLockMode.None;
                    manager.PlayAudio(2);
                }
            }
        }
        else
        {
            gameObject.transform.localScale = Vector3.zero;
        }
        if (canClick == true)
        {
            RayShizzle();
        }
        else if (Input.GetButtonUp("Fire1") == true)
        {
            canClick = true;
        }
    }

    public void BuySelected(float currency, GameObject tower, Vector3 loc)
    {
        if (loc == null)
        {
            return;
        }
        Tower t = tower.GetComponent<Tower>();
        if (currency >= t.cost)
        {
            currencyAmount -= t.cost;
            location.GetComponent<TowerSpawnPlace>().isTaken = true;
            Instantiate(towers[currentTowerSelected], location.transform, false);
            GameObject toKill = Instantiate(spawnParticle, location.transform.position, Quaternion.identity);
            Destroy(toKill, 1);
            manager.PlayAudio(1);
            manager.PlayAudio(0);
            manager.PlayAudio(13);
        }
        else
        {
            print("not enough money");
            manager.PlayAudio(0);
        }
    }

    //by Casper
    void SetMouseInfo(bool visible)
    {
        if (visible == true)
        {
            manager.mouseVisible = true;
            manager.mouseInfo.text = "Place Tower";
        }
        else
        {
            manager.mouseVisible = false;
        }
    }

    public void RayShizzle()
    {
        bool checkForExeption = false;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.transform.gameObject.tag == "Platform" && cam.curCamPos != 0)
            {
                if (hit.transform.gameObject.GetComponent<TowerSpawnPlace>().isTaken == false)
                {
                    buildspot = hit.transform.gameObject;
                    if (Input.GetButtonUp("Fire1"))
                    {
                        gameObject.transform.position = Input.mousePosition;
                        transform.position = new Vector3(Mathf.Clamp(transform.position.x, Screen.width * 0.1f, Screen.width * 0.75f), Mathf.Clamp(transform.position.y, Screen.height * 0.2f, Screen.height * 0.8f), 0);
                        location = buildspot;
                        canDoStuff = true;
                        Cursor.lockState = CursorLockMode.Locked;
                        manager.PlayAudio(2);
                    }
                }
                else
                {
                    buildspot = hit.transform.gameObject;
                    if (Input.GetButtonUp("Fire1"))
                    {
                        hit.transform.gameObject.GetComponent<TowerSpawnPlace>().isTaken = false;
                        GameObject toKill = Instantiate(dieParticle, buildspot.transform.transform.position, Quaternion.identity);
                        Destroy(buildspot.transform.GetChild(0).gameObject);
                        manager.PlayAudio(1);
                    }
                    buildspot = null;
                    SetMouseInfo(true);
                    manager.mouseInfo.text = "Destroy Tower";
                    checkForExeption = true;
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
        if (canDoStuff == true)
        {
            buildspot = null;
        }
        if (buildspot != null)
        {
            SetMouseInfo(true);
            if (selectLight.transform.position != buildspot.transform.position + new Vector3(0, 10, 0) || selectLight.enabled == false)
            {
                selectLight.transform.position = buildspot.transform.position;
                selectLight.transform.position += new Vector3(0, 10, 0);
                selectLight.enabled = true;
                manager.PlayAudio(10);
            }
        }
        else if (checkForExeption == false)
        {
            SetMouseInfo(false);
            selectLight.enabled = false;
        }
    }

    public void TheRotation()
    {
        if (towers[currentTowerSelected].GetComponent<Tower>())
        {
            costOfTower.text = towers[currentTowerSelected].GetComponent<Tower>().cost.ToString();
        }
        if (!isRotatingLeft && !isRotatingRight)
        {
            if (FindObjectOfType<Dialogue>() == null)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    //rotatingObject.transform.Rotate(0, 0, 72);
                    movement = 72;
                    isRotatingRight = true;
                    manager.PlayAudio(10);

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
                        manager.PlayAudio(10);

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
