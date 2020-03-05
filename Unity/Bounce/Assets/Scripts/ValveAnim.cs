using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveAnim : MonoBehaviour
{

    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 distanza;
    private float rotationSpeed = 10f;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            distanza = (touchPosition - transform.position);
            rb.velocity = new Vector2(distanza.x, distanza.y) * rotationSpeed;

            if(touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}
