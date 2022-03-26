using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int MaxHealth = 100;
    public int CurrentHealth;

    public HealthBar healthBar;

    public GameObject OptionPanel;
    public GameObject SettingPanel;

    bool isOption = false;
    bool isSetting = false;


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
        healthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isOption == false)
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

    }

    void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        healthBar.SetHealth(CurrentHealth);
    }


}
