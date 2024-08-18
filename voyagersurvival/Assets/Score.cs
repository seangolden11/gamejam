using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    

    public void Init()
    {
        text = GetComponent<Text>();
        Debug.Log(GameManger.Instance.gameTime);
        text.text = string.Format("Score : {0:F2}", GameManger.Instance.gameTime);
    }
}
