using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{


    public int QuestNumber;

    public int DialogueNumber;

    public int MaxHealth = 100;
    public int CurrentHealth;
    public int MaxMana = 100;
    public int CurrentMana;
    public int MaxSouls = 5;
    public int CurrentSouls;
    public int AttackStats = 0;
    public int Level = 1;
    public int CurrentExp = 0;
    public int MaxExp = 10;


    public WeaponsDataScriptableObjects[] weapons;

    public int CurrentWeapons;


    [Header("StatsText")]
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ManaText;
    public TextMeshProUGUI AttackText;
    public TextMeshProUGUI SoulsText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI ExpText;


    public Player PlayerScript;

    private void Start()
    {
        MaxHealth = 100;
        MaxMana = 100;
        CurrentExp = 0;
        CurrentHealth = 100;
        CurrentMana = 100;
        CurrentSouls = 0;
        MaxExp = 10;
        MaxSouls = 5;
        Level = 1;
        AttackStats = 10;
        CurrentWeapons = 0;
  

        PlayerScript = GetComponent<Player>();
    }

    public void SetHealth(int health)
    {
        CurrentHealth = health;
    }

    public int GetHealth()
    {
        return CurrentHealth;
    }

    public void UpdateStats()
    {
        LevelText.text = "Lv : " + Level;
        HealthText.text = "Health : " + CurrentHealth + " / " + MaxHealth.ToString("F0");
        ManaText.text = "Mana : " + CurrentMana + " / " + MaxMana.ToString("F0");

        for(int i = 0; i < weapons.Length; i++)
        {
            if(i == CurrentWeapons)
            {
               AttackStats =  weapons[i].attack;
            }
        }


        AttackText.text = "Attack : " + AttackStats.ToString("F0");

        SoulsText.text = "Souls : " + CurrentSouls + " / " + MaxSouls.ToString("F0");
        ExpText.text = "Exp : " + CurrentExp + " / " + MaxExp.ToString("F0");

    }




}
