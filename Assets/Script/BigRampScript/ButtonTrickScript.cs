using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrickScript : MonoBehaviour
{
    public Animator anim;
    private string currentAnimation;
    public static bool butAnim, backFlip, frontFlip;
    public GameObject bustBigRamp;
    public static int xnButTrick;

    void Start()
    {
        // anim = GetComponent<Animator>();
        butAnim = false;
        backFlip = false;
        // xnButTrick = BustBigRamp.xn;
    }
    
    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation) return;

        anim.Play(animation);
        currentAnimation = animation;
    }
    
    void ChangeAnimationNonStop(string animation)
    {
        if (!MoveZakeBigRamp.zakeLoseUpTrue || !MoveZakeBigRamp.zakeLoseUp)
        {
            anim.Play(animation);
            currentAnimation = animation;
        }
    }

    private void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "Button_Back_Flip":
                backFlip = true;
                BustBigRamp.trickButton = true;
                break;
            case "Button_Front_Flip":
                frontFlip = true;
                BustBigRamp.trickButton = true;
                break;
        }
    }

    private void OnMouseUp()
    {
        MoveZakeBigRamp.zakeLoseUp = false;
        backFlip = false;
        frontFlip = false;
        ChangeAnimationNonStop("TrickZero");
    }


    void FixedUpdate()
    {
        if (BustBigRamp.trickButton && butAnim)
        {
            if (BustBigRamp.xn > 0) bustBigRamp.SetActive(true);
            if (BustBigRamp.xn < 10)
            {
                if (MoveZakeBigRamp.zakeDownRamp)
                {
                    BustBigRamp.xn = 0;
                    xnButTrick = 0;
                }
                else BustBigRamp.xn = xnButTrick;
                BustBigRamp.trickButton = false;
            }
        }
        
        if ((MoveZakeBigRamp.zakeJumpUpBigRamp || MoveZakeBigRamp.zakeDownRamp) && (!MoveZakeBigRamp.zakeLoseUpTrue || !MoveZakeBigRamp.zakeLoseUp))
        {
            butAnim = true;
        }
        else
        {
            butAnim = false;
        }
        
        if (MoveZakeBigRamp.zakeLoseUpTrue || MoveZakeBigRamp.zakeLoseUp) butAnim = false;
        
        if (backFlip && butAnim && (!MoveZakeBigRamp.zakeLoseUpTrue || !MoveZakeBigRamp.zakeLoseUp))
        {
            MoveZakeBigRamp.zakeLoseUp = true;
            ChangeAnimationNonStop("TrickBackFlip");
        }
        else if (frontFlip && butAnim && (!MoveZakeBigRamp.zakeLoseUpTrue || !MoveZakeBigRamp.zakeLoseUp))
        {
            MoveZakeBigRamp.zakeLoseUp = true;
            ChangeAnimationNonStop("TrickFrontFlip");
        }

    }
}
