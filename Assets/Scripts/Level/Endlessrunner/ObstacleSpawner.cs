using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    [SerializeField] private float timeBetweenSpawn;
    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
         }
    }
    void Spawn()
    {
        float randomY = Random.Range(minY,minY);

        Instantiate(obstacle, transform.position + new Vector3(0,randomY,0), transform.rotation);
    }
}
