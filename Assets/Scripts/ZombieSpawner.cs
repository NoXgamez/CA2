using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : ObjectHealth
{
    public GameObject zombiePrefab;
    public GameObject spawnerPrefab;
    public float spawnTime = 5;
    public int spawnArea = 2;

    public int maxZombiesToSpawn = 10;
    int zombiesSpawned;

    private void Start()
    {
        InvokeRepeating("SpawnZombie", spawnArea, spawnTime);
    }

    void SpawnZombie()
    {
        Vector3 randomPosition = Random.insideUnitCircle * spawnArea;

        Instantiate(zombiePrefab, transform.position + randomPosition, Quaternion.identity);

        zombiesSpawned++;

        if (zombiesSpawned >= maxZombiesToSpawn)
            CancelInvoke("SpawnZombie");
    }

    public override void HandleCollision(GameObject otherObject)
    {
        if (otherObject.CompareTag("Bullet"))
        {
            Bullet bullet = otherObject.GetComponent<Bullet>();
            SubtractHealth(bullet.damage);
        }

        base.HandleCollision(otherObject);
    }

    public GameObject explosion;

    public override void OnDeath()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);

        base.OnDeath();
    }
}