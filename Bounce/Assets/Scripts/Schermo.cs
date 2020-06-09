using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class Schermo : MonoBehaviour
{
    public Collider2D single;
    public Collider2D multi;
    public Collider2D quit;
    public Rigidbody2D rb;
    //public Canvas screen;

    bool loading = false;           //MainMenu.cs

    public static bool daltonico;

    public Canvas heroUI;
    //public GameObject Scoreboard;
    private Canvas schermoMenu;
    public Canvas rulesMenu;

    public Button letsGo;

    // Start is called before the first frame update
    void Start()
    {

        schermoMenu = gameObject.GetComponent<Canvas>();
        rulesMenu.enabled = false;

        GameObject g = GameObject.Find("Daltonico");
        g.GetComponent<Image>().color = new Color(1f, 1f, 1f, .5f);

        schermoMenu.enabled = true;
        letsGo.interactable = true;
        rb.gravityScale = 0;
        rb.simulated = false;
        single.enabled = false;
        multi.enabled = false;
        quit.enabled = false;
        heroUI.enabled = false;
        //Scoreboard.enabled = false;
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
        yield return new WaitForSeconds(0.3f);
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
        yield return new WaitForSeconds(0.3f);
        Application.Quit();
    }

    public void HeroSelect()
    {
        schermoMenu.enabled = false;
        heroUI.enabled = true;
        //Scoreboard.enabled = true;
    }

    public void SinglePlayer()        //MainMenu.cs
    {
        LoadScene(1);
    }

    public void SinglePlayer2()
    {
        LoadScene(2);
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
        Time.timeScale = 1f;
        if (single.enabled)
        {
            rb.simulated = true;
            rb.gravityScale = 80;
        }
        
    }

    public void enableMulti()
    {
        multi.enabled = true;
        Time.timeScale = 1f;
        if (multi.enabled)
        {
            rb.simulated = true;
            rb.gravityScale = 80;
        }
    }

    public void enableQuit()
    {
        quit.enabled = true;
        Time.timeScale = 1f;
        if (quit.enabled)
        {
            rb.simulated = true;
            rb.gravityScale = 80;
        }
    }

    public void VolumeON()
    {
        AudioListener.volume = 1f;
    }

    public void VolumeOFF()
    {
        AudioListener.volume = 0f;
    }

    public void RulesUION()
    {
        rulesMenu.enabled = true;
    }

    public void RulesUIOFF()
    {
        rulesMenu.enabled = false;
    }

    public void daltonicoON_OFF()
    {
        if (!daltonico)
        {
            daltonico = true;
            GameObject g = GameObject.Find("Daltonico");
            g.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            daltonico = false;
            GameObject g = GameObject.Find("Daltonico");
            g.GetComponent<Image>().color = new Color(1f, 1f, 1f, .5f);
        }
    }
}