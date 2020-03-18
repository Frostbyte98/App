using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Canvas overlay;
    public GameObject ball;
    private GameObject palla;
    Vector3 Pos;
    private int i = 1;

    int punteggio;
    public static float points;
    public static int multiPoints;
    public static int contaPallineRosse;
    public int totaleRosse;

    private GameObject Empty;


    private void Start()
    {
        Pos.x = ball.transform.position.x;
        Pos.y = ball.transform.position.y;
        Pos.z = ball.transform.position.z;

        totaleRosse = GameObject.FindGameObjectsWithTag("Rossa").Length;
        multiPoints = 1;
        contaPallineRosse = 0;
        punteggio = 0;

        Empty = GameObject.FindGameObjectWithTag("oggettoVuoto");
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
            Blocco.cestoCollider.enabled = true;
            Destroy(GameObject.FindWithTag("Contatore"));
            Pos = new Vector3(Pos.x, Pos.y, Pos.z);
            palla = Instantiate(ball, Pos, Camera.main.transform.rotation) as GameObject;
            palla.name = "Ball (" + i + ")";
            ball = palla;
            i++;
        }
        else
        {
            if(this.GetRosse() == totaleRosse)
            {
                overlay.GetComponent<Pause>().Vinto();
            }
            else
            {
                overlay.GetComponent<Pause>().Perso();
            }
        }
    }
}
