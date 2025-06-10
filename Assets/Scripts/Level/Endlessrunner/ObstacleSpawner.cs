
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacle;
    [SerializeField] private float maxY;
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
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
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        int randomIndex = Random.Range(0, obstacle.Length);
        Instantiate(obstacle[randomIndex], transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
