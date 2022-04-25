using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowLock : MonoBehaviour
{

    Animator crossbowAnim;
    bool isLocked = false;
    float range = 1000f;
    public Camera CrossbowCamara;
    public Player PlayerScript;
    public GameObject ExpPrefab;
    public WeaponsDataScriptableObjects Weapon;
    bool lockAttack = false;




    // Start is called before the first frame update
    void Start()
    {
        crossbowAnim = GetComponent<Animator>();
        crossbowAnim.SetTrigger("change");
        crossbowAnim.SetBool("isLocked", false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && lockAttack == false)
        {
            Shoot();
            lockAttack = true;
            StartCoroutine(LockAttack());
        }


        if (Input.GetMouseButton(1))
        {
            crossbowAnim.SetBool("isLocked", true);
            Camera.main.fieldOfView = 20;
        }else
        {
            crossbowAnim.SetBool("isLocked", false);
            Camera.main.fieldOfView = 60;
        }



    }

    IEnumerator LockAttack()
    {
        yield return new WaitForSeconds(3);
        lockAttack = false;

    }

    void Shoot()
    {

        RaycastHit hit;

        if (Physics.Raycast(CrossbowCamara.transform.position, CrossbowCamara.transform.forward, out hit, range) && hit.collider.tag == "Monster")
        {

            hit.transform.gameObject.GetComponent<EnemiesData>().SetHealth(hit.transform.gameObject.GetComponent<EnemiesData>().GetHealth() - Weapon.attack);
            hit.transform.gameObject.GetComponent<BossMovement>().GetComponent<Animator>().SetTrigger("hurt");
            hit.transform.gameObject.GetComponent<BossMovement>().SetHurtStats(true);

            if (hit.transform.gameObject.GetComponent<EnemiesData>().GetHealth() <= 0)
            {
                Destroy(hit.transform.gameObject);
                Instantiate(ExpPrefab, hit.transform.position, Quaternion.identity);
            }

        }


    }
}
