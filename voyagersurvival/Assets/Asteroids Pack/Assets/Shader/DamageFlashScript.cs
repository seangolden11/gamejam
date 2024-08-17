using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlashScript : MonoBehaviour
{
    private Material originalMaterial;
    public Material redMaterial;
    public float redDuration = 0.1f; // 빨간색으로 변할 시간

    private void Start()
    {
        // 물체의 원래 Material을 저장합니다.
        originalMaterial = GetComponent<Renderer>().material;
    }

    public void TakeDamage()
    {
        // 물체를 빨간색으로 변경합니다.
        GetComponent<Renderer>().material = redMaterial;

        // 일정 시간 후에 원래 Material로 복구합니다.
        Invoke("ResetColor", redDuration);
    }

    private void ResetColor()
    {
        GetComponent<Renderer>().material = originalMaterial;
    }
}
