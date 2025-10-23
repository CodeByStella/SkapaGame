using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailScript : MonoBehaviour
{
    //private bool isOn;
    //private void Start()
    //{
    //    isOn = false;
    //}

    //private void Update()
    //{
    //    if (isOn)
    //    {
    //        SceneManager.LoadScene("Main_Menu");
    //    }
    //}

    public void TouchRestart()
    {
        LoadScene.loadMain = false;
        SceneManager.LoadScene("LoadScene");
        Time.timeScale = 1;
        //if (SceneManager.GetActiveScene().name == "Level_Krasnodar") SceneManager.LoadScene("Level_Krasnodar");
        //else if (SceneManager.GetActiveScene().name == "Level_School") SceneManager.LoadScene("Level_School");
        //else if (SceneManager.GetActiveScene().name == "Level_LasVegas") SceneManager.LoadScene("Level_LasVegas");
    }
    public void TouchHome()
    {
        LoadScene.loadMain = true;
        SceneManager.LoadScene("LoadScene");
        Time.timeScale = 1;
        //isOn=true;
    }
}
