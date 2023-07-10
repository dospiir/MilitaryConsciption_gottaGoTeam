using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{

    public void LoadGame()
    {
        SceneManager.LoadScene("Intro");
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

        public void ExitGame()
        {
        
            Application.Quit();
         
        }

    public void ReplayScene()
    {
        SceneManager.LoadScene("Normandy");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("UI");
    }

    public void ReplayScene2()
    {
        SceneManager.LoadScene("ADONJON");
    }

}


