using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SignUpUI : MonoBehaviour
{
    const string privateCode = "lnbj95v1qUCWGTlaogy7bw68W79ddRdkiD6Gaes-L-bg";
    const string publicCode = "5ea2c6740cf2aa0c28c25658";
    const string webURL = "http://dreamlo.com/pc/";
    public string value = "";
    public string error = "";

    public enum State
    {
        None = 0,
        WaitingForResponse = 1,
        ERROR = 2,
        OK = 3
    }

    public State state = State.None;

    private Canvas canvas;
    public InputField inputName;
    public InputField inputCode;
    public Text wwwMessage;
    public Button ok;

    private void Awake()
    {
        canvas = gameObject.GetComponent<Canvas>();
        
        if (!PlayerPrefs.GetString("SignUpMenu").Equals("true"))
        {
            SignUpMenu();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void SignUpMenu()
    {
        gameObject.SetActive(true);
    }

    public void RedeemCode(string code)
    {
        this.value = "";
        this.error = "";

        string URL = webURL + publicCode + "/redeem/" + code;

        StartCoroutine(WebService(URL));
    }

    public void validateCode()
    {
        RedeemCode(inputCode.text);
    }

    IEnumerator WebService(string url)
    {
        this.state = State.WaitingForResponse;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.error != "" && www.error != null)
            {
                this.state = State.ERROR;
            }
            else
            {
                string s = www.downloadHandler.text;
                if (s.Contains("|"))
                {
                    string[] values = s.Split(new char[] { '|' });
                    if (values[0] == "ERROR")
                    {
                        this.state = State.ERROR;
                        this.error = values[1];
                        wwwMessage.color = Color.red;
                        wwwMessage.text = "codice non valido";
                    }
                    else if (values[0] == "OK")
                    {
                        this.state = State.OK;
                        if (values.Length > 1) this.value = values[1];
                        wwwMessage.color = Color.green;
                        wwwMessage.text = "codice valido";
                        if (string.IsNullOrEmpty(inputName.text))
                        {
                            ok.interactable = false;
                        }
                        else
                        {
                            ok.interactable = true;
                        }
                    }
                }
            }
        }
    }

    private string ID()
    {
        string str = "";
        byte[] buffer = new byte[16];
        for (int b = 0; b < 16; ++b)
        {
            buffer[b] = (byte)Random.Range(0, 255);
            str += buffer[b].ToString("X").PadLeft(2, '0');
        }
        return str;
    }
    
    public void Submit()
    {
        string str = "";
        byte[] buffer = new byte[16];
        for (int b = 0; b < 16; ++b)
        {
            buffer[b] = (byte)Random.Range(0, 255);
            str += buffer[b].ToString("X").PadLeft(2, '0');
        }

        canvas.enabled = false;
        PlayerPrefs.SetString("nomeUtente", inputName.text+"#"+ID().Substring(0,5));
        PlayerPrefs.SetString("SignUpMenu", "true");
        PlayerPrefs.Save();
    }
}
