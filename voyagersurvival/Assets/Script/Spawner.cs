using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    PoolManager poolman;

    void Start()
    {
        poolman = GameManger.Instance.pool;
    }


}
