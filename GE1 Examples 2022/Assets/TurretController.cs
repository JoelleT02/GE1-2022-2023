using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
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
    private IEnumerator coroutine;
    private bool playerInRange;
    private Transform player;
    private Quaternion rotation;
    private Vector3 position;

    private void Start()
    {
        turretFOV = GameObject.Find("ColliderCheck").GetComponent<Collider>();
        turretFOV.isTrigger = true;
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        player = GameObject.FindWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (coroutine != null) return;
        coroutine = shootPlayer();
        StartCoroutine(coroutine);
        playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (coroutine == null) return;
        StopCoroutine(coroutine);
        coroutine = null;
        playerInRange = false;
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

    private void Update()
    {
        if (!playerInRange) return;
        position = player.position - transform.position;
        rotation = Quaternion.LookRotation(position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
