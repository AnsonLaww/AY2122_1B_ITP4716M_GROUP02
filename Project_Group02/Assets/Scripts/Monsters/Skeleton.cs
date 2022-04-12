using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    NavMeshAgent nma;
    Transform Player;


    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player").transform;

        nma.stoppingDistance = 2f;


    }

    void Update()
    {
        Vector3 v3Pos = transform.position;
        v3Pos.y = 0f;

        Vector3 v3playerPos = Player.position;
        v3playerPos.y = 0f;

        if (Vector3.Distance(v3Pos, v3playerPos) < (nma.radius + 0.5f))
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
