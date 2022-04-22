using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    float moveSpeed = 3f;
    Animator anim;
    Rigidbody rig;
    public GameObject LookObj;
    bool isWalking, isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        isWalking = false;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        rig.transform.position = new Vector3(0, 0, transform.forward.z);
        gameObject.transform.LookAt(LookObj.transform);
        anim.SetBool("isWalking", true);
    }




}
