using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGContinue : MonoBehaviour
{
    int currentCoins = PlayerPrefs.GetInt("TotalCoins", 0);

    void Plus()
    {
        currentCoins += 3;
        PlayerPrefs.SetInt("TotalCoins", currentCoins);
        PlayerPrefs.Save();
    }
}
