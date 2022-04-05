using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{

    Transform playerTrans;

    bool bSnapping = false;
    float fSnapDist = 5f;

    float fDistance;

    Vector3 v3StartPos;
    float fStartTime;
    float fDuration = 0.25f;


    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        fDistance = Vector3.Distance(transform.position, playerTrans.position);

        if (!bSnapping)
        {
            if (fDistance < fSnapDist)
            {
                bSnapping = true;
                v3StartPos = transform.position;
                fStartTime = Time.time;
            }
        }
        else
        {
            Vector3 v3CurrentPos = transform.position;
            Vector3 v3EndPos = playerTrans.position;
            transform.position = Vector3.Lerp(v3StartPos, v3EndPos, (Time.time - fStartTime) / fDuration);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
        }

        
    }
}
