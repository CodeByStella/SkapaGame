using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOff321 : MonoBehaviour
{
    public GameObject ThreeTwoOne;
    public GameObject PauseButton;
    void Update()
    {
        if (ThreeTwoOne.activeSelf)
        {
            PauseButton.SetActive(false);
            //Debug.Log("Работает");
        }
        else PauseButton.SetActive(true);
        //PauseButton.SetActive(false);
        //Debug.Log("Не то");
    }
}
