using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

public class MoveZakeBigRamp : MonoBehaviour
{
    public static bool zakeStartBigRamp;
    public static bool zakeDownBigRamp;
    public static bool zakeMidBigRamp;
    public static bool zakeUpBigRamp;
    public static bool zakeJumpUpBigRamp;
    public static bool zakeJumpDownBigRamp;
    public static bool zakeDownRamp;
    public static bool zakeMidRamp;
    public static bool zakeUpRamp;
    private int scenCountBigRamp = 0;
    public static float downParam = -0.01f;
    private float upParam = 1.9f;
    private int liveBR = 3;
    public GameObject cameraMove;
    private List <String> allTrickInGame = new List<string>();
    public Animator anim;
    private string currentAnimation;
    public static int countRamp = 0;
    private float cameraPositionControl = 1.4f;
    private static int pauseCam = 0;
    public static bool pauseCamBool = false;
    public static bool zakeFinalUpRamp;
    public static bool zakeBackRamp;
    public static bool zakeFinalRamp;
    public static bool rampOne;
    public static bool rampTwo;
    public static bool zakeLoseDownPlay;
    public static bool zakeLoseNotPower;
    public static bool zakeLoseNotPowerPlay;
    public static bool zakeDownAndMidBigRamp;
    public static bool zakeMidAndUpBigRamp;
    public static bool zakeDownAndMidRamp;
    public static bool zakeMidAndUpRamp;

    public static bool zakeLoseDown;
    public static bool zakeLoseUp;
    public static bool zakeLoseUpTrue;
    public GameObject bustX;

    void Start()
    {
        zakeStartBigRamp = true;
        zakeDownBigRamp = false;
        zakeMidBigRamp = false;
        zakeUpBigRamp = false;
        zakeJumpUpBigRamp = false;
        zakeJumpDownBigRamp = false;
        zakeDownRamp = false;
        zakeMidRamp = false;
        zakeUpRamp = false;
        zakeFinalUpRamp = false;
        zakeBackRamp = false;
        zakeLoseDownPlay = false;
        zakeLoseNotPower = false;
        zakeLoseNotPowerPlay = false;
        zakeLoseUpTrue = false;
        zakeDownAndMidBigRamp = false;
        zakeMidAndUpBigRamp = false;
        zakeDownAndMidRamp = false;
        zakeMidAndUpRamp = false;
        anim = GetComponent<Animator>();
        ChangeAnimation("Hello");
        pauseCamBool = false;
        zakeFinalRamp = zakeBackRamp;
        pauseCam = 0;
        countRamp = 0;
        rampOne = false;
        rampTwo = false;
        liveBR = 3;
    }

    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation && currentAnimation != "Slide") return;

        anim.Play(animation);
        currentAnimation = animation;
    }

    void FixedUpdate()
    {
        pauseCam++;
        
        if (MoveCameraBigRamp.cameraBoolStart)
        {
            ScriptPower.bigRampStart = false;
        }
        
        if (pauseCam == 300)
        {
            pauseCamBool = true;
            Debug.Log("TRUE");
        }
        
        if (ScriptPower.bigRampStart)
        {
            if (zakeStartBigRamp)
            {
                // ChangeAnimation("Start");
                ChangeAnimation("Slide");
                ScenMove(0f, -2f, 43, -120f, 22);
            } 
            else if (zakeDownBigRamp)
            {
                ChangeAnimation("Slide");
                ScenMove(2f, -2.8f, 60, 0f, 0);
            } 
            else if (zakeDownAndMidBigRamp)
            {
                ScenMove(3f, -1.2f, 11, 240f, 11);
            }
            else if (zakeMidBigRamp)
            {
                ScenMove(3f, 0f, 16, 0f, 0);
            } 
            else if (zakeMidAndUpBigRamp)
            {
                ScenMove(2.8f, 1.2f, 11, 240f, 11);
            }
            else if (zakeUpBigRamp)
            {
                ScenMove(2f, 2.8f, 18, 0f, 0);
            }
            else if (zakeJumpUpBigRamp && countRamp == 0)
            {
                // ChangeAnimation("Slide");
                ScenMove(2.51f, 2.51f, 335, -14f, 335);
            }
            else if (zakeJumpUpBigRamp &&  countRamp == 1)
            {
                // ChangeAnimation("Slide");
                ScenMove(2.5f, 2.48f, 335, -14f, 335);
            }
            else if (zakeJumpUpBigRamp && countRamp == 2)
            {
                // ChangeAnimation("Slide");
                ScenMove(2.8f, 2.4f, 295, -17f, 295);
            }
            else if (zakeDownRamp)
            {
                ChangeAnimation("Slide");
                if (countRamp != 3)
                {
                    ScenMove(2f, -1.9f, 53, 0f, 0);   
                }
                else
                {
                    ScenMove(2f, -1.9f, 57, 0f, 0);
                }
                if (!rampOne && countRamp == 1)
                {
                    ScriptPower.continuePower = false;  
                    Time.timeScale = 0.4f;
                } 
                else if (!rampTwo && countRamp == 2)
                {
                    ScriptPower.continuePower = false;  
                    Time.timeScale = 0.4f;
                }
            } 
            else if (zakeDownAndMidRamp)
            {
                if (countRamp != 3)
                {
                    ScenMove(3f, -1.2f, 12, 240f, 8);   
                }
                else
                {
                    ScenMove(3f, -1.2f, 12, 240f, 10);
                }
            }
            else if (zakeMidRamp && (countRamp == 0 || countRamp == 1 || countRamp == 2))
            {
                ScenMove(3f, 0f, 22, 0f, 0);
                Time.timeScale = 1f;
                ScriptPower.continuePower = true;
            }
            else if (zakeMidRamp && countRamp == 3)
            {
                ScenMove(3f, 0f, 45, 0f, 0);
                Time.timeScale = 1f;
            }
            else if (zakeMidAndUpRamp)
            {
                if (countRamp != 2)
                {
                    ScenMove(2.8f, 1.2f, 11, 240f, 11);   
                }
                else
                {
                    ScenMove(2.8f, 1.2f, 12, 240f, 12); 
                }
            }
            else if (zakeUpRamp)
            {
                if (countRamp != 3)
                {
                    ScenMove(2f, 2.8f, 20, 0f, 0);   
                }
                else
                {
                    ScenMove(2f, 2.8f, 15, 0f, 0);  
                }
            }
            else if (zakeFinalUpRamp)
            {
                ScenMove(0f, 2.1f, 280, 120f, 18);
            }
            else if (zakeBackRamp)
            {
                ChangeAnimation("Slide");
                ScenMove(-2f, -2.8f, 18, -180f, 14);
            } 
            else if (zakeFinalRamp)
            {
                ChangeAnimation("End");
                ScenMove(-3f, 0f, 50, -120f, 20);
            } 
            else if (zakeLoseDown)
            {
                ScenMove(2.2f, 2.2f, 325, -14f, 325);
            } 
            else if (zakeLoseUp)
            {
                ChangeAnimation("FalseHightPower");
                gameObject.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
                ScenMove(2f, -1.8f, 60, 120f, 20);
            }
            else if (zakeLoseDownPlay)
            {
                ChangeAnimation("FalseLowPower");
                gameObject.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
                ScenMove(-0.5f, -2.5f, 50, 50f, 50);
            } 
            else if (zakeLoseNotPower)
            {
                ChangeAnimation("FalseNotPower");
                gameObject.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
                ScenMove(1f, 0.5f, 50, -50f, 50);
            } 
            else if (zakeLoseNotPowerPlay)
            {
                ScenMove(0f, -3f, 80, 0f, 0);
            }
            // else if (zakeJumpDownBigRamp)
            // {
            //     ScenMove(2f, -2f, 250);
            // }
        }
        
    }

    public void ScenMove(float x, float y, int countMoveSwap, float zRotation, int countRotate)
    {
        bustX.transform.position += new Vector3(x * Time.deltaTime, 0f, 0f);
        if (zakeJumpUpBigRamp || zakeFinalUpRamp || (zakeLoseDown && !zakeDownRamp && !zakeMidRamp && !zakeUpRamp && !zakeDownBigRamp && !zakeMidBigRamp && !zakeUpBigRamp &&!zakeStartBigRamp))
        {
            downParam += -0.015f;
            gameObject.transform.position += new Vector3(x * Time.deltaTime, (y + downParam) * Time.deltaTime);
            if (scenCountBigRamp <= countRotate) gameObject.transform.Rotate(new Vector3(0f, 0f, zRotation) * Time.deltaTime);
            if (pauseCamBool) cameraMove.transform.position += new Vector3(x * Time.deltaTime, 0f);
        }
        else if (zakeFinalRamp)
        {
            downParam += -0.05f;
            gameObject.transform.position += new Vector3((x - downParam) * Time.deltaTime, 0f);
            if (scenCountBigRamp <= countRotate) gameObject.transform.Rotate(new Vector3(0f, 0f, zRotation) * Time.deltaTime);
            // if (pauseCamBool) cameraMove.transform.position += new Vector3((x - 1) * Time.deltaTime, 0f);
        }
        else
        {
            gameObject.transform.position += new Vector3(x * Time.deltaTime, y * Time.deltaTime);
                if (scenCountBigRamp >= (countMoveSwap - countRotate)) gameObject.transform.Rotate(new Vector3(0f, 0f, zRotation) * Time.deltaTime);
                if (cameraMove.transform.position.y <= -1.8f)
                {
                    if (pauseCamBool && cameraMove.transform.position.x <= 57.4f && !zakeBackRamp) 
                        cameraMove.transform.position += new Vector3(x * Time.deltaTime, 0f);
                } 
                else if (cameraMove.transform.position.y > -1.8f)
                {
                    if (pauseCamBool && cameraMove.transform.position.x <= 57.4f && !zakeBackRamp)
                        cameraMove.transform.position += new Vector3(x * Time.deltaTime, y / 1.4f * Time.deltaTime);
                }
        }
        scenCountBigRamp++;
        if (scenCountBigRamp == countMoveSwap)
        {
            if (zakeStartBigRamp)
            {
                zakeStartBigRamp = false;
                zakeDownBigRamp = true;
            }
            else if (zakeDownBigRamp)
            {
                zakeDownBigRamp = false;
                zakeDownAndMidBigRamp = true;
            }
            else if (zakeDownAndMidBigRamp)
            {
                zakeDownAndMidBigRamp = false;
                zakeMidBigRamp = true;
            }
            else if (zakeMidBigRamp)
            {
                zakeMidBigRamp = false;
                zakeMidAndUpBigRamp = true;
            } 
            else if (zakeMidAndUpBigRamp)
            {
                zakeMidAndUpBigRamp = false;
                zakeUpBigRamp = true;
            }
            else if (zakeUpBigRamp)
            {
                zakeUpBigRamp = false;
                if (!zakeLoseDown)
                {
                    zakeJumpUpBigRamp = true;   
                }
            } 
            else if (zakeJumpUpBigRamp)
            {
                zakeJumpUpBigRamp = false;
                
                if (!zakeLoseUp && !zakeLoseUpTrue)
                {
                    zakeDownRamp = true; 
                }
                else
                {
                    zakeLoseUp = true;
                }
                countRamp++;
            }
            else if (zakeDownRamp)
            {
                zakeDownRamp = false;
                zakeDownAndMidRamp = true;
                BustBigRamp.xn = 0;
                ButtonTrickScript.xnButTrick = BustBigRamp.xn;
            }
            else if (zakeDownAndMidRamp)
            {
                zakeDownAndMidRamp = false;
                zakeMidRamp = true;
            }
            else if (zakeMidRamp)
            {
                zakeMidRamp = false;
                zakeMidAndUpRamp = true;
            } 
            else if (zakeMidAndUpRamp)
            {
                zakeMidAndUpRamp = false;
                zakeUpRamp = true;
            }
            else if (zakeUpRamp && countRamp != 3)
            {
                zakeUpRamp = false;
                if (countRamp == 1 && rampOne)
                {
                    zakeJumpUpBigRamp = true;  
                } 
                else if (countRamp == 2 && rampTwo)
                {
                    zakeJumpUpBigRamp = true;
                }
                else if (countRamp == 3)
                {
                    zakeJumpUpBigRamp = true;
                }
                else
                {
                    zakeLoseNotPower = true;
                }
            }
            else if (zakeUpRamp && countRamp == 3)
            {
                zakeUpRamp = false;
                zakeFinalUpRamp = true;
            }
            else if (zakeFinalUpRamp)
            {
                zakeFinalUpRamp = false;
                zakeBackRamp = true;

            } 
            else if (zakeBackRamp)
            {
                zakeBackRamp = false;
                zakeFinalRamp = true;
                BustBigRamp.xn = 0;
            }
            else if (zakeFinalRamp)
            {
                zakeFinalRamp = false;
                BustBigRamp.xn = 0;
                SceneManager.LoadScene("Main_Menu");
            }
            else if (zakeLoseUp)
            {
                zakeLoseUpTrue = true;
                zakeLoseUp = false;
                BustBigRamp.xn = 0;
                SceneManager.LoadScene("Main_Menu");
            } 
            else if (zakeLoseDown)
            {
                zakeLoseDown = false;

                zakeLoseDownPlay = true;
                BustBigRamp.xn = 0;
            }
            else if (zakeLoseDownPlay)
            {
                zakeLoseDownPlay = false;
                BustBigRamp.xn = 0;
                if (MoveCameraBigRamp.lifeCoin != 0)
                {
                    GoCar.goSaveZik = true;
                }
                else
                {
                    SceneManager.LoadScene("Main_Menu");
                }
            }
            else if (zakeLoseNotPower)
            {
                zakeLoseNotPower = false;
                zakeLoseNotPowerPlay = true;
                BustBigRamp.xn = 0;
            }
            else if (zakeLoseNotPowerPlay)
            {
                zakeLoseNotPowerPlay = false;
                BustBigRamp.xn = 0;
                SceneManager.LoadScene("Main_Menu");
            }
            scenCountBigRamp = 0;
            downParam = -0.01f;
        } 
    }
}
