using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    MeshRenderer mr;
    public Texture[] Texture;
    int curPlace;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        curPlace = 0;
    }

    // Update is called once per frame
    public void ChangeOffset(float deltax, float deltay)
    {
        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x +=  deltax * Time.deltaTime/ 10f;
        offset.y += deltay * Time.deltaTime / 10f;

        mat.mainTextureOffset = offset;
    }

    public void ChangePlace()
    {
        if (++curPlace >= Texture.Length)
            return;
        mr.material.mainTexture = Texture[curPlace];
    }
}
