using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public GameObject UpgradePanel;
    AudioSource audioSoure;
    public AudioClip failsound;
    public AudioClip successsound;

    private void Start()
    {
        DataManager.Instance.LoadGameData();
        UpgradePanel.SetActive(false);
        audioSoure = GetComponent<AudioSource>();
        
        if (DataManager.Instance.data.weaponLevel.Length != 3)
        {
            Debug.Log("re");
            DataManager.Instance.data.weaponLevel = new int[3];
        }
    }
    public void PlayStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Upgrade()
    {
        UpgradePanel.SetActive(true);
        /*
        Transform[] allChildren = UpgradePanel.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.GetComponent<WeaponButton>())
            {
                child.GetComponent<WeaponButton>().Init();
            }
        }
        */
    }

    private void OnApplicationQuit()
    {
        DataManager.Instance.SaveGameData();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            UpgradePanel?.SetActive(false);
    }

    public void UpgradeWeapon(WeaponData data)
    {
        audioSoure.clip = failsound;
        if (DataManager.Instance.data.mineral > (DataManager.Instance.data.weaponLevel[data.weaponID]+1) * 200)
        {
            if (DataManager.Instance.data.weaponLevel[data.weaponID] <= 3)
            {
                DataManager.Instance.data.mineral -= (DataManager.Instance.data.weaponLevel[data.weaponID]+1) * 200;
                DataManager.Instance.data.weaponLevel[data.weaponID]++;
                audioSoure.clip = successsound;
                
            
            }

        }
        Transform[] allChildren = UpgradePanel.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.GetComponent<WeaponButton>())
            {
                child.GetComponent<WeaponButton>().Init();
            }
        }
        audioSoure.Play();
    }

}
