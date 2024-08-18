using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManger : MonoBehaviour
{
   public static GameManger Instance;

    public PoolManager pool;
    public Satellite_update sate;
    public GameObject player;
    public ScrollUV scrolluv;
    public float gameTime;
    public ParticleSystem[] ps;
    public GameObject effectGroup;
    public int[] weaponLevel;
    public GameObject weaponPanel;
    public int maxMineral;
    AudioSource audioSoure;
    public WeaponData[] weaponDatas;
    public float ChangeOffset;
    float changetime;


    private void Awake()
    {
        Instance = this;
       
        gameTime = 0;
        audioSoure = GetComponent<AudioSource>();
        
    }


    private void Update()
    {
        gameTime += Time.deltaTime;
        changetime += Time.deltaTime;
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (weaponPanel.activeSelf)
                weaponPanel.SetActive(false);
            weaponPanel.SetActive(true);
        }*/
        if (changetime > ChangeOffset)
        {
            changetime = 0;
            scrolluv.ChangePlace();
        }
    }


    private void OnApplicationQuit()
    {
        DataManager.Instance.SaveGameData();
    }

    private void Start()
    {
        DataManager.Instance.LoadGameData();
        for (int i = 0; i < weaponLevel.Length; i++)
        {
            weaponLevel[i] = DataManager.Instance.data.weaponLevel[i];
        }

    }

    public void PlayEffect(int id,Vector3 pos)
    {
        ps[id].transform.position = pos;
        Instantiate(ps[id]).Play();
        
    }

    public void GetMineral(int mineral)
    {
        int curmineral = DataManager.Instance.data.mineral;
        if (curmineral > maxMineral)
        {
            curmineral = maxMineral;
            return;
        }
        audioSoure.Play();
        DataManager.Instance.data.mineral += mineral;
    }
}
