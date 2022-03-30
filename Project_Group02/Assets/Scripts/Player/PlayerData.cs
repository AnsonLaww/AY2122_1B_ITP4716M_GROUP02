using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public int QuestNumber;

    public int DialogueNumber;

    public float MaxHealth;
    public float CurrentHealth;
    public float MaxMana;
    public float CurrentMana;
    public float AttackStats;
    public float MaxSouls;
    public float CurrentSouls;



    [Header("StatsText")]
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ManaText;
    public TextMeshProUGUI AttackText;
    public TextMeshProUGUI SoulsText;


    public Player PlayerScript;

    private void Start()
    {
        PlayerScript = GetComponent<Player>();
    }

    public void UpdateStats()
    {
        HealthText.text = "Health : " + PlayerScript.CurrentHealth + " / " + PlayerScript.MaxHealth.ToString("F0");
        ManaText.text = "Mana : " + PlayerScript.CurrentMana + " / " + PlayerScript.MaxMana.ToString("F0");
        AttackText.text = "Attack : " + PlayerScript.AttackStats.ToString("F0");
        SoulsText.text = "Souls : " + PlayerScript.CurrentSouls + " / " + PlayerScript.MaxSouls.ToString("F0");

    }




}
