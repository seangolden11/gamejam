using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlider : MonoBehaviour
{
    // Start is called before the first frame update
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float maxhp = GameManger.Instance.sate.maxHp;
        float curhp = GameManger.Instance.sate.curHp;
        slider.value = curhp/maxhp;
    }
}
