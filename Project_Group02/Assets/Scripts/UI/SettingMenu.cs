using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    public GameObject SettingObj;
   

    public void GoToSettingObj()
    {
        SettingObj.SetActive(true);
        Time.timeScale = 0;
    }

    public void GoBackObj()
    {

        SettingObj.SetActive(false);
        Time.timeScale = 1;
    }
}
