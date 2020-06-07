using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroUIManager : MonoBehaviour
{
    private Canvas Menu;

    private void Awake()
    {
        Menu = GameObject.Find("Screen").GetComponent<Canvas>();
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
