using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    public WeaponData data;
    Text text1;
    Text text2;
    Image icon1;

    private void Start()
    {
        text1 = transform.GetChild(0).GetComponent<Text>();
        
        icon1 = transform.GetChild(2).GetComponent<Image>();
        text1.text = data.weaponName;
        
        icon1.sprite = data.weaponIcon;
    }
}
