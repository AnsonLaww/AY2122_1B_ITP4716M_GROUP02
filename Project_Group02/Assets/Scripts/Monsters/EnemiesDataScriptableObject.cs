using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemies", menuName = "Enemies/New Enemies")]
public class EnemiesDataScriptableObject : ScriptableObject
{
    public string Name;
    public string Descriptions;
    public int Health;
    public int AttackDamage;
    public int Defend;
    public int Experience;

}
