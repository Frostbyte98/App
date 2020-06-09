using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastRecordDisplay : MonoBehaviour
{

    public Text value;
    public Text value2;
    
    // Start is called before the first frame update
    void Start()
    {
        value.text = PlayerPrefs.GetInt("lastRecord", 0).ToString();
        value2.text = PlayerPrefs.GetInt("lastRecord2", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
