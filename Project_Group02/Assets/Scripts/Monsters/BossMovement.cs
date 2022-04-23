using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMovement : MonoBehaviour
{
    float moveSpeed = 3f;
    Animator anim;
    Rigidbody rig;
    public GameObject player;
    bool isWalking, isAttacking;
    public NavMeshAgent agent;
    public float updateTime = 0;
    bool getHurtStats = false;
    public GameObject Instantiate_Position;
    public GameObject Box;
    int ballCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        isWalking = false;
        isAttacking = false;

    }

    public bool GetHurt()
    {
        return getHurtStats;
    }

    public void SetHurtStats(bool getHurtStats)
    {
        this.getHurtStats = getHurtStats;
    }


    // Update is called once per frame
    void Update()
    {
        int randomTimer = Random.Range(0, 200);
        updateTime += Time.deltaTime;
        anim.SetBool("isWalking", true);
        float dist = Vector3.Distance(this.transform.position, player.transform.position);

        

        for(int i = 0; i < 200; i++)
        {
            if (i == randomTimer)
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
                isAttacking = true;
                isWalking = false;
   

                randomTimer = 0;
            }
            else
            {
                anim.SetBool("isAttacking", false);
                anim.SetBool("isWalking", true);
                isAttacking = false;
                isWalking = true;
            }
        }

        while (isAttacking && ballCount !=3)
        {
             SpawnLightingBall();
             ballCount++;
        }

        ballCount = 0;

        if(getHurtStats == true)
        {

            anim.SetTrigger("idle");
        }
      
    }

    void SpawnLightingBall()
    {
           GameObject instantiateObject = Instantiate(Box, Instantiate_Position.transform.position, Instantiate_Position.transform.rotation);
           instantiateObject.transform.position = new Vector3(-30f, instantiateObject.transform.position.y, instantiateObject.transform.position.z);

    }


    private void LateUpdate()
    {
        if(updateTime > 2)
        {
            agent.destination = player.transform.position;
            updateTime = 0;
        }
    }



}
