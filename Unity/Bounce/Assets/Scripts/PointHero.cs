using UnityEngine;
using System.Collections;
using System.Collections.Generic;

internal class PointHero : MonoBehaviour
{
    int punteggio = 0;

    public void SetScore (int value)
    {
        punteggio = punteggio + value;
    }

    public int GetScore() => punteggio;
}