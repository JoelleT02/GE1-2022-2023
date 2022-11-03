using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject enemy;
    private int spawnPointX;
    private int spawnPointY;
    private int spawnPointZ;
    private Vector3 spawnPosition;
    public float timer;
    public float cooldown;
    

    private void Awake()
    {
        enemies = new List<GameObject>();
        timer = 1f;
        cooldown = 1f;
    }

    private void Update()
    {
        if (enemies.Count < 5 && timer <= 0)
        {
            StartCoroutine(Spawn());
            timer = cooldown;
        }

        timer -= Time.deltaTime;
    }

    private IEnumerator Spawn()
    {
        Enemy();
        yield return new WaitForSeconds(1f);
    }

    private void Enemy()
    {
        spawnPointX = Random.Range(-25, 25);
        spawnPointY = 5;
        spawnPointZ = Random.Range(-25, 25);
        spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

        enemies.Add(Instantiate(enemy, spawnPosition, Quaternion.identity));
    }
}
