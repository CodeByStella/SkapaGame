using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyGoldCount : MonoBehaviour
{
    public static int TotalCoins;
    // public int Money = 135;
    void Start()
    {
        // TotalCoins = 119;
        int Gvalue = PlayerPrefs.GetInt("GOLDMoneySave");
        //int Money = PlayerPrefs.GetInt("TotalCoins");
        PlayerPrefs.SetInt("TotalCoins", Gvalue);
        TotalCoins = /*Money*/PlayerPrefs.GetInt("TotalCoins"); //+ Gvalue;
        // PlayerPrefs.SetInt("GOLDMoneySave", 120);
        //GetComponent<Text>().text = /*PlayerPrefs.GetInt("TotalCoins").*/TotalCoins.ToString();
    }
    //public void MoneyUpd()
    //{
    //    GetComponent<Text>().text = /*PlayerPrefs.GetInt("TotalCoins").*/TotalCoins.ToString();
    //}
    void Update()
    {
        // GetComponent<Text>().text = PlayerPrefs.GetInt("TotalCoins").ToString();
        GetComponent<Text>().text = TotalCoins.ToString();
    }
}
