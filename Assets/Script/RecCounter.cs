using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecCounter : MonoBehaviour
{
    public GameObject Menu, Distance, Distance1, Home, Restart;
    private int value1, value2, value3, value4, value5;
    public Text text1, text2, text3, text4, text5, top1, top2, top3, top4, top5;
    void Start()
    {
        //if (Move_Camera.distanceCount > value1)
        //{
        //    value5 = value4;
        //    value4 = value3;
        //    value3 = value2;
        //    value2 = value1;
        //    value1 = Move_Camera.distanceCount;
        //    text1.color = Color.green;
        //    top1.color = Color.green;
        //    Do();
        //}
        //else if (Move_Camera.distanceCount > value2 && Move_Camera.distanceCount < value1)
        //{
        //    value5 = value4;
        //    value4 = value3;
        //    value3 = value2;
        //    value2 = Move_Camera.distanceCount;
        //    text1.color = Color.green;
        //    top1.color = Color.green;
        //    Do();
        //}
        //else if (Move_Camera.distanceCount > value3 && Move_Camera.distanceCount < value2)
        //{
        //    value5 = value4;
        //    value4 = value3;
        //    value3 = Move_Camera.distanceCount;
        //    text1.color = Color.green;
        //    top1.color = Color.green;
        //    Do();
        //}
        //else if (Move_Camera.distanceCount > value4 && Move_Camera.distanceCount < value3)
        //{
        //    value5 = value4;
        //    value4 = Move_Camera.distanceCount;
        //    text1.color = Color.green;
        //    top1.color = Color.green;
        //    Do();
        //}
        //else if (Move_Camera.distanceCount > value5 && Move_Camera.distanceCount < value4)
        //{
        //    value5 = Move_Camera.distanceCount;
        //    text1.color = Color.green;
        //    top1.color = Color.green;
        //    Do();
        //}
        //void Do()
        //{
        //    Menu.SetActive(true);
        //    Distance.SetActive(false);
        //    Distance1.SetActive(false);
        //    Home.SetActive(false);
        //    Restart.SetActive(false);
        //    text1.text = value1.ToString();
        //    text2.text = value2.ToString();
        //    text3.text = value3.ToString();
        //    text4.text = value4.ToString();
        //    text5.text = value5.ToString();
        //    value1 = PlayerPrefs.GetInt("value1");
        //    value2 = PlayerPrefs.GetInt("value2");
        //    value3 = PlayerPrefs.GetInt("value3");
        //    value4 = PlayerPrefs.GetInt("value4");
        //    value5 = PlayerPrefs.GetInt("value5");
        //}
        ////
        //Move_Camera.distanceCount
        ////
        //text1.text = value1.ToString();
        //text2.text = value2.ToString();
        //text3.text = value3.ToString();
        //text4.text = value4.ToString();
        //text5.text = value5.ToString();
        ////
        //Menu.SetActive(true);
        //Distance.SetActive(false);
        //Distance1.SetActive(false);
        //Home.SetActive(false);
        //Restart.SetActive(false);
        //value5 = value4;
        //value4 = value3;
        //value3 = value2;
        //value2 = value1;
        //value1 = Move_Camera.distanceCount;
        //text1.color = Color.green;
        //top1.color = Color.green;
        ////
    }
    public void Count()
    {
        top1.color = Color.white;
        top2.color = Color.white;
        top3.color = Color.white;
        top4.color = Color.white;
        top5.color = Color.white;
        text1.color = Color.white;
        text2.color = Color.white;
        text3.color = Color.white;
        text4.color = Color.white;
        text5.color = Color.white;
        value1 = PlayerPrefs.GetInt("value1");
        value2 = PlayerPrefs.GetInt("value2");
        value3 = PlayerPrefs.GetInt("value3");
        value4 = PlayerPrefs.GetInt("value4");
        value5 = PlayerPrefs.GetInt("value5");
        if (Move_Camera.distanceCount > value1)
        {
            value5 = value4;
            value4 = value3;
            value3 = value2;
            value2 = value1;
            value1 = Move_Camera.distanceCount;
            text1.color = Color.green;
            top1.color = Color.green;
            Do();
        }
        else if (Move_Camera.distanceCount > value2 && Move_Camera.distanceCount < value1)
        {
            value5 = value4;
            value4 = value3;
            value3 = value2;
            value2 = Move_Camera.distanceCount;
            text1.color = Color.green;
            top1.color = Color.green;
            Do();
        }
        else if (Move_Camera.distanceCount > value3 && Move_Camera.distanceCount < value2)
        {
            value5 = value4;
            value4 = value3;
            value3 = Move_Camera.distanceCount;
            text1.color = Color.green;
            top1.color = Color.green;
            Do();
        }
        else if (Move_Camera.distanceCount > value4 && Move_Camera.distanceCount < value3)
        {
            value5 = value4;
            value4 = Move_Camera.distanceCount;
            text1.color = Color.green;
            top1.color = Color.green;
            Do();
        }
        else if (Move_Camera.distanceCount > value5 && Move_Camera.distanceCount < value4)
        {
            value5 = Move_Camera.distanceCount;
            text1.color = Color.green;
            top1.color = Color.green;
            Do();
        }
        void Do()
        {
            Menu.SetActive(true);
            Distance.SetActive(false);
            Distance1.SetActive(false);
            Home.SetActive(false);
            Restart.SetActive(false);
            text1.text = value1.ToString();
            text2.text = value2.ToString();
            text3.text = value3.ToString();
            text4.text = value4.ToString();
            text5.text = value5.ToString();
            value1 = PlayerPrefs.GetInt("value1");
            value2 = PlayerPrefs.GetInt("value2");
            value3 = PlayerPrefs.GetInt("value3");
            value4 = PlayerPrefs.GetInt("value4");
            value5 = PlayerPrefs.GetInt("value5");
        }
    }
}
