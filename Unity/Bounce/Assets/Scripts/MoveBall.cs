using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb.gravityScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            rb.gravityScale = 1;
            Camera cam = Camera.main;
            transform.position = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
            
    }
}
