using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeroClass : MonoBehaviour
{
    /// <summary>
    /// Анимация
    /// </summary>
    public Animator anim;
    /// <summary>
    /// Объекты линий
    /// </summary>
    public GameObject topLine;
    public GameObject midLine;
    public GameObject botLine;

    /// <summary>
    /// Стартовые координаты герия
    /// </summary>
    public float startPositionY = -0.5f;
    public float startPositionX = -7f;
    
    /// <summary>
    /// Координаты линий
    /// </summary>
    public float top = 0.206f;
    public float mid = -0.183f;
    public float bot = -0.49f;

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
    public float force;
    private int _extraJump;
    public int extraJumpValue;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;
    private bool _isGround = true;
// <<<<<<< Updated upstream
    
    public static int live = 3;
    private bool Jump = false;
// >>>>>>> Stashed changes

    [Header("Жизни")] public GameObject[] liveZak = new GameObject[9];

    /// <summary>
    /// Функция старта
    /// </summary>
    void Start()
    {
        gameObject.transform.localScale = new Vector3(0.55f, 0.55f,0f);
        _mRigidbody = GetComponent<Rigidbody2D>();
        gameObject.transform.position = new Vector3(startPositionX, startPositionY, 0);
        _extraJump = extraJumpValue;
        anim.SetBool("ReadyKick", false);
    }
    
    /// <summary>
    /// Функция начала
    /// </summary>\
    private void Awake()
    {
        // SwipeDetector.OnSwipe += Move;
        live = 3;
    }

    /// <summary>
    /// Функция обновления
    /// </summary>
    private void Update()
    {
        anim.SetBool("ReadyKick", true);
        OnEnableOrDisableLines();
        if (_isGround) _extraJump = extraJumpValue;
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            switch (_touch.phase)
            {
                case TouchPhase.Began:
                    _beg = _touch.position;
                    break;
                case TouchPhase.Ended:
                    Jump = true;
                    _end = _touch.position;
                    if (_beg == _end && _extraJump > 0)
                    {
                        _mRigidbody.AddForce(transform.up * force);
                        _extraJump--;
                    }
                    else if (_beg == _end && _extraJump == 0 && _isGround)
                    {
                        _mRigidbody.AddForce(transform.up * force);
                        _extraJump--;
                    }
                    break;
            }
        }

        if (Jump)
        {
            anim.SetBool("ReadyJump", true);
            anim.SetBool("ReadyJump", false);
            Jump = false;
        }
    }

    /// <summary>
    /// Фиксированное обновление
    /// </summary>
    private void FixedUpdate()
    {
        _isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);
        
        if (live == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                liveZak[i].SetActive(true);   
            }

            for (int i = 3; i < 9; i++)
            {
                liveZak[i].SetActive(false);    
            }
            
        }
        else if (live == 2)
        {
            liveZak[0].SetActive(false);
            liveZak[1].SetActive(false);
            liveZak[6].SetActive(true);
            liveZak[4].SetActive(true);
        }
        else if (live == 1)
        {
            liveZak[5].SetActive(true);
            liveZak[7].SetActive(true);
            liveZak[6].SetActive(true);
            liveZak[4].SetActive(false);
            liveZak[2].SetActive(false);
        }
        else
        {
            liveZak[8].SetActive(true);
            liveZak[5].SetActive(false);
            
        }
    }

    /// <summary>
    /// Функция свайпа
    /// </summary>
    /// <param name="data">Тип свайпа (вверх, вниз)</param>
    private void Move(SwipeData data)
    {
        if (Input.GetKeyDown(KeyCode.W) || data.Direction == global::SwipeDirection.Up)
        {
            switch (index)
            {
                case 1:
                    _y = mid;
                    gameObject.transform.localScale = new Vector3(0.55f, 0.55f,0f);
                    index++;
                    break;
                case 2:
                    _y = top;
                    gameObject.transform.localScale = new Vector3(0.45f, 0.45f,0f);
                    index++;
                    break;
                default:
                    return;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || data.Direction == global::SwipeDirection.Down)
        {
            switch (index)
            {
                case 3:
                    _y = mid;
                    gameObject.transform.localScale = new Vector3(0.5f, 0.5f,0f);
                    index--;
                    break;
                case 2:
                    _y = bot;
                    gameObject.transform.localScale = new Vector3(0.6f, 0.6f,0f);
                    index--;
                    break;
                default:
                    return;
            }
        }
        
        gameObject.transform.position = new Vector3(
            gameObject.transform.position.x,
            _y,
            gameObject.transform.position.z);
    }

    /// <summary>
    /// Отклчение или включение линий
    /// </summary>
    private void OnEnableOrDisableLines()
    {
        switch (index)
        {
            case 1:
                topLine.GetComponent<BoxCollider2D>().enabled = false;
                midLine.GetComponent<BoxCollider2D>().enabled = false;
                botLine.GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<SpriteRenderer>().sortingOrder = 6;
                break;
            case 2:
                topLine.GetComponent<BoxCollider2D>().enabled = false;
                midLine.GetComponent<BoxCollider2D>().enabled = true;
                botLine.GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().sortingOrder = 4;
                break;
            case 3:
                topLine.GetComponent<BoxCollider2D>().enabled = true;
                midLine.GetComponent<BoxCollider2D>().enabled = false;
                botLine.GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<SpriteRenderer>().sortingOrder = 2;
                break;
        }
    }
}
