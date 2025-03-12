using System.Collections;
using UnityEngine;

public class ObtacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 2f;
    public float spawnX = 10f;
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            spawnRate = Random.Range(1f, 3f);
            yield return new WaitForSeconds(spawnRate);
            float randomSpawnY = 0;

            switch (obstaclePrefab.tag)
            {
                case "bird":
                    randomSpawnY = Random.Range(-2, 5);
                    break;
                case "tree":
                    randomSpawnY = Random.Range(-2f, -5f);
                    break;
                case "cloud":
                    randomSpawnY = Random.Range(1f, 5f);
                    break;
                default:
                    continue;
            }

            Vector3 spawnPositionTree = new Vector3(spawnX, randomSpawnY, 0);

            Instantiate(obstaclePrefab, spawnPositionTree, Quaternion.identity);
        }
    }
}
