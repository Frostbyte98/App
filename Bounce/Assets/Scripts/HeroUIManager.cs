using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroUIManager : MonoBehaviour
{
    private Canvas Menu;
    private Button Button2;
    private Text testo;

    private void Awake()
    {
        Menu = GameObject.Find("Screen").GetComponent<Canvas>();
        Button2 = GameObject.Find("Lv2").GetComponent<Button>();
        testo = Button2.transform.GetChild(0).GetComponent<Text>();
    }

    private void Start()
    {
        if (PlayerPrefs.GetString("livello1Completato") == "true")
        {
            Button2.interactable = true;
            testo.color = new Color(0f, 0f, 0f, 1f);
        }
        else
        {
            Button2.interactable = false;
            testo.color = new Color(0f, 0f, 0f, .5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.GetComponent<Canvas>().enabled = false;
            Menu.enabled = true;
        }
    }
}
