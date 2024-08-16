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

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        dirvec = Random.insideUnitCircle.normalized;
        isAlive = true;
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
        
    }

    private void LateUpdate()
    {
        if (!isAlive)
            return;
           
    }

    private void OnEnable()
    {
        dirvec = Random.insideUnitCircle.normalized;
    }
}
