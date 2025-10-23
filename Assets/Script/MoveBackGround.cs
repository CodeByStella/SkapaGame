using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBackGround : MonoBehaviour
{
    public float cameraSpeedForMenu = 100f;
    public GameObject[] backGroundForDestroy = new GameObject[3];
    private int i = new int();
    public Material[] skybox = new Material[3];


    private void Start()
    {
        i = 0;
    }

    private void FixedUpdate()
    {
        i++;
        if (ControlScriptForMenu.swipeRight && ControlScriptForMenu.krasnodarLvl)
        {
            gameObject.transform.position += new Vector3(cameraSpeedForMenu * Time.deltaTime, 0);
            if (gameObject.name == "School(Clone)" && i == 67)
            {
                Debug.Log("Sch");
                ControlScriptForMenu.krasnodarLvl = false;
                ControlScriptForMenu.schoolLvl = true;
                ControlScriptForMenu.swipeRight = false;
                i = 0;
                ControlScriptForMenu.swipeActive = true;
            }
        }
        else if (ControlScriptForMenu.swipeLeft && ControlScriptForMenu.krasnodarLvl)
        {
            if (gameObject.name == "LasVegasCityAll(Clone)" && i == 49)
            {
                Debug.Log("Las");
                ControlScriptForMenu.krasnodarLvl = false;
                ControlScriptForMenu.lasvegasrLvl = true;
                ControlScriptForMenu.swipeLeft = false;
                i = 0;
                ControlScriptForMenu.swipeActive = true;
            }
        }
        
        if (ControlScriptForMenu.swipeRight && ControlScriptForMenu.schoolLvl)
        {
            if (gameObject.name == "LasVegasCityAll(Clone)" && i == 38)
            {
                Debug.Log("Las");
                ControlScriptForMenu.schoolLvl = false;
                ControlScriptForMenu.lasvegasrLvl = true;
                ControlScriptForMenu.swipeRight = false;
                i = 0;
                ControlScriptForMenu.swipeActive = true;
            }
        }
        else if (ControlScriptForMenu.swipeLeft && ControlScriptForMenu.schoolLvl)
        {
            if (gameObject.name == "KrasnodarLvl(Clone)" && i == 86)
            {
                Debug.Log("Kras");
                ControlScriptForMenu.schoolLvl = false;
                ControlScriptForMenu.krasnodarLvl = true;
                ControlScriptForMenu.swipeLeft = false;
                i = 0;
                ControlScriptForMenu.swipeActive = true;
            }
        }
        
        if (ControlScriptForMenu.swipeRight && ControlScriptForMenu.lasvegasrLvl)
        {
            if (gameObject.name == "KrasnodarLvl(Clone)" && i == 85)
            {
                Debug.Log("Kras");
                ControlScriptForMenu.lasvegasrLvl = false;
                ControlScriptForMenu.krasnodarLvl = true;
                ControlScriptForMenu.swipeRight = false;
                i = 0;
                ControlScriptForMenu.swipeActive = true;
            }
        }
        else if (ControlScriptForMenu.swipeLeft && ControlScriptForMenu.lasvegasrLvl)
        {
            if (gameObject.name == "School(Clone)" && i == 61)
            {
                Debug.Log("Sch");
                ControlScriptForMenu.lasvegasrLvl = false;
                ControlScriptForMenu.schoolLvl = true;
                ControlScriptForMenu.swipeLeft = false;
                i = 0;
                ControlScriptForMenu.swipeActive = true;
            }
        }
    }
}
