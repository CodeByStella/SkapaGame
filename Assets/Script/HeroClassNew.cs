using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class HeroClassNew : MonoBehaviour
{
    /// <summary>
    /// Анимация
    /// </summary>
    public Animator anim;
    /// <summary>
    /// Стартовые координаты герия
    /// </summary>
    public float startPositionY = -0.5f;
    public float startPositionX = -7f;
    /// <summary>
    /// Индекс и смещение
    /// </summary>
    public static int index = 2;
    private float _y;
    
    /// <summary>
    /// Объект физики
    /// </summary>
    private Rigidbody2D _mRigidbody;

    /// <summary>
    /// Переменные для свайпа и тача
    /// </summary>
    private Vector2 _beg, _end;
    private Touch _touch;
    
    /// <summary>
    /// Переменные для прыжка
    /// </summary>
    public float force = 50f;
    public static int extraJump;
    public int extraJumpValue;
    public Transform groundCheck;
    public float checkRadius = 0.5f;
    public LayerMask whatisGround;
    public static bool isGround = true;

    public static bool MoveTop = false;
    public static bool MoveBot = false;
    public static bool JumpHero = false;
// <<<<<<< Updated upstream
    
    public static int live = 3;
    public static bool Jump = false;
    public static bool JumpTwo = false;
    public static bool _stopTwoJump = false;
    public static bool Fail = false;

    public float copyMoveCamera;

    public GameObject menuFail;

    public static bool stopControlBool = true;
    
    public static int moneyFinal;

    public GameObject GameOver;

    public GameObject Ouch;

    public GameObject pauseSprite;
    public float ZakeMidLine = 0.5f;
    public float UpForce = 0.3f;
    public float DownForce = -0.2f;
    private string currentAnimation;
    public static bool FailDown;
    
    private List <String> allTrickInGame = new List<string>();

    public GameObject bustLvl;

    public static bool fireOnBot;

    public GameObject shadow;
    public static bool shadowBool;
    int g = 0;
    private int failCount = 0;
    private MethodsAPIScript _api;
    private Dictionary<int, string> mapTricks = new Dictionary<int, string>
    {
        {1, "TrickOllieFlip"},
        {2, "TrickImpossible"},
        {3, "TrickMethod"},
        {4, "TrickNollie"},
        {5, "TrickNollieFlip"},
        {6, "TrickChrist"},
        {7, "Trick360"},
        {8, "TrickBackFlip"},
        {9, "TrickBenihana"},
    };
    

    // >>>>>>> Stashed changes

    [Header("Жизни")] public GameObject[] liveZak = new GameObject[9];

    /// <summary>
    /// Функция старта
    /// </summary>
    void Start()
    {
        failCount = 0;
        shadowBool = false;
        fireOnBot = false;
        Fail = false;
        FailDown = false;
        extraJump = 0;
        gameObject.transform.localScale = new Vector3(ZakeMidLine, ZakeMidLine,0f);
        _mRigidbody = GetComponent<Rigidbody2D>();
        gameObject.transform.position = new Vector3(startPositionX, startPositionY, 0);
        extraJump = extraJumpValue;
        // anim.SetBool("ReadyKick", false);
        moneyFinal = PlayerPrefs.GetInt("Money");
        index = 2;
        anim = GetComponent<Animator>();
        _api = FindObjectOfType<MethodsAPIScript>();
        StartCoroutine(LoadSelectedTrick());
        if (!GameOverScript.GameOverBool && !Fail)
        {
            ChangeAnimation("Kick");   
        }
        
        if (PlayerPrefs.GetInt("TrickOllieFlip") == 1)
        {
            allTrickInGame.Add("TrickOllieFlip");
        }
        
        if (PlayerPrefs.GetInt("TrickImpossible") == 1)
        {
            allTrickInGame.Add("TrickImpossible");
        }

        if (PlayerPrefs.GetInt("TrickMethod") == 1)
        {
            allTrickInGame.Add("TrickMethod");
        }

        if (PlayerPrefs.GetInt("TrickNollie") == 1)
        {
            allTrickInGame.Add("TrickNollie");
        }
        
        if (PlayerPrefs.GetInt("TrickNollieFlip") == 1)
        {
            allTrickInGame.Add("TrickNollieFlip");
        }
        
        if (PlayerPrefs.GetInt("TrickChrist") == 1)
        {
            allTrickInGame.Add("TrickChrist");
        }
        
        if (PlayerPrefs.GetInt("Trick360") == 1)
        {
            allTrickInGame.Add("Trick360");
        }
        
        if (PlayerPrefs.GetInt("Trick360Christ") == 1)
        {
            allTrickInGame.Add("Trick360Christ");
        }
        
        if (PlayerPrefs.GetInt("TrickBackFlip") == 1)
        {
            allTrickInGame.Add("TrickBackFlip");
        }
        
        if (PlayerPrefs.GetInt("TrickBenihana") == 1)
        {
            allTrickInGame.Add("TrickBenihana");
        }
    }

    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation || currentAnimation == "Fail" && Fail && FailDown) return;

        anim.Play(animation);
        currentAnimation = animation;
    }

    /// <summary>
    /// Функция начала
    /// </summary>\
    private void Awake()
    {
        // SwipeDetector.OnSwipe += Move;
        live = 3;
        Move_Camera.cameraSpeed = 10f;
        GetComponent<SpriteRenderer>().sortingOrder = 4;
        // Fail = false;
        stopControlBool = true;
        GameOverScript.GameOverBool = true;
    }
    
    public void Jumping()
    {
        if (Jump && extraJump == 1 && !MoveTop && !MoveBot && !Fail && stopControlBool)
        {
            shadowBool = true;
            // anim.SetBool("ReadyJump", true);
            JumpTwo = true;
            // Debug.Log("JUMP TWO REDDY");
            ChangeAnimation("Jump");
            isGround = false;
            _mRigidbody.AddForce(new Vector2(0f, force));
            GameObject.Find("SoundRide").GetComponent<AudioSource>().mute = true;
            GameObject.Find("SoundOllieUp").GetComponent<AudioSource>().Play();
            extraJump++;
        }
    }

    public void JumpingTwo()
    {
        if (JumpTwo && extraJump == 3 /*&& !_stopTwoJump*/ && !MoveTop && !MoveBot && !Fail && stopControlBool &&
            allTrickInGame.Count == 0)
        {
            // Debug.Log(extraJump);
            anim.SetBool("ReadyJumpTwo", true);
            ChangeAnimation("JumpTwo");
            _mRigidbody.AddForce(new Vector2(0f, force));
            // JumpTwo = false;
            extraJump++;
            if (BustLvl.xn >= 1) bustLvl.SetActive(true);
            if (BustLvl.xn < 5) BustLvl.xn++;
        } else if (JumpTwo && extraJump == 3 /*&& !_stopTwoJump*/ && !MoveTop && !MoveBot && !Fail && stopControlBool &&
                   allTrickInGame.Count != 0)
        {
            int randomTrick = 0;
            randomTrick = Random.Range(0, allTrickInGame.Count - 1);
            // Debug.Log(extraJump);
            // Debug.Log("JUMP TWO ON");
            // anim.SetBool("ReadyJumpTwo", true);
            ChangeAnimation(allTrickInGame[randomTrick]);
            _mRigidbody.AddForce(new Vector2(0f, force));
            // JumpTwo = false;
            extraJump++;
            if (BustLvl.xn >= 1) bustLvl.SetActive(true);
        
            if (BustLvl.xn < 5) BustLvl.xn++;
        }
    }

    /// <summary>
    /// Функция обновления
    /// </summary>
    private void Update()
    {
        if (!Jump && !JumpTwo && !Fail && stopControlBool && currentAnimation != "Kick" && !GameOverScript.GameOverBool)
        {
            ChangeAnimation("Slide");   
        }
        OnEnableOrDisableLines();

        if (stopControlBool && !Fail && !Jump && !JumpTwo && MoveTop && isGround)
        {
            // anim.SetBool("UpLine", true);
            if (!Fail && !GameOverScript.GameOverBool)
            {
                ChangeAnimation("UpLine");
            }
            _mRigidbody.AddForce(new Vector2(0f, UpForce));
            Debug.Log("TOP ON");
        }
        else if (stopControlBool && !Fail && !Jump && !JumpTwo && MoveBot && isGround)
        {
            // anim.SetBool("DownLine", true);
            if (!Fail && !GameOverScript.GameOverBool)
            {
                ChangeAnimation("DownLine");   
            }
            _mRigidbody.AddForce(new Vector2(0f, DownForce));
            Debug.Log("BOT ON");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Line")
        {
            Jump = false;
            JumpTwo = false;
            // Debug.Log("JUMP TWO FALSE");
            // JumpTwo = false;
            if (extraJump < 3)
            {
                BustLvl.xn = 0;
            }
            isGround = true;
            extraJump = 0;
            if (index == 2) shadow.transform.localScale = new Vector3(5f, 4f);
            else if (index == 1) shadow.transform.localScale = new Vector3(6f, 5f);
            else if (index == 3) shadow.transform.localScale = new Vector3(4f, 3f);
            g = 0;
            _stopTwoJump = false;
            GameObject.Find("SoundRide").GetComponent<AudioSource>().mute = false;
            GameObject.Find("SoundOllieDown").GetComponent<AudioSource>().Play();
            if (Move_Camera.fireTrue)
            {
                fireOnBot = true;
            }
            ChangeAnimation("Kick");
        }
    }

    /// <summary>
    /// Фиксированное обновление
    /// </summary>
    private void FixedUpdate()
    {
        if ((Fail || FailDown) && failCount == 0)
        {
            ChangeAnimation("Fail");
            failCount = 1;
        }
        if (extraJump == 1) Jumping();
        else if (extraJump > 1) JumpingTwo();
            // Debug.Log(Move_Camera.cameraSpeed);
        if (Move_Camera.cameraSpeed == 5f && !Fail)
        {
            Move_Camera.cameraSpeed = copyMoveCamera;
        }
        
        if (MoveControl.animDownLine && !Fail && !FailDown)
        {
            // anim.SetBool("DownLine", true);
            ChangeAnimation("DownLine");
        }

        if (MoveControl.animUpLine && !Fail && !FailDown)
        {
            // anim.SetBool("UpLine", true);
            ChangeAnimation("UpLine");
        }

        if (live == 3)
        {
            liveZak[0].SetActive(true);
            liveZak[1].SetActive(false);
            liveZak[2].SetActive(false);
            liveZak[3].SetActive(false);
            if (Fail && FailDown)
            {
                // anim.SetBool("Fail", true);
                ChangeAnimation("Fail");
                extraJump = 0;
            }
        }
        else if (live == 2)
        {
            liveZak[0].SetActive(false);
            liveZak[1].SetActive(true);
            liveZak[2].SetActive(false);
            liveZak[3].SetActive(false);
            if (Fail && FailDown)
            {
                // anim.SetBool("Fail", true);   
                ChangeAnimation("Fail");
                extraJump = 0;
            }
        }
        else if (live == 1)
        {
            liveZak[0].SetActive(false);
            liveZak[1].SetActive(false);
            liveZak[2].SetActive(true);
            liveZak[3].SetActive(false);
            if (Fail && FailDown)
            {
                // anim.SetBool("Fail", true);   
                ChangeAnimation("Fail");
                extraJump = 0;
            }
        }
        else
        {
            liveZak[0].SetActive(false);
            liveZak[1].SetActive(false);
            liveZak[2].SetActive(false);
            liveZak[3].SetActive(true);
            if (Fail && FailDown)
            {
                // anim.SetBool("Fail", true);  
                // Handheld.Vibrate();
                ChangeAnimation("Fail");
                extraJump = 0;
            }
        }

        if (live <= 0 && !GameOverScript.GameOverBool)
        {
            GameOverTrue();
        }
        
        if (extraJump > 0 && Script321.startLvl && shadowBool)
        {
            g++;
            if (g < 40)
            {
                shadow.transform.localScale += new Vector3(-0.1f, -0.05f);
            }
            else if (g >= 40 && g < 80)
            {
                shadow.transform.localScale += new Vector3(0.1f, 0.05f);
            }
            else
            {
                g = 0;
                shadowBool = false;
            }
        }
    }

    /// <summary>
    /// Отклчение или включение линий
    /// </summary>
    private void OnEnableOrDisableLines()
    {
        switch (index)
        {
            case 1:
                GetComponent<SpriteRenderer>().sortingOrder = 6;
                force = 30f;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sortingOrder = 4;
                force = 26f;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sortingOrder = 2;
                force = 24f;
                break;
        }
    }

    IEnumerator LoadSelectedTrick()
    {
        string currentTrickName;

        if (_api != null)
        {
            yield return _api.GetTricks((tricks) =>
        {
            if (tricks == null || tricks.Length == 0)
            {
                Debug.LogWarning("Нет данных о трюках с сервера");
                return;
            }

            // ищем выбранный трюк
            foreach (var trick in tricks)
            {
                if (trick.is_in_use)
                {
                    currentTrickName = mapTricks[trick.trick_id];
                    ChangeAnimation(currentTrickName);
                    Debug.Log("Активный трюк: " + currentTrickName);
                    return;
                }
            }

            // если сервер не вернул selected=true → выбираем дефолтный
            currentTrickName = "TrickOllieFlip";
            ChangeAnimation(currentTrickName);
        });
        }
    }

    private void StopGame()
    {
        GameObject.Find("SoundRide").GetComponent<AudioSource>().mute = true;
        if (live > 0 && Fail)
        {
            BustLvl.xn = 0;
            // Move_Camera.cameraSpeed = 0f;
            // anim.SetBool("Fail", false);
            ChangeAnimation("Up");
        }
        else if (live <= 0 && Fail)
        {
            BustLvl.xn = 0;
            // Move_Camera.cameraSpeed = 0f;
            Move_Camera.cameraSpeedCopy = 10f;
            pauseSprite.SetActive(false);
            GameOver.SetActive(true);
            GameOverScript.GameOverBool = true;
        }
        
    }

    private void StopTwoJump()
    {
        _stopTwoJump = true;
        isGround = true;
    }

    private void CameraNonStop()
    {
        FailDown = false;
        Move_Camera.cameraSpeed = 10f;
        DinamicBG.StopBG = false;
        // Move_Camera.cameraSpeed = Move_Camera.cameraSpeedCopy;
    }

    private void UpZakeClose()
    {
        if (live != 0)
        {
            stopControlBool = true;
            // anim.SetBool("Up", false);
            // ChangeAnimation("Up");
            Fail = false;
            FailDown = false;
            extraJump = 0;
            GameObject.Find("SoundRide").GetComponent<AudioSource>().mute = false;
            Move_Camera.cameraSpeed = Move_Camera.cameraSpeedCopy;
            if (!Fail) ChangeAnimation("Kick");
        }
    }

    private void SmallRace()
    {
        if (Move_Camera.cameraSpeed > 6f)
        {
            copyMoveCamera = Move_Camera.cameraSpeed;   
        }
        if (FailDown) Move_Camera.cameraSpeed = 5f;
    }

    private void stopControl()
    {
        Ouch.SetActive(true);
        OuchScript.OuchBool = true;
        stopControlBool = false;
    }

    public void GameOverTrue()
    {
        Time.timeScale = 0;
        menuFail.SetActive(true);  
        Fail = false;
        moneyFinal += Move_Camera.count;
        //PlayerPrefs.SetInt("Money", moneyFinal);
        if (_api != null)
        {
            StartCoroutine(_api.UpdateCoins(moneyFinal));
        }
    }

    public void DownLineTrue()
    {
        if (!FailDown) anim.SetBool("DownLine", false);
    }

    public void UpLineTrue()
    {
        if (!FailDown) anim.SetBool("UpLine", false);
    }

    public void PlayAnimSlide()
    {
        ChangeAnimation("Slide");
    }

    public void StopCamera()
    {
        Move_Camera.cameraSpeed = 0f;
        Debug.Log("COPY SPEED " + Move_Camera.cameraSpeedCopy);
        DinamicBG.StopBG = true;
        FailDown = false;
    }

    public void fixBag()
    {
        // if (Fail && FailDown && live != 0)
        // {
            // Fail = false;
            // FailDown = false;
            // Move_Camera.cameraSpeed = Move_Camera.cameraSpeedCopy;
        // }
        failCount = 0;

    }
    
    public void CountFail()
    {
        failCount = 0;
    }
}
