using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Asteroid : MonoBehaviour
{
    Rigidbody rigid;
    bool isAlive;
    Vector2 dirvec;
    public float speed;
    public Vector2 spawnPos;
    public float lifeTime;
    GameObject player;

    void Start()
    {
        player = GameManger.Instance.player;
        rigid = GetComponent<Rigidbody>();
        dirvec = GetRandomDirection();
        isAlive = true;
        spawnPos = transform.position;
        
    }

    private void FixedUpdate()
    {
        if (!isAlive)
        {
            return;
        }
        
        Vector3 nextvec = dirvec * speed * Time.fixedDeltaTime;
        nextvec.z = 0;

        rigid.MovePosition(rigid.position + nextvec);

        if (Vector2.Distance(transform.position, spawnPos) > lifeTime)
        {
            isAlive = false;
            this.gameObject.SetActive(false);
        }
        
    }

    private void LateUpdate()
    {
        if (!isAlive)
            return;
           
    }

    public void OnActive()
    {
        if (!player)
            player = GameManger.Instance.player;
        dirvec = GetRandomDirection();
        
        isAlive = true;
    }

    Vector2 GetRandomDirection()
    {
        // Ÿ�� ��ġ���� ���� ��ġ�� ���� ���� ���͸� ���մϴ�.
        
        Vector2 direction = (Vector2)player.transform.position - (Vector2)transform.position;

        // ������ ������ ���մϴ�.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 45 ~ -45�� ������ ������ ������ �����մϴ�.
        float randomAngle = Random.Range(-45, 45);

        // ���� ������ ���� ������ ���մϴ�.
        angle += randomAngle;

        // ���� ������ �������� ��ȯ�� ��, �� ������ ���� ���� ���͸� ���մϴ�.
        float radian = angle * Mathf.Deg2Rad;

        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
}
