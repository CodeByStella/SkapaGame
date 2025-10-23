using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BustBigRamp : MonoBehaviour
{
    public Animator anim;
    private string currentAnimation;
    public static int xn = 0;
    public static bool trickButton;

    void Start()
    {
        anim = GetComponent<Animator>();
        trickButton = false;
    }
    
    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation && currentAnimation != "x2BigRamp"  && currentAnimation != "x10BigRamp") return;

        anim.Play(animation);
        currentAnimation = animation;
    }


    void FixedUpdate()
    {
        if (ButtonTrickScript.xnButTrick == 1)
        {
            ButtonTrickScript.xnButTrick = 2;
        }
        if (xn == 2)
        {
            ChangeAnimation("x2BigRamp");
        } 
        else if (xn == 3)
        {
            ChangeAnimation("x3BigRamp");
        }
        else if (xn == 4)
        {
            ChangeAnimation("x4BigRamp");
        }
        else if (xn == 5)
        {
            ChangeAnimation("x5BigRamp");
        }
        else if (xn == 6)
        {
            ChangeAnimation("x6BigRamp");
        }
        else if (xn == 7)
        {
            ChangeAnimation("x7BigRamp");
        }
        else if (xn == 8)
        {
            ChangeAnimation("x8BigRamp");
        }
        else if (xn == 9)
        {
            ChangeAnimation("x9BigRamp");
        }
        else if (xn == 10)
        {
            ChangeAnimation("x10BigRamp");
        }
    }

    void StopAnimBust()
    {
        if (ButtonTrickScript.butAnim && trickButton) ButtonTrickScript.xnButTrick++;
        gameObject.SetActive(false);
    }
}