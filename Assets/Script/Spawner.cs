using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public Transform player;
    public float despawnDistance = 15f;

    public void Start()
    {
        Spawn();
        transform.position = transform.position + new Vector3(7, 0, 0);
    }

    public void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position + new Vector3(3, 0, 0), Quaternion.identity);

        DespawnOnDistance despawnScript = spawnedObstacle.AddComponent<DespawnOnDistance>();
        despawnScript.player = player;
        despawnScript.despawnDistance = despawnDistance;
    }
}
