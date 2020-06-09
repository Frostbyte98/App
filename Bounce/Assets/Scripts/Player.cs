using Bounce.Scoreboards;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static string nomeGiocatore; //temporaneamente, poi non sarà qui
    public string utenteNome;
    
    public Canvas overlay;
    public GameObject scoreboardUI;
    public GameObject ball;
    private GameObject palla;
    Vector3 Pos;
    private int i = 1;

    int punteggio;
    public static int points;
    public static int multiPoints;
    public static int contaPallineRosse;
    public int totaleRosse;

    private GameObject Empty;
    public static bool colpitoRossa;
    public Text scoreText;
    public static bool isRecord;
    public int lastRecord;
    public int lastRecord2;

    private void Start()
    {
        colpitoRossa = false;

        isRecord = false;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            return;
        }

        //scoreboardUI.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
        
        Pos.x = ball.transform.position.x;
        Pos.y = ball.transform.position.y;
        Pos.z = ball.transform.position.z;

        totaleRosse = GameObject.FindGameObjectsWithTag("Rossa").Length;
        multiPoints = 1;
        contaPallineRosse = 0;
        punteggio = 0;
        lastRecord = PlayerPrefs.GetInt("lastRecord", 0);
        lastRecord2 = PlayerPrefs.GetInt("lastRecord2", 0);
        utenteNome = PlayerPrefs.GetString("nomeUtente");

        Empty = GameObject.Find("Empty");
    }

    public void SetMalus()
    {
        punteggio -= (int)(0.15 * punteggio);
    }

    public int GetMalus()
    {
        return (int)(0.15 * punteggio);
    }

    public void SetScore(int value)
    {
        punteggio += value;

        points = punteggio;
    }

    public int GetScore() => punteggio;

    public void SetMultiPoint(int value)
    {
        multiPoints = value;
    }

    public int GetMultiPoint() => multiPoints;

    public void SetRosse()
    {
        contaPallineRosse++;
    }

    public int GetRosse() => contaPallineRosse;

    // Update is called once per frame
    void Update()
    {
        if (ball == null)
        {
            return;
        }
        
        if (Camera.main.WorldToViewportPoint(ball.transform.position).y < 0)
        {
            Spawn();
        }

        if (this.GetRosse() < 10)
        {
            SetMultiPoint(1);
        }

        if (this.GetRosse() >= 10 && this.GetRosse() < 17)
        {
            SetMultiPoint(2);
        }

        if (this.GetRosse() >= 17)
        {
            SetMultiPoint(3);
        }

    }

    void Spawn()
    {
        if (i < 10)
        {
            Debug.Log(colpitoRossa);
            
            StartCoroutine(malusWait(colpitoRossa));
            
            Blocco.cestoCollider.enabled = true;
            Empty.GetComponent<DragFingerMove>().enabled = true;
            Empty.transform.rotation = new Quaternion(0, 0, 0, 0);
            Destroy(GameObject.FindWithTag("Contatore"));
            Pos = new Vector3(Pos.x, Pos.y, Pos.z);
            palla = Instantiate(ball, Pos, Empty.transform.rotation, Empty.transform) as GameObject;
            palla.name = "Ball (" + i + ")";
            ball = palla;
            colpitoRossa = false;
            i++;
        }
        else
        {
            if (this.GetRosse() == totaleRosse)
            {

                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    if ((points > lastRecord) || (lastRecord == 0))
                    {
                        isRecord = true;
                        PlayerPrefs.SetInt("lastRecord", points);
                    }

                    /*if (info.entryScore == 0)
                    {
                        isRecord = true;
                        info.entryScore = Player.points;
                    }
                    else
                    {
                        //salva eventuale record
                        if (info.entryScore < Player.points)
                        {
                            isRecord = true;
                            info.entryScore = Player.points;
                        }
                    }*/
                    if (Leaderboard.called == 0)
                    {
                        Leaderboard.AddNewHighscore(utenteNome, points);
                    }
                    overlay.GetComponent<Pause>().Vinto();
                    PlayerPrefs.SetString("livello1Completato", "true");
                    PlayerPrefs.Save();
                }
                
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    if ((points > lastRecord2) || (lastRecord2 == 0))
                    {
                        isRecord = true;
                        PlayerPrefs.SetInt("lastRecord2", points);
                    }

                    /*if (info.entryScore == 0)
                    {
                        isRecord = true;
                        info.entryScore = Player.points;
                    }
                    else
                    {
                        //salva eventuale record
                        if (info.entryScore < Player.points)
                        {
                            isRecord = true;
                            info.entryScore = Player.points;
                        }
                    }*/
                    if (Leaderboard.called == 0)
                    {
                        Leaderboard.AddNewHighscore(utenteNome, points);
                    }
                    overlay.GetComponent<Pause>().Vinto();
                }
            }
            else
            {

                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    if ((points > lastRecord) || (lastRecord == 0))
                    {
                        isRecord = true;
                        PlayerPrefs.SetInt("lastRecord", points);
                    }

                    /*if (info.entryScore == 0)
                    {
                        isRecord = true;
                        info.entryScore = Player.points;
                    }
                    else
                    {
                        //salva eventuale record
                        if (info.entryScore < Player.points)
                        {
                            isRecord = true;
                            info.entryScore = Player.points;
                        }
                    }*/

                    if (Leaderboard.called == 0)
                    {
                        Leaderboard.AddNewHighscore(utenteNome, points);
                    }
                    overlay.GetComponent<Pause>().Perso();
                }

                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    if ((points > lastRecord2) || (lastRecord2 == 0))
                    {
                        isRecord = true;
                        PlayerPrefs.SetInt("lastRecord2", points);
                    }

                    /*if (info.entryScore == 0)
                    {
                        isRecord = true;
                        info.entryScore = Player.points;
                    }
                    else
                    {
                        //salva eventuale record
                        if (info.entryScore < Player.points)
                        {
                            isRecord = true;
                            info.entryScore = Player.points;
                        }
                    }*/

                    if (Leaderboard.called == 0)
                    {
                        Leaderboard.AddNewHighscore(utenteNome, points);
                    }
                    overlay.GetComponent<Pause>().Perso();
                }
            }
        }
    }

    IEnumerator malusWait(bool colpitaRossa)
    {
        if (colpitoRossa == false && this.GetRosse()<19)
        {
            SetMalus();
            scoreText.text = GetScore().ToString();
            overlay.GetComponent<Pause>().malusOverlay();
        }
        yield return new WaitForSeconds(2.5f);
        overlay.GetComponent<Pause>().malusOverlayFalse();
    }
}
