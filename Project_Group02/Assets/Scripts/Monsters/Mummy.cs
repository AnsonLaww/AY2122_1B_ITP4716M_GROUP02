using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mummy : MonoBehaviour
{
    NavMeshAgent nma;
    Transform Player;
    [SerializeField]
    private GameObject Exp;

    // Start is called before the first frame update
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player").transform;

        nma.stoppingDistance = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v3Pos = transform.position;
        v3Pos.y = 0f;

        Vector3 v3playerPos = Player.position;
        v3playerPos.y = 0f;

        

        if (Vector3.Distance(v3Pos, v3playerPos) < (nma.radius + 0.5f) || Vector3.Distance(v3Pos, v3playerPos) > 25f)
        {
            nma.isStopped = true;
            nma.velocity = Vector3.zero;
        }
        else
        {
            nma.isStopped = false;
            nma.SetDestination(Player.position);
        }
    }


}

