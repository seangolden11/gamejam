using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    PoolManager poolman;
    Vector3 spawnPoint;
    float timer;
    public float radius;
    Satellite_update sate;

    void Start()
    {
        poolman = GameManger.Instance.pool;
        sate = GameManger.Instance.sate;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.2f)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        spawnPoint = Random.insideUnitCircle.normalized;
        spawnPoint.y *= radius;
        spawnPoint.x *= radius;
        spawnPoint += sate.transform.position;
        GameObject asteroid = GameManger.Instance.pool.Get(Random.Range(0, 2));
        asteroid.transform.position = spawnPoint;
        asteroid.GetComponent<Asteroid>().spawnPos = spawnPoint;
    }

}
