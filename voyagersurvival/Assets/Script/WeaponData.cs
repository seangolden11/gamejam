using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObject/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("# main info")]

    public int weaponID;
    public string weaponName;
    public string weaponDesc;
    public Sprite weaponIcon;

    [Header("# Level Data")]

    
    public float[] damages;
    public int[] counts;

    [Header("# Weapon")]

    public GameObject weapon;
}
