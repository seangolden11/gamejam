using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text Text;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float remaintime = GameManger.Instance.gameTime;
        int min = Mathf.FloorToInt(remaintime / 60);
       
        int sec = Mathf.FloorToInt(remaintime % 60);
        
        Text.text = string.Format("{0:D2}:{1:D2}", min, sec);
    }
}
