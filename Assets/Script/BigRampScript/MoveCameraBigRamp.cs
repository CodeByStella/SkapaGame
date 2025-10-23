using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCameraBigRamp : MonoBehaviour
{
    //57.4             -8.2  2.4
    private int cameraMoveCount = 0;
    private int cameraSizeCount = 0;
    public float cameraSize = -0.1f;
    public static bool cameraBoolStart;
    public static bool cameraStart321 = false;
    public static bool cameraBackStandart;
    public static bool cameraGoBigRamp = false;
    public GameObject go321;
    public GameObject powerBar;
    public GameObject powerBar2;
    public GameObject powerBar3;
    public GameObject coin1, coin2, coin3;
    public static int lifeCoin;

    void Start()
    {
        cameraMoveCount = 0;
        cameraSizeCount = 0;
        cameraBoolStart = true;
        cameraStart321 = false;
        cameraBackStandart = false;
        cameraGoBigRamp = false;
        lifeCoin = 3;
    }

    void FixedUpdate()
    {
        if (CoinControl.CoinReload)
        {
            CoinControl.CoinReload = false;
            SceneManager.LoadScene("Level_Big_Ramp");
        }
        
        if (cameraBoolStart)
        {
            Script321.startBigRamp = false;
            powerBar.SetActive(false);
        }
        
        Debug.Log("НАЧАЛО");
        Debug.Log(Script321.startBigRamp);
        Debug.Log(ScriptPower.bigRampStart);
        Debug.Log(MoveZakeBigRamp.countRamp);
        Debug.Log(MoveZakeBigRamp.zakeLoseUp);
        Debug.Log(MoveZakeBigRamp.zakeLoseDown);
        Debug.Log("КОНЕЦ");
        
        if (Script321.startBigRamp && !ScriptPower.bigRampStart && MoveZakeBigRamp.countRamp == 0 &&
            !MoveZakeBigRamp.zakeLoseUp && !MoveZakeBigRamp.zakeLoseDown) 
        {
            powerBar.SetActive(true);
        }

        if (ScriptPower.bigRampStart && !ScriptPower.continuePower && !MoveZakeBigRamp.rampOne && MoveZakeBigRamp.countRamp == 1 &&
            !MoveZakeBigRamp.zakeLoseUp && !MoveZakeBigRamp.zakeLoseDown)
        {
            powerBar2.SetActive(true);
        }
        
        if (ScriptPower.bigRampStart && !ScriptPower.continuePower && !MoveZakeBigRamp.rampTwo && MoveZakeBigRamp.countRamp == 2 &&
            !MoveZakeBigRamp.zakeLoseUp && !MoveZakeBigRamp.zakeLoseDown)
        {
            powerBar3.SetActive(true);
        }
        
        cameraMoveCount++;
        if (cameraBoolStart)
        {
            transform.position += new Vector3(-20 * Time.deltaTime, 0);
            if (cameraMoveCount == 143)
            {
                cameraBoolStart = false;
                cameraStart321 = true;
                cameraMoveCount = 0;
            }
        } 
        else if (cameraStart321)
        {
            cameraSizeCount++;
            Camera.main.orthographicSize += cameraSize;
            transform.position += new Vector3(-10.5f * Time.deltaTime, 3.9f * Time.deltaTime);
            if (cameraSizeCount == 37)
            {
                go321.SetActive(true);
                cameraStart321 = false;
                cameraBackStandart = true;
                cameraSizeCount = 0;
            }
        } 
        else if (cameraBackStandart && ScriptPower.bigRampStart && MoveZakeBigRamp.pauseCamBool)
        {
            cameraSizeCount++;
            Camera.main.orthographicSize -= cameraSize;
            transform.position += new Vector3(10.5f * Time.deltaTime, -3.9f * Time.deltaTime);
            if (cameraSizeCount == 22)
            {
                cameraBackStandart = false;
                cameraGoBigRamp = true;
                cameraSizeCount = 0;
            }
        }
        else if (cameraGoBigRamp && (MoveZakeBigRamp.zakeJumpUpBigRamp || MoveZakeBigRamp.zakeFinalUpRamp || (MoveZakeBigRamp.zakeLoseDown && 
            !MoveZakeBigRamp.zakeDownRamp && !MoveZakeBigRamp.zakeMidRamp && !MoveZakeBigRamp.zakeUpRamp && !MoveZakeBigRamp.zakeDownBigRamp && 
            !MoveZakeBigRamp.zakeMidBigRamp && !MoveZakeBigRamp.zakeUpBigRamp && !MoveZakeBigRamp.zakeStartBigRamp)))
        {
            cameraSizeCount++;
            if (MoveZakeBigRamp.countRamp == 0)
            {
                if (MoveZakeBigRamp.downParam > -2.6f)
                {
                    Camera.main.orthographicSize += -0.014f;
                    transform.position += new Vector3(-1.37f * Time.deltaTime, 1.67f * Time.deltaTime);
                }
                else if (MoveZakeBigRamp.downParam < -2.6f)
                {
                    Camera.main.orthographicSize += 0.014f;
                    transform.position += new Vector3(1.37f * Time.deltaTime, -1.67f * Time.deltaTime);
                }   
            }
            else if (MoveZakeBigRamp.countRamp == 1)
            {
                if (MoveZakeBigRamp.downParam > -2.6f)
                {
                    Camera.main.orthographicSize += -0.014f;
                    transform.position += new Vector3(-1.3f * Time.deltaTime, 1.3f * Time.deltaTime);
                }
                else if (MoveZakeBigRamp.downParam < -2.6f)
                {
                    Camera.main.orthographicSize += 0.014f;
                    transform.position += new Vector3(1.3f * Time.deltaTime, -1.3f * Time.deltaTime);
                }   
            }
            else if (MoveZakeBigRamp.countRamp == 2)
            {
                if (MoveZakeBigRamp.downParam > -2.6f)
                {
                    Camera.main.orthographicSize += -0.014f;
                    transform.position += new Vector3(-1.3f * Time.deltaTime, 0.8f * Time.deltaTime);
                }
                else if (MoveZakeBigRamp.downParam < -2.6f)
                {
                    Camera.main.orthographicSize += 0.019f;
                    transform.position += new Vector3(1.3f * Time.deltaTime, -1.1f * Time.deltaTime);
                }   
            }
            else if (MoveZakeBigRamp.countRamp == 3)
            {
                if (MoveZakeBigRamp.downParam > -1.9f)
                {
                    Camera.main.orthographicSize += -0.015f;
                    transform.position += new Vector3(1.75f * Time.deltaTime, 0.7f * Time.deltaTime);
                }
                else if (MoveZakeBigRamp.downParam < -1.9f)
                {
                    Camera.main.orthographicSize += 0.012f;
                    transform.position += new Vector3(-1.45f * Time.deltaTime, -0.7f * Time.deltaTime);
                }   
            }
            
            if (cameraSizeCount == 50)
            {
                cameraBackStandart = false;
                cameraGoBigRamp = true;
                cameraSizeCount = 0;
            }
        }
    }
}
