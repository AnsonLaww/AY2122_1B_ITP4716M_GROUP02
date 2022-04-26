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
    public GameObject Frontsign;

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
        
        HealthBar.SetMaxHealth(PlayerData.MaxHealth);
        HealthBar.SetHealth(PlayerData.CurrentHealth);
        ManaBar.SetMaxMana(PlayerData.MaxMana);

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
            Frontsign.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isOption == true && isSetting == false)
        {
            OptionPanel.SetActive(false);
            isOption = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Frontsign.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isOption == true && isSetting == true)
        {
            OptionPanel.SetActive(false);
            SettingPanel.SetActive(false);
            isOption = false;
            isSetting = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Frontsign.SetActive(true);

        }




        if (Input.GetKeyDown(KeyCode.Tab) && isStat == false && isOption == false)
        {
            StatsPanel.SetActive(true);
            isStat = true;

        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isStat == true)
        {
            StatsPanel.SetActive(false);
            isOption = false;
            isSetting = false;
            isStat = false;
        }

        if (PlayerData.CurrentExp >= PlayerData.MaxExp)
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
        PlayerData.CurrentExp += 1;
    }

     void LevelUp()
    {
        PlayerData.MaxExp += 1;
        PlayerData.CurrentExp = 0;
        PlayerData.MaxHealth += 5;
        PlayerData.MaxMana += 5;
        PlayerData.CurrentHealth = PlayerData.MaxHealth;
        PlayerData.CurrentMana = PlayerData.MaxMana;
        PlayerData.Level += 1;
        PlayerData.AttackStats += 5;
    }

    void TakeDamage(int damage)
    {
        PlayerData.CurrentHealth -= damage;

        HealthBar.SetHealth(PlayerData.CurrentHealth);

        if(PlayerData.CurrentHealth <= 0)
        {
            PlayerData.CurrentHealth = 0;
            LoadScene();
        }
    }

    void UseMana(int mana)
    {
        PlayerData.CurrentMana -= mana;
        ManaBar.SetMana(PlayerData.CurrentMana);
    }


    public void LoadScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            TakeDamage(other.gameObject.GetComponent<EnemiesData>().GetAttackDamage());
        }
        if (other.gameObject.tag == "Exp")
        {
            SetExp();
        }
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("BossScene");
        }


    }

 
}
