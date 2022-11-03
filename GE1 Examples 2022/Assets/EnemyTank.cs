using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyTank : MonoBehaviour
{
    public Transform turret;
    public Rigidbody turretRB;
    public bool tankShot;
    public float deathTimer;
    public EnemySpawner enemySpawner;

    private void Start()
    {
        turret = transform.GetChild(0);
        turret.gameObject.AddComponent<Rigidbody>();
        turretRB = turret.gameObject.GetComponent<Rigidbody>();
        turretRB.useGravity = true;
        turretRB.isKinematic = true;
        deathTimer = 7f;
        tankShot = false;
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit!");
            turret.transform.parent = null;
            tankShot = true;
            turretRB.useGravity = true;
            turretRB.isKinematic = false;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0, 10), Random.Range(0, 10));
            turret.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(1, 10), Random.Range(1, 10));
            Destroy(other.gameObject);
        }
    }

    private void despawnTank()
    {
        if (deathTimer <= 4 && deathTimer > 0)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().drag = 1f;
            gameObject.GetComponent<Rigidbody>().angularDrag = 1f;
            turret.gameObject.GetComponent<Collider>().enabled = false;
            turret.gameObject.GetComponent<Rigidbody>().drag = 1f;
            turret.gameObject.GetComponent<Rigidbody>().angularDrag = 1f;
            
        }
        
        else if (deathTimer <= 0)
        {
            enemySpawner.enemies.Remove(gameObject);
            Destroy(gameObject);
            Destroy(turret.gameObject);
        }
    }
    
    private void Update()
    {
        if (tankShot)
        {
            deathTimer -= Time.deltaTime;
            despawnTank();
        }
    }
}
