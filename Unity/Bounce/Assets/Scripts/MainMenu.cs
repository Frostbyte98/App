using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class MainMenu: MonoBehaviour {


    bool loading = false;

    public void LoadScene(int index)
    {
        if (!loading)
        {
            StartCoroutine(LoadSceneDelay(index));
        }
    }

    IEnumerator LoadSceneDelay(int index)
    {
        loading = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(index);
    }

    public void QuitApp()
    {
        if (!loading)
        {
            StartCoroutine(QuitAppDelay());
        }
    }

    IEnumerator QuitAppDelay()
    {
        loading = true;
        yield return new WaitForSeconds(2);
        Application.Quit();
    }
    
    
    
    public void SinglePlayer()
      {
        LoadScene(1);
    }

    public void MultiPlayer()
      {
        Debug.Log("Not implemented yet...");
      }

      public void QuitGame()
      {
        QuitApp();
        Debug.Log("Game is exiting...");
      }
 }
