using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static PlayDeck.PlayDeckBridge;

public class ScriptLearn : MonoBehaviour
{
    public static bool learn_start, close_learn, first_learn, two_learn, three_learn, four_learn, five_learn, six_learn;

    public GameObject swipe_down, swipe_up, tap, double_tap, score_l, live_l;

    public GameObject score, score_shadow, pause, live, jump;
    public static bool isRun = true;

    private UserData _userData;
    private MethodsAPIScript _api;
    ////int dist;
    // Start is called before the first frame update
    void Start()
    {
        learn_start = false;
        first_learn = false;
        two_learn = false;
        three_learn = false;
        four_learn = false;
        five_learn = false;
        six_learn = false;
        close_learn = false;
        _api = FindObjectOfType<MethodsAPIScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UserData.GetTutorialResult() == false)
        {
            if (_api != null)
            {
                StartCoroutine(_api.CompleteTutorial());
            }
            
            if (learn_start && first_learn)
            {
                jump.SetActive(false);
                if (Move_Camera.cameraSpeed > 0.01f) Move_Camera.cameraSpeed -= 0.1f;
                if (Move_Camera.cameraSpeed <= 0.01f)
                {
                    Move_Camera.cameraSpeed = 0;
                    UIOff();
                    isRun = false;
                    swipe_down.SetActive(true);
                    if (MoveControl.botLine)
                    {
                        Move_Camera.cameraSpeed = 10;
                        UIOn();
                        isRun = true;
                        first_learn = false;
                        two_learn = true;
                        swipe_down.SetActive(false);
                    }
                }
            }
            else if (learn_start && two_learn)
            {
                if (Move_Camera.cameraSpeed > 0.01f) Move_Camera.cameraSpeed -= 0.1f;
                if (Move_Camera.cameraSpeed <= 0.01f)
                {
                    Move_Camera.cameraSpeed = 0;
                    UIOff();
                    isRun = false;
                    swipe_up.SetActive(true);
                    if (MoveControl.topLine || MoveControl.midLine)
                    {
                        Move_Camera.cameraSpeed = 10;
                        isRun = true;
                        UIOn();
                        two_learn = false;
                        three_learn = true;
                        swipe_up.SetActive(false);
                    }
                }
            }
            else if (learn_start && three_learn)
            {
                jump.SetActive(true);
                if (Move_Camera.cameraSpeed > 0.01f) Move_Camera.cameraSpeed -= 0.1f;
                if (Move_Camera.cameraSpeed <= 0.01f)
                {
                    Move_Camera.cameraSpeed = 0;
                    UIOff();
                    isRun = false;
                    tap.SetActive(true);
                    if (HeroClassNew.Jump)
                    {
                        jump.SetActive(false);
                        Move_Camera.cameraSpeed = 10;
                        isRun = true;
                        UIOn();
                        three_learn = false;
                        four_learn = true;
                        tap.SetActive(false);
                    }
                }
            }
            else if (learn_start && four_learn)
            {
                jump.SetActive(true);
                if (Move_Camera.cameraSpeed > 0.01f) Move_Camera.cameraSpeed -= 0.1f;
                if (Move_Camera.cameraSpeed <= 0.01f)
                {
                    Move_Camera.cameraSpeed = 0;
                    UIOff();
                    isRun = false;
                    double_tap.SetActive(true);
                    if (HeroClassNew.extraJump > 3)
                    {
                        isRun = true;
                        jump.SetActive(false);
                        Move_Camera.cameraSpeed = 10;
                        UIOn();
                        four_learn = false;
                        five_learn = true;
                        double_tap.SetActive(false);
                    }
                }
            }
            else if (learn_start && five_learn)
            {
                if (Move_Camera.cameraSpeed > 0.01f) Move_Camera.cameraSpeed -= 0.1f;
                if (Move_Camera.cameraSpeed <= 0.01f)
                {
                    Move_Camera.cameraSpeed = 0;
                    pause.SetActive(false);
                    live.SetActive(false);
                    isRun = false;
                    score_l.SetActive(true);
                    if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        Move_Camera.cameraSpeed = 10;
                        isRun = true;
                        UIOn();
                        five_learn = false;
                        six_learn = true;
                        score_l.SetActive(false);
                    }
                    //if (close_learn)
                    //{
                    //    close_learn = false;
                    //    Move_Camera.cameraSpeed = 10;
                    //    UIOn();
                    //    five_learn = false;
                    //    six_learn = true;
                    //    score_l.SetActive(false);
                    //}
                }
            }
            else if (learn_start && six_learn)
            {
                if (Move_Camera.cameraSpeed > 0.01f) Move_Camera.cameraSpeed -= 0.1f;
                if (Move_Camera.cameraSpeed <= 0.01f)
                {
                    Move_Camera.cameraSpeed = 0;
                    isRun = false;
                    UIOff();
                    live.SetActive(true);
                    live_l.SetActive(true);
                    if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        Move_Camera.cameraSpeed = 10;
                        isRun = true;
                        UIOn();
                        six_learn = false;
                        live_l.SetActive(false);
                        jump.SetActive(true);
                        learn_start = false;
                        PlayerPrefs.SetInt("Learn", 1);
                    }
                    //if (close_learn)
                    //{
                    //    close_learn = false;
                    //    Move_Camera.cameraSpeed = 10;
                    //    UIOn();
                    //    six_learn = false;
                    //    live_l.SetActive(false);
                    //    jump.SetActive(true);
                    //    learn_start = false;
                    //    PlayerPrefs.SetInt("Learn", 1);
                    //}
                }
            }
        }
    }
    void UIOff()
    {
        score.SetActive(false);
        score_shadow.SetActive(false);
        pause.SetActive(false);
        live.SetActive(false);
    }
    
    void UIOn()
    {
        score.SetActive(true);
        score_shadow.SetActive(true);
        pause.SetActive(true);
        live.SetActive(true);
    }
}
