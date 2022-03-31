using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMonster : MonoBehaviour
{
    public GameObject monster;
    public int xPos;
    public int zPos;
    public int monsterCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    IEnumerator MonsterDrop()
    {
        while (monsterCount < 10)
        {
            xPos = Random.Range(1, 12);
            zPos = Random.Range(6, 19);
            Instantiate(monster, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            monsterCount += 1;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(MonsterDrop());
        }
    }
}
