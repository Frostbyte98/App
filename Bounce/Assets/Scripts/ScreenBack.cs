using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenBack : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool GameIsPaused;
    // Start is called before the first frame update

    private void Start()
    {
        pauseMenuUI.SetActive(false);
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

    public void Continue()
    {
        if (GameIsPaused)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
    }

    public void Restart()
    {
        if (GameIsPaused)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene("SingleMode");
            GameIsPaused = false;
        }
    }

    public void Menu()
    {
        if (GameIsPaused)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
            GameIsPaused = false;
        }
    }
}
