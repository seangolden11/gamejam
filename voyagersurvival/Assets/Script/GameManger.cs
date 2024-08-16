using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
   public static GameManger Instance;

    public PoolManager pool;
    public Satellite_update sate;
    public GameObject player;
    public ScrollUV scrolluv;
    public float gameTime;
    public GameObject effectPrefab;
    public GameObject effectGroup;


    private void Awake()
    {
        Instance = this;

        gameTime = 0;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;


    }
}
