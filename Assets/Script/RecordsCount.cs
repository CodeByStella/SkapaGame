using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsCount : MonoBehaviour
{
    public Image Menu;
    public Sprite School, Krasnodar, Lasvegas;
    // private int sch1, sch2, sch3, sch4, sch5;
    // private int kras1, kras2, kras3, kras4, kras5;
    // private int las1, las2, las3, las4, las5;
    // public Text stext1, stext2, stext3, stext4, stext5;
    // public Text ktext1, ktext2, ktext3, ktext4, ktext5;
    // public Text ltext1, ltext2, ltext3, ltext4, ltext5;
    private int first, second, third, fourth, fifth;
    public Text one, two, three, four, five;

    private void Start()
    {
        
        if(ControlScriptForMenu.schoolLvl)
        {
            first = PlayerPrefs.GetInt("school1");
            second = PlayerPrefs.GetInt("school2");
            third = PlayerPrefs.GetInt("school3");
            fourth = PlayerPrefs.GetInt("school4");
            fifth = PlayerPrefs.GetInt("school5");
            Menu.sprite = School;
            Debug.Log(first);
            Debug.Log(second);
            Debug.Log(third);
            Debug.Log(fourth);
            Debug.Log(fifth);
        }
        else if(ControlScriptForMenu.krasnodarLvl)
        {
            first = PlayerPrefs.GetInt("kras1");
            second = PlayerPrefs.GetInt("kras2");
            third = PlayerPrefs.GetInt("kras3");
            fourth = PlayerPrefs.GetInt("kras4");
            fifth = PlayerPrefs.GetInt("kras5");
            Menu.sprite = Krasnodar;
        }
        else if(ControlScriptForMenu.lasvegasrLvl)
        {
            first = PlayerPrefs.GetInt("las1");
            second = PlayerPrefs.GetInt("las2");
            third = PlayerPrefs.GetInt("las3");
            fourth = PlayerPrefs.GetInt("las4");
            fifth = PlayerPrefs.GetInt("las5");
            Menu.sprite = Lasvegas;
        }
        one.text = first.ToString();
        two.text = second.ToString();
        three.text = third.ToString();
        four.text = fourth.ToString();
        five.text = fifth.ToString();
        // sch1 = PlayerPrefs.GetInt("sch1");
        // sch2 = PlayerPrefs.GetInt("sch2");
        // sch3 = PlayerPrefs.GetInt("sch3");
        // sch4 = PlayerPrefs.GetInt("sch4");
        // sch5 = PlayerPrefs.GetInt("sch5");
        // kras1 = PlayerPrefs.GetInt("kras1");
        // kras2 = PlayerPrefs.GetInt("kras2");
        // kras3 = PlayerPrefs.GetInt("kras3");
        // kras4 = PlayerPrefs.GetInt("kras4");
        // las5 = PlayerPrefs.GetInt("las5");
        // las2 = PlayerPrefs.GetInt("las2");
        // las3 = PlayerPrefs.GetInt("las3");
        // las4 = PlayerPrefs.GetInt("las4");
        // las5 = PlayerPrefs.GetInt("las5");
        // stext1.text = sch1.ToString();
        // stext2.text = sch2.ToString();
        // stext3.text = sch3.ToString();
        // stext4.text = sch4.ToString();
        // stext5.text = sch5.ToString();
        // ktext1.text = kras1.ToString();
        // ktext2.text = kras2.ToString();
        // ktext3.text = kras3.ToString();
        // ktext4.text = kras4.ToString();
        // ktext5.text = kras5.ToString();
        // ltext1.text = las1.ToString();
        // ltext2.text = las2.ToString();
        // ltext3.text = las3.ToString();
        // ltext4.text = las4.ToString();
        // ltext5.text = las5.ToString();
    }
    //void Update()
    //{
    //    text1.text = value1.ToString();
    //    text2.text = value2.ToString();
    //    text3.text = value3.ToString();
    //    text4.text = value4.ToString();
    //    text5.text = value5.ToString();
    //    if (PlayerPrefs.GetInt("Distance1") > value1)
    //    {
    //        value5 = value4;
    //        value4 = value3;
    //        value3 = value2;
    //        value2 = value1;
    //        value1 = PlayerPrefs.GetInt("Distance1");
    //    }
    //    else if(PlayerPrefs.GetInt("Distance1") > value2 & PlayerPrefs.GetInt("Distance1") < value1)
    //    {
    //        value5 = value4;
    //        value4 = value3;
    //        value3 = value2;
    //        value2 = PlayerPrefs.GetInt("Distance1");
    //    }
    //    else if (PlayerPrefs.GetInt("Distance1") > value3 & PlayerPrefs.GetInt("Distance1") < value2)
    //    {
    //        value5 = value4;
    //        value4 = value3;
    //        value3 = PlayerPrefs.GetInt("Distance1");
    //    }
    //    else if (PlayerPrefs.GetInt("Distance1") > value4 & PlayerPrefs.GetInt("Distance1") < value3)
    //    {
    //        value5 = value4;
    //        value4 = PlayerPrefs.GetInt("Distance1");
    //    }
    //    else if (PlayerPrefs.GetInt("Distance1") > value5 & PlayerPrefs.GetInt("Distance1") < value4)
    //    {
    //        value5 = PlayerPrefs.GetInt("Distance1");
    //    }
    //    PlayerPrefs.SetInt("value1", value1);
    //    PlayerPrefs.SetInt("value2", value2);
    //    PlayerPrefs.SetInt("value3", value3);
    //    PlayerPrefs.SetInt("value4", value4);
    //    PlayerPrefs.SetInt("value5", value5);
    //}
}
