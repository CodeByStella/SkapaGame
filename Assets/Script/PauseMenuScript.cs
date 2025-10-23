using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject menuPause;
    public GameObject pause;
    // public GameObject cube;
    public void TouchRestart()
    {
        //PlayerPrefs.SetInt("moneyOne", 0);
        //PlayerPrefs.SetInt("moneyTwo", 0);
        //PlayerPrefs.SetInt("moneyThree", 0);
        // if (ControlScriptForMenu.schoolLvl)
        // {
        //     ControlScriptForMenu.s = true;
        // }
        // else if (ControlScriptForMenu.lasvegasrLvl)
        // {
        //     ControlScriptForMenu.l = true;
        // }
        // else if (ControlScriptForMenu.krasnodarLvl)
        // {
        //     ControlScriptForMenu.k = true;
        // }
        LoadScene.loadStop = false;
        LoadScene.loadMain = false;
        SceneManager.LoadScene("LoadScene");
        // SceneManager.LoadScene("LoadScene_Ref");
        //if (SceneManager.GetActiveScene().name == "Level_Krasnodar") SceneManager.LoadScene("Level_Krasnodar");
        //else if (SceneManager.GetActiveScene().name == "Level_School") SceneManager.LoadScene("Level_School");
        //else if (SceneManager.GetActiveScene().name == "Level_LasVegas") SceneManager.LoadScene("Level_LasVegas");
    }
    public void TouchHome()
    {
        LoadScene.loadMain = true;
        LoadScene.loadStop = false;
        SceneManager.LoadScene("LoadScene");
        //Time.timeScale = 1;
    }
    public void TouchResume()
    {
        menuPause.SetActive(false);
        pause.SetActive(true);
        CubeCtrl.check = true;
        Time.timeScale = 1;
    }
}
