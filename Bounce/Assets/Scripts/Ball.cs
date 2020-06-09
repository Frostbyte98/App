using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public Canvas overlay;
    private float speed = 500f;
    public Rigidbody2D ball;
    bool hasMoved = false;
    Vector2 point;

    GameObject Empty;

    public GameObject player;

    private float lastClickTime = 0;
    private float catchTime = 0.25f;

    public Text scoreText;

    void Start()
    {
        ball.GetComponent<Rigidbody2D>();
        ball.simulated = false;
        Empty = GameObject.Find("Empty");
        Vector2 point = Vector2.zero;
    }

    void Update()
    {

        if (!overlay.GetComponent<Pause>().isNotPaused() && !hasMoved)
        {
            StartCoroutine(Click());
        }



    }

    IEnumerator Click()
    {
        yield return new WaitForSeconds(0f);

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastClickTime < catchTime)
            {
                hasMoved = true;
                /*Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = new Vector2(point.x - transform.position.x, point.y - transform.position.y);*/
                StartCoroutine(Lancio(/*direction*/));
            }
            else
            {
                hasMoved = false;
            }
            lastClickTime = Time.time;
        }

        /*if (Input.GetMouseButtonDown(0) && !hasMoved && !overlay.GetComponent<Pause>().isNotPaused())
        {            
            hasMoved = true;
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = new Vector2(point.x - transform.position.x, point.y - transform.position.y);
            StartCoroutine(Lancio(direction));        
        }*/
    }

    IEnumerator Lancio(/*Vector2 direction*/)
    {
        //ball.velocity = direction.normalized * speed;
        Empty.GetComponent<DragFingerMove>().enabled = false;
        ball.simulated = true;
        //ball.AddForce(direction.normalized * speed, ForceMode2D.Impulse);
        ball.AddForce(transform.up * -speed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0f);
    }

}