using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Collider hitCollider;
    Animator swordAnim;
    public ManaBar ManaBar;
    public WeaponsDataScriptableObjects Weapon;
    bool isAttacked;
    public GameObject ExpPrefab;
    public float Force;


    // Start is called before the first frame update
    void Start()
    {
        swordAnim = GetComponent<Animator>();
        swordAnim.SetTrigger("change");
        hitCollider = GetComponent<BoxCollider>();
        hitCollider.enabled = false;
        isAttacked = false;
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && isAttacked == false)
        {
            swordAnim.SetBool("isAttacked", true);
            isAttacked = true;
            hitCollider.enabled = true;
            Invoke("EnableHitBlock", 0.5f);
        }
        if(Input.GetMouseButtonUp(0) && isAttacked == true)
        {
            swordAnim.SetBool("isAttacked", false);
            isAttacked = false;
        }


    }

    private void EnableHitBlock()
    {
        hitCollider.enabled = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            other.gameObject.GetComponent<EnemiesData>().SetHealth(other.gameObject.GetComponent<EnemiesData>().GetHealth() - Weapon.attack);
            other.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * Force, ForceMode.Impulse);
            if (other.transform.gameObject.GetComponent<BossMovement>())
            {
                other.transform.gameObject.GetComponent<BossMovement>().GetComponent<Animator>().SetTrigger("hurt");
                other.transform.gameObject.GetComponent<BossMovement>().SetHurtStats(true);
            }

            if (other.transform.gameObject.GetComponent<EnemiesData>().GetHealth() <= 0)
            {
                ManaBar.SetMana(PlayerData.CurrentMana + 10);
                Destroy(other.transform.gameObject);
            }


        }
    }

}