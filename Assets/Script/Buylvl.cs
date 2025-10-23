using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buylvl : MonoBehaviour
{
    public GameObject buyk;
    public GameObject buyl;
    public Image StartButton;
    public Sprite SStart;
    public int KrasPrice = 30;
    public int LasPrice = 90;
    //public static bool isBought = false;
    //void Start()
    //{
    //    //PlayerPrefs.SetInt("Kras", 0);
    //    //PlayerPrefs.SetInt("Las", 0);
    //    // ControlScriptForMenu.schoolLvl = true;
    //    // ControlScriptForMenu.lasvegasrLvl = false;
    //    // ControlScriptForMenu.krasnodarLvl = false;
    //    // ControlScriptForMenu.s = true;
    //    // ControlScriptForMenu.k = false;
    //    // ControlScriptForMenu.l = false;
    //    //PlayerPrefs.SetInt("Kras", 0); PlayerPrefs.SetInt("Las", 0);
    //}
    public void YesK()
    {
        if(MoneyGoldCount.TotalCoins >= 30)
        {
            //int PriceCoins = PlayerPrefs.GetInt("TotalCoins");
            //totalCoins -= 30; PlayerPrefs.SetInt("TotalCoins", totalCoins);
            MoneyGoldCount.TotalCoins -= KrasPrice;
            PlayerPrefs.SetInt("Kras", 1);
            StartButton.sprite = SStart;
            buyk.SetActive(false);
            //isBought = true;
        }
        else if (MoneyGoldCount.TotalCoins < 30) buyk.SetActive(false);
    }
    public void YesL()
    {
        if (MoneyGoldCount.TotalCoins >= 90)
        {
            //int PriceCoins = /*PlayerPrefs.GetInt("TotalCoins")*/;
            /*totalCoins -= 90; PlayerPrefs.SetInt("TotalCoins", totalCoins)*/ 
            MoneyGoldCount.TotalCoins -= LasPrice;
            PlayerPrefs.SetInt("Las", 1);
            StartButton.sprite = SStart;
            buyl.SetActive(false);
            //isBought = true;
        }
        else if (MoneyGoldCount.TotalCoins < 90) buyl.SetActive(false);
    }
    public void NoK()
    {
        buyk.SetActive(false);
    }
    public void NoL()
    {
        buyl.SetActive(false);
    }
}
