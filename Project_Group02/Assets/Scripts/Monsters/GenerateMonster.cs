using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMonster : MonoBehaviour
{
    public GameObject[] monsters;
    public int xPos = 0;
    public int zPos = 0;


    float nextSpawn = 0.0f;
    float spawnRate = 5f;

    // Update is called once per frame
    IEnumerator MonsterDrop()
    {
        xPos = Random.Range(130, 600);
        zPos = Random.Range(-170, 185);


        yield return new WaitForSeconds(10f);

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {

            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                foreach (GameObject monster in monsters)
                {
                    Instantiate(monster, new Vector3(xPos, 10, zPos), Quaternion.identity);
                    StartCoroutine(MonsterDrop());
                   
                }
            }
        }
    }

}


