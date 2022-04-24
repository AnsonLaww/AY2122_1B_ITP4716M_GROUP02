using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingBallMovement : MonoBehaviour
{
    Animation ballAnim;

    // Start is called before the first frame update
    void Start()
    {
        ballAnim = GetComponent<Animation>();
    }



    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Counter()
    {
        yield return new WaitForSeconds(3);
        ballAnim.Stop();
    }


}
