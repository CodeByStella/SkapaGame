using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartSchool : MonoBehaviour
{
    void OnMouseUpAsButton()
    {
        // ControlScriptForMenu.s = true;
        ControlScriptForMenu.schoolLvl = true;
        LoadScene.loadMain = false;
        LoadScene.loadStop = false;
        SceneManager.LoadScene("LoadScene");
    }
}
