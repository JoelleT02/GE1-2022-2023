using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Collider turretFOV;
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public float rotationSpeed;
    public float fireRate;
    private GameObject tankBullet;
    private bool coroutineStarted;
    private IEnumerator coroutine;

    private void Start()
    {
        turretFOV = GameObject.Find("ColliderCheck").GetComponent<Collider>();
        turretFOV.isTrigger = true;
        spawnPoint = GameObject.Find("SpawnPoint").transform;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (coroutine != null) return;
            coroutine = shootPlayer();
            StartCoroutine(coroutine);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (coroutine == null) return;
        StopCoroutine(coroutine);
        coroutine = null;
    }

    private IEnumerator shootPlayer()
    {
        while (true)
        {
            tankBullet = Instantiate(bulletPrefab);
            tankBullet.transform.rotation = spawnPoint.rotation;
            tankBullet.transform.position = spawnPoint.position;
            yield return new WaitForSeconds(1 / fireRate);
        }
    }
}
