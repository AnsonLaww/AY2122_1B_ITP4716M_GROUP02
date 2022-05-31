using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowLock : MonoBehaviour
{

    Animator crossbowAnim;
    float range = 10000f;
    public Camera CrossbowCamara;
    public Player PlayerScript;
    public GameObject ExpPrefab;
    public WeaponsDataScriptableObjects Weapon;
    bool lockAttack = false;




    // Start is called before the first frame update
    void Start()
    {
        crossbowAnim = GetComponent<Animator>();
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

        }else if(Input.GetMouseButtonUp(1))
        {
            crossbowAnim.SetBool("isLocked", false);
        }



    }

    private void FixedUpdate()
    {
        if (lockAttack)
        {
            Debug.Log("Can't Shoot");
        }
        else
        {
            Debug.Log("Can Shoot");
        }
    }

    IEnumerator LockAttack()
    {

        yield return new WaitForSeconds(3);
        FindObjectOfType<AudioManager>().Play("CrossbowReload");
        lockAttack = false;


    }

    void Shoot()
    {

        FindObjectOfType<AudioManager>().Play("CrossbowAttack");

        RaycastHit hit;

        if (Physics.Raycast(CrossbowCamara.transform.position, CrossbowCamara.transform.forward, out hit, range) && hit.collider.tag == "Monster")
        {
            Debug.DrawLine(CrossbowCamara.transform.position, hit.transform.position, Color.red, 0.5f, true);
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
