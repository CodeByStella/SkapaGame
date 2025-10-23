using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPower : MonoBehaviour
{
    public GameObject ButtonBack;
    public GameObject ButtonForward;
    public static bool barUp;
    public static bool barDown;
    public GameObject barSlide;
    public static bool bigRampStart;
    public static bool continuePower;
    

    void Start()
    {
        barUp = true;
        barDown = false;
        if (MoveZakeBigRamp.countRamp == 0)
        {
            bigRampStart = false;
        }
        else
        {
            bigRampStart = true;
        }
        continuePower = false;
    }

    void FixedUpdate()
    {
        if (gameObject.transform.name != "Square (1)")
        {
            gameObject.transform.position += new Vector3(0.04f, 0f, 0f);
        }
        
        if (barUp)
        {
            barSlide.transform.localPosition += new Vector3(0f, 1f);
            if (barSlide.transform.localPosition.y >= 13)
            {
                barUp = false;
                ButtonBack.SetActive(false);
                ButtonForward.SetActive(false);
                barDown = true;
            }
        }
        else if (barDown)
        {
            barSlide.transform.localPosition += new Vector3(0f, -1f);
            if (barSlide.transform.localPosition.y <= -16)
            {
                barUp = true;
                ButtonBack.SetActive(false);
                ButtonForward.SetActive(false);
                barDown = false;
            }
        }
    }

    private void OnMouseDown()
    {
        if (barSlide.transform.localPosition.y <= 14f && barSlide.transform.localPosition.y > 2f)
        {
            ButtonBack.SetActive(true);
            ButtonForward.SetActive(true);
            bigRampStart = true;
            // continuePower = true;
            MoveZakeBigRamp.zakeLoseUp = true;
            MoveZakeBigRamp.zakeLoseUpTrue = true;
            Debug.Log("UpLoseTrue");
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        else if (barSlide.transform.localPosition.y <= 2f && barSlide.transform.localPosition.y > -9f)
        {
            ButtonBack.SetActive(true);
            ButtonForward.SetActive(true);
            bigRampStart = true;
            continuePower = true;
            gameObject.SetActive(false);
            if (MoveZakeBigRamp.countRamp == 1)
            {
                MoveZakeBigRamp.rampOne = true;
            }
            else if (MoveZakeBigRamp.countRamp == 2)
            {
                MoveZakeBigRamp.rampTwo = true;
            }
            Time.timeScale = 1f;
        }
        else if (barSlide.transform.localPosition.y <= -9f && barSlide.transform.localPosition.y > -16f)
        {
            ButtonBack.SetActive(true);
            ButtonForward.SetActive(true);
            bigRampStart = true;
            // continuePower = true;
            MoveZakeBigRamp.zakeLoseDown = true;
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
