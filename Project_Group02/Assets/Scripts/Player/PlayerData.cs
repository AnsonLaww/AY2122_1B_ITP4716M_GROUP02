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
    public static int MaxAmount;
    public static int CurrentAmount;
    public static int Skill = 0;
    private int updateSkill = 0;

    public WeaponsDataScriptableObjects[] weapons;

    public int CurrentWeapons;


    [Header("StatsText")]
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ManaText;
    public TextMeshProUGUI AttackText;
    public TextMeshProUGUI SoulsText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI ExpText;
    public TextMeshProUGUI AmountText;
    public TextMeshProUGUI SkillText;
    public TextMeshProUGUI UpdateHealthText;
    public TextMeshProUGUI UpdateManaText;
    public TextMeshProUGUI UpdateAttackText;
    public TextMeshProUGUI UpdateSoulText;

    private void Start()
    {

        MaxHealth = 100;
        MaxExp = 10;
        MaxMana = 100;
        MaxSouls = 5;
        CurrentExp = 0;
        CurrentHealth = 100;
        CurrentMana = 100;
        CurrentSouls = 0;
        updateSkill = 0;
    }

    public void SetHealth(int health)
    {
        CurrentHealth = health;
    }

    public int GetHealth()
    {
        return CurrentHealth;
    }

    public void SetExp(int exp)
    {
        CurrentExp += exp;
    }

    public void UpGradeHealth()
    {
        if(Skill <=3 || Skill > 0)
        {
            MaxHealth += 1;
            updateSkill += 1;
        }

    }

    public void DownGradeHealth()
    {
        if (Skill <= 3 || Skill > 0)
        {
            MaxHealth -= 1;
            updateSkill -= 1;
        }

    }

    public void UpGradeMana()
    {
        if (Skill <= 3 || Skill > 0)
        {
            MaxMana += 1;
            updateSkill += 1;
        }

    }

    public void DownGradeMana()
    {
        if (Skill <= 3 || Skill > 0)
        {
            MaxMana -= 1;
            updateSkill -= 1;
        }

    }

    public void UpGradeSouls()
    {
        if (Skill <= 3 || Skill > 0)
        {
            MaxSouls += 1;
            updateSkill += 1;
        }

    }

    public void DownGradeSouls()
    {
        if (Skill <= 3 || Skill > 0)
        {
            MaxSouls -= 1;
            updateSkill -= 1;
        }

    }

    public void UpGradeAttack()
    {
        if (Skill <= 3 || Skill > 0)
        {
            AttackStats += 1;
            updateSkill += 1;
        }

    }

    public void DownGradeAttack()
    {
        if (Skill <= 3 || Skill > 0)
        {
            AttackStats -= 1;
            updateSkill -= 1;
        }

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
                AttackStats = weapons[i].attack;
                MaxAmount = weapons[i].MaxAmount;
                CurrentAmount = weapons[i].Amount;
                AmountText.text = "Amount : " + CurrentAmount + " / " + MaxAmount.ToString("F0");


            }
        }


        AttackText.text = "Attack : " + AttackStats.ToString("F0");

        SoulsText.text = "Souls : " + CurrentSouls + " / " + MaxSouls.ToString("F0");
        ExpText.text = "Exp : " + CurrentExp + " / " + MaxExp.ToString("F0");

        SkillText.text = "Skill : " + Skill.ToString("F0");
        UpdateAttackText.text = updateSkill.ToString("F0");
        UpdateHealthText.text = updateSkill.ToString("F0");
        UpdateManaText.text = updateSkill.ToString("F0");
        UpdateSoulText.text = updateSkill.ToString("F0");

    }




}
