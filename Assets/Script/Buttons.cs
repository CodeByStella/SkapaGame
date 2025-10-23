using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Assets.Pixelation.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    //public GameObject MusOff, MusOn;
    public GameObject buyk;
    public GameObject buyl;
    public GameObject[] menuAtribute = new GameObject[6];
    public GameObject shopMenuActive;
    public GameObject BGActive;
    public Text BuyTextLvl;
    //public Text MyMoney;
    public int SumBuyLvl;
    public int MyMoneyInt;
    public GameObject StartButton;
    public GameObject TaskButton;
    public GameObject TaskWindow;
    public GameObject BuyButton;
    public static bool Shop = false;
    public static bool PromoCodeMenu = false;
    public GameObject PromoMenu;
    public Text[] ButtonBuy = new Text[8];
    private String buttonName;
    public GameObject PromoBtnMenuNotActive;
    public GameObject BigRampGo;
    public GameObject PromoBtnMenuActive;
    public GameObject bigRampMenuDublicat;
    public static GameObject BRLVL;
    public GameObject LearnBTN;
    // public GameObject loadLevel;
    public static bool PixelStart;
    public int shopSearch = 0;
    public GameObject animStart;
    public int seconds=3;
    public GameObject recMenu;
    public Image recImage;
    public Sprite school, krasnodar, lasvegas; /*MenuS, MenuK, MenuL*/
    public GameObject shirt;
    public GameObject Kubok;
    public static bool Startb = false;
    public Button Left;
    public Button Right;
    public bool mens = true, menk = false, menl = false;
    public GameObject[] records = new GameObject[3]; 
    public GameObject AudioButton, Gold, Money, ScrollTricks, ScrollCoins, ScrollSkins;
    private int _first, _second, _third, _fourth, _fifth;
    public Text _one, _two, _three, _four, _five;
    public static bool pix;
    public static bool can_swi;
    public static bool tricks, coins, skins;
    public GameObject BGRampMenu;

    private MethodsAPIScript _methodsAPIScript;


    private void Start()
    {
        coins = true;
        tricks = false;
        skins = false;
        pix = false;
        can_swi = false;
        //MusOn.SetActive(true);
        //MusOff.SetActive(false);
        // PlayerPrefs.SetInt("TrickMethod", 0);
        // PlayerPrefs.SetInt("TrickNollie", 0);
        // PlayerPrefs.SetInt("TrickNollieFlip", 0);
        // PlayerPrefs.SetInt("TrickChrist", 0);
        // PlayerPrefs.SetInt("Trick360", 0);
        // PlayerPrefs.SetInt("Trick360Christ", 0);
        // PlayerPrefs.SetInt("TrickBackFlip", 0);
        // PlayerPrefs.SetInt("TrickBenihana", 0);
        shopSearch = 0;
        // if (PlayerPrefs.GetInt("KrasnodarBuy") != 0 && PlayerPrefs.GetInt("KrasnodarBuy") != 1) PlayerPrefs.SetInt("KrasnodarBuy", 0);
        // if (PlayerPrefs.GetInt("LasVegasBuy") != 0 && PlayerPrefs.GetInt("LasVegasBuy") != 1) PlayerPrefs.SetInt("LasVegasBuy", 0);
        //SumBuyLvl = Convert.ToInt32(BuyTextLvl.text);
        //MyMoneyInt = Convert.ToInt32(MyMoney.text);
        //Debug.Log(MyMoneyInt);
        //Debug.Log(SumBuyLvl);
        Shop = false;
        PromoCodeMenu = false;
        //Button back = GetComponent<Button>();
        //buttonName = gameObject.AddComponent<Button>().name;
        //back.onClick.AddListener(BackGameMenu);
        PixelStart = false;
        // animStart.SetActive(false);
        // ControlScriptForMenu.s = false;
        // ControlScriptForMenu.l = false;
        // ControlScriptForMenu.k = false;
    }

    //private void Update()
    //{
    //    // Debug.Log(PlayerPrefs.GetInt("TrickMethod"));
    //    // Debug.Log(buttonName);
    //}

    //public void BigRamp()
    //{
    //    BRLVL.SetActive(false);
    //}

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Startbut":
                // if (ControlScriptForMenu.schoolLvl)
                // {
                //     ControlScriptForMenu.s = true;
                // }
                // else if (ControlScriptForMenu.lasvegasrLvl)
                // {
                //     ControlScriptForMenu.l = true;
                // }
                // else if (ControlScriptForMenu.krasnodarLvl)
                // {
                //     ControlScriptForMenu.k = true;
                // }

                LoadScene.loadStop = false;
                LoadScene.loadMain = false;
                //loadLevel.SetActive(true);
                //DestroyZik();
                //SceneManager.LoadScene("LoadScene");
                //StartCoroutine(LoadAsync());
                // animStart.SetActive(true);
                //SceneManager.LoadScene("Level_School");
                break;
            case "Continue":
                PlayerPrefs.SetInt("moneyOne", 0);
                PlayerPrefs.SetInt("moneyTwo", 0);
                PlayerPrefs.SetInt("moneyThree", 0);
                PlayerPrefs.SetInt("GOLDMoneySave", 3);
                Time.timeScale = 1;
                bigRampMenuDublicat.SetActive(false);
                break;
            case "BigRampLvl":
                SceneManager.LoadScene("Level_Big_Ramp_Ref");
                break;
            //case "MusOff":
            //    MusOff.SetActive(false);
            //    MusOn.SetActive(true);
            //    break;
            //case "MusOn":
            //    MusOff.SetActive(true);
            //    MusOn.SetActive(false);
            //break;
            case "BigRampGo":
                Move_Camera.cameraSpeed = 0f;
                HelicLvl.HelicBack = true;
                Move_Camera.distanceSpeed = 0;
                Time.timeScale = 1;
                PlayerPrefs.SetInt("moneyOne", 0);
                PlayerPrefs.SetInt("moneyTwo", 0);
                PlayerPrefs.SetInt("moneyThree", 0);
                PlayerPrefs.SetInt("GOLDMoneySave", 0);
                BGRampMenu.SetActive(false);
                // BRLVL.SetActive(false);
                break;
            //case "Tshirt":
            //    gameObject.SetActive(false);
            //    Shop = true;
            //    shopMenuActive.SetActive(true);
            //    BGActive.SetActive(true);
            //    BRLVL.SetActive(false);
            //    LearnBTN.SetActive(false);
            //    shopSearch++;
            //    break;
            // case "BuyLevel":
            //     if (ControlScriptForMenu.krasnodarLvl && !Shop)
            //     {
            //         SumBuyLvl = Convert.ToInt32(BuyTextLvl.text);
            //         MyMoneyInt = Convert.ToInt32(MyMoney.text);
            //         if (MyMoneyInt < SumBuyLvl)
            //         {
            //             Debug.Log("Недостаточно средств");
            //         }
            //         else
            //         {
            //             MyMoneyInt = MyMoneyInt - SumBuyLvl;
            //             PlayerPrefs.SetInt("Money", MyMoneyInt);
            //             StartButton.SetActive(true);
            //             BuyButton.SetActive(false);
            //             PlayerPrefs.SetInt("KrasnodarBuy", 1);
            //             MyMoney.text = MyMoneyInt.ToString();
            //         }
            //     }
            //     else if (ControlScriptForMenu.lasvegasrLvl && !Shop)
            //     {
            //         SumBuyLvl = Convert.ToInt32(BuyTextLvl.text);
            //         MyMoneyInt = Convert.ToInt32(MyMoney.text);
            //         if (MyMoneyInt < SumBuyLvl)
            //         {
            //             Debug.Log("Недостаточно средств");
            //         }
            //         else
            //         {
            //             MyMoneyInt = MyMoneyInt - SumBuyLvl;
            //             PlayerPrefs.SetInt("Money", MyMoneyInt);
            //             StartButton.SetActive(true);
            //             BuyButton.SetActive(false);
            //             PlayerPrefs.SetInt("LasVegasBuy", 1);
            //             MyMoney.text = MyMoneyInt.ToString();
            //         }
            //     }
            //     break;
            case "BackGameMenu":
                Shop = false;
                PromoCodeMenu = false;
                shopMenuActive.SetActive(false);
                BGActive.SetActive(false);
                ShopMenu.indexShopItem = 0;
                //TaskButton.SetActive(true);
                shirt.SetActive(true);
                break;
            case "BackShop":
                Shop = true;
                //TaskButton.SetActive(true);
                PromoCodeMenu = false;
                PromoMenu.SetActive(false);
                shopMenuActive.SetActive(true);
                break;
            case "Learn":
                PlayerPrefs.SetInt("Learn", 0);
                break;
            case "PromoCode":
                PromoCodeMenu = true;
                Shop = false;
                shopMenuActive.SetActive(false);
                PromoMenu.SetActive(true);
                PromoBtnMenuNotActive.SetActive(false);
                PromoBtnMenuActive.SetActive(true);
                break;
            case "Buy1B":
                if (PlayerPrefs.GetInt("TrickMethod") != 1 && ShopMenu.indexShopItem == 2)
                {
                    int price0 = Convert.ToInt32(ButtonBuy[0].text);
                    // MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price0)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price0;
                        PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[0].text = "Used";
                        PlayerPrefs.SetInt("TrickMethod", 1);
                        // MyMoney.text = MyMoneyInt.ToString();
                        _methodsAPIScript.PurchaseTrick(1);
                    }
                }

                if (PlayerPrefs.GetInt("Tshirt1") != 1 && ShopMenu.indexShopItem == 1)
                {
                    int price0 = Convert.ToInt32(ButtonBuy[0].text);
                    // MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price0)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price0;
                        PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[0].text = "Choose";
                        PlayerPrefs.SetInt("Tshirt1", 1);
                        // MyMoney.text = MyMoneyInt.ToString();
                    }
                }
                else if (PlayerPrefs.GetInt("Tshirt1") == 1 && ShopMenu.indexShopItem == 1)
                {
                    ButtonBuy[0].text = "Picked";
                    PlayerPrefs.SetInt("Tshirt1Pick", 1);
                    PlayerPrefs.SetInt("Tshirt2Pick", 0);
                    PlayerPrefs.SetInt("Tshirt3Pick", 0);
                    PlayerPrefs.SetInt("Tshirt4Pick", 0);
                }
                break;
            case "Buy2B":
                if (PlayerPrefs.GetInt("TrickNollie") != 1 && ShopMenu.indexShopItem == 2)
                {
                    int price1 = Convert.ToInt32(ButtonBuy[1].text);
                    // MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price1)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price1;
                        //PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[1].text = "Used";
                        //PlayerPrefs.SetInt("TrickNollie", 1);
                        // MyMoney.text = MyMoneyInt.ToString();
                        _methodsAPIScript.PurchaseTrick(2);
                    }
                }
                
                if (PlayerPrefs.GetInt("Tshirt2") != 1 && ShopMenu.indexShopItem == 1)
                {
                    int price1 = Convert.ToInt32(ButtonBuy[1].text);
                    // MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price1)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price1;
                        //PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[1].text = "Choose";
                        //PlayerPrefs.SetInt("Tshirt2", 1);
                        // MyMoney.text = MyMoneyInt.ToString();
                    }
                }
                else if (PlayerPrefs.GetInt("Tshirt2") == 1 && ShopMenu.indexShopItem == 1)
                {
                    ButtonBuy[1].text = "Picked";
                    PlayerPrefs.SetInt("Tshirt1Pick", 0);
                    PlayerPrefs.SetInt("Tshirt2Pick", 1);
                    PlayerPrefs.SetInt("Tshirt3Pick", 0);
                    PlayerPrefs.SetInt("Tshirt4Pick", 0);
                }
                break;
            case "Buy3B":
                if (PlayerPrefs.GetInt("TrickNollieFlip") != 1 && ShopMenu.indexShopItem == 2)
                {
                    int price2 = Convert.ToInt32(ButtonBuy[2].text);
                    // MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price2)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price2;
                        //PlayerPrefs.SetInt("Money", MyMoneyInt);
                        //PlayerPrefs.SetInt("TrickNollieFlip", 1);
                        ButtonBuy[1].text = "Used";
                        // MyMoney.text = MyMoneyInt.ToString();
                        _methodsAPIScript.PurchaseTrick(3);
                    }
                }
                
                if (PlayerPrefs.GetInt("Tshirt3") != 1 && ShopMenu.indexShopItem == 1)
                {
                    int price1 = Convert.ToInt32(ButtonBuy[2].text);
                    // MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price1)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price1;
                        PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[2].text = "Choose";
                        PlayerPrefs.SetInt("Tshirt3", 1);
                        // MyMoney.text = MyMoneyInt.ToString();
                    }
                }
                else if (PlayerPrefs.GetInt("Tshirt3") == 1 && ShopMenu.indexShopItem == 1)
                {
                    ButtonBuy[2].text = "Picked";
                    PlayerPrefs.SetInt("Tshirt1Pick", 0);
                    PlayerPrefs.SetInt("Tshirt2Pick", 0);
                    PlayerPrefs.SetInt("Tshirt3Pick", 1);
                    PlayerPrefs.SetInt("Tshirt4Pick", 0);
                }
                break;
            case "Buy4B":
                if (PlayerPrefs.GetInt("TrickChrist") != 1 && ShopMenu.indexShopItem == 2)
                {
                    int price1 = Convert.ToInt32(ButtonBuy[3].text);
                    // MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price1)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price1;
                        //PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[3].text = "Used";
                        //PlayerPrefs.SetInt("TrickChrist", 1);
                        // MyMoney.text = MyMoneyInt.ToString();
                        _methodsAPIScript.PurchaseTrick(4);
                    }
                }
                
                if (PlayerPrefs.GetInt("Tshirt4") != 1 && ShopMenu.indexShopItem == 1)
                {
                    int price1 = Convert.ToInt32(ButtonBuy[3].text);
                    // MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price1)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price1;
                        PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[3].text = "Choose";
                        PlayerPrefs.SetInt("Tshirt4", 1);
                        // MyMoney.text = MyMoneyInt.ToString();

                    }
                }
                else if (PlayerPrefs.GetInt("Tshirt4") == 1 && ShopMenu.indexShopItem == 1)
                {
                    ButtonBuy[3].text = "Picked";
                    PlayerPrefs.SetInt("Tshirt1Pick", 0);
                    PlayerPrefs.SetInt("Tshirt2Pick", 0);
                    PlayerPrefs.SetInt("Tshirt3Pick", 0);
                    PlayerPrefs.SetInt("Tshirt4Pick", 1);
                }
                break;
            case "Buy5B":
                if (PlayerPrefs.GetInt("Trick360") != 1 && ShopMenu.indexShopItem == 2)
                {
                    int price1 = Convert.ToInt32(ButtonBuy[4].text);
                    // MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price1)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price1;
                        //PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[4].text = "Used";
                        //PlayerPrefs.SetInt("Trick360", 1);
                        // MyMoney.text = MyMoneyInt.ToString();
                        _methodsAPIScript.PurchaseTrick(5);
                    }
                }
                break;
            case "Buy6B":
                if (PlayerPrefs.GetInt("Trick360Christ") != 1 && ShopMenu.indexShopItem == 2)
                {
                    int price1 = Convert.ToInt32(ButtonBuy[5].text);
                    // MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price1)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price1;
                        //PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[5].text = "Used";
                        //PlayerPrefs.SetInt("Trick360Christ", 1);
                        _methodsAPIScript.PurchaseTrick(6);
                        // MyMoney.text = MyMoneyInt.ToString();
                    }
                }
                break;
            case "Buy7B":
                if (PlayerPrefs.GetInt("TrickBackFlip") != 1 && ShopMenu.indexShopItem == 2)
                {
                    int price1 = Convert.ToInt32(ButtonBuy[6].text);
                    // MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price1)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price1;
                        //PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[6].text = "Used";
                        //PlayerPrefs.SetInt("TrickBackFlip", 1);
                        _methodsAPIScript.PurchaseTrick(7);
                        // MyMoney.text = MyMoneyInt.ToString();
                    }
                }
                break;
            case "Buy8B":
                if (PlayerPrefs.GetInt("TrickBenihana") != 1 && ShopMenu.indexShopItem == 2)
                {
                    
                    int price1 = Convert.ToInt32(ButtonBuy[7].text);
                    // MyMoneyInt = Convert.ToInt32(MyMoney.text);
                    if (MyMoneyInt < price1)
                    {
                        Debug.Log("Недостаточно средств");
                    }
                    else
                    {
                        MyMoneyInt = MyMoneyInt - price1;
                        //PlayerPrefs.SetInt("Money", MyMoneyInt);
                        ButtonBuy[7].text = "Used";
                        //PlayerPrefs.SetInt("TrickBenihana", 1);
                        _methodsAPIScript.PurchaseTrick(8);
                        // MyMoney.text = MyMoneyInt.ToString();
                    }
                }
                break;
        }
    }

    public void BackGameMenu()
    {
        //string nameButton = EventSystem.current.currentSelectedGameObject.name;
        //Debug.Log(nameButton + "!!!");
        Shop = false;
        shopMenuActive.SetActive(false);
        AudioButton.SetActive(true);
        TaskButton.SetActive(true);
        TaskWindow.SetActive(false);
        Gold.SetActive(true);
        Money.SetActive(true);
        StartButton.SetActive(true);
        Kubok.SetActive(true);
        shirt.SetActive(true);
    }
    public void Task()
    {
        shopMenuActive.SetActive(false);
        AudioButton.SetActive(false);
        //TaskButton.SetActive(false);
        TaskWindow.SetActive(true);
        Gold.SetActive(false);
        Money.SetActive(false);
        StartButton.SetActive(false);
        Kubok.SetActive(false);
        shirt.SetActive(false);
    }

    public void Tshirt()
    {
        AudioButton.SetActive(false);
        Gold.SetActive(false);
        TaskButton.SetActive(false);
        // Money.SetActive(false);
        StartButton.SetActive(false);
        Kubok.SetActive(false);
        shirt.SetActive(false);
        Shop = true;
        shopMenuActive.SetActive(true);
        // BGActive.SetActive(true);
        // BRLVL.SetActive(false);
        // LearnBTN.SetActive(false);
        shopSearch++;
    }
    
    public void Startbut()
    {
        TaskButton.SetActive(false);
        // Startb = true;
        LoadScene.loadMain = false;
        // LoadScene.loadStop = false;
        //ControlScriptForMenu.schoolLvl = ControlScriptForMenu.s;
        //ControlScriptForMenu.krasnodarLvl = ControlScriptForMenu.k;
        //ControlScriptForMenu.lasvegasrLvl = ControlScriptForMenu.l;
        //PlayerPrefs.SetInt("moneyOne", 0);
        //PlayerPrefs.SetInt("moneyTwo", 0);
        //PlayerPrefs.SetInt("moneyThree", 0);
        if (ControlScriptForMenu.s && !ControlScriptForMenu.l && !ControlScriptForMenu.k) 
        {
            // Debug.Log("School");
            animStart.SetActive(true);
        }
        else if(ControlScriptForMenu.k && !ControlScriptForMenu.l && !ControlScriptForMenu.s)
        {
            if (PlayerPrefs.GetInt("Kras") == 0)
            {
                // Debug.Log("Krasnodar");
                // Debug.Log("School" + ControlScriptForMenu.schoolLvl);
                // Debug.Log("Kras" + ControlScriptForMenu.krasnodarLvl);
                // Debug.Log("Las" + ControlScriptForMenu.lasvegasrLvl);
                if (MoneyGoldCount.TotalCoins >= 30) buyk.SetActive(true);
            }
            else if (PlayerPrefs.GetInt("Kras") == 1) animStart.SetActive(true);
            //else animStart.SetActive(true);
        }
        else if (ControlScriptForMenu.l && !ControlScriptForMenu.k && !ControlScriptForMenu.s)
        {
            if (PlayerPrefs.GetInt("Las") == 0)
            {
                // Debug.Log("Lasvegas");
                // Debug.Log("School" + ControlScriptForMenu.s);
                // Debug.Log("Kras" + ControlScriptForMenu.k);
                // Debug.Log("Las" + ControlScriptForMenu.l);
                if (MoneyGoldCount.TotalCoins >= 90) buyl.SetActive(true);
            }
            else if(PlayerPrefs.GetInt("Las") == 1) animStart.SetActive(true);
            //else animStart.SetActive(true);
        }
        //else
        //{
        //    Debug.Log("else");
        //    animStart.SetActive(true);s
        //}
        //Debug.Log(ControlScriptForMenu.s);
        //Debug.Log(ControlScriptForMenu.k);
        //Debug.Log(ControlScriptForMenu.l);
        //animStart.SetActive(true);
        //ControlScriptForMenu.schoolLvl = ControlScriptForMenu.s;
        //ControlScriptForMenu.krasnodarLvl = ControlScriptForMenu.k;
        //ControlScriptForMenu.lasvegasrLvl = ControlScriptForMenu.l;
        //SceneManager.LoadScene("Level_School");
    }

    public void Kubook()
    {
        recMenu.SetActive(true);
        if (ControlScriptForMenu.s)
        {
            recMenu.SetActive(true); recImage.sprite = school;
            _first = PlayerPrefs.GetInt("school1");
            _second = PlayerPrefs.GetInt("school2");
            _third = PlayerPrefs.GetInt("school3");
            _fourth = PlayerPrefs.GetInt("school4");
            _fifth = PlayerPrefs.GetInt("school5");
            //records[0].SetActive(false); records[1].SetActive(true); records[2].SetActive(false);
        }
        else if (ControlScriptForMenu.k)
        {
            recMenu.SetActive(true); recImage.sprite = krasnodar;
            _first = PlayerPrefs.GetInt("kras1");
            _second = PlayerPrefs.GetInt("kras2");
            _third = PlayerPrefs.GetInt("kras3");
            _fourth = PlayerPrefs.GetInt("kras4");
            _fifth = PlayerPrefs.GetInt("kras5");
            //records[0].SetActive(false); records[1].SetActive(true); records[2].SetActive(false);
        }
        else if (ControlScriptForMenu.l)
        {
            recMenu.SetActive(true); recImage.sprite = lasvegas;
            _first = PlayerPrefs.GetInt("las1");
            _second = PlayerPrefs.GetInt("las2");
            _third = PlayerPrefs.GetInt("las3");
            _fourth = PlayerPrefs.GetInt("las4");
            _fifth = PlayerPrefs.GetInt("las5");
            //records[0].SetActive(false); records[1].SetActive(true); records[2].SetActive(false);
        }
        _one.text = _first.ToString();
        _two.text = _second.ToString();
        _three.text = _third.ToString();
        _four.text = _fourth.ToString();
        _five.text = _fifth.ToString();
        //recMenu.SetActive(true);
        //if (PlayerPrefs.GetInt("Las") == 0)
        //{
        //    Right.interactable = false;
        //}
        //else Right.interactable = true;
        //if(PlayerPrefs.GetInt("Kras") == 0)
        //{
        //    Left.interactable = false;
        //}
        //else Left.interactable = true;
    }
    public void LeftBut()
    {
        if (records[0])
        {
            records[2].SetActive(true);
            records[1].SetActive(false);
            records[0].SetActive(false);
        }
        else if (records[1]) 
        {
            records[0].SetActive(true); 
            records[2].SetActive(false);
            records[1].SetActive(false);
        }
        else if (records[2]) 
        {
            records[1].SetActive(true);
            records[0].SetActive(false);
            records[2].SetActive(false);
        }
        //////if (MenuS)
        //////{
        //////    MenuK.SetActive(true);
        //////    Left.interactable = false;
        //////    Right.interactable = true;
        //////    MenuS.SetActive(false);
        //////    //menk = true;
        //////}
        //////else if (MenuK)
        //////{
        //////    Left.interactable = false;
        //////}
        //////else if (MenuL)
        //////{
        //////    MenuS.SetActive(true);
        //////    Left.interactable = true;
        //////    Right.interactable = true;
        //////    MenuL.SetActive(false);
        //////    //mens = true;
        //////}
        //if (mens) //kras<-school
        //{
        //    MenuK.SetActive(true);
        //    MenuS.SetActive(false);
        //    menk = true;
        //    Right.interactable = true;
        //    if (PlayerPrefs.GetInt("Las") == 0)
        //    {
        //        Left.interactable = false;
        //    }
        //    else Left.interactable = true;


        //}
        //if (menk) //las<-kras
        //{
        //    MenuL.SetActive(true);
        //    MenuK.SetActive(false);
        //    menl = true;
        //    Left.interactable = true;
        //    if (PlayerPrefs.GetInt("Kras") == 0)
        //    {
        //        Right.interactable = false;
        //    }
        //    else Right.interactable = true;


        //}
        //if (menl) //school<-las
        //{
        //    MenuS.SetActive(true);
        //    MenuL.SetActive(false);
        //    mens = true;
        //    if (PlayerPrefs.GetInt("Las") == 0)
        //    {
        //        Right.interactable = false;
        //    }
        //    else Right.interactable = true;
        //    if (PlayerPrefs.GetInt("Kras") == 0)
        //    {
        //        Left.interactable = false;
        //    }
        //    else Left.interactable = true;

        //}
    }
    public void RightBut()
    {
        if (records[0])
        {
            records[1].SetActive(true);
            records[2].SetActive(false);
            records[0].SetActive(false);
        }
        else if (records[1])
        {
            records[2].SetActive(true);
            records[0].SetActive(false);
            records[1].SetActive(false);
        }
        else if (records[2])
        {
            records[0].SetActive(true);
            records[1].SetActive(false);
            records[2].SetActive(false);
        }
        //////if (MenuS)
        //////{
        //////    MenuL.SetActive(true);
        //////    Left.interactable = true;
        //////    Right.interactable = false;
        //////    MenuS.SetActive(false);
        //////    //menl = true;
        //////}
        //////else if (MenuL)
        //////    Right.interactable = false;
        ////// else if (MenuK)
        //////{
        //////    MenuS.SetActive(true);
        //////    Left.interactable = true;
        //////    Right.interactable = true;
        //////    MenuK.SetActive(false);
        //////    //mens = true;
        //////}
        //if (mens) //school->las
        //{
        //    MenuL.SetActive(true);
        //    MenuS.SetActive(false);
        //    menl = true;
        //    Left.interactable = true;
        //    if (PlayerPrefs.GetInt("Kras") == 0)
        //    {
        //        Right.interactable = false;
        //    }
        //    else Right.interactable = true;

        //}
        //if (MenuK) //kras->school
        //{
        //    MenuS.SetActive(true);
        //    MenuK.SetActive(false);
        //    mens = true;
        //    if (PlayerPrefs.GetInt("Kras") == 0)
        //    {
        //        Left.interactable = false;
        //    }
        //    else Left.interactable = true;
        //    if (PlayerPrefs.GetInt("Las") == 0)
        //    {
        //        Right.interactable = false;
        //    }
        //    else Right.interactable = true;

        //}
        //if (MenuL) //las->kras
        //{
        //    MenuK.SetActive(true);
        //    if (PlayerPrefs.GetInt("Las") == 0)
        //    {
        //        Left.interactable = false;
        //    }
        //    else Left.interactable = true;
        //    Right.interactable = true;
        //    MenuL.SetActive(false);
        //}
    }

    public void Back()
    {
        recMenu.SetActive(false);
    }

    // void DestroyZik()
    // {
    //     GameObject zikMain = GameObject.FindGameObjectWithTag("ZikMain");
    //     Destroy(zikMain);
    // }
    public void Tricks()
    {
        // Debug.Log("Tricks");
        tricks = true;
        skins = false;
        coins = false;
        ScrollTricks.SetActive(true);
        ScrollCoins.SetActive(false);
        ScrollSkins.SetActive(false);
    }
    public void Coins()
    {
        // Debug.Log("Coins");
        tricks = false;
        skins = false;
        coins = true;
        ScrollTricks.SetActive(false);
        ScrollCoins.SetActive(true);
        ScrollSkins.SetActive(false);
    }
    public void Skins()
    {
        // Debug.Log("Skins");
        tricks = false;
        skins = true;
        coins = false;
        ScrollTricks.SetActive(false);
        ScrollCoins.SetActive(false);
        ScrollSkins.SetActive(true);
    }
    
    public void Pixel()
    {
        pix = !pix;
    }

    private void FixedUpdate()
    {
        if (Shop && shopSearch == 1)
        {
            // PromoBtnMenuNotActive.SetActive(true);
            // PromoBtnMenuActive.SetActive(false);
            shopMenuActive.SetActive(true);
            // PromoMenu.SetActive(false);
        }
    }

    public void SwitchDisplay()
    {
        can_swi = !can_swi;
    }

    public void TshirtScr()
    {
        // Debug.Log("работает");
        // ButtonScr();
        // Debug.Log (this.gameObject.name);
    }

    private void ButtonScr()
    {
        if (gameObject.transform.name == "Buy1B" && skins)
        {
            // Debug.Log("Buy1B");
            Text childText = gameObject.GetComponentInChildren<Text>();
            childText.text = "Unselected";
        }
        else if (gameObject.transform.name == "Buy2B" && skins)
        {
            // Debug.Log("Buy2B");
            Text childText = gameObject.GetComponentInChildren<Text>();
            childText.text = "Unselected";
        }
        else if (gameObject.transform.name == "Buy3B" && skins)
        {
            // Debug.Log("Buy3B");
            Text childText = gameObject.GetComponentInChildren<Text>();
            childText.text = "Unselected";
        }
        else if (gameObject.transform.name == "Buy4B" && skins)
        {
            // Debug.Log("Buy4B");
            Text childText = gameObject.GetComponentInChildren<Text>();
            childText.text = "Unselected";
        }
    }
    


    // IEnumerator LoadAsync()
    // {
    //     // if (ControlScriptForMenu.krasnodarLvl && !Shop) SceneManager.LoadScene("Level_Krasnodar");
    //     // else if (ControlScriptForMenu.lasvegasrLvl && !Shop) SceneManager.LoadScene("Level_LasVegas");
    //     // else if (ControlScriptForMenu.schoolLvl && !Shop) SceneManager.LoadScene("Level_School");
    //     if (ControlScriptForMenu.krasnodarLvl && !Shop)
    //     {
    //         AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level_Krasnodar");
    //         while (!asyncLoad.isDone)
    //         {
    //             yield return null;
    //         }
    //     }
    //     else if (ControlScriptForMenu.lasvegasrLvl && !Shop)
    //     {
    //         AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level_LasVegas");
    //         while (!asyncLoad.isDone)
    //         {
    //             yield return null;
    //         }
    //     }
    //     else if (ControlScriptForMenu.schoolLvl && !Shop)
    //     {
    //         AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level_School");
    //         while (!asyncLoad.isDone)
    //         {
    //             yield return null;
    //         }
    //     }
    // }
}
