using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody rigid;
    bool isAlive;
    Vector2 dirvec;
    public float speed;
    Vector2 spawnPos;
    public float lifeTime;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        dirvec = Random.insideUnitCircle.normalized;
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

    private void OnEnable()
    {
        dirvec = Random.insideUnitCircle.normalized;
        spawnPos = transform.position;
    }
}
