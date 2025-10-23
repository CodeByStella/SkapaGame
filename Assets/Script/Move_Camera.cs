using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using System.Collections;
using UnityEngine.SceneManagement;

public class Move_Camera : MonoBehaviour
{
    [SerializeField]
    [Header("Скорость камеры")] public static float cameraSpeed = 10f;
    [Header("Сохранение скорости камеры")] public static float cameraSpeedCopy = 0f;
    [Header("Обычный бекграунд")] public GameObject[] background1 = new GameObject[1];
    [Header("Обычный бекграунд краснодар")] public GameObject[] backgroundv = new GameObject[1];
    [Header("Обычный бекграунд вегас")] public GameObject[] backgroundl = new GameObject[1];
    [Header("Координаты бека")] public float coordinate = 67.12f;
    [Header("Препятствия")] public GameObject[] obstacles = new GameObject[6];
    [Header("Монетки")] public GameObject money;
    [Header("Монетка 1")] public GameObject moneyOne;
    [Header("Монетка 2")] public GameObject moneyTwo;
    [Header("Монетка 3")] public GameObject moneyThree;
    [Header("Меню биг рамп")] public GameObject bigRampMenu;
    [Header("Счет монет")] public Text moneyScore;
    [Header("Счет дистанции")] public Text distanceScore;
    [Header("Счет дистанции")] public Text distanceScoreBack;
    [Header("Зиа")] public GameObject[] Zia = new GameObject[3];
    [Header("Буст растояние")] public GameObject[] BustRace = new GameObject[3];
    [Header("Зиа активация")] public bool Zia1000 = true;
    [Header("Зиа активация")] public bool Zia2000 = true;
    [Header("Зиа активация")] public bool Zia3000 = true;
    [Header("Огонь")] public GameObject fire;
    public static int road, moneyChance, moneyForUpLvl;
    public int numObstacles;
    public GameObject ShootFoto;

    private Vector2 scale;
    private Vector2 position;
    private int sort;
    public static int count = 0;
    public static int distanceCount = 0;
    public static int distanceSpeed = 1;
    public int countDistanceCopy = 0;
    private Vector2 scaleMoney;
    private Vector2 positionMoney;
    private Vector2 positionMoneyTop;
    private int randomBG;
    public float yBg = 0f;
    public float ObstTopLine = 4f;
    public float ObstMidLine = 4.5f;
    public float ObstBotLine = 5f;
    public float ObstYTopLine = -1.1f;
    public float ObstYMidLine = -2.7f;
    public float ObstYBotLine = -4.3f;
    public float MonScaleTopLine = 0.15f;
    public float MonScaleMidLine = 0.2f;
    public float MonScaleBotLine = 0.25f;
    public float MonYOneTopLine = 0.9f;
    public float MonYTwoTopLine = 2f;
    public float MonYOneMidLine = -0.7f;
    public float MonYTwoMidLine = 0.4f;
    public float MonYOneBotLine = -2.3f;
    public float MonYTwoBotLine = -1.2f;
    public float PlusMonTwo = 2f;
    private static int countMetr = 0;
    private int randomMusic;
    private bool musicSwap;
    private int musicTime;
    private bool firstBG, twoBG;
    private int krasBgi;
    public static bool fireTrue;
    public static bool roadTop, roadMid, roadBot;

    private List<float> xCoords = new List<float>();

    /// <временно>
    private int _moneysave;
    /// <временно>

    private void Start()
    {
        _moneysave = PlayerPrefs.GetInt("GOLDMoneySave");
        // ControlScriptForMenu.schoolLvl = false;
        // ControlScriptForMenu.krasnodarLvl = false;
        // ControlScriptForMenu.lasvegasrLvl = true;
        //ControlScriptForMenu.schoolLvl = ControlScriptForMenu.s;
        //ControlScriptForMenu.krasnodarLvl = ControlScriptForMenu.k;
        //ControlScriptForMenu.lasvegasrLvl = ControlScriptForMenu.l;
        //ControlScriptForMenu.schoolLvl = false;
        //ControlScriptForMenu.lasvegasrLvl = false;
        //ControlScriptForMenu.krasnodarLvl = true;
        count = 0;
        distanceCount = 0;
        distanceSpeed = 1;
        countMetr = 0;
        randomMusic = Random.Range(0, 3);
        musicSwap = true;
        MusicPlay();
        firstBG = false;
        twoBG = false;
        krasBgi = 2;
        Zia1000 = true;
        Zia2000 = true;
        Zia3000 = true;
        cameraSpeed = 10;
        fireTrue = false;
        cameraSpeedCopy = cameraSpeed;
        roadTop = false;
        roadMid = false;
        roadBot = false;
        // ControlScriptForMenu.k = false;
        // ControlScriptForMenu.l = false;
        // ControlScriptForMenu.s = false;
        LoadScene.loadStop = true;
        // Debug.Log("loadStop" + LoadScene.loadStop);
    }

    private void Update()
    {
        if (fireTrue && HeroClassNew.fireOnBot) fire.SetActive(true);
    }

    void FixedUpdate()
    {
        if (!Script321.startLvl && !HeroClassNew.Fail && !HeroClassNew.FailDown)
        {
            cameraSpeed = cameraSpeedCopy;
        }
        ///временно
        if (PlayerPrefs.GetInt("moneyOne") == 1)
        {
            MoneyAdd();
        }
        ///временно
        else if (PlayerPrefs.GetInt("moneyTwo") == 1)
        {
            MoneyAdd();
        }
        ///временно
        else if (PlayerPrefs.GetInt("moneyThree") == 1)
        {
            MoneyAdd();
        }
        ///временно
        if (PlayerPrefs.GetInt("moneyOne") == 1 && PlayerPrefs.GetInt("moneyTwo") == 1 &&
            PlayerPrefs.GetInt("moneyThree") == 1)
        {
            // PlayerPrefs.SetInt("GOLDMoneySave", 3);
            bigRampMenu.SetActive(true);
            Time.timeScale = 0;
        }
        
        // Debug.Log("RANDOM MUSIC: " + randomMusic);
        if (count < 15 && !HelicLvl.HelicBack && !HelicLvl.HelicBig && !HelicLvl.HelicGoCloth)
        {
            distanceSpeed = 1;
        } else if (count >= 15 && count < 30 && !HelicLvl.HelicBack && !HelicLvl.HelicBig && !HelicLvl.HelicGoCloth)
        {
            distanceCount = 2;
        }
        else if (count >= 30 && count < 45 && !HelicLvl.HelicBack && !HelicLvl.HelicBig && !HelicLvl.HelicGoCloth)
        {
            distanceCount = 3;
        }
        
        if (Money.moneyBool)
        {
            count++;
            moneyScore.text = count.ToString();
            GetComponent<AudioSource>().Play();
            Money.moneyBool = false;
        }
        
        if (BG_Destroy.destroyBG)
        {
            if (background1.Length == 1)
            {
                Instantiate(background1[0], new Vector2(coordinate, yBg), Quaternion.identity); // создаем бекграунд
            } 
            else if (ControlScriptForMenu.lasvegasrLvl) //(SceneManager.GetActiveScene().name == "Level_LasVegas")
                {
                    randomBG = Random.Range(0, background1.Length - 1);
                }
            else if (ControlScriptForMenu.schoolLvl)//SceneManager.GetActiveScene().name == "Level_School")
            {
                if (firstBG)
                {
                    randomBG = 4;
                    firstBG = false;
                    twoBG = true;
                } 
                else if (twoBG)
                {
                    randomBG = 5;
                    twoBG = false;
                }
                else
                {
                    randomBG = Random.Range(0, background1.Length - 2);
                    if (randomBG == 3)
                    {
                        firstBG = true;
                    }
                }
            } 
            else if (ControlScriptForMenu.krasnodarLvl)//(SceneManager.GetActiveScene().name == "Level_Krasnodar")
            {
                if (krasBgi == 6)
                {
                    krasBgi = 0;
                }
                randomBG = krasBgi;
                // Debug.Log(randomBG);
            }
            if (ControlScriptForMenu.schoolLvl)
            {
                Instantiate(background1[randomBG], new Vector2(coordinate, yBg), Quaternion.identity);
            }
            if (ControlScriptForMenu.krasnodarLvl)
            {
                Instantiate(backgroundv[randomBG], new Vector2(coordinate, yBg), Quaternion.identity);
            }
            if (ControlScriptForMenu.lasvegasrLvl)
            {
                Instantiate(backgroundl[randomBG], new Vector2(coordinate, 1.08f), Quaternion.identity);
            }
            krasBgi++;

            xCoords.Add(Random.Range(coordinate - Random.Range(1f, 13.66f), coordinate - Random.Range(7.96f, 15f))); // 1 
            xCoords.Add(Random.Range(coordinate - Random.Range(1f, 13.66f), coordinate - Random.Range(7.96f, 15f))); // 2
            xCoords.Add(Random.Range(coordinate - Random.Range(1f, 13.66f), coordinate - Random.Range(7.96f, 15f))); // 3
            
            // Debug.Log(distanceCount);
            
            for (int i = 0; i < 3; i++)
            {
                roadBot = true;
                roadMid = true;
                roadTop = true;
                road = Random.Range(0, 3);
                moneyChance = Random.Range(0, 10);
                moneyForUpLvl = Random.Range(0, 20);
                if (!ScriptLearn.learn_start)
                {
                    switch (road)
                    {
                        case 0:
                            if (roadTop) {
                                scale = new Vector2(ObstTopLine, ObstTopLine);
                                position = new Vector2(xCoords[road], ObstYTopLine);
                                sort = 1;
                                if (moneyChance == 0 && moneyForUpLvl != 1)
                                {
                                    scaleMoney = new Vector2(0.3f, 0.3f); //new Vector2(MonScaleTopLine, MonScaleTopLine);
                                    positionMoney = new Vector2(xCoords[road], MonYOneTopLine);
                                    roadTop = false;
                                }
                                else if (moneyChance == 1 && moneyForUpLvl != 1)
                                {
                                    scaleMoney = new Vector2(0.3f, 0.3f); //new Vector2(MonScaleTopLine,MonScaleTopLine); 
                                    positionMoney = new Vector2(xCoords[road], MonYOneTopLine);
                                    positionMoneyTop = new Vector2(xCoords[road] + PlusMonTwo, MonYTwoTopLine);
                                    roadTop = false;
                                }
                                else if (moneyForUpLvl == 1)
                                {
                                    scaleMoney = new Vector2(0.3f, 0.3f);
                                    positionMoney = new Vector2(xCoords[road], MonYOneTopLine);
                                    roadTop = false;
                                }
                            }
                            break;
                        case 1:
                            if (roadMid)
                            {
                                scale = new Vector2(ObstMidLine, ObstMidLine);
                                position = new Vector2(xCoords[road], ObstYMidLine);
                                sort = 3;
                                if (moneyChance == 0 && moneyForUpLvl != 1)
                                {
                                    scaleMoney = new Vector2(0.4f, 0.4f); //new Vector2(MonScaleMidLine,MonScaleMidLine);
                                    positionMoney = new Vector2(xCoords[road], MonYOneMidLine);
                                    roadMid = false;
                                } 
                                else if (moneyChance == 1 && moneyForUpLvl != 1)
                                {
                                    scaleMoney = new Vector2(0.4f, 0.4f); //new Vector2(MonScaleMidLine,MonScaleMidLine);
                                    positionMoney = new Vector2(xCoords[road], MonYOneMidLine);
                                    positionMoneyTop = new Vector2(xCoords[road] + PlusMonTwo, MonYTwoMidLine);
                                    roadMid = false;
                                }
                                else if (moneyForUpLvl == 1)
                                {
                                    scaleMoney = new Vector2(0.4f, 0.4f);
                                    positionMoney = new Vector2(xCoords[road], MonYOneMidLine);
                                    roadMid = false;
                                }
                            }
                            break;
                        default:
                            if (roadBot)
                            {
                                scale = new Vector2(ObstBotLine, ObstBotLine);
                                position = new Vector2(xCoords[road], ObstYBotLine);
                                sort = 5;
                                if (moneyChance == 0 && moneyForUpLvl != 1)
                                {
                                    scaleMoney = new Vector2(0.5f, 0.5f); //new Vector2(MonScaleBotLine,MonScaleBotLine); 
                                    positionMoney = new Vector2(xCoords[road], MonYOneBotLine);
                                    roadBot = false;
                                }
                                else if (moneyChance == 1 && moneyForUpLvl != 1)
                                {
                                    scaleMoney = new Vector2(0.5f, 0.5f); //new Vector2(MonScaleBotLine,MonScaleBotLine);
                                    positionMoney = new Vector2(xCoords[road], MonYOneBotLine);
                                    positionMoneyTop = new Vector2(xCoords[road] + PlusMonTwo, MonYTwoBotLine);
                                    roadBot = false;
                                }
                                else if (moneyForUpLvl == 1)
                                {
                                    scaleMoney = new Vector2(0.5f, 0.5f);
                                    positionMoney = new Vector2(xCoords[road], MonYOneBotLine);
                                    roadBot = false;
                                }
                            }
                            break;
                    }
                }
                GeneratObj(scale, position, sort, moneyChance, scaleMoney, positionMoney, positionMoneyTop, road, moneyForUpLvl);
                xCoords[road] = Random.Range(xCoords[road] + 10.66f, xCoords[road] + 15.96f);;
            }

            coordinate += 33.56f;
            BG_Destroy.destroyBG = false;
            xCoords.Clear();
        }

        if (Script321.startLvl)
        {
            transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0);   
        }

        if (distanceCount >= countDistanceCopy + 500)
        {
            cameraSpeed += 2;
            cameraSpeedCopy = cameraSpeed;
            countDistanceCopy += 500;
            // Debug.Log(countDistanceCopy);
        }
        
        countMetr++;
        if (countMetr == 5 && !HeroClassNew.Fail)
        {
            if (HeroClassNew.JumpTwo)
            {
                if (BustLvl.xn == 2)
                {
                    distanceCount += distanceSpeed * 8;
                }
                else if (BustLvl.xn == 3)
                {
                    distanceCount += distanceSpeed * 12;
                }
                else if (BustLvl.xn == 4)
                {
                    distanceCount += distanceSpeed * 16;
                }
                else if (BustLvl.xn == 5)
                {
                    distanceCount += distanceSpeed * 20;
                }
                else
                {
                    distanceCount += distanceSpeed * 4;   
                }

                distanceScoreBack.text = distanceCount.ToString();
                distanceScore.text = distanceCount.ToString();
                countMetr = 0; 
            } 
            else if (HeroClassNew.Jump)
            {
                distanceCount += distanceSpeed * 2;
                distanceScoreBack.text = distanceCount.ToString();
                distanceScore.text = distanceCount.ToString();
                countMetr = 0; 
            }
            else if (!ScriptLearn.isRun)
            {
                distanceCount += 0;
                distanceScoreBack.text = distanceCount.ToString();
                distanceScore.text = distanceCount.ToString();
                countMetr = 0;
            }
            else
            {
                distanceCount += distanceSpeed;
                distanceScoreBack.text = distanceCount.ToString();
                distanceScore.text = distanceCount.ToString();
                countMetr = 0;
            }
        }
        else if (HeroClassNew.Fail || !Script321.startLvl)
        {
            countMetr = 0;
        }

        musicTime++;
        
        if (musicTime == 5250 && randomMusic == 0)
        {
            randomMusic = 1;
            musicSwap = true;
            
        } else if (musicTime == 5000 && randomMusic == 1)
        {
            randomMusic = 0;
            musicSwap = true;
        }
        // Debug.Log("MUSIC TIME" + musicTime);
        
        if (distanceCount >= 1000 && Zia1000)
        {
            Zia[0].SetActive(true);
            BustRace[0].SetActive(true);
            Zia1000 = false;
        }
                
        if (distanceCount >= 2000 && Zia2000)
        {
            Zia[1].SetActive(true);
            BustRace[1].SetActive(true);
            Zia2000 = false;
        }
                
        if (distanceCount >= 3000 && Zia3000)
        {
            Zia[2].SetActive(true);
            BustRace[2].SetActive(true);
            Zia3000 = false;
        }
    }

    void GeneratObj(Vector2 scale, Vector2 position, int sorting, int moneyChance, Vector2 scaleMoney, Vector2 positionMoney, Vector2 positionMoneyTop, int road, int moneyForUpLvl)
    {
        if (road == 0)
        {
            numObstacles = Random.Range(0, obstacles.Length - 1);
        }
        else
        {
            numObstacles = Random.Range(0, obstacles.Length - 4);   
        }
        obstacles[numObstacles].GetComponent<SpriteRenderer>().sortingOrder = sorting;
        if (numObstacles == obstacles.Length -3) obstacles[numObstacles].transform.localScale = new Vector2(ObstTopLine + 1f, ObstTopLine + 1f);
        else if (numObstacles == obstacles.Length - 1 || numObstacles == obstacles.Length - 2) obstacles[numObstacles].transform.localScale = new Vector2(ObstTopLine + 0.5f, ObstTopLine + 0.5f);
        else obstacles[numObstacles].transform.localScale = scale;
        
        if (numObstacles == obstacles.Length -3) Instantiate(obstacles[numObstacles], new Vector2(xCoords[road], -0.9f), Quaternion.identity);
        else if (numObstacles == obstacles.Length - 1 || numObstacles == obstacles.Length - 2 ) Instantiate(obstacles[numObstacles], new Vector2(xCoords[road], -0.7f), Quaternion.identity);
        else Instantiate(obstacles[numObstacles], position, Quaternion.identity);

        if (moneyChance == 0 && moneyForUpLvl != 1)
        {
            money.GetComponent<SpriteRenderer>().sortingOrder = sorting;
            money.transform.localScale = scaleMoney;
            if (numObstacles == obstacles.Length - 1 || numObstacles == obstacles.Length - 2 || numObstacles == obstacles.Length -3) Instantiate(money, new Vector2(xCoords[road], 1.45f), Quaternion.identity);
            else Instantiate(money, positionMoney, Quaternion.identity); 
        }
        else if (moneyChance == 1 && moneyForUpLvl != 1)
        {
            money.GetComponent<SpriteRenderer>().sortingOrder = sorting;
            money.transform.localScale = scaleMoney;
            if (numObstacles == obstacles.Length - 1 || numObstacles == obstacles.Length - 2 ||
                numObstacles == obstacles.Length - 3)
            {
                Instantiate(money, new Vector2(xCoords[road], 1.45f), Quaternion.identity);
                Instantiate(money, new Vector2(xCoords[road] + PlusMonTwo, 2.55f), Quaternion.identity);   
            }
            else
            {
                Instantiate(money, positionMoney, Quaternion.identity);
                Instantiate(money, positionMoneyTop, Quaternion.identity);
            }
        }
        else if (moneyForUpLvl == 1)
        {
            if (PlayerPrefs.GetInt("moneyOne") == 0)
            {
                moneyOne.GetComponent<SpriteRenderer>().sortingOrder = sorting;
                moneyOne.transform.localScale = scaleMoney;
                Instantiate(moneyOne, positionMoney, Quaternion.identity); 
            }
            else if (PlayerPrefs.GetInt("moneyTwo") == 0)
            {
                moneyTwo.GetComponent<SpriteRenderer>().sortingOrder = sorting;
                moneyTwo.transform.localScale = scaleMoney;
                Instantiate(moneyTwo, positionMoney, Quaternion.identity); 
            }
            else if (PlayerPrefs.GetInt("moneyThree") == 0)
            {
                moneyThree.GetComponent<SpriteRenderer>().sortingOrder = sorting;
                moneyThree.transform.localScale = scaleMoney;
                Instantiate(moneyThree, positionMoney, Quaternion.identity); 
            }
        }
    }

    void MoneyAdd()
    {
        _moneysave += 1;
        PlayerPrefs.SetInt("GOLDMoneySave", _moneysave);
        PlayerPrefs.SetInt("moneyOne", 0);
        PlayerPrefs.SetInt("moneyTwo", 0);
        PlayerPrefs.SetInt("moneyThree", 0);
    }

    void MusicPlay()
    {
        if (randomMusic == 0 && musicSwap)
        {
            GameObject.Find("SoundCxcz").GetComponent<AudioSource>().Play();
            musicSwap = false;
        }
        else if (randomMusic == 1 && musicSwap)
        {
            GameObject.Find("SoundIvan").GetComponent<AudioSource>().Play();
            musicSwap = false;
        }
        else if (randomMusic == 2 && musicSwap)
        {
            GameObject.Find("SoundDream").GetComponent<AudioSource>().Play();
            musicSwap = false;
        }
    }
}
