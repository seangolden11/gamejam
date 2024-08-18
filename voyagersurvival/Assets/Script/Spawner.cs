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
    public int spawnLevel;
    public SpawnData[] spawnData;
    
    
    void Start()
    {
        poolman = GameManger.Instance.pool;
        sate = GameManger.Instance.sate;

        
    }

    private void Update()
    {
        timer += Time.deltaTime;
        spawnLevel = Mathf.FloorToInt(GameManger.Instance.gameTime/ 10f);
        if(spawnLevel >= spawnData.Length)
        {
            spawnLevel = spawnData.Length - 1;
        }
        if(timer > spawnData[spawnLevel].spawnTime)
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
        spawnPoint.z = 0;
        GameObject asteroid = GameManger.Instance.pool.Get(Random.Range(0, 2));
        asteroid.transform.position = spawnPoint;
        asteroid.GetComponent<Asteroid>().spawnPos = spawnPoint;
        asteroid.GetComponent<Asteroid>().OnActive(spawnData[spawnLevel].health, spawnData[spawnLevel].damage);
    }

    [System.Serializable]
    public class SpawnData
    {
        public float spawnTime;
        
        public int health;
        public float speed;
        public float damage;
    }

}
