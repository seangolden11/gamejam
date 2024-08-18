using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBody : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // z���� 0���� ���� (2D�̹Ƿ�)


        Vector3 direction = mousePosition - transform.position;
        direction.Normalize();



        // �̻����� ���콺�� �ٶ󺸵��� ȸ��
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
