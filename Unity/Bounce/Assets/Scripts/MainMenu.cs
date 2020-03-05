using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
 public class MainMenu: MonoBehaviour {
 
      public void SinglePlayer()
      {
        SceneManager.LoadScene(1);
      }

      public void MultiPlayer()
      {
        Debug.Log("Not implemented yet...");
      }

      public void QuitGame()
      {
        Application.Quit();
        Debug.Log("Game is exiting...");
      }
 }
