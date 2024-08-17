using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float timer;
    public float fireSpeed;
    public int curweaponid;
    private void Start()
    {
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireSpeed)
        {
            timer = 0;
            Fire();
        }
    }

    void Fire()
    {
        Transform temptrans=  GameManger.Instance.pool.GetBullet(curweaponid).transform;
        temptrans.parent = transform;
        temptrans.localPosition = Vector3.zero;
        temptrans.localRotation = Quaternion.identity;
    }
}
