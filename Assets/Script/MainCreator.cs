using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCreator : MonoBehaviour
{
    public GameObject zik;
    public static Vector2 ZikMain = new Vector2(0, 0);
    public static bool zikAwake;
    public GameObject canvasMain = new GameObject("Canvas");
    void Start()
    {

    }

    private void Awake()
    {
        Instantiate(zik, ZikMain, Quaternion.identity).transform.SetParent(canvasMain.transform);
    }
}
