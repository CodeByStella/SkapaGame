using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Pixelation.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class ControlScriptForMenu : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public static bool krasnodarLvl = false;
    public static bool schoolLvl = true;
    public static bool lasvegasrLvl = false;
    public static bool swipeLeft = false;
    public static bool swipeRight = false;
    public static bool swipeActive = true;
    public static bool s = false;
    public static bool k = false;
    public static bool l = false;
    public Material BWS;
    public Image BGM;
    public Image StartButton;
    public Sprite SStart;
    public Sprite KrasLock;
    public Sprite Kras;
    public Sprite LasLock;
    public Sprite Las;
    public Sprite Soon;
    Camera camera1;



    private void Start()
    {
        schoolLvl = true;
        lasvegasrLvl = false;
        krasnodarLvl = false;
        swipeActive = true;
        // PlayerPrefs.SetInt("Kras", 0);
        // PlayerPrefs.SetInt("Las", 0);
        camera1 = GetComponent<Camera>();
    }

    //private void Awake()
    //{
    //    schoolLvl = true;
    //    lasvegasrLvl = false;
    //    krasnodarLvl = false;
    //}

    // void Update()
    // {
    //     //if(Buylvl.isBought) BGM.material = null;
    //     //if (Buylvl.isBought) Buylvl.isBought = false;
    // }

    private void Update()
    {
        if (!swipeActive)
        {
            Pixelation scriptToDisable = gameObject.GetComponent<Pixelation>();
            scriptToDisable.enabled = true;
        }
        else if (swipeActive && Pixelation.BlockCount >= 600f)
        {
            Pixelation scriptToDisable = gameObject.GetComponent<Pixelation>();
            scriptToDisable.enabled = false;   
        }

        // if (Buttons.can_swi)
        // {
        //     camera.targetDisplay = 2;   
        // }
        // else
        // {
        //     camera.targetDisplay = 0;
        // }
    }
    
    void CameraTargetDisplay (int target) {
        camera1.targetDisplay = target;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.x > 0)
            {
                if (!swipeRight && krasnodarLvl && !Buttons.Shop && swipeActive)
                {
                    // Instantiate(backGround[2], new Vector3(-329f, 790.9656f, -490.3669f), Quaternion.identity);
                    swipeRight = true;
                    schoolLvl = false;
                    lasvegasrLvl = false;
                    krasnodarLvl = true;
                    s = false;
                    l = true;
                    k = false;
                    // Debug.Log("class");
                    // Debug.Log(s + "s");
                    // Debug.Log(k + "k");
                    // Debug.Log(l + "l");

                    // Debug.Log(MoneyGoldCount.TotalCoins);
                    if (PlayerPrefs.GetInt("Las") == 0)
                    {
                        //BGM.material = BWS;
                        if(MoneyGoldCount.TotalCoins < 90)
                        {
                            // StartButton.sprite = LasLock;
                            StartButton.sprite = Soon;
                        }
                        // else StartButton.sprite = Las;
                        else StartButton.sprite = Soon;
                    }
                    if (PlayerPrefs.GetInt("Las") == 1)
                    {
                        StartButton.sprite = SStart;
                        //BGM.material = null;
                    }
                }
                else if (!swipeRight && schoolLvl && !Buttons.Shop && swipeActive)
                {
                    // Instantiate(backGround[1], new Vector3(-422f, 26.0934f, 27.6826f), Quaternion.identity);
                    swipeRight = true;
                    schoolLvl = true;
                    lasvegasrLvl = false;
                    krasnodarLvl = false;
                    s = false;
                    l = false;
                    k = true;
                    // Debug.Log("class");
                    // Debug.Log(s + "s");
                    // Debug.Log(k + "k");
                    // Debug.Log(l + "l");
                    if (PlayerPrefs.GetInt("Kras") == 0)
                    {
                        //BGM.material = BWS;
                        if (MoneyGoldCount.TotalCoins < 90)
                        {
                            // StartButton.sprite = KrasLock;
                            StartButton.sprite = Soon;
                        }
                        // else StartButton.sprite = Kras;  
                        else StartButton.sprite = Soon;
                    }       
                    if (PlayerPrefs.GetInt("Kras") == 1)
                    {
                        //BGM.material = null;
                        StartButton.sprite = SStart;
                    }
                }
                else if (!swipeRight && lasvegasrLvl && !Buttons.Shop && swipeActive)
                {
                    // Instantiate(backGround[0], new Vector3(-824f, 40.2057f, 73.30154f), Quaternion.identity);
                    swipeRight = true;
                    schoolLvl = false;
                    lasvegasrLvl = true;
                    krasnodarLvl = false;
                    s = true;
                    l = false;
                    k = false;
                    // Debug.Log("class");
                    // Debug.Log(s + "s");
                    // Debug.Log(k + "k");
                    // Debug.Log(l + "l");
                    StartButton.sprite = SStart;
                    //BGM.material = null;
                }
            }
            else
            {
                if (!swipeLeft && krasnodarLvl && !Buttons.Shop && swipeActive)
                {
                    swipeLeft = true;
                    schoolLvl = false;
                    lasvegasrLvl = false;
                    krasnodarLvl = true;
                    s = true;
                    l = false;
                    k = false;
                    // Debug.Log("class");
                    // Debug.Log(s + "s");
                    // Debug.Log(k + "k");
                    // Debug.Log(l + "l");
                    StartButton.sprite = SStart;
                    //BGM.material = null;
                }
                else if (!swipeLeft && schoolLvl && !Buttons.Shop && swipeActive)
                {
                    swipeLeft = true;
                    schoolLvl = true;
                    lasvegasrLvl = false;
                    krasnodarLvl = false;
                    s = false;
                    l = true;
                    k = false;
                    // Debug.Log("class");
                    // Debug.Log(s + "s");
                    // Debug.Log(k + "k");
                    // Debug.Log(l + "l");
                    if (PlayerPrefs.GetInt("Las") == 0)
                    {
                        //BGM.material = BWS;
                        if (MoneyGoldCount.TotalCoins < 90)
                        {
                            // StartButton.sprite = LasLock;
                            StartButton.sprite = Soon;
                        }
                        // else StartButton.sprite = Las;
                        else StartButton.sprite = Soon;
                    }
                    if (PlayerPrefs.GetInt("Las") == 1)
                    {
                        StartButton.sprite = SStart;
                        //BGM.material = null;
                    }
                }
                else if (!swipeLeft && lasvegasrLvl && !Buttons.Shop && swipeActive)
                {
                    swipeLeft = true;
                    schoolLvl = false;
                    lasvegasrLvl = true;
                    krasnodarLvl = false;
                    s = false;
                    l = false;
                    k = true;
                    // Debug.Log("class");
                    // Debug.Log(s + "s");
                    // Debug.Log(k + "k");
                    // Debug.Log(l + "l");
                    if (PlayerPrefs.GetInt("Kras") == 0)
                    {
                        //BGM.material = BWS;
                        if (MoneyGoldCount.TotalCoins < 30)
                        {
                            // StartButton.sprite = KrasLock;
                            StartButton.sprite = Soon;
                        }
                        // else StartButton.sprite = Kras;
                        else StartButton.sprite = Soon;
                    }
                    if (PlayerPrefs.GetInt("Kras") == 1)
                    {
                        //BGM.material = null;
                        StartButton.sprite = SStart;
                    }
                }
            }

        }
        else if ((Mathf.Abs(eventData.delta.x)) < (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.y > 0)
            {
            }
            else
            {
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}