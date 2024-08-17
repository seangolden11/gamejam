using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlashScript : MonoBehaviour
{
    private Material originalMaterial;
    public Material redMaterial;
    public float redDuration = 0.1f; // ���������� ���� �ð�

    private void Start()
    {
        // ��ü�� ���� Material�� �����մϴ�.
        originalMaterial = GetComponent<Renderer>().material;
    }

    public void TakeDamage()
    {
        // ��ü�� ���������� �����մϴ�.
        GetComponent<Renderer>().material = redMaterial;

        // ���� �ð� �Ŀ� ���� Material�� �����մϴ�.
        Invoke("ResetColor", redDuration);
    }

    private void ResetColor()
    {
        GetComponent<Renderer>().material = originalMaterial;
    }
}
