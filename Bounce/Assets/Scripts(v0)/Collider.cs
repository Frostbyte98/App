﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{

    public Collider2D single;
    public Collider2D multi;
    public Collider2D quit;
    public Rigidbody2D rb;

    public void enableSingle()
    {
        single.enabled = true;
        if (single.enabled)
        {
            rb.gravityScale = 80;
        }
    }

    public void enableMulti()
    {
        multi.enabled = true;
        if (multi.enabled)
        {
            rb.gravityScale = 80;
        }
    }

    public void enableQuit()
    {
        quit.enabled = true;
        if (quit.enabled)
        {
            rb.gravityScale = 80;
        }
    }
}
