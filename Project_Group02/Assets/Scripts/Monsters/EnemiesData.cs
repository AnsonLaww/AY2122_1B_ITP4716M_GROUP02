using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesData : MonoBehaviour
{
    private new string name;
    private string descriptions;
    [SerializeField]
    private int health;
    private int attackDamage;
    private int defend;
    private int experience;


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
        health = enemiesScriptableObj.Health;
        attackDamage = enemiesScriptableObj.AttackDamage;
        defend = enemiesScriptableObj.Defend;
        experience = enemiesScriptableObj.Experience;
        
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public int GetHealth()
    {
        return this.health;
    }


}
