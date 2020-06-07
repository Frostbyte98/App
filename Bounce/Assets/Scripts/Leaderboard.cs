using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    const string privateCode = "MCK7IV9UZUGRyewGbM-JbA6mc06cXPCkCXAGhgJX7LQw";
    const string publicCode = "5e9a14530cf2aa0c28a54589";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoreList;
    static Leaderboard instance;

    public static int called;


    public Transform highscoresHolderTransform = null;
    public GameObject scoreboardEntryObject = null;

    private void Awake()
    {
        instance = this;
        called = 0;
    }

    private void Start()
    {
        StartCoroutine(RefrashHighscores());
    }

    public static void AddNewHighscore(string username, int score)
    {
        called++;
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }
    
    IEnumerator UploadNewHighscore(string username, int score)
    {
        UnityWebRequest www = UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        yield return www.SendWebRequest();

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload riuscito");
            LoadHighscore();
        }
        else
        {
            Debug.Log("ERRORE: upload non riuscito >> " + www.error);
        }
    }

    public void LoadHighscore()
    {
        StartCoroutine(DownloadHighscore());
    }

    IEnumerator DownloadHighscore()
    {
        UnityWebRequest www = UnityWebRequest.Get(webURL + publicCode + "/pipe/100");
        yield return www.SendWebRequest();

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscore(www.downloadHandler.text);
            UIhighscore(highscoreList);
        }
        else
        {
            Debug.Log("ERRORE: fetch con il database non riuscito >> " + www.error);
        }
    }

    public void UIhighscore(Highscore[] highscoreList)
    {
        foreach (Transform child in highscoresHolderTransform)
        {
            Destroy(child.gameObject);
        }

        for (int j = 0; j < highscoreList.Length; j++)
        {
            highscoreList[j].position = (j + 1);
            Instantiate(scoreboardEntryObject, highscoresHolderTransform).GetComponent<DisplayLeaderboard>().Initialise(highscoreList[j]);
        }
    }

    void FormatHighscore(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        highscoreList = new Highscore[entries.Length];

        for(int i=0; i<entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            int position = i + 1;
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoreList[i] = new Highscore(position, username, score);
            Debug.Log(highscoreList[i].position + ") " + highscoreList[i].username + ": " + highscoreList[i].score);
        }
    }

    IEnumerator RefrashHighscores()
    {
        while (true)
        {
            LoadHighscore();
            yield return new WaitForSeconds(30);
        }
    }

    public struct Highscore
    {
        public int position;
        public string username;
        public int score;

        public Highscore(int _position, string _username, int _score)
        {
            position = _position;
            username = _username;
            score = _score;
        }
    }
}
