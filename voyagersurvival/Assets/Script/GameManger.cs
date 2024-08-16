using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
   public static GameManger Instance;
    public PoolManager pool;

    public GameObject effectPrefab;
    public GameObject effectGroup;

    private void Awake()
    {
        Instance = this;
    }
}
