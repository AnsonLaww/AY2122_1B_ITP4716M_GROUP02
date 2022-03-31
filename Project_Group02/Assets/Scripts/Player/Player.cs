using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int MaxHealth = 100;
    public int CurrentHealth;
    public int MaxMana = 100;
    public int CurrentMana;
    public int MaxSouls = 5;
    public int CurrentSouls;
    public int AttackStats;


    public HealthBar healthBar;

    public GameObject OptionPanel;
    public GameObject SettingPanel;
    public GameObject StatsPanel;

    public PlayerData data;


    bool isOption = false;
    bool isSetting = false;
    bool isStat = false;

    public void SetIsSetting(bool isSetting)
    {
        this.isSetting = isSetting;
    }

    public void SetIsOption(bool isOption)
    {
        this.isOption = isOption;
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
        CurrentSouls = 0;
        AttackStats = 10;
        healthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        data.UpdateStats();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isOption == false && isStat == false)
        {
            OptionPanel.SetActive(true);
            isOption = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isOption == true && isSetting == false)
        {
            OptionPanel.SetActive(false);
            isOption = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isOption == true && isSetting == true)
        {
            OptionPanel.SetActive(false);
            SettingPanel.SetActive(false);
            isOption = false;
            isSetting = false;
        }

        if (Input.GetKeyDown(KeyCode.Tab) && isStat == false && isOption == false)
        {
            StatsPanel.SetActive(true);
            isStat = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && isStat == true)
        {
            StatsPanel.SetActive(false);
            isOption = false;
            isSetting = false;
            isStat = false;
        }
    }

    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        healthBar.SetHealth(CurrentHealth);

        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.tag == "Monster")
            {
                TakeDamage(5);
            }
    }
}
