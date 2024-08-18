using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject[] bulletPrefabs;

    List<GameObject>[] pools;
    List<GameObject>[] bulletPools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int i=0;i< pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }

        bulletPools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < bulletPools.Length; i++)
        {
            bulletPools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach(GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            
            pools[index].Add(select);
        }

        return select;
    }

    public GameObject GetBullet(int index)
    {
        GameObject select = null;

        foreach (GameObject item in bulletPools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(bulletPrefabs[index], transform);

            bulletPools[index].Add(select);
        }

        return select;
    }
}
