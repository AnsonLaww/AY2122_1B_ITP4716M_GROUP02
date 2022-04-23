using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    public HealthBar HealthBar;
    public ManaBar ManaBar;


    public GameObject OptionPanel;
    public GameObject SettingPanel;
    public GameObject StatsPanel;
    public GameObject Crossbow;
    public GameObject Ak47;
    public GameObject Sword;

    public PlayerData data;


    bool isOption = false;
    bool isSetting = false;
    bool isStat = false;
    bool isCrossbow = false;
    bool isAk47 = false;
    bool isSword = false;


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
        
        HealthBar.SetMaxHealth(data.MaxHealth);
        ManaBar.SetMaxMana(data.MaxMana);
    }

    // Update is called once per frame
    void Update()
    {
        data.UpdateStats();


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
        else if (Input.GetKeyDown(KeyCode.Tab) && isStat == true)
        {
            StatsPanel.SetActive(false);
            isOption = false;
            isSetting = false;
            isStat = false;
        }

        if (data.CurrentExp >= data.MaxExp)
        {
            LevelUp();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Crossbow.SetActive(true);
            Ak47.SetActive(false);
            Sword.SetActive(false);
            isCrossbow = true;
            data.CurrentWeapons = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && isCrossbow == true)
        {
            Crossbow.SetActive(false);
            isCrossbow = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Ak47.SetActive(true);
            Crossbow.SetActive(false);
            Sword.SetActive(false);
            isAk47 = true;
            data.CurrentWeapons = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && isAk47 == true)
        {
            Ak47.SetActive(false);
            isAk47 = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Crossbow.SetActive(false);
            Ak47.SetActive(false);
            Sword.SetActive(true);
            isSword = true;
            data.CurrentWeapons = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && isSword == true)
        {
            Sword.SetActive(false);
            isSword = false;
        }


    }

    public void SetExp()
    {
        data.CurrentExp += 1;
    }

     void LevelUp()
    {
        data.MaxExp += 1;
        data.CurrentExp = 0;
        data.MaxHealth += 5;
        data.MaxMana += 5;
        data.CurrentHealth = data.MaxHealth;
        data.CurrentMana = data.MaxMana;
        data.Level += 1;
        data.AttackStats += 5;
    }

    void TakeDamage(int damage)
    {
        data.CurrentHealth -= damage;

        HealthBar.SetHealth(data.CurrentHealth);

        if(data.CurrentHealth <= 0)
        {
            data.CurrentHealth = 0;
            LoadScene();
        }
    }

    void UseMana(int mana)
    {
        data.CurrentMana -= mana;
        ManaBar.SetMana(data.CurrentMana);
    }


    public void LoadScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            TakeDamage(5);
        }
        if (other.CompareTag("Exp"))
        {
            SetExp();
        }
        if (other.tag == "Finish")
        {
            SceneManager.LoadScene("BossScene");
        }
    }
}
