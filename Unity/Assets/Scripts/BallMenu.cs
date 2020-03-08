using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallMenu : MonoBehaviour
{

    public Rigidbody2D rb;
    public Collider2D single;
    public Collider2D multi;
    public Collider2D quit;

    // Start is called before the first frame update
    void Start()
    {
        rb.gravityScale = 0;
        single.enabled = false;
        multi.enabled = false;
        quit.enabled = false;
    }
}
