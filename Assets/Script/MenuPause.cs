using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject menuPause, pause, sound, menuFail;

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Resume":
                menuPause.SetActive(false);
                pause.SetActive(true);
                Time.timeScale = 1;
                break;
            case "Restart":
                /*if (SceneManager.GetActiveScene().name == "Level_Krasnodar") SceneManager.LoadScene("Level_Krasnodar");*/
                /*else if (SceneManager.GetActiveScene().name == "Level_School") */SceneManager.LoadScene("Level_School_Ref");
                //else if (SceneManager.GetActiveScene().name == "Level_LasVegas") SceneManager.LoadScene("Level_LasVegas");
                break;
            case "Home":
                // LoadScene.loadMain = true;
                ControlScriptForMenu.schoolLvl = true; //ControlScriptForMenu.s = true;
                ControlScriptForMenu.krasnodarLvl = false; //ControlScriptForMenu.k = false;
                ControlScriptForMenu.lasvegasrLvl = false; //ControlScriptForMenu.l = false;
                SceneManager.LoadScene("Main_Menu_Ref");
                
                break;
            case "Sound":
                menuPause.SetActive(false);
                sound.SetActive(true);
                break;
            case "Back":
                if (HeroClassNew.live <= 0)
                {
                    menuFail.SetActive(true);
                    sound.SetActive(false);
                }
                else
                {
                    menuPause.SetActive(true);
                    sound.SetActive(false);
                }
                break;
        }
    }
}
