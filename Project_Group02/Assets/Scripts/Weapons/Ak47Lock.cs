using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47Lock : MonoBehaviour
{
    Animator Ak47Anim;
    bool isLocked = false;
    float range = 1000f;
    public Camera Ak47Camara;
    public Player PlayerScript;
    public GameObject ExpPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Ak47Anim = GetComponent<Animator>();
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
            Ak47Anim.SetBool("isLocked", true);
            isLocked = true;

        }

        if (Input.GetMouseButtonUp(1) && isLocked == true)
        {
            Ak47Anim.SetBool("isLocked", false);
            isLocked = false;
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(Ak47Camara.transform.position, Ak47Camara.transform.forward, out hit, range) && hit.collider.tag == "Monster")
        {
            Destroy(hit.transform.gameObject);
            Instantiate(ExpPrefab, hit.transform.position, Quaternion.identity);
        }
    }
}
