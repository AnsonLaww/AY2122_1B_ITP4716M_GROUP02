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


    // Start is called before the first frame update
    void Start()
    {
        crossbowAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }


        if (Input.GetMouseButton(1))
        {
            crossbowAnim.SetBool("isLocked", true);
            isLocked = true;
          
        }

        if (Input.GetMouseButtonUp(1) && isLocked == true)
        {
            crossbowAnim.SetBool("isLocked", false);
            isLocked = false;
        }
    }

    void Shoot()
    {

        RaycastHit hit;

        if (Physics.Raycast(CrossbowCamara.transform.position, CrossbowCamara.transform.forward, out hit, range) && hit.collider.tag == "Monster")
        {

            hit.transform.gameObject.GetComponent<EnemiesData>().SetHealth(hit.transform.gameObject.GetComponent<EnemiesData>().GetHealth() - Weapon.attack);

            if(hit.transform.gameObject.GetComponent<EnemiesData>().GetHealth() <= 0)
            {
                Destroy(hit.transform.gameObject);
                Instantiate(ExpPrefab, hit.transform.position, Quaternion.identity);
            }

        }


    }
}
