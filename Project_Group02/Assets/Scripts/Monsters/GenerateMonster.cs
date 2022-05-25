using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMonster : MonoBehaviour
{
    public GameObject[] monsters;
    public int xPos = 0;
    public int zPos = 0;

    const int MAX_MONSTER_COUNTER = 10;
    public List<GameObject> monstersCount;


    private void Start()
    {
        monstersCount = new List<GameObject>();
    }


    // Update is called once per frame
    IEnumerator MonsterDrop()
    {
        xPos = Random.Range(-80, 90);
        zPos = Random.Range(-70, -110);


        yield return new WaitForSeconds(10f);

    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player" && monstersCount.Count < 10)
        {
            foreach(GameObject monster in monsters)
            {

                Instantiate(monster, new Vector3(xPos, 7, zPos), Quaternion.identity);
                monstersCount.Add(monster);
                StartCoroutine(MonsterDrop());

            }

        }
        
    }

    public void SetMonsterCountList(List<GameObject> monstersCount)
    {
        this.monstersCount = monstersCount;
    }



}

