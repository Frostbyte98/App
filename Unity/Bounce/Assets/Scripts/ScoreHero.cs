using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHero : MonoBehaviour
{
    // Start is called before the first frame update
    int punteggio = 0;

    public void SetScore (int value)
    {
        punteggio += value;
    }

    public int GetScore() => punteggio;
}
