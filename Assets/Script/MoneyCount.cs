using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCount : MonoBehaviour
{
    public static bool switchSum;
    
    void Start()
    {
        switchSum = false;
        // PlayerPrefs.SetInt("Money", 900);
        GetComponent<Text>().text = PlayerPrefs.GetInt("Money").ToString();
    }

    void Update()
    {
        if (switchSum)
        {
            GetComponent<Text>().text = PlayerPrefs.GetInt("Money").ToString();
            switchSum = false;
        }
    }
}