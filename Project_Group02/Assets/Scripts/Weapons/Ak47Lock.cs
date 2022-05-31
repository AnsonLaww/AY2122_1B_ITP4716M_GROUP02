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
    public WeaponsDataScriptableObjects Weapon;
    bool canShoot = true;

    //Weapon Recoil







    // Start is called before the first frame update
    void Start()
    {
        Ak47Anim = GetComponent<Animator>();
        Ak47Anim.SetBool("isLocked", false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && canShoot)
        {
            canShoot = false;
            Shoot();
            StartCoroutine(ShootGun());

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



    IEnumerator ShootGun()
    {

        yield return new WaitForSeconds(0.1f);
        canShoot = true;
        FindObjectOfType<AudioManager>().Play("AkFire");
    }


    void Shoot()
    {
        transform.position -= Vector3.forward * 0.1f;
        RaycastHit hit;

        if (Physics.Raycast(Ak47Camara.transform.position, Ak47Camara.transform.forward, out hit, range) && hit.collider.tag == "Monster")
        {
            Debug.DrawLine(Ak47Camara.transform.position, hit.transform.position, Color.red, 0.5f, true);
            hit.transform.gameObject.GetComponent<EnemiesData>().SetHealth(hit.transform.gameObject.GetComponent<EnemiesData>().GetHealth() - Weapon.attack);
            Debug.Log(hit.transform.gameObject.GetComponent<EnemiesData>().GetHealth());
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
