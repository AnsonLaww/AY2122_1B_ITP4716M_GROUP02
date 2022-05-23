using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
public class StartMenu : MonoBehaviour
{

    public void NextScene()
    {
        SceneManager.LoadScene("OpeningScene");
    }

    public void ExitScene()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }




}
