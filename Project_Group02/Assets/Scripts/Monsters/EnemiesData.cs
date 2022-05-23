using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemiesData : MonoBehaviour
{
    private new string name;
    private string descriptions;

    [SerializeField]
    private int health;
    private int attackDamage;
    private int defend;
    private int experience;
    private int maxhealth;
    


    public EnemiesDataScriptableObject enemiesScriptableObj;






    public virtual void OnEnable()
    {
        SetUpEnemy();
    }
    
    // Start is called before the first frame update
    public virtual void SetUpEnemy()
    {
        name = enemiesScriptableObj.Name;
        descriptions = enemiesScriptableObj.Descriptions;
        maxhealth = enemiesScriptableObj.Health;
        attackDamage = enemiesScriptableObj.AttackDamage;
        defend = enemiesScriptableObj.Defend;
        experience = enemiesScriptableObj.Experience;
        health = enemiesScriptableObj.Health;
    }

    public int GetMaxHealth()
    {
        return this.maxhealth;

    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public int GetHealth()
    {
        return this.health;
    }

    public int GetAttackDamage()
    {
        return attackDamage;
    }

    public int GetExp()
    {
        return experience;
    }

 




}
