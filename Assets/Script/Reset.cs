using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("value1", 0);
        PlayerPrefs.SetInt("value2", 0);
        PlayerPrefs.SetInt("value3", 0);
        PlayerPrefs.SetInt("value4", 0);
        PlayerPrefs.SetInt("value5", 0);
    }
}
