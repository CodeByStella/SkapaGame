using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    private bool multiTouchJump = false;
    public static bool stopBustJump;

    private void Start()
    {
        multiTouchJump = false;
        stopBustJump = false;
    }

    private void FixedUpdate()
    {
        if (!ScriptLearn.first_learn || !ScriptLearn.two_learn)
        {
            // Touch input (multi-touch)
            if (Input.touchCount > 1 && !stopBustJump)
            {
                if (HeroClassNew.extraJump <= 3)
                {
                    HeroClassNew.extraJump++;
                    stopBustJump = true;
                }
    
                if (!HeroClassNew.MoveTop && !HeroClassNew.MoveBot)
                {
                    HeroClassNew.Jump = true;
                }
                else if (HeroClassNew.Jump)
                {
                    Debug.Log("Jump 2 Ready");
                    HeroClassNew.JumpTwo = true;
                }
            }
            
            // Keyboard input (Spacebar only)
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (HeroClassNew.extraJump <= 3)
                {
                    HeroClassNew.extraJump++;
                }

                if (!HeroClassNew.MoveTop && !HeroClassNew.MoveBot)
                {
                    HeroClassNew.Jump = true;
                }
                else if (HeroClassNew.Jump)
                {
                    Debug.Log("Jump 2 Ready");
                    HeroClassNew.JumpTwo = true;
                }
            }   
        }
    }

    private void OnMouseDown()
    {
        if (!ScriptLearn.first_learn || !ScriptLearn.two_learn)
        {
            if (HeroClassNew.extraJump <= 3)
            {
                HeroClassNew.extraJump++;
            }

            if (!HeroClassNew.MoveTop && !HeroClassNew.MoveBot)
            {
                HeroClassNew.Jump = true;
            }
            else if (HeroClassNew.Jump)
            {
                Debug.Log("Jump 2 Ready");
                HeroClassNew.JumpTwo = true;
            }
        }
    }

    private void OnMouseUp()
    {
        stopBustJump = false;
    }

    private void Jump()
    {
        if (!ScriptLearn.first_learn || !ScriptLearn.two_learn)
        {
            if (HeroClassNew.extraJump <= 3)
            {
                HeroClassNew.extraJump++;
            }

            if (!HeroClassNew.MoveTop && !HeroClassNew.MoveBot)
                HeroClassNew.Jump = true;
            else if (HeroClassNew.Jump)
            {
                Debug.Log("Jump 2 Ready");
                HeroClassNew.JumpTwo = true;
            }
        }
    } 
}
