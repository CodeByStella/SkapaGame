using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitoringBuyLevel : MonoBehaviour
{
    public GameObject StartButton, Kubok;
    public GameObject BuyButton;
    public Text BuySum;
    public GameObject Mus, tShirt, BRLVL, learn;

    private void Start()
    {
        LoadScene.loadStop = true;
        Debug.Log("loadStop" + LoadScene.loadStop);
    }

    void FixedUpdate()
    {
        // if (ControlScriptForMenu.krasnodarLvl && PlayerPrefs.GetInt("KrasnodarBuy") == 0)
        // {
        //     if (!Buttons.Shop && !Buttons.PromoCodeMenu)
        //     {
        //         StartButton.SetActive(false);
        //         BuyButton.SetActive(true);
        //         BuySum.text = "10";  
        //         onMus.SetActive(true);
        //         tShirt.SetActive(true);
        //     }
        // }
        // else if (ControlScriptForMenu.lasvegasrLvl && PlayerPrefs.GetInt("LasVegasBuy") == 0)
        // {
        //     if (!Buttons.Shop && !Buttons.PromoCodeMenu)
        //     {
        //         StartButton.SetActive(false);
        //         BuyButton.SetActive(true);
        //         BuySum.text = "20";   
        //         onMus.SetActive(true);
        //         tShirt.SetActive(true);
        //     }
        // }
        // else
        // {
            if (!Buttons.Shop && !Buttons.PromoCodeMenu)
            {
                StartButton.SetActive(true);
                // BuyButton.SetActive(false);  
                BRLVL.SetActive(false);
                //if (MusicMenu.Music)
                //{
                //    onMus.SetActive(true);
                //    offMus.SetActive(false);
                //}
                //if (!MusicMenu.Music)
                //{
                //    onMus.SetActive(false);
                //    offMus.SetActive(true);
                //}
                tShirt.SetActive(true);
                learn.SetActive(false);
                Mus.SetActive(true);
                Kubok.SetActive(true);
            }
            else
            {
                StartButton.SetActive(false);
                // BuyButton.SetActive(false);  
                BRLVL.SetActive(false);
                //onMus.SetActive(false);
                //offMus.SetActive(false);
                tShirt.SetActive(false);
                learn.SetActive(false);
                Mus.SetActive(false);
                Kubok.SetActive(false);
            }        
            // }
    }
}
