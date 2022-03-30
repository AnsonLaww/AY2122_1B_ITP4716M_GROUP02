using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{

    public GameObject SettingPanel;
    public GameObject PlayerOBJ;

    Player sc;

    // Start is called before the first frame update
    void Start()
    {
        sc = PlayerOBJ.GetComponent<Player>();
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
        sc.SetIsOption(true);
        sc.SetIsSetting(true);
    }




}
