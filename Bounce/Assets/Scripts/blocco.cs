using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blocco : MonoBehaviour
{

    public GameObject ball;
    private Player pallaScript; //attenzione prima era ball spown ora sta in player
    private Collider2D col2d;
    private List<GameObject> objects = new List<GameObject>();

    public Text scoreText;
    public int score = 0;
    private bool counted = false;
    private Player ScoreScript;
    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        col2d = gameObject.GetComponent<Collider2D>();
        if (col2d.enabled == false)
        {
            col2d.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ball = GameObject.FindWithTag("Palla");
        //metti in una lista tutti i blocchi colpiti
        if (col2d.IsTouching(ball.GetComponent<Collider2D>()))
        {
            objects.Add(gameObject);
            if (!counted)
            {
                player.GetComponent<Player>().SetScore(score);
                scoreText.text = player.GetComponent<Player>().GetScore().ToString();
                counted = true;
            }
        }

        //se la pallina non è più nello schermo, elimina i blocchi colpiti
        if (Camera.main.WorldToViewportPoint(ball.transform.position).y < 0)
        {
            foreach (GameObject go in objects)
            {
                Destroy(go, 1);
            }
            Destroy(ball, 0.03f);
        }
        else
        {
            foreach (GameObject go in objects)
            {
                Destroy(go, 10);
            }
        }
    }
}