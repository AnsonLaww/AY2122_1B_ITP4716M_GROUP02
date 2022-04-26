using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{


    public int QuestNumber;

    public int DialogueNumber;

    public static int MaxHealth = 100;
    public static int CurrentHealth = 100;
    public static int MaxMana = 100;
    public static int CurrentMana = 100;
    public static int MaxSouls = 5;
    public static int CurrentSouls = 0;
    public static int AttackStats = 0;
    public static int Level = 1;
    public static int CurrentExp = 0;
    public static int MaxExp = 10;


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
