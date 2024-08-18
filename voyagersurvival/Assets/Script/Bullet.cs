using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    float Damage;
    public float speed = 5f;
    int bulletId;
    public float rotationSpeed = 200f;
    TrailRenderer ps;
    float curtime;
    int per;
    
    
    void Start()
    {
        ps = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody>();
        curtime = 0;
        per = 3;
    }

    // Update is called once per frame
    void Update()
    {
        curtime += Time.deltaTime;
        if (curtime > 30)
        {
            curtime = 0;
            ps.Clear();
            gameObject.SetActive(false);

        }
        switch (bulletId)
        {
            case 0:
                // 마우스의 월드 좌표를 가져옴
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0; // z축을 0으로 고정 (2D이므로)

                // 미사일의 현재 위치와 마우스 위치 사이의 방향을 계산
                Vector3 direction = mousePosition - transform.position;
                direction.Normalize();

                // 미사일의 현재 회전 각도를 가져옴
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                // 현재 각도와 목표 각도 사이의 회전 각도를 계산
                Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

                // 천천히 회전하기 위해 현재 회전에서 목표 회전까지 이동
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // 미사일을 앞으로 이동 (미사일의 앞쪽이 y축이 아니라면 Vector3.up을 Vector3.right로 변경)
                transform.position += transform.right * speed * Time.deltaTime;
                break;
            case 1:
                transform.position += transform.right * speed * Time.deltaTime;
                break;
            case 2:
                transform.position += transform.right * speed * Time.deltaTime;
                break;

        }
    }

    private void OnEnable()
    {
        if (ps == null) { 
            ps = GetComponent<TrailRenderer>();
        }
        ps.emitting = false;
    }

    public void Init(float Damage, int bid)
    {
        this.Damage = Damage;
        this.bulletId = bid;
        ps.emitting = true;
        per = 3;
        
    }

    

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {

            return;
        }

        rb.velocity = Vector3.zero;
        ps.Play();
        gameObject.SetActive(false);
    }*/

    void OnTriggerEnter(Collider collision)
    {
        
        if (!collision.CompareTag("Enemy"))
        {
            return;
        }
        
        
        if (collision.GetComponent<Asteroid>())
            collision.GetComponent<Asteroid>().GiveDamage(Damage);
        else if (collision.GetComponent<StokeAsteroid>())
            collision.GetComponent<StokeAsteroid>().GiveDamage(Damage);

        if(bulletId == 2)
        {
            per--;
            if(per >= 0)
            {
                return;
            }
        }

        rb.velocity = Vector3.zero;
        ps.Clear();

        GameManger.Instance.PlayEffect(bulletId, transform.position);
        gameObject.SetActive(false);

    }

}