using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject RulesMenuUI;
    public GameObject malusUI;
    public GameObject finalScreenUI;
    public GameObject scoreboardUI;
    private bool GameIsPaused;

    public GameObject completato;
    public GameObject Noncompletato;
    public GameObject record;
    public GameObject vinto;
    public GameObject perso;
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject points;

    // Start is called before the first frame update

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        Scoreboard();
        finalScreenUI.SetActive(false);
        malusUI.SetActive(false);

        completato.SetActive(false);
        Noncompletato.SetActive(false);
        vinto.SetActive(false);
        perso.SetActive(false);
        s1.SetActive(false);
        s2.SetActive(false);
        s3.SetActive(false);
        points.SetActive(false);
        record.SetActive(false);
        RulesMenuUI.SetActive(false);
    }

    private void Scoreboard()
    {
        GameIsPaused = true;
        scoreboardUI.SetActive(true);
        scoreboardUI.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0f;
    }

    public void ScoreboardOFF()
    {
        GameIsPaused = false;
        scoreboardUI.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1f;
    }

    public void VolumeON()
    {
        AudioListener.volume = 1f;
    }

    public void VolumeOFF()
    {
        AudioListener.volume = 0f;
    }

    public void PauseMenu()
    {
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void RuleMenu()
    {
        GameIsPaused = true;
        RulesMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OK()
    {
        if (GameIsPaused)
        {
            GameIsPaused = false;
            RulesMenuUI.SetActive(false);
            Time.timeScale = 1f;

            PlayerPrefs.SetString("RuleMenu", "true");
            PlayerPrefs.Save();
        }
    }

    public void Continue()
    {
        if (GameIsPaused)
        {
            GameIsPaused = false;
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
      
    }

    public void Restart()
    {
        if (GameIsPaused)
        {
            Wait();
            pauseMenuUI.SetActive(false);
            finalScreenUI.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameIsPaused = false;
        }
    }

    public void Menu()
    {
        if (GameIsPaused)
        {
            Wait();
            pauseMenuUI.SetActive(false);
            finalScreenUI.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
            GameIsPaused = false;
        }
    }

    public void Quit()
    {
        Wait();
        Application.Quit();
    }

    public void Vinto()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
        malusUI.SetActive(false);
        finalScreenUI.SetActive(true);
        completato.SetActive(true);
        vinto.SetActive(true);

        s1.SetActive(true);
        s2.SetActive(true);
        s3.SetActive(true);

        points.GetComponent<Text>().text = Player.points.ToString();

        points.SetActive(true);

        if (Player.isRecord)
        {
            record.SetActive(true);
        }
    }

    public void Perso()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
        malusUI.SetActive(false);
        finalScreenUI.SetActive(true);
        Noncompletato.SetActive(true);
        perso.SetActive(true);

        points.GetComponent<Text>().text = Player.points.ToString();

        points.SetActive(true);

        if (Player.isRecord)
        {
            record.SetActive(true);
        }

        /*Gestione stelle fine turno*/

        if (Player.contaPallineRosse < 10)
        {
            s1.SetActive(true);

        }
        if(Player.contaPallineRosse >= 10 && Player.contaPallineRosse < 18)
        {
            s1.SetActive(true);
            s2.SetActive(true);
        }
        if(Player.contaPallineRosse >= 18)
        {
            s1.SetActive(true);
            s2.SetActive(true);
            s3.SetActive(true);
        }
    }

    public bool isNotPaused()
    {
        return GameIsPaused;
    }

    public void malusOverlay()
    {
        malusUI.SetActive(true);
    }

    public void malusOverlayFalse()
    {
        malusUI.SetActive(false);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
