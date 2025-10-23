using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public static bool loadMain = true;

    public static bool loadStop = false;

    // Start is called before the first frame update
    void Start()
    {
        //loadMain = !loadMain;
        // ControlScriptForMenu.schoolLvl = false;
        StartCoroutine(LoadAsync());
        // Debug.Log("k " + ControlScriptForMenu.k);
        // Debug.Log("l " + ControlScriptForMenu.l);
        // Debug.Log("s " + ControlScriptForMenu.s);
        // Debug.Log("krasnodarLvl " + ControlScriptForMenu.krasnodarLvl);
        // Debug.Log("lasvegasrLvl " + ControlScriptForMenu.lasvegasrLvl);
        // Debug.Log("schoolLvl " + ControlScriptForMenu.schoolLvl);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("loadMain " + loadMain);
        // Debug.Log("loadStop " + loadStop);
    }

    IEnumerator LoadAsync()
    {
        // if (ControlScriptForMenu.k || ControlScriptForMenu.l || ControlScriptForMenu.s)
        // {
        //     loadMain = false;
        //     loadStop = false;
        // }

        // Debug.Log("1" + Buttons.Shop);
        // Debug.Log("2" + loadMain);
        // Debug.Log("3" + loadStop);
        // Debug.Log("4" + ControlScriptForMenu.s);
        // Debug.Log("5" + ControlScriptForMenu.l);
        if (!Buttons.Shop && loadMain == false/* && !loadStop*/)
        {
            // Debug.Log(ControlScriptForMenu.schoolLvl);
            // Debug.Log(ControlScriptForMenu.lasvegasrLvl);
            // Debug.Log(ControlScriptForMenu.krasnodarLvl);
            PlayerPrefs.SetInt("moneyOne", 0);
            PlayerPrefs.SetInt("moneyTwo", 0);
            PlayerPrefs.SetInt("moneyThree", 0);
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level_School");
            // Debug.Log("Level_School active");
            while (!asyncLoad.isDone)
            {
                if (!asyncLoad.isDone) yield return null;
                else loadStop = true;
            }
            // if (/*ControlScriptForMenu.s &&*/ ControlScriptForMenu.schoolLvl && !ControlScriptForMenu.lasvegasrLvl && !ControlScriptForMenu.krasnodarLvl)
            // {
            //     AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level_School");
            //     Debug.Log("Level_School active");
            //     while (!asyncLoad.isDone)
            //     {
            //         if (!asyncLoad.isDone) yield return null;
            //         else loadStop = true;
            //     }
            // }
            // else if (/*ControlScriptForMenu.l &&*/ ControlScriptForMenu.lasvegasrLvl && !ControlScriptForMenu.krasnodarLvl && !ControlScriptForMenu.schoolLvl)
            // {
            //     AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level_School");
            //     loadStop = true;
            //     while (!asyncLoad.isDone)
            //     {
            //         if (!asyncLoad.isDone) yield return null;
            //         else loadStop = true;
            //     }
            // }
            // else if (/*ControlScriptForMenu.k &&*/ ControlScriptForMenu.krasnodarLvl && !ControlScriptForMenu.lasvegasrLvl && !ControlScriptForMenu.schoolLvl)
            // {
            //     AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level_School");
            //     loadStop = true;
            //     while (!asyncLoad.isDone)
            //     {
            //         if (!asyncLoad.isDone) yield return null;
            //         else loadStop = true;
            //     }
            // }
            // else if (!ControlScriptForMenu.k && !ControlScriptForMenu.l && !ControlScriptForMenu.s)
            // {
            //     AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main_Menu");
            //     Debug.Log("Main_Menu active");
            //     loadStop = true;
            //     while (!asyncLoad.isDone)
            //     {
            //         if (!asyncLoad.isDone) yield return null;
            //         else loadStop = true;
            //     }
            // }
        }
        else 
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main_Menu");
            // Debug.Log("Main_Menu active");
            loadStop = true;
            while (!asyncLoad.isDone)
            {
                if (!asyncLoad.isDone) yield return null;
                else loadStop = true;
            }
        }
    }
}
