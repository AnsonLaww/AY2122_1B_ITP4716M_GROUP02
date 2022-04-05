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
            Debug.Log(hit.transform.name);
            Debug.DrawLine(Camera.main.transform.position, hit.transform.position, Color.red, 0.5f, true);
            Destroy(hit.transform.gameObject);
            PlayerScript.SetExp();

        }

        


    }


}
