using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Satellite_update : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rigid;
    ScrollUV scrolluv;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        scrolluv = GameManger.Instance.scrolluv;
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + (inputVec * Time.fixedDeltaTime * speed));
        scrolluv.ChangeOffset(inputVec.x, inputVec.y);
    }
}
