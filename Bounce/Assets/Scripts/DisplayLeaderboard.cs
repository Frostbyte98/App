using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Leaderboard;

public class DisplayLeaderboard : MonoBehaviour
{

    public Text entryPositionText = null;
    public Text entryNameText = null;
    public Text entryScoreText = null;

    public void Initialise(Highscore scoreboardEntryData)
    {
        entryPositionText.text = scoreboardEntryData.position.ToString() + "°";
        entryNameText.text = scoreboardEntryData.username;
        entryScoreText.text = scoreboardEntryData.score.ToString();
    }
}
