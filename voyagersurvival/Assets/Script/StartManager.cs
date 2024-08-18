using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public GameObject UpgradePanel;

    private void Start()
    {
        DataManager.Instance.LoadGameData();
        UpgradePanel.SetActive(false);
        
        if (DataManager.Instance.data.weaponLevel.Length != 3)
        {
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
        Transform[] allChildren = UpgradePanel.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.GetComponent<WeaponButton>())
            {
                child.GetComponent<WeaponButton>().Init();
            }
        }

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
        
        if (DataManager.Instance.data.mineral > DataManager.Instance.data.weaponLevel[data.weaponID] * 200)
        {
            if (DataManager.Instance.data.weaponLevel[data.weaponID] <= 3)
            {
                DataManager.Instance.data.mineral -= DataManager.Instance.data.weaponLevel[data.weaponID] * 200;
                DataManager.Instance.data.weaponLevel[data.weaponID]++;

                
            
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
    }
}
