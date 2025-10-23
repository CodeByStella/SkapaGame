using System;
using Assets.Pixelation.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMain : MonoBehaviour
{
    private string currentAnimation;
    public Animator anim;
    public static bool pixel;
    public static bool bganim, bgswipe;
    public GameObject bgPod;

    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation) return;

        // BGduplicate(animation);
        anim.Play(animation);
        currentAnimation = animation;
    }

    void Start()
    {
        pixel = false;
        bganim = false;
        bgswipe = false;
        ChangeAnimation("LLRSc");
    }


    void FixedUpdate()
    {
        if (!ControlScriptForMenu.swipeActive)
        {
            Buttons.can_swi = true;
        }
        else
        {
            Buttons.can_swi = false;
        }
        if (!ControlScriptForMenu.swipeActive && !Pixelation.shdplus)
        {
            Pixelation.shdplus = true;
        }
        else if (ControlScriptForMenu.swipeActive && Pixelation.BlockCount >= 600.0f && Pixelation.shdplus)
        {
            Pixelation.shdplus = false;
        }
        ///
        if (ControlScriptForMenu.swipeActive)
        {
            if (ControlScriptForMenu.schoolLvl && ControlScriptForMenu.swipeLeft)
            {
                ChangeAnimation("RLRSc");
                ControlScriptForMenu.swipeActive = false;
            }
            else if (ControlScriptForMenu.schoolLvl && ControlScriptForMenu.swipeRight)
            {
                ChangeAnimation("LRLSc");
                ControlScriptForMenu.swipeActive = false;
            }
            else if (ControlScriptForMenu.krasnodarLvl && ControlScriptForMenu.swipeLeft)
            {
                ChangeAnimation("RLRKras");
                ControlScriptForMenu.swipeActive = false;
            }
            else if (ControlScriptForMenu.krasnodarLvl && ControlScriptForMenu.swipeRight)
            {
                ChangeAnimation("LRLKras");
                ControlScriptForMenu.swipeActive = false;
            }
            else if (ControlScriptForMenu.lasvegasrLvl && ControlScriptForMenu.swipeLeft)
            {
                ChangeAnimation("RLRLv");
                ControlScriptForMenu.swipeActive = false;
            }
            else if (ControlScriptForMenu.lasvegasrLvl && ControlScriptForMenu.swipeRight)
            {
                ChangeAnimation("LRLLv");
                ControlScriptForMenu.swipeActive = false;
            }
        }
        
        SwipeAnimation();

        // if (ScriptPod.activeBg)
        // {
        //     bgPod.SetActive(true);
        // }
        // else
        // {
        //     bgPod.SetActive(false);
        // }
    }

    void SwipeAnimation()
    {
        if (currentAnimation == "LLRKras" && bgswipe || currentAnimation == "RRLKras" && bgswipe)
        {
            grayscale.materialSwap = true;
            pixel = false;
            ChangeAnimation("KrasStat");
            ControlScriptForMenu.swipeActive = true;
            ControlScriptForMenu.krasnodarLvl = true;
            ControlScriptForMenu.schoolLvl = false;
            ControlScriptForMenu.lasvegasrLvl = false;
            ControlScriptForMenu.swipeLeft = false;
            ControlScriptForMenu.swipeRight = false;
            bgswipe = false; 
        }
        else if (currentAnimation == "LRLKras" && bganim)
        {
            pixel = true;
            ChangeAnimation("RRLLv");
            SPMain.SPKras = false;
            SPMain.SPSc = false;
            SPMain.SPLv = true;

        }
        else if (currentAnimation == "RLRKras"  && bganim)
        {
            pixel = true;
            ChangeAnimation("LLRSc");
            SPMain.SPKras = false;
            SPMain.SPSc = true;
            SPMain.SPLv = false;
        }
        else if (currentAnimation == "LLRSc" && bgswipe || currentAnimation == "RRLSc"  && bgswipe)
        {
            grayscale.materialSwap = false;
            pixel = false;
            ChangeAnimation("ScStat");
            ControlScriptForMenu.swipeActive = true;
            ControlScriptForMenu.krasnodarLvl = false;
            ControlScriptForMenu.schoolLvl = true;
            ControlScriptForMenu.lasvegasrLvl = false;
            ControlScriptForMenu.swipeLeft = false;
            ControlScriptForMenu.swipeRight = false;
            bgswipe = false; 
        }
        else if (currentAnimation == "LRLSc" && bganim)
        {
            pixel = true;
            ChangeAnimation("RRLKras");
            SPMain.SPKras = true;
            SPMain.SPSc = false;
            SPMain.SPLv = false;
        }
        else if (currentAnimation == "RLRSc" && bganim)
        {
            pixel = true;
            ChangeAnimation("LLRLv");
            SPMain.SPKras = false;
            SPMain.SPSc = false;
            SPMain.SPLv = true;
        }
        else if (currentAnimation == "LLRLv" && bgswipe || currentAnimation == "RRLLv" && bgswipe)
        {
            grayscale.materialSwap = true;
            pixel = false;
            ChangeAnimation("LvStat");
            ControlScriptForMenu.swipeActive = true;
            ControlScriptForMenu.krasnodarLvl = false;
            ControlScriptForMenu.schoolLvl = false;
            ControlScriptForMenu.lasvegasrLvl = true;
            ControlScriptForMenu.swipeLeft = false;
            ControlScriptForMenu.swipeRight = false;
            bgswipe = false; 
        }
        else if (currentAnimation == "LRLLv" && bganim)
        {
            pixel = true;
            ChangeAnimation("RRLSc");
            SPMain.SPKras = false;
            SPMain.SPSc = true;
            SPMain.SPLv = false;
        }
        else if (currentAnimation == "RLRLv" && bganim)
        {
            pixel = true;
            ChangeAnimation("LLRKras");
            SPMain.SPKras = true;
            SPMain.SPSc = false;
            SPMain.SPLv = false;
        }
    }

    void BGstop()
    {
        bganim = false;
        bgswipe = true;
    }

    void BGactive()
    {
        bganim = true;
    }

    void BlikSc()
    {
        ScriptPod.school = true;
    }
    
    void BlikLas()
    {
        ScriptPod.lasv = true;
    }
    
    void BlikKras()
    {
        ScriptPod.krasn = true;
    }

    void ActivePod()
    {
        // ScriptPod.activeBg = true;
    }

    // void BGduplicate(String name)
    // {
    //     if (gameObject.transform.name == "BGALL")
    //     {
    //         ChangeAnimation(name);
    //     }
    // }
}
