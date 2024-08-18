using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followtarget : MonoBehaviour
{
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameManger.Instance.player.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 nextpos = target.position;
        nextpos.z = transform.position.z;
        transform.position = nextpos;
    }
}
