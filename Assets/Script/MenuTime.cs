using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTime : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
        ControlScriptForMenu.s = true;
    }
}
