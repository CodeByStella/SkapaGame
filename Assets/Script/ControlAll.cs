using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAll : MonoBehaviour
{
    public GameObject ContrPosition;
    public GameObject lineGame;
    public static float mouseMax = -1.6f;
    public static float mouseMin = -4.45f;
    public static float lineTop = -4.1f;
    public static float lineMid = -5.7f;
    public static float lineBot = -7.4f;
    private void OnMouseDown()
    {
        if (gameObject.transform.name == "ArrowUp")
        {
            if (MoveControl.midLine && HeroClassNew.stopControlBool && !HeroClassNew.Fail)
            {
                ContrPosition.transform.position = new Vector3(0f, -1.6f, 0f);
                MoveControl.topLine = true;
                MoveControl.midLine = false;
                MoveControl.botLine = false;
                HeroClassNew.index = 3;
                MoveControl.animUpLine = true;
            }
            else if (MoveControl.botLine && HeroClassNew.stopControlBool && !HeroClassNew.Fail)
            {
                ContrPosition.transform.position = new Vector3(-7.4f, -3f, 10f);
                MoveControl.topLine = false;
                MoveControl.midLine = true;
                MoveControl.botLine = false;
                HeroClassNew.index = 2;
                MoveControl.animUpLine = true;
            }
        }

        if (gameObject.transform.name == "ArrowDown")
        {
            if (MoveControl.midLine && HeroClassNew.stopControlBool && !HeroClassNew.Fail)
            {
                ContrPosition.transform.position = new Vector3(0f, -4.45f, 0f);
                MoveControl.topLine = false;
                MoveControl.midLine = false;
                MoveControl.botLine = true;
                HeroClassNew.index = 1;
                MoveControl.animDownLine = true;
            }
            else if (MoveControl.topLine && HeroClassNew.stopControlBool && !HeroClassNew.Fail)
            {
                ContrPosition.transform.position = new Vector3(0f, -3f, 0f);
                MoveControl.topLine = false;
                MoveControl.midLine = true;
                MoveControl.botLine = false;
                HeroClassNew.index = 2;
                MoveControl.animDownLine = true;
            }
        }

        if (gameObject.transform.name == "JumpControl")
        {
            
        }
    }

    // private void FixedUpdate()
    // {
    //     if (MoveControl.topLine && MoveControl.animUpLine && lineGame.transform.position.y >= lineTop)
    //     {
    //         MoveControl.animUpLine = false;
    //     } 
    //     
    //     if (MoveControl.botLine && MoveControl.animDownLine && lineGame.transform.position.y <= lineTop)
    //     {
    //         MoveControl.animDownLine = false;
    //     } 
    // }
}
