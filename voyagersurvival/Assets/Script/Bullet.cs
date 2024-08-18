using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    float Damage;
    public float speed = 5f;
    int bulletId;
    public float rotationSpeed = 200f;
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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

        }
    }

    public void Init(float Damage, int bid)
    {
        this.Damage = Damage;
        this.bulletId = bid;
        
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

        rb.velocity = Vector3.zero;

        collision.GetComponent<Asteroid>().GiveDamage(Damage);

        GameManger.Instance.PlayEffect(bulletId, transform.position);
        gameObject.SetActive(false);

    }

}