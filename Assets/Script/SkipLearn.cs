using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipLearn : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("Learn", 0);
    }

}
