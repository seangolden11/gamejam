using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Satellite_update : MonoBehaviour
{
    public Vector3 inputVec;
    public float speed;
    Rigidbody rigid;
    ScrollUV scrolluv;
    public float maxHp;
    public float curHp;
    Weapon wp;
    AudioSource audioSoure;
    

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        scrolluv = GameManger.Instance.scrolluv;
        curHp = maxHp;
        wp = GetComponentInChildren<Weapon>();
        inputVec.z = 0;
        audioSoure = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxis("Horizontal");
        inputVec.y = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            wp.Init(GameManger.Instance.weaponDatas[1]);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            wp.Init(GameManger.Instance.weaponDatas[0]);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            wp.Init(GameManger.Instance.weaponDatas[2]);
        }
        
    }

    void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + (inputVec * Time.fixedDeltaTime * speed));
        scrolluv.ChangeOffset(inputVec.x, inputVec.y);

       
    }

    void OnTriggerEnter(Collider collision)
    {

        if (!collision.CompareTag("Enemy"))
        {
            return;
        }
        if (collision.GetComponent<Asteroid>())
            curHp -= collision.GetComponent<Asteroid>().Damage;
        else if (collision.GetComponent<StokeAsteroid>())
            curHp -= collision.GetComponent<StokeAsteroid>().Damage;
        audioSoure.Play();
        collision.gameObject.SetActive(false);
        if (curHp < 0)
        {
            GameManger.Instance.GameOver();
            gameObject.SetActive(false);
        }

    }
}
