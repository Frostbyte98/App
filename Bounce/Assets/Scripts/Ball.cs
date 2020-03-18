using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public Canvas overlay;
    private float speed = 300f;
    public Rigidbody2D ball;
    bool hasMoved = false;
    Vector2 point;

    void Start()
    {
        ball.GetComponent<Rigidbody2D>();
        Vector2 point = Vector2.zero;
    }

    void Update()
    {

        if (!overlay.GetComponent<Pause>().isNotPaused())
        {
            StartCoroutine(Click());
        }


        
    }

    IEnumerator Click()
    {
        yield return new WaitForSeconds(0f);

        if (Input.GetMouseButtonUp(0) && !hasMoved && !overlay.GetComponent<Pause>().isNotPaused())
        {            
            hasMoved = true;
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = new Vector2(point.x - transform.position.x, point.y - transform.position.y);
            StartCoroutine(Lancio(direction));        
        }
    }

    IEnumerator Lancio(Vector2 direction)
    {
        //ball.velocity = direction.normalized * speed;
        ball.AddForce(direction.normalized * speed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0f);
    }
}