using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x += Time.deltaTime / 20f;
        offset.y += Time.deltaTime / 20f;

        mat.mainTextureOffset = offset;
    }
}
