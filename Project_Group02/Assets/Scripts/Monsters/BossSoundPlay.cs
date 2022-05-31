using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSoundPlay : MonoBehaviour
{
    bool isSoundPlaying = false;
    string[] sounds = { "Boss_Sound_One", "Boss_Sound_Two", "Boss_Sound_Three" };
    // Start is called before the first frame update
    void Start()
    {
        isSoundPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isSoundPlaying == false)
        {
            
            isSoundPlaying = true;
            StartCoroutine(SoundEnd());
        }
    }

    IEnumerator SoundEnd()
    {
        int randSound = Random.Range(0, 3);
        FindObjectOfType<AudioManager>().Play(sounds[randSound]);
        yield return new WaitWhile(() => FindObjectOfType<AudioManager>().sounds[randSound].source.isPlaying);
        isSoundPlaying = false;
    }

}
