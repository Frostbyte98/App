using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blocco : MonoBehaviour
{

    public GameObject ball;
    private Player pallaScript; //attenzione prima era ball spawn ora sta in player
    private Collider2D col2d;
    public static Collider2D cestoCollider;
    private List<GameObject> objects = new List<GameObject>();

    public Text scoreText;
    public Text multiPointText;
    public int score = 0;
    private bool counted = false;
    private bool contata = false;
    private Player ScoreScript;
    public GameObject player;

    private Text point;
    private Text pointCesto;

    public AudioClip impact;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        cestoCollider = GameObject.FindWithTag("Cesto").GetComponent<Collider2D>();
        col2d = gameObject.GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();

        point = this.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        point.enabled = false;
        pointCesto = GameObject.FindWithTag("Cesto").transform.GetChild(0).GetChild(0).GetComponent<Text>();
        pointCesto.enabled = false;

        if (col2d.enabled == false)
        {
            col2d.enabled = true;
        }

        Player.colpitoRossa = false;
    }

    // Update is called once per frame
    void Update()
    {
        ball = GameObject.FindWithTag("Palla");

        if (ball == null)
        {
            return;
        }

        //metti in una lista tutti i blocchi colpiti
        if (col2d.IsTouching(ball.GetComponent<Collider2D>()))
        {

            if (gameObject.CompareTag("Rossa"))
            {
                Player.colpitoRossa = true;
            }

            objects.Add(gameObject);

            if (!counted)
            {
                if (ball.gameObject.tag == "Palla")
                {
                    audioSource.PlayOneShot(impact);
                }

                player.GetComponent<Player>().SetScore(score * player.GetComponent<Player>().GetMultiPoint());
                multiPointText.text = $"x{player.GetComponent<Player>().GetMultiPoint().ToString()}";
                scoreText.text = player.GetComponent<Player>().GetScore().ToString();
                point.text = (score* player.GetComponent<Player>().GetMultiPoint()).ToString();
                point.enabled = true;

                if (!(col2d.CompareTag("Cesto")))
                {
                    counted = true;
                }
                else
                {
                    cestoCollider.enabled = false;
                }
            }
        }

        //se la pallina non è più nello schermo, elimina i blocchi colpiti
        if (Camera.main.WorldToViewportPoint(ball.transform.position).y < 0)
        {
            StartCoroutine(DisabilitaPuntiCesto());

            foreach (GameObject go in objects)
            {
                if (!go.CompareTag("Cesto"))
                {
                    if (go.CompareTag("Rossa") && !contata)
                    {
                        contata = true;
                        player.GetComponent<Player>().SetRosse();
                    }

                    Destroy(go, 2);
                }
            }

            if (!col2d.CompareTag("Cesto"))
            {
                Destroy(ball, 0.03f);
            }
        }
        else
        {
            foreach (GameObject go in objects)
            {
                if (!go.CompareTag("Cesto"))
                {
                    if (go.CompareTag("Rossa") && !contata)
                    {
                        contata = true;
                        player.GetComponent<Player>().SetRosse();
                    }

                    Destroy(go, 2);
                }
            }
        }
    }

    IEnumerator DisabilitaPuntiCesto()
    {
        yield return new WaitForSeconds(2);
        pointCesto.enabled = false;
    }
}
