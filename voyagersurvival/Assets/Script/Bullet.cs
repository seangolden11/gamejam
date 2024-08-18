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
                // ���콺�� ���� ��ǥ�� ������
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0; // z���� 0���� ���� (2D�̹Ƿ�)

                // �̻����� ���� ��ġ�� ���콺 ��ġ ������ ������ ���
                Vector3 direction = mousePosition - transform.position;
                direction.Normalize();

                // �̻����� ���� ȸ�� ������ ������
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                // ���� ������ ��ǥ ���� ������ ȸ�� ������ ���
                Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

                // õõ�� ȸ���ϱ� ���� ���� ȸ������ ��ǥ ȸ������ �̵�
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // �̻����� ������ �̵� (�̻����� ������ y���� �ƴ϶�� Vector3.up�� Vector3.right�� ����)
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