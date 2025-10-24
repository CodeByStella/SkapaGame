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
        // Load total coins from PlayerPrefs
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        Debug.Log("Total coins loaded: " + TotalCoins);
    }
    //public void MoneyUpd()
    //{
    //    GetComponent<Text>().text = /*PlayerPrefs.GetInt("TotalCoins").*/TotalCoins.ToString();
    //}
    void Update()
    {
        // Update display with current total coins
        GetComponent<Text>().text = TotalCoins.ToString();
    }
    
    // Method to update coin count when coins are collected
    public static void UpdateCoinDisplay()
    {
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
    }
}
