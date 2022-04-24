using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    public GameObject SettingObj;

    private void OnEnable()
    {

        SceneManager.LoadScene("Main", LoadSceneMode.Single);


    }





}
