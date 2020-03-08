using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Screen : MonoBehaviour
{
    public Collider2D single;
    public Collider2D multi;
    public Collider2D quit;
    public Rigidbody2D rb;

    bool loading = false;           //MainMenu.cs

    // Start is called before the first frame update
    void Start()
    {
        rb.gravityScale = 0;
        single.enabled = false;
        multi.enabled = false;
        quit.enabled = false;
    }

    public void LoadScene(int index)        //MainMenu.cs
    {
        if (!loading)
        {
            StartCoroutine(LoadSceneDelay(index));
        }
    }

    IEnumerator LoadSceneDelay(int index)        //MainMenu.cs
    {
        loading = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(index);
    }

    public void QuitApp()        //MainMenu.cs
    {
        if (!loading)
        {
            StartCoroutine(QuitAppDelay());
        }
    }

    IEnumerator QuitAppDelay()        //MainMenu.cs
    {
        loading = true;
        yield return new WaitForSeconds(2);
        Application.Quit();
    }

    public void SinglePlayer()        //MainMenu.cs
    {
        LoadScene(1);
    }

    public void MultiPlayer()        //MainMenu.cs
    {
        Debug.Log("Not implemented yet...");
    }

    public void QuitGame()        //MainMenu.cs
    {
        QuitApp();
        Debug.Log("Game is exiting...");
    }

    public void BackScene()        //MainMenu.cs
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void enableSingle()
    {
        single.enabled = true;
        if (single.enabled)
        {
            rb.gravityScale = 80;
        }
    }

    public void enableMulti()
    {
        multi.enabled = true;
        if (multi.enabled)
        {
            rb.gravityScale = 80;
        }
    }

    public void enableQuit()
    {
        quit.enabled = true;
        if (quit.enabled)
        {
            rb.gravityScale = 80;
        }
    }
}