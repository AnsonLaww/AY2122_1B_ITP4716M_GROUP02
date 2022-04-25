using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator swordAnim;
    public WeaponsDataScriptableObjects Weapon;
    bool isAttacked;
    bool lockAttack = false;



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
            lockAttack = true;
            StartCoroutine(LockAttack());
        }
        if(Input.GetMouseButtonUp(0) && isAttacked == true)
        {
            swordAnim.SetBool("isAttacked", false);
            isAttacked = false;
        }


    }


    IEnumerator LockAttack()
    {
        yield return new WaitForSeconds(3);
        lockAttack = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            other.gameObject.GetComponent<EnemiesData>().SetHealth(other.gameObject.GetComponent<EnemiesData>().GetHealth() - Weapon.attack);
            other.gameObject.GetComponent<BossMovement>().SetHurtStats(true);


        }
    }

}