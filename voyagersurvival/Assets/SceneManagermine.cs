using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagermine : MonoBehaviour
{
    
    public void ExitApp()
    {
        Application.Quit();
    }

    public void Totitle()
    {
        SceneManager.LoadScene("Start Scene");
    }
}
