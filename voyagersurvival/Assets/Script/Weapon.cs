using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float timer;
    public float fireSpeed;
    public int curweaponid;
    public WeaponData data;
    public int curlevel;
    AudioSource audioSoure;
    int count;
    public int[] shootangle;
    
    private void Start()
    {
        audioSoure = GetComponent<AudioSource>();
        timer = 0;
        curlevel = 0;
        Init(data);

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

    public void Init(WeaponData data)
    {
        
        this.data = data;
        curweaponid = data.weaponID;
        this.curlevel = GameManger.Instance.weaponLevel[curweaponid];
        fireSpeed = data.fireSpeed[curlevel];
        audioSoure.clip = data.firesound;
        this.count = data.counts[curlevel];
        
    }

    void Fire()
    {
        for (int i = 0; i < count; i++)
        {
            Transform temptrans = GameManger.Instance.pool.GetBullet(curweaponid).transform;
            temptrans.parent = transform;
            temptrans.localPosition = Vector3.zero;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // z축을 0으로 고정 (2D이므로)
            Vector3 direction = mousePosition - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            temptrans.rotation = Quaternion.Euler(new Vector3(0, 0, angle + shootangle[i]));
            temptrans.gameObject.GetComponent<Bullet>().Init(data.damages[curlevel], data.weaponID);
        }
        if (audioSoure.clip)
        {
            audioSoure.Play();
        }

    }
}
