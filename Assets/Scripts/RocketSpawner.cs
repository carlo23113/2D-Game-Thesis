using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject rockets;
    int randomSpawnPoint;
    public static bool spawnAllowed;

    private void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnRocket", 0f, 1f);
    }

    void SpawnRocket()
    {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(rockets, spawnPoints[randomSpawnPoint].position, rockets.transform.rotation = Quaternion.Euler(0,0,90));
        }
    }
}
