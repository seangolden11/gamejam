using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    PoolManager poolman;
    Vector3 spawnPoint;
    float timer;
    float stoketimer;
    float moonTimer;
    public float radius;
    Satellite_update sate;
    public int spawnLevel;
    public SpawnData[] spawnData;
    public bool isPlanet;
    
    
    void Start()
    {
        poolman = GameManger.Instance.pool;
        sate = GameManger.Instance.sate;

        
    }

    private void Update()
    {
        timer += Time.deltaTime;
        stoketimer += Time.deltaTime;
        moonTimer += Time.deltaTime;

        spawnLevel = Mathf.FloorToInt(GameManger.Instance.gameTime/ 30f);
        if(spawnLevel >= spawnData.Length)
        {
            spawnLevel = spawnData.Length - 1;
        }
        if(timer > spawnData[spawnLevel].spawnTime)
        {
            timer = 0;
            Spawn(0,2);

        }
        if (stoketimer > spawnData[spawnLevel].spawnStokeTime)
        {
            stoketimer = 0;
            Spawn(3, 5);

        }
        if (moonTimer > spawnData[spawnLevel].spawnMoontime && !isPlanet)
        {
            moonTimer = 0;
            Spawn(6, 6);

        }

    }

    void Spawn(int start, int finish)
    {
        spawnPoint = Random.insideUnitCircle.normalized;
        if (start == 6)
        {
            spawnPoint.y *= radius + 4;
            spawnPoint.x *= radius + 4;
        }
        else
        {
            spawnPoint.y *= radius;
            spawnPoint.x *= radius;
        }
        if (isPlanet)
        {
            spawnPoint += transform.position;
            spawnPoint.z = 0;
            GameObject asteroid = GameManger.Instance.pool.Get(Random.Range(start, finish));
            asteroid.transform.position = spawnPoint;
            if (start == 0)
            {
                asteroid.GetComponent<Asteroid>().spawnPos = spawnPoint;
                asteroid.GetComponent<Asteroid>().OnActive(spawnData[spawnLevel].health, spawnData[spawnLevel].damage);
            }
            else if (start == 3)
            {
                asteroid.GetComponent<StokeAsteroid>().spawnPos = spawnPoint;
                asteroid.GetComponent<StokeAsteroid>().OnActive(spawnData[spawnLevel].health, spawnData[spawnLevel].damage);
            }
        }
        else
        {
            spawnPoint += sate.transform.position;
            spawnPoint.z = 0;
            GameObject asteroid = GameManger.Instance.pool.Get(Random.Range(start, finish));
            asteroid.transform.position = spawnPoint;
            if (start == 0)
            {
                asteroid.GetComponent<Asteroid>().spawnPos = spawnPoint;
                asteroid.GetComponent<Asteroid>().OnActive(spawnData[spawnLevel].health, spawnData[spawnLevel].damage);
            }
            else if (start == 3)
            {
                asteroid.GetComponent<StokeAsteroid>().spawnPos = spawnPoint;
                asteroid.GetComponent<StokeAsteroid>().OnActive(spawnData[spawnLevel].health, spawnData[spawnLevel].damage);
            }
            else if (start == 6)
            {
                asteroid.GetComponent<Asteroid>().spawnPos = spawnPoint;
                asteroid.GetComponent<Asteroid>().OnActive(spawnData[spawnLevel].health * 5, spawnData[spawnLevel].damage * 5);
            }
        }
    }

    [System.Serializable]
    public class SpawnData
    {
        public float spawnTime;
        public float spawnStokeTime;
        public float spawnMoontime;
        
        public int health;
        public float speed;
        public float damage;
    }

}
