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
    public bool isStart;

    private void Start()
    {
        text1 = transform.GetChild(0).GetComponent<Text>();
        
        icon1 = transform.GetChild(2).GetComponent<Image>();
        text1.text = data.weaponName;
        
        icon1.sprite = data.weaponIcon;

        if (isStart)
        {
            text2 = transform.GetChild(1).GetComponent<Text>();
            text1.text = string.Format("{0} LV.{1}", data.weaponName, DataManager.Instance.data.weaponLevel[data.weaponID]);
            text2.text = string.Format("Cost : {0}", 200 * (DataManager.Instance.data.weaponLevel[data.weaponID] +1));
            
        }
    }

    public void Init()
    {
        
        text1.text = string.Format("{0} LV.{1}", data.weaponName, DataManager.Instance.data.weaponLevel[data.weaponID]);
        text2.text = string.Format("Cost : {0}", 200 * (DataManager.Instance.data.weaponLevel[data.weaponID]+1));
    }
}
