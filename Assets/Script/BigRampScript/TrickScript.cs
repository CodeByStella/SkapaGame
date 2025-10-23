using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class TrickScript : MonoBehaviour
{
    private List <String> allTrickInGame = new List<string>();
    public Animator anim;
    private string currentAnimation;
    public static string[] arrowControl = new string[2];
    public static int countArrowNull = 0;
    public static bool trickOn = true;
    public GameObject bustBigRamp;

    void Start()
    {
        anim = GetComponent<Animator>();
        ChangeAnimation("Hello");
        arrowControl[0] = null;
        arrowControl[1] = null;
        trickOn = false;
    }
    
    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation) return;

        anim.Play(animation);
        currentAnimation = animation;
    }

    void FixedUpdate()
    {

        countArrowNull++;
        if (MoveZakeBigRamp.zakeJumpUpBigRamp || MoveZakeBigRamp.zakeFinalUpRamp)
        {
            if (arrowControl[0] != null && arrowControl[1] == null) TrickListForOne();
            else if (arrowControl != null && arrowControl[1] != null) TrickListForCombo();
        }
        
        if (arrowControl[0] != null && arrowControl[1] != null)
        {
            arrowControl[0] = null;
            arrowControl[1] = null;
            countArrowNull = 0;
            Debug.Log("CountArrow = 0");
        }

        if (countArrowNull == 75)
        {
            arrowControl[0] = null;
            arrowControl[1] = null;
            countArrowNull = 0;
            Debug.Log("CountArrow = 0");
        }
    }

    private void TrickOff ()
    {
        ChangeAnimation("Slide");
        MoveZakeBigRamp.zakeLoseUp = false;
    }

    private void TrickListForOne()
    {
        if (arrowControl[0] == "Right" && arrowControl[1] == null && trickOn)
            {
                ChangeAnimation("TrickOllieFlip");
                MoveZakeBigRamp.zakeLoseUp = true;
                trickOn = false;
                if (BustBigRamp.xn > 0) bustBigRamp.SetActive(true);
                if (BustBigRamp.xn < 10) BustBigRamp.xn++;
            } 
            else if (arrowControl[0] == "Down" && arrowControl[1] == null && trickOn)
            {
                ChangeAnimation("TrickImpossible");
                MoveZakeBigRamp.zakeLoseUp = true;
                trickOn = false;
                if (BustBigRamp.xn > 0) bustBigRamp.SetActive(true);
                if (BustBigRamp.xn < 10) BustBigRamp.xn++;
            } 
            else if (arrowControl[0] == "Left" && arrowControl[1] == null && trickOn)
            {
                ChangeAnimation("TrickMethod");
                MoveZakeBigRamp.zakeLoseUp = true;
                trickOn = false;
                if (BustBigRamp.xn > 0) bustBigRamp.SetActive(true);
                if (BustBigRamp.xn < 10) BustBigRamp.xn++;
            }
            // else if (arrowControl[0] == "Up" && arrowControl[1] == null && trickOn)
            // {
            //     ChangeAnimation("TrickNollie");
            //     MoveZakeBigRamp.zakeLoseUp = true;
            //     trickOn = false;
            //     if (BustBigRamp.xn > 0) bustBigRamp.SetActive(true);
            //     if (BustBigRamp.xn < 10) BustBigRamp.xn++;
            // }
            else if (arrowControl[0] == "Up" && arrowControl[1] == "Left" && trickOn)
            {
                ChangeAnimation("TrickNollieFlip");
                MoveZakeBigRamp.zakeLoseUp = true;
                trickOn = false;
                if (BustBigRamp.xn > 0) bustBigRamp.SetActive(true);
                if (BustBigRamp.xn < 10) BustBigRamp.xn++;
            }
            else if (arrowControl[0] == "Right Up" && arrowControl[1] == null && trickOn)
            {
                ChangeAnimation("TrickChrist");
                MoveZakeBigRamp.zakeLoseUp = true;
                trickOn = false;
                if (BustBigRamp.xn > 0) bustBigRamp.SetActive(true);
                if (BustBigRamp.xn < 10) BustBigRamp.xn++;
            } 
            else if (arrowControl[0] == "Left Down" && arrowControl[1] == null && trickOn)
            {
                ChangeAnimation("TrickBenihana");
                MoveZakeBigRamp.zakeLoseUp = true;
                trickOn = false;
                if (BustBigRamp.xn > 0) bustBigRamp.SetActive(true);
                if (BustBigRamp.xn < 10) BustBigRamp.xn++;
            }
    }

    private void TrickListForCombo()
    {
        if (arrowControl[0] == "Left" && arrowControl[1] == "Right" && trickOn)
        {
            ChangeAnimation("Trick360");
            MoveZakeBigRamp.zakeLoseUp = true;
            trickOn = false;
            if (BustBigRamp.xn > 0) bustBigRamp.SetActive(true);
            if (BustBigRamp.xn < 10) BustBigRamp.xn++;
        }
        else if (arrowControl[0] == "Left" && arrowControl[1] == "Right Up" && trickOn)
        {
            ChangeAnimation("Trick360Christ");
            MoveZakeBigRamp.zakeLoseUp = true;
            trickOn = false;
            if (BustBigRamp.xn > 0) bustBigRamp.SetActive(true);
            if (BustBigRamp.xn < 10) BustBigRamp.xn++;
        }
        else if (arrowControl[0] == "Up" && arrowControl[1] == "Down" && trickOn)
        {
            ChangeAnimation("TrickBackFlip");
            MoveZakeBigRamp.zakeLoseUp = true;
            trickOn = false;
            if (BustBigRamp.xn > 0) bustBigRamp.SetActive(true);
            if (BustBigRamp.xn < 10) BustBigRamp.xn++;
        }
        else
        {
            arrowControl[0] = arrowControl[1];
            arrowControl[1] = null;
            TrickListForOne();
        }
    }
}
