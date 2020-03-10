using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    /*Questo script è da integrare nello script Blocco.cs prima della funzione Destroy, così da avere nell'ordine: collisione + audio, esplosione + audio, sparizione blocchetto*/

    private Animator anim;
    private bool explode = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        explode = true;
        anim.SetTrigger("explode");
    }
}
