using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{

    public GameObject SettingPanel;
    public GameObject PlayerOBJ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void ReturnTitle()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToSetting()
    {
        SettingPanel.SetActive(true);
        this.gameObject.SetActive(false);
        PlayerOBJ.GetComponent<Player>().SetIsOption(true);
        PlayerOBJ.GetComponent<Player>().SetIsSetting(true);
    }




}
