using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public Rigidbody projectile;
    public Player player;
    public GameObject headTarget;
    public Vector3 playerPosition;
    public GameObject firePoint;
    public float projectileSpeed;
    float nextFire;
    float fireRate;
    public float StartHealth = 100;
    public float health;

    [Header("Unity Stuff")]
    public Image healthBar;

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / 100f;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    } 
    private void Start()
    {
        fireRate = Random.Range(0f, 10f);
        health = StartHealth;
        if (projectileSpeed == 0)
        {
            projectileSpeed = 3000;
        }

        nextFire = Time.time; 
        if (player == null)
        {
            player = GetComponent<Player>();
        }
        //if (headTarget == null)
        //{
        //    headTarget == player.GetComponent<GameObject>;
        //}
    }
    private void Shoot()
    {
        playerPosition = headTarget.transform.position;
        Rigidbody shot = Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation) as Rigidbody;
        shot.AddForce(shot.transform.forward * projectileSpeed);
        Destroy(shot.gameObject, 5.0f);
    }

    private void Update()
    {
        /*Vector3 lookVector = player.transform.position - transform.position;
        lookVector.y = transform.position.y;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
        */
        Quaternion rot = Quaternion.LookRotation(headTarget.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
        CheckIfTimeToFire();
        fireRate = Random.Range(0f, 10f);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            health -= 10;
            healthBar.fillAmount = health / 100f;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }
    }
}
