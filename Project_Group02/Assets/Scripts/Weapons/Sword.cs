using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator swordAnim;
    public WeaponsDataScriptableObjects Weapon;
    bool isAttacked;
    public GameObject ExpPrefab;


    // Start is called before the first frame update
    void Start()
    {
        swordAnim = GetComponent<Animator>();
        swordAnim.SetTrigger("change");


        isAttacked = false;
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && isAttacked == false)
        {
            swordAnim.SetBool("isAttacked", true);
            isAttacked = true;
        }
        if(Input.GetMouseButtonUp(0) && isAttacked == true)
        {
            swordAnim.SetBool("isAttacked", false);
            isAttacked = false;
        }


    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            other.gameObject.GetComponent<EnemiesData>().SetHealth(other.gameObject.GetComponent<EnemiesData>().GetHealth() - Weapon.attack);
            if (other.transform.gameObject.GetComponent<BossMovement>())
            {
                other.transform.gameObject.GetComponent<BossMovement>().GetComponent<Animator>().SetTrigger("hurt");
                other.transform.gameObject.GetComponent<BossMovement>().SetHurtStats(true);
            }

            if (other.transform.gameObject.GetComponent<EnemiesData>().GetHealth() <= 0)
            {
                Instantiate(ExpPrefab, other.transform.position, Quaternion.identity);
                Exp.exp = other.transform.gameObject.GetComponent<EnemiesData>().GetExp();
                Destroy(other.transform.gameObject);
            }


        }
    }

}