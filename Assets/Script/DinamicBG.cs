using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinamicBG : MonoBehaviour
{
    public float citySpeed = 0.03f;
    public float mountainsSpeed = 0.01f;
    public static bool StopBG = false;
    public GameObject cld;

    private void Start()
    {
        StopBG = false;
    }

    void FixedUpdate()
    {
        if (Script321.startLvl)
        {
            if (SceneManager.GetActiveScene().name == "Level_LasVegas")
            {
                if (gameObject.transform.name == "BG_CityAll" && !StopBG || gameObject.transform.name == "BG_City_Kras" && !StopBG)
                {
                    gameObject.transform.position -= new Vector3(citySpeed, 0f, 0f);
                    Debug.Log(gameObject.transform.localPosition.x);
                }
        
                if (gameObject.transform.name == "BG_MountainsAll" && !StopBG || gameObject.transform.name == "BG_Sky_Kras" && !StopBG)
                {
                    gameObject.transform.position -= new Vector3(mountainsSpeed, 0f, 0f);
                }
        
                if (gameObject.transform.localPosition.x <= -33.45f)
                {
                    gameObject.transform.localPosition = new Vector3(0f, 0f, 10f);
                }   
            }
            else if (SceneManager.GetActiveScene().name == "Level_School")
            {
                if (gameObject.transform.name == "kras" && Move_Camera.cameraSpeed != 0 || gameObject.transform.name == "lasv" && Move_Camera.cameraSpeed != 0)
                {
                    gameObject.transform.localPosition += new Vector3(-0.01f, 0, 0);
                    //if (ControlScriptForMenu.lasvegasrLvl)
                    //{
                    //    if (gameObject.transform.name != "cloud")
                    //    {
                    //        gameObject.transform.localPosition += new Vector3(-0.01f, 0, 0);
                    //    }
                    //    if (gameObject.transform.name == "cloud")
                    //    {
                    //        cld.transform.localPosition += new Vector3(-0.013f, 0, 0);
                    //    }
                }
                if (gameObject.transform.name == "cloud" && Move_Camera.cameraSpeed != 0)
                    gameObject.transform.localPosition += new Vector3(-0.013f, 0, 0);
                if (gameObject.transform.localPosition.x <= -29.59f)
                {
                    gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
                }
           
            }
        }
    }
}
