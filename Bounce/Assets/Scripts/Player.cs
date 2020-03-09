using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject ball;
    public GameObject palla;
    private GameObject Contatore;
    Vector3 Pos;
    private int i = 1;

    int punteggio = 0;

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
        if (i < 5)
        {
            Destroy(GameObject.FindWithTag("Contatore"));
            Pos = new Vector3(179f, 473.2f, 0f);
            palla = Instantiate(ball, Pos, Camera.main.transform.rotation) as GameObject;
            palla.name = "Ball (" + i + ")";
            ball = palla;
            i++;
        }
    }
}
