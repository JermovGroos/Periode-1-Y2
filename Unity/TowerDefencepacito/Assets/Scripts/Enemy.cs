using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(CharacterController))]

public class Enemy : MonoBehaviour
{

    Transform goal;
    public float speed = 10;
    Transform child;
    Transform cam;
    public float health = 1;
//    SpriteRenderer rend;
    CharacterController cc;
    public enum EnemyType
    {
        Boombox = 0,
        Tire = 1,
        Digger = 2
    }
    [HideInInspector]
    public EnemyType type = EnemyType.Boombox;

    void Start()
    {
        cam = Camera.main.transform;
        child = transform.GetChild(0);
  //      rend = child.GetComponent<SpriteRenderer>();
        cc = transform.GetComponent<CharacterController>();
        goal = GameObject.FindGameObjectWithTag("Tower").transform;
    }

    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        transform.LookAt(goal.position);
        //transform.position += transform.forward * Time.deltaTime * speed;
        cc.Move(transform.forward * Time.deltaTime * speed);
        child.LookAt(cam.position);
        // rend.flipX = !rend.flipX;
    }

    public void DoDamage(float damage)
    {
        health -= damage;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tower")
        {
            TowerHealth tower = FindObjectOfType<TowerHealth>();
            if (tower.health <= 0)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                tower.health--;
            }
            Destroy(gameObject);
        }
    }
}
