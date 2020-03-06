using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{

    public Rigidbody2D ball;
    private Collider2D col2d;
    private float old_x;
    public Text scoreText;
    public int score = 50;

    private ScoreHero ScoreScript;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        col2d = gameObject.GetComponent<Collider2D>();

        
        if (col2d.enabled == false)
        {
            col2d.enabled = true;
        }

        old_x = gameObject.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {

        float new_x = gameObject.transform.position.x;

        if ((col2d.IsTouching(ball.GetComponent<Collider2D>())) && (new_x==old_x))
        {
            Destroy(gameObject, 3);
            //ScoreScript.SetScore(score);
            //scoreText.text = ScoreScript.ToString();

            player.GetComponent<ScoreHero>().SetScore(score);
            scoreText.text = player.GetComponent<ScoreHero>().GetScore().ToString();

        }
        
        else if ((this.transform.position.y < -1) && (col2d.IsTouching(ball.GetComponent<Collider2D>())))
        {
            Destroy(gameObject, 1);
            //ScoreScript.SetScore(score);
            //scoreText.text = ScoreScript.ToString();

            player.GetComponent<ScoreHero>().SetScore(score);
            scoreText.text = player.GetComponent<ScoreHero>().GetScore().ToString();
        }

        old_x = gameObject.transform.position.x;
    }
}
