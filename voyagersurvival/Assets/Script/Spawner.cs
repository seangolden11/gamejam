using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    PoolManager poolman;

    float timer;


    void Start()
    {
        poolman = GameManger.Instance.pool;
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
        GameObject asteroid = GameManger.Instance.pool.Get(Random.Range(0, 2));
        asteroid.transform.position = Vector3.zero;
    }

}
