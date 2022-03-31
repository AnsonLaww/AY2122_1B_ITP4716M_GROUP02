using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMonster : MonoBehaviour
{
    public GameObject monster;
    public int xPos;
    public int zPos;
    public int monsterCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    IEnumerator MonsterDrop()
    {
        while (monsterCount < 10)
        {
            xPos = Random.Range(10, 120);
            zPos = Random.Range(60, 190);


            yield return new WaitForSeconds(0.1f);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && monsterCount < 10)
        {
            Instantiate(monster, new Vector3(xPos, 0, zPos), Quaternion.identity);
            monsterCount += 1;
            StartCoroutine(MonsterDrop());
        }
    }
}
