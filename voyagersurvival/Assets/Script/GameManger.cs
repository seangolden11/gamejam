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
    public ParticleSystem[] ps;
    public GameObject effectGroup;
    public int[] weaponLevel;


    private void Awake()
    {
        Instance = this;
        for(int i = 0; i < weaponLevel.Length; i++)
        {
            weaponLevel[i] = 0;
        }
        gameTime = 0;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;


    }


    private void OnApplicationQuit()
    {
        DataManager.Instance.SaveGameData();
    }

    private void Start()
    {
        DataManager.Instance.LoadGameData();
    }

    public void PlayEffect(int id,Vector3 pos)
    {
        ps[id].transform.position = pos;
        Instantiate(ps[id]).Play();
        
    }
}
