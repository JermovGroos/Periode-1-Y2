using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [Tooltip("The amount of health this enemy has")]
    public float health = 5;
    [Tooltip("The speed of this enemy")]
    public float speed = 2;
    [Tooltip("Amount of damage the enemy does when attacking" + "This is whether it explodes or enters the base")]
    public float damage = 1;
    [Tooltip("The base entrance of this path")]
    public Transform targetLocation;
    [Tooltip("How much money this enemy will give when killed")]
    public float worth = 5;

    //this var is for the currency system
    GameObject currencyHolder;
    bool died = false;
    public GameObject waveManager;
    private bool ignited;
    [Space]
    public float onFireTime = 1.5f;
    public float onFireDmg = 1;
    [Space]
    public BaseManager baseManager;

    NavMeshAgent agent;

    public int kindOfEnemy;

    public void Awaken()
    {
        baseManager = GameObject.FindGameObjectWithTag("Base").GetComponent<BaseManager>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        currencyHolder = GameObject.FindGameObjectWithTag("Currency");
    }

    public void SetTarget(GameObject targetty)
    {
        agent.SetDestination(targetty.transform.position);
        targetLocation = targetty.transform;
    }

    public void IsDead()
    {
        if (health <= 0 && !died)
        {
            //Destroy(gameObject);
            currencyHolder.GetComponent<TowerSelection>().currencyAmount += worth;
            TemporaryDyingAnimation();
            died = true;
        }
        if (ignited)
        {
            DoDamage(onFireDmg * Time.deltaTime);
        }
    }

    public void Die()
    {
        currencyHolder.GetComponent<TowerSelection>().currencyAmount += worth;
        TemporaryDyingAnimation();
        died = true;
    }

    public void DoDamage(float amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, 999);
    }

    public void TemporaryDyingAnimation()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        if(kindOfEnemy == 0) //tire
        {
            waveManager.GetComponent<WaveSpawner>().tires.Remove(gameObject);
        }
        if (kindOfEnemy == 1) // boombox
        {
            waveManager.GetComponent<WaveSpawner>().boxes.Remove(gameObject);
        }
        if (kindOfEnemy == 2) // digger
        {
            waveManager.GetComponent<WaveSpawner>().diggers.Remove(gameObject);
        }
        Destroy(gameObject);
    }

    //flamethrower and area of effect detection
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.GetComponentInParent<FlameThrower>())
        {
            DoDamage(other.gameObject.GetComponentInParent<FlameThrower>().damage*Time.deltaTime);
            ignited = true;
            StartCoroutine("DMGoverTimeDuration");
        }
        if (other.gameObject.GetComponentInParent<Frost>())
        {
            agent.speed = speed * other.gameObject.GetComponentInParent<Frost>().speedMultiplier;
            StartCoroutine("SlowTime");
        }
        if (other.gameObject.GetComponentInParent<Bomb>())
        {
            DoDamage(other.gameObject.GetComponentInParent<Bomb>().damage/10);
        }
    }

    public IEnumerator DMGoverTimeDuration()
    {
        yield return new WaitForSeconds(onFireTime);
        ignited = false;
    }

    public IEnumerator SlowTime()
    {
        yield return new WaitForSeconds(1);
        agent.speed = speed;
    }
}