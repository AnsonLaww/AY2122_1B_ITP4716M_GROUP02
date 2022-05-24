using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingBallMovement : MonoBehaviour
{
    Animation ballAnim;
    Rigidbody ballRigid;
    public Transform targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        ballAnim = GetComponent<Animation>();
        ballRigid = GetComponent<Rigidbody>();
        targetPosition = GameObject.Find("FirstPersonController").transform;

    }



    // Update is called once per frame
    void Update()
    {

        Vector3 direction = targetPosition.transform.position - this.transform.position;
        direction.Normalize();
        ballRigid.AddForce(direction * 3000 * Time.deltaTime);
        StartCoroutine(DestroyObject());

    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSecondsRealtime(3);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            Destroy(this.gameObject);
        }
    }

}
