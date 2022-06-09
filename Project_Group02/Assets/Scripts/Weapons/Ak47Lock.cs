using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47Lock : MonoBehaviour
{
    Animator Ak47Anim;
    float range = 10000f;
    public Camera Ak47Camara;
    public Player PlayerScript;
    public GameObject ExpPrefab;
    public ManaBar ManaBar;
    public WeaponsDataScriptableObjects Weapon;
    public float Force;
    public float KnockTime;
    bool canShoot = true;
    int count = 10;
    bool isFired = false;
    




    // Start is called before the first frame update
    void Start()
    {
        Ak47Anim = GetComponent<Animator>();
        Ak47Anim.SetBool("isLocked", false);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButton(0) && canShoot && count > 0)
        {
            canShoot = false;
            Shoot();
            UseMana(1);
            count -= 1;
            
            StartCoroutine(ShootGun());
            if (count <= 0)
            {
                canShoot = false;
                StartCoroutine(LockAttack());
            }

            if (PlayerData.CurrentMana <= 0)
            {
                canShoot = false;
            }

        }

 


        if (Input.GetMouseButton(1))
        {
            Ak47Anim.SetBool("isLocked", true);

        }
        else if (Input.GetMouseButtonUp(1))
        {
            Ak47Anim.SetBool("isLocked", false);
        }




    }

    void UseMana(int mana)
    {
        PlayerData.CurrentMana -= mana;
        ManaBar.SetMana(PlayerData.CurrentMana);
    }

    IEnumerator LockAttack()
    {


        FindObjectOfType<AudioManager>().Play("AkReload");
        yield return new WaitForSeconds(3);
        count = 10;
        canShoot = true;


    }


    IEnumerator ShootGun()
    {

        yield return new WaitForSeconds(0.1f);
        Ak47Anim.SetBool("isFired", false);
        canShoot = true;
        FindObjectOfType<AudioManager>().Play("AkFire");
    }


    void Shoot()
    { 
        RaycastHit hit;
        Ak47Anim.SetBool("isFired", true);
        if (Physics.Raycast(Ak47Camara.transform.position, Ak47Camara.transform.forward, out hit, range) && hit.collider.tag == "Monster")
        {
            Debug.DrawLine(Ak47Camara.transform.position, hit.transform.position, Color.red, 0.5f, true);
            hit.transform.gameObject.GetComponent<EnemiesData>().SetHealth(hit.transform.gameObject.GetComponent<EnemiesData>().GetHealth() - Weapon.attack);
            Debug.Log(hit.transform.gameObject.GetComponent<EnemiesData>().GetHealth());
            hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * Force, ForceMode.Impulse);

            if (hit.transform.gameObject.GetComponent<BossMovement>())
            {
                hit.transform.gameObject.GetComponent<BossMovement>().GetComponent<Animator>().SetTrigger("hurt");
                hit.transform.gameObject.GetComponent<BossMovement>().SetHurtStats(true);
            }


            if (hit.transform.gameObject.GetComponent<EnemiesData>().GetHealth() <= 0)
            {
                Instantiate(ExpPrefab, hit.transform.position, Quaternion.identity);
                Exp.exp = hit.transform.gameObject.GetComponent<EnemiesData>().GetExp();
                Destroy(hit.transform.gameObject);

            }
        }
    }


}
