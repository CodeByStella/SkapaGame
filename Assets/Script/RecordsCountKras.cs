using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsCountKras : MonoBehaviour
{
    private int sch1, sch2, sch3, sch4, sch5;
    public Text text1, text2, text3, text4, text5;

    private void Start()

    {
        sch1 = PlayerPrefs.GetInt("value1");
        sch2 = PlayerPrefs.GetInt("value2");
        sch3 = PlayerPrefs.GetInt("value3");
        sch4 = PlayerPrefs.GetInt("value4");
        sch5 = PlayerPrefs.GetInt("value5");
        text1.text = sch1.ToString();
        text2.text = sch2.ToString();
        text3.text = sch3.ToString();
        text4.text = sch4.ToString();
        text5.text = sch5.ToString();
    }
}
