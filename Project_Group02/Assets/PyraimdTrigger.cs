using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyraimdTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public BoxCollider[] PyraimdCollders;

    private void Start()
    {
        foreach(BoxCollider pyraimdColler in PyraimdCollders)
        {
            pyraimdColler.isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerData.Key == 0)
        {
            PyraimdCollders[0].isTrigger = true;
        }

        if (PlayerData.Key == 1)
        {
            PyraimdCollders[1].isTrigger = true;
        }


        if (PlayerData.Key == 2)
        {
            PyraimdCollders[2].isTrigger = true;
        }

  
    }
}
