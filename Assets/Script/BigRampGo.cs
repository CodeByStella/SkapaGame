using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigRampGo : MonoBehaviour
{
    public static void Clickk()
    {
        Move_Camera.cameraSpeed = 0f;
        HelicLvl.HelicBack = true;
        Move_Camera.distanceSpeed = 0;
        Time.timeScale = 1;
        PlayerPrefs.SetInt("moneyOne", 0);
        PlayerPrefs.SetInt("moneyTwo", 0);
        PlayerPrefs.SetInt("moneyThree", 0);
        Buttons.BRLVL.SetActive(false);
    }
}
