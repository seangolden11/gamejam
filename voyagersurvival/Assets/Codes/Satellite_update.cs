using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite_update : MonoBehaviour
{
    public Vector2 inputVec;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + inputVec);
    }
}
