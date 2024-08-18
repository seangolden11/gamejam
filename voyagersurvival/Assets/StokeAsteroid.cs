using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class StokeAsteroid : MonoBehaviour
{
    Rigidbody rigid;
    bool isAlive;
    Vector2 dirvec;
    public float speed;
    public Vector2 spawnPos;
    public float lifeTime;
    GameObject player;
    public float curHp;
    public float maxHp;
    public float Damage;

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
        dirvec = GetRandomDirection();
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

    public void OnActive(float maxhp, float damage)
    {
        if (!player)
            player = GameManger.Instance.player;
        dirvec = GetRandomDirection();
        this.maxHp = maxhp;
        this.Damage = damage;
        curHp = maxHp;

        isAlive = true;
    }



    Vector2 GetRandomDirection()
    {
        // Ÿ�� ��ġ���� ���� ��ġ�� ���� ���� ���͸� ���մϴ�.
        Debug.Log(player.transform.position);
        Debug.Log(transform.position);
        Vector2 direction = (Vector2)player.transform.position - (Vector2)transform.position;

        // ������ ������ ���մϴ�.
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        // ���� ������ �������� ��ȯ�� ��, �� ������ ���� ���� ���͸� ���մϴ�.
        float radian = angle * Mathf.Deg2Rad;

        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public void GiveDamage(float damage)
    {
        curHp -= damage;
        if (curHp < 0)
        {
            GameManger.Instance.GetMineral((int)maxHp);
            isAlive = false;
            this.gameObject.SetActive(false);
        }
    }
}
