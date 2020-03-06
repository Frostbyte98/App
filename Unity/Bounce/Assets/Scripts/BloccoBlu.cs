using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloccoBlu : MonoBehaviour
{
    int punteggio = 100;
    public Collider2D ball;
    //public PointHero Hero;
    private Collider2D blocco;

    public GameObject player;
    private PointHero pointhero;

    void Awake()
    {
        pointhero = GetComponent<PointHero>();
    }

    // Start is called before the first frame update
    void Start()
    {
        blocco = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (blocco.IsTouching(ball))
        {
            Destroy(gameObject, 1);
            player.GetComponent<PointHero>().SetScore(punteggio);

            Debug.Log(player.GetComponent<PointHero>().GetScore());
        }
    }
}
