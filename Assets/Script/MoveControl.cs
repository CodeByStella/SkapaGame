using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public Transform player;
    public GameObject lineGame;
    public static bool topLine = false;
    public bool topLineRepeat;
    public static bool midLine = false;
    public bool midLineRepeat;
    public static bool botLine = false;
    public bool botLineRepeat;
    public static bool animUpLine = false;
    public static bool animDownLine = false;
    public GameObject ZakeScale;
    public static float mouseMax = -0.8f;
    public static float mouseMin = -3.65f;
    public static float lineTop = -4.1f;
    public static float lineMid = -5.5f;
    public static float lineBot = -7f;
    public GameObject shadow;

    private void Start()
    {
        topLine = false;
        midLine = true;
        botLine = false;
        animUpLine = false;
        animDownLine = false;
        topLineRepeat = false;
        midLineRepeat = true;
        botLineRepeat = false;
    }

    private void OnMouseDrag()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.y = mouse.y > mouseMax ? mouseMax : mouse.y;
        mouse.y = mouse.y < mouseMin ? mouseMin : mouse.y;
        if (HeroClassNew.stopControlBool && !HeroClassNew.Fail)
        {
            player.position = new Vector2(player.position.x, mouse.y);    
        }
        
        if (player.transform.localPosition.y >= -1.4f && player.transform.localPosition.y <= -0.8f && !topLine && Input.touchCount == 1 && !HeroClassNew.Fail)
        {
            topLine = true;
            midLine = false;
            botLine = false;
            topLineRepeat = topLine;
            midLineRepeat = midLine;
            botLineRepeat = botLine;
            HeroClassNew.index = 3;
        }
        else if (player.transform.localPosition.y <= -2.5f && player.transform.localPosition.y >= -3.65f && !botLine && Input.touchCount == 1 && !HeroClassNew.Fail)
        {
            topLine = false;
            midLine = false;
            botLine = true;
            topLineRepeat = topLine;
            midLineRepeat = midLine;
            botLineRepeat = botLine;
            HeroClassNew.index = 1;
        }
        else if (player.transform.localPosition.y < -1.4f && player.transform.localPosition.y > -2.5f && !midLine && Input.touchCount == 1 && !HeroClassNew.Fail)
        {
            topLine = false;
            midLine = true;
            botLine = false;
            topLineRepeat = topLine;
            midLineRepeat = midLine;
            botLineRepeat = botLine;
            HeroClassNew.index = 2;
        }
        // Debug.Log(player.transform.localPosition);
    }

    private void FixedUpdate()
    {
        // Debug.Log(Input.touchCount);
        if (topLine && !HeroClassNew.Fail)
        {
            if (lineGame.transform.localPosition.y < lineTop)
            {
                animUpLine = true;
                if (shadow.transform.localPosition.y < -1.45f) shadow.transform.position += new Vector3(0f, 0.1f, 0f);
                shadow.transform.localScale += new Vector3(-0.05f, -0.05f, 0f);  
                lineGame.transform.position += new Vector3(0f, 0.1f, 0f);
                ZakeScale.transform.localScale += new Vector3(-0.005f, -0.005f, 0f);
            }
            else
            {
                animUpLine = false;
            }
        }
        else if (botLine && !HeroClassNew.Fail)
        {
            if (lineGame.transform.localPosition.y > lineBot)
            {
                animDownLine = true;
                shadow.transform.position += new Vector3(0f, -0.07f, 0f);
                shadow.transform.localScale += new Vector3(0.05f, 0.05f, 0f);
                lineGame.transform.position += new Vector3(0f, -0.1f, 0f);
                ZakeScale.transform.localScale += new Vector3(0.005f, 0.005f, 0f);
                ZakeScale.transform.localPosition += new Vector3(0f, -0.05f, 0f);
            }
            else
            {
                animDownLine = false;
            }
            
            if (shadow.transform.localPosition.y >= -4.05f)
            {
                shadow.transform.localPosition += new Vector3(0f, -0.04f, 0f);
            }
        }
        else if (midLine && !HeroClassNew.Fail)
        {
            if (lineGame.transform.localPosition.y > lineMid)
            {
                animDownLine = true;
                if (Move_Camera.distanceCount > 5) shadow.transform.position += new Vector3(0f, -0.05f, 0f);
                if (Move_Camera.distanceCount > 5) shadow.transform.localScale += new Vector3(0.05f, 0.05f, 0f);
                lineGame.transform.position += new Vector3(0f, -0.1f, 0f);
                ZakeScale.transform.localScale += new Vector3(0.005f, 0.005f, 0f);
                ZakeScale.transform.localPosition += new Vector3(0f, -0.05f, 0f);
            }
            else
            {
                animDownLine = false;
            }

            if (shadow.transform.localPosition.y >= -2.957f)
            {
                shadow.transform.localPosition += new Vector3(0f, -0.04f, 0f);
            }

            if (lineGame.transform.localPosition.y < lineMid)
            {
                animUpLine = true;
                shadow.transform.position += new Vector3(0f, 0.1f, 0f);
                shadow.transform.localScale += new Vector3(-0.05f, -0.05f, 0f);
                lineGame.transform.position += new Vector3(0f, 0.1f, 0f);
                ZakeScale.transform.localScale += new Vector3(-0.005f, -0.005f, 0f);
            } 
            else
            {
                animUpLine = false;
            }
        }
    }
}
