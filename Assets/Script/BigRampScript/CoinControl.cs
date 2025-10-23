using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    public static int coinMove1, coinMove2;

    public static bool coinDelet, coinDown, coinUp;
    public static bool CoinReload;
    
    void Start()
    {
        coinMove1 = 0;
        coinMove2 = 0;
        coinDelet = false;
        coinDown = false;
        coinUp = false;
        CoinReload = false;
    }
    
    void Update()
    {
        if (MoveCameraBigRamp.lifeCoin == 3)
        {
            
        }
        else if (MoveCameraBigRamp.lifeCoin == 2 && coinDelet)
        {
            if (coinDelet && coinDown) CoinMoveDown("Coin3");
            if (coinDelet && coinUp) CoinMoveUp("Coin3");
        }
        else if (MoveCameraBigRamp.lifeCoin == 1 && coinDelet)
        {
            CoinMoveDown("Coin2");
        }
        else if (MoveCameraBigRamp.lifeCoin == 0 && coinDelet)
        {
            CoinMoveDown("Coin1");
        }
    }

    void CoinMoveDown(String coinName)
    {
        if (gameObject.transform.name == coinName && coinDelet && coinDown)
        {
            gameObject.transform.localPosition += new Vector3(0f, -12f, 0f);
            coinMove1++;
            if (coinMove1 == 5)
            {
                coinDown = false;
                coinUp = true;
            }
        }
    }

    void CoinMoveUp(String coinName)
    {
        if (gameObject.transform.name == coinName && coinDelet && coinUp)
        {
            gameObject.transform.localPosition += new Vector3(0f, 12f, 0f);
            coinMove2++;
            if (coinMove2 == 20)
            {
                coinDelet = false;
                coinUp = false;
                coinMove1 = 0;
                coinMove2 = 0;
                CoinReload = true;
            }
        }
    }
}
