using UnityEngine;
using UnityEngine.UI;

namespace Bounce.Scoreboards
{
    public class ScoreboardEntryUI : MonoBehaviour
    {
        [SerializeField] private Text entryPositionText = null;
        [SerializeField] private Text entryNameText = null;
        [SerializeField] private Text entryScoreText = null;

        public void Initialise(ScoreboardEntryData scoreboardEntryData)
        {
            entryPositionText.text = scoreboardEntryData.entryPosition.ToString() + "°";
            entryNameText.text = scoreboardEntryData.entryName;
            entryScoreText.text = scoreboardEntryData.entryScore.ToString();
        }
    }
}
