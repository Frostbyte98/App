using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ball;
    private GameObject palla;
    private GameObject Contatore;
    Vector3 Pos;
    private int i = 1;

    int punteggio = 0;


    private void Start()
    {
        Pos.x = ball.transform.position.x;
        Pos.y = ball.transform.position.y;
        Pos.z = ball.transform.position.z;
    }

    public void SetScore(int value)
    {
        punteggio += value;
    }

    public int GetScore() => punteggio;

    // Update is called once per frame
    void Update()
    {
        
        if (Camera.main.WorldToViewportPoint(ball.transform.position).y < 0)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        if (i < 10)
        {
            Destroy(GameObject.FindWithTag("Contatore"));
            Pos = new Vector3(Pos.x, Pos.y, Pos.z);
            palla = Instantiate(ball, Pos, Camera.main.transform.rotation) as GameObject;
            palla.name = "Ball (" + i + ")";
            ball = palla;
            i++;
        }

        /*else{//codice per schermata di fine livello: HAI VINTO o PERSO + PUNTEGGIO FINALE OTTENUTO}*/
    }
}
