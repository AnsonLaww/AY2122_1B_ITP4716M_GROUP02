using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/New Weapon")]
public class WeaponsDataScriptableObjects : ScriptableObject
{
    public new string name;
    public string description;
    public int attack;
    public int upgradeCost;


}
