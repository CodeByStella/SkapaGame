using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BustLvl : MonoBehaviour
{
    public Animator anim;
    private string currentAnimation;
    public static bool x2;
    public static bool x3;
    public static bool x4;
    public static bool x5;
    public static int xn = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        x2 = false;
        x3 = false;
        x4 = false;
        x5 = false;
    }
    
    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation && currentAnimation != "x2"  && currentAnimation != "x5") return;

        anim.Play(animation);
        currentAnimation = animation;
    }


    void FixedUpdate()
    {
        if (xn == 2)
        {
            ChangeAnimation("x2");
        } 
        else if (xn == 3)
        {
            ChangeAnimation("x3");
        }
        else if (xn == 4)
        {
            ChangeAnimation("x4");
        }
        else if (xn == 5)
        {
            ChangeAnimation("x5");
        }
    }

    void StopAnimBust()
    {
        gameObject.SetActive(false);
    }
}
