using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Bounce.Scoreboards
{
    public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardEntries = 5;
        [SerializeField] private Transform highscoresHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;

        //public InputField input;
        private GameObject menu;
        private GameObject heroUI;
        private GameObject scoreBoard;
        public static int lastRecord = 0;

        private string SavePath => $"{Application.persistentDataPath}/highscores.json";

        private void Awake()
        {
            menu = GameObject.Find("Screen");
            heroUI = GameObject.Find("HeroCanvas");
            scoreBoard = GameObject.Find("Scoreboard");
        }

        private void Start()
        {
            ScoreboardSaveData savedScores = GetSavedScores();

            UpdateUI(savedScores);

            SaveScores(savedScores);

            if (savedScores == null || savedScores.highscores.Count <= 0)
            {
                Debug.Log("Caricamento da file non riuscito");
                lastRecord = 0;
            }
            else
            {
                lastRecord = savedScores.highscores[0].entryScore;
            }
        }

        [ContextMenu("Add Test Entry")]
        public void AddNewEntry()
        {
            AddEntry(new ScoreboardEntryData()
            {
                entryName = Player.nomeGiocatore,
                entryScore = Player.points
            });
        }

        public void AddEntry(ScoreboardEntryData scoreboardEntryData)
        {
            ScoreboardSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            //Check if the score is high enough to be added.
            for (int i = 0; i < savedScores.highscores.Count; i++)
            {
                if (Player.points > savedScores.highscores[i].entryScore)
                {
                    savedScores.highscores.Insert(i, scoreboardEntryData);
                    scoreAdded = true;
                    break;
                }
            }

            //Check if the score can be added to the end of the list.
            if (!scoreAdded && savedScores.highscores.Count < maxScoreboardEntries)
            {
                savedScores.highscores.Add(scoreboardEntryData);
            }

            //Remove any scores past the limit.
            if (savedScores.highscores.Count > maxScoreboardEntries)
            {
                savedScores.highscores.RemoveRange(maxScoreboardEntries, savedScores.highscores.Count - maxScoreboardEntries);
            }

            UpdateUI(savedScores);

            SaveScores(savedScores);
        }

        private void UpdateUI(ScoreboardSaveData savedScores)
        {
            foreach (Transform child in highscoresHolderTransform)
            {
                Destroy(child.gameObject);
            }

            /*foreach (ScoreboardEntryData highscore in savedScores.highscores)
            {
                Instantiate(scoreboardEntryObject, highscoresHolderTransform).GetComponent<ScoreboardEntryUI>().Initialise(highscore);
            }*/

            for(int j=0; j<savedScores.highscores.Count; j++)
            {
                savedScores.highscores[j].entryPosition = (j + 1);
                Instantiate(scoreboardEntryObject, highscoresHolderTransform).GetComponent<ScoreboardEntryUI>().Initialise(savedScores.highscores[j]);
            }
        }

        private ScoreboardSaveData GetSavedScores()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreboardSaveData();
            }

            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<ScoreboardSaveData>(json);
            }
        }

        private void SaveScores(ScoreboardSaveData scoreboardSaveData)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreboardSaveData, true);
                stream.Write(json);
            }
        }

        public void backMenu()
        {
            scoreBoard.transform.GetChild(0).GetComponent<Canvas>().enabled = false;
            heroUI.GetComponent<Canvas>().enabled = false;
            menu.GetComponent<Canvas>().enabled = true;
        }
    }
}
