using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopButtons : MonoBehaviour
{
    [SerializeField] GameObject moneyText;

    private int _money;

    private bool item_is_buy;
    private MethodsAPIScript _methodsAPIScript;

    private void Start()
    {
        // PlayerPrefs.SetInt("TsirtPick1", 0);
        // PlayerPrefs.SetInt("TsirtPick2", 0);
        // PlayerPrefs.SetInt("TsirtPick3", 0);
        // PlayerPrefs.SetInt("TsirtPick4", 0);
        // PlayerPrefs.SetInt("TsirtBuy1", 0);
        // PlayerPrefs.SetInt("TsirtBuy2", 0);
        // PlayerPrefs.SetInt("TsirtBuy3", 0);
        // PlayerPrefs.SetInt("TsirtBuy4", 0);
        //     
        //     PlayerPrefs.SetInt("TrickOllieFlip", 0);
        //     PlayerPrefs.SetInt("TrickImpossible", 0);
        //     PlayerPrefs.SetInt("TrickMethod", 0);
        //     PlayerPrefs.SetInt("TrickNollie", 0);
        //     PlayerPrefs.SetInt("TrickNollieFlip", 0);
        //     PlayerPrefs.SetInt("TrickChrist", 0);
        //     PlayerPrefs.SetInt("Trick360", 0);
        //     PlayerPrefs.SetInt("Trick360Christ", 0);
        //     PlayerPrefs.SetInt("TrickBackFlip", 0);
        //     PlayerPrefs.SetInt("TrickBenihana", 0);
        if (int.TryParse(moneyText.GetComponent<Text>().text, out int result))
            _money = result;
    }

    public void TshirtScr()
    {
        // Debug.Log("работает");
        if (Buttons.skins) ButtonSkinsScr(this.gameObject.name);
        else if (Buttons.tricks) ButtonTricsStr(this.gameObject.name);
        
            // Debug.Log (this.gameObject.name);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("TrickOllieFlip") == 1 && this.gameObject.name == "Buy1B" && Buttons.tricks)
        {
            Text childText = this.gameObject.GetComponentInChildren<Text>();
            childText.text = "Picked";
        }
        else if (PlayerPrefs.GetInt("TrickImpossible") == 1 && this.gameObject.name == "Buy2B" && Buttons.tricks)
        {
            Text childText = this.gameObject.GetComponentInChildren<Text>();
            childText.text = "Picked";
        }
        else if (PlayerPrefs.GetInt("TrickMethod") == 1 && this.gameObject.name == "Buy3B" && Buttons.tricks)
        {
            Text childText = this.gameObject.GetComponentInChildren<Text>();
            childText.text = "Picked";
        }
        else if (PlayerPrefs.GetInt("TrickNollie") == 1 && this.gameObject.name == "Buy4B" && Buttons.tricks)
        {
            Text childText = this.gameObject.GetComponentInChildren<Text>();
            childText.text = "Picked";
        }
        else if (PlayerPrefs.GetInt("TrickNollieFlip") == 1 && this.gameObject.name == "Buy5B" && Buttons.tricks)
        {
            Text childText = this.gameObject.GetComponentInChildren<Text>();
            childText.text = "Picked";
        }
        else if (PlayerPrefs.GetInt("TrickChrist") == 1 && this.gameObject.name == "Buy6B" && Buttons.tricks)
        {
            Text childText = this.gameObject.GetComponentInChildren<Text>();
            childText.text = "Picked";
        }
        else if (PlayerPrefs.GetInt("Trick360") == 1 && this.gameObject.name == "Buy7B" && Buttons.tricks)
        {
            Text childText = this.gameObject.GetComponentInChildren<Text>();
            childText.text = "Picked";
        }
        else if (PlayerPrefs.GetInt("Trick360Christ") == 1 && this.gameObject.name == "Buy8B" && Buttons.tricks)
        {
            Text childText = this.gameObject.GetComponentInChildren<Text>();
            childText.text = "Picked";
        }
        else if (PlayerPrefs.GetInt("TrickBackFlip") == 1 && this.gameObject.name == "Buy9B" && Buttons.tricks)
        {
            Text childText = this.gameObject.GetComponentInChildren<Text>();
            childText.text = "Picked";
        }
        else if (PlayerPrefs.GetInt("TrickBenihana") == 1 && this.gameObject.name == "Buy10B" && Buttons.tricks)
        {
            Text childText = this.gameObject.GetComponentInChildren<Text>();
            childText.text = "Picked";
        }
        
        
        if (PlayerPrefs.GetInt("TsirtPick1") == 1 && Buttons.skins)
        {
            // Debug.Log("Pick 1");
            if (this.gameObject.name == "Buy2B" && PlayerPrefs.GetInt("TsirtBuy2") == 1
                || this.gameObject.name == "Buy3B" && PlayerPrefs.GetInt("TsirtBuy3") == 1
                || this.gameObject.name == "Buy4B" && PlayerPrefs.GetInt("TsirtBuy4") == 1)
            {
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Choose";
            }

            if (this.gameObject.name == "Buy1B" && PlayerPrefs.GetInt("TsirtPick1") == 1)
            {
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Picked";
            }
        }
        else if (PlayerPrefs.GetInt("TsirtPick2") == 1 && Buttons.skins)
        {
            // Debug.Log("Pick 2");
            if (this.gameObject.name == "Buy1B" && PlayerPrefs.GetInt("TsirtBuy1") == 1
                || this.gameObject.name == "Buy3B" && PlayerPrefs.GetInt("TsirtBuy3") == 1
                || this.gameObject.name == "Buy4B" && PlayerPrefs.GetInt("TsirtBuy4") == 1)
            {
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Choose";
            }
            
            if (this.gameObject.name == "Buy2B" && PlayerPrefs.GetInt("TsirtPick2") == 1)
            {
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Picked";
            }
        }
        else if (PlayerPrefs.GetInt("TsirtPick3") == 1 && Buttons.skins)
        {
            // Debug.Log("Pick 3");
            if (this.gameObject.name == "Buy1B" && PlayerPrefs.GetInt("TsirtBuy1") == 1
                || this.gameObject.name == "Buy2B" && PlayerPrefs.GetInt("TsirtBuy2") == 1
                || this.gameObject.name == "Buy4B" && PlayerPrefs.GetInt("TsirtBuy4") == 1)
            {
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Choose";
            }
            
            if (this.gameObject.name == "Buy3B" && PlayerPrefs.GetInt("TsirtPick3") == 1)
            {
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Picked";
            }
        }
        else if (PlayerPrefs.GetInt("TsirtPick4") == 1 && Buttons.skins)
        {
            // Debug.Log("Pick 4");
            if (this.gameObject.name == "Buy1B" && PlayerPrefs.GetInt("TsirtBuy1") == 1
                || this.gameObject.name == "Buy2B" && PlayerPrefs.GetInt("TsirtBuy2") == 1
                || this.gameObject.name == "Buy3B" && PlayerPrefs.GetInt("TsirtBuy3") == 1)
            {
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Choose";
            }
            
            if (this.gameObject.name == "Buy4B" && PlayerPrefs.GetInt("TsirtPick4") == 1)
            {
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Picked";
            }
        }
    }

    private void ButtonSkinsScr(String nameObject)
    {
        // Debug.Log(PlayerPrefs.GetInt("TsirtBuy1"));
        // Debug.Log(PlayerPrefs.GetInt("TsirtBuy2"));
        // Debug.Log(PlayerPrefs.GetInt("TsirtBuy3"));
        // Debug.Log(PlayerPrefs.GetInt("TsirtBuy4"));
        // Debug.Log(PlayerPrefs.GetInt("TsirtPick1"));
        // Debug.Log(PlayerPrefs.GetInt("TsirtPick2"));
        // Debug.Log(PlayerPrefs.GetInt("TsirtPick3"));
        // Debug.Log(PlayerPrefs.GetInt("TsirtPick4"));
        if (Buttons.skins)
        {
            if (nameObject == "Buy1B" && PlayerPrefs.GetInt("TsirtBuy1") == 0)
            {
                item_is_buy = BuyScr(500);
                if (item_is_buy)
                {
                    PlayerPrefs.SetInt("TsirtBuy1", 1);
                    // Debug.Log("Buy1B Buy");
                    // childStr.GetComponent<Text>().text = "Unselected";
                    Text childText = this.gameObject.GetComponentInChildren<Text>();
                    childText.text = "Choose";   
                }
            }
            else if (nameObject == "Buy1B" && PlayerPrefs.GetInt("TsirtBuy1") == 1)
            {
                PlayerPrefs.SetInt("TsirtPick1", 1);
                PlayerPrefs.SetInt("TsirtPick2", 0);
                PlayerPrefs.SetInt("TsirtPick3", 0);
                PlayerPrefs.SetInt("TsirtPick4", 0);
                // Debug.Log("Buy1B Pick");
                // childStr.GetComponent<Text>().text = "Unselected";
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Picked";
            }
            
            if (nameObject == "Buy2B" && PlayerPrefs.GetInt("TsirtBuy2") == 0)
            {
                item_is_buy = BuyScr(800);
                if (item_is_buy)
                {
                    PlayerPrefs.SetInt("TsirtBuy2", 1);
                    // Debug.Log("Buy2B");
                    Text childText = this.gameObject.GetComponentInChildren<Text>();
                    childText.text = "Choose";
                }
            }
            else if (nameObject == "Buy2B" && PlayerPrefs.GetInt("TsirtBuy1") == 1)
            {
                PlayerPrefs.SetInt("TsirtPick1", 0);
                PlayerPrefs.SetInt("TsirtPick2", 1);
                PlayerPrefs.SetInt("TsirtPick3", 0);
                PlayerPrefs.SetInt("TsirtPick4", 0);
                // Debug.Log("Buy1B");
                // childStr.GetComponent<Text>().text = "Unselected";
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Picked";
            }
            
            if (nameObject == "Buy3B" && PlayerPrefs.GetInt("TsirtBuy3") == 0)
            {
                PlayerPrefs.SetInt("TsirtBuy3", 1);
                // Debug.Log("Buy3B");
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Choose";
            }
            else if (nameObject == "Buy3B" && PlayerPrefs.GetInt("TsirtBuy1") == 1)
            {
                PlayerPrefs.SetInt("TsirtPick1", 0);
                PlayerPrefs.SetInt("TsirtPick2", 0);
                PlayerPrefs.SetInt("TsirtPick3", 1);
                PlayerPrefs.SetInt("TsirtPick4", 0);
                // Debug.Log("Buy1B");
                // childStr.GetComponent<Text>().text = "Unselected";
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Picked";
            }
            
            if (nameObject == "Buy4B" && PlayerPrefs.GetInt("TsirtBuy4") == 0)
            {
                PlayerPrefs.SetInt("TsirtBuy4", 1);
                // Debug.Log("Buy4B");
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Choose";
            }
            else if (nameObject == "Buy4B" && PlayerPrefs.GetInt("TsirtBuy1") == 1)
            {
                PlayerPrefs.SetInt("TsirtPick1", 0);
                PlayerPrefs.SetInt("TsirtPick2", 0);
                PlayerPrefs.SetInt("TsirtPick3", 0);
                PlayerPrefs.SetInt("TsirtPick4", 1);
                // Debug.Log("Buy1B");
                // childStr.GetComponent<Text>().text = "Unselected";
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Picked";
            }
        }
    }

    private void ButtonTricsStr(String nameObject)
    {
        if (Buttons.tricks)
        {
            if (nameObject == "Buy1B" && PlayerPrefs.GetInt("TrickOllieFlip") == 0)
            {
                item_is_buy = BuyScr(100);
                if (item_is_buy)
                {
                    PlayerPrefs.SetInt("TrickOllieFlip", 1);
                    // Debug.Log("TrickOllieFlip");
                    // childStr.GetComponent<Text>().text = "Unselected";
                    Text childText = this.gameObject.GetComponentInChildren<Text>();
                    childText.text = "Picked";   
                }
                _methodsAPIScript.PurchaseTrick(1);
            }
            else if (nameObject == "Buy2B" && PlayerPrefs.GetInt("TrickImpossible") == 0)
            {
                item_is_buy = BuyScr(200);
                if (item_is_buy)
                {
                    PlayerPrefs.SetInt("TrickImpossible", 1);
                    // Debug.Log("TrickImpossible");
                    // childStr.GetComponent<Text>().text = "Unselected";
                    Text childText = this.gameObject.GetComponentInChildren<Text>();
                    childText.text = "Picked";
                }
                _methodsAPIScript.PurchaseTrick(2);
            }
            else if (nameObject == "Buy3B" && PlayerPrefs.GetInt("TrickMethod") == 0)
            {
                item_is_buy = BuyScr(300);
                if (item_is_buy)
                {
                    PlayerPrefs.SetInt("TrickMethod", 1);
                    // Debug.Log("TrickMethod");
                    // childStr.GetComponent<Text>().text = "Unselected";
                    Text childText = this.gameObject.GetComponentInChildren<Text>();
                    childText.text = "Picked";   
                }
                _methodsAPIScript.PurchaseTrick(3);
            }
            else if (nameObject == "Buy4B" && PlayerPrefs.GetInt("TrickNollie") == 0)
            {
                item_is_buy = BuyScr(400);
                if (item_is_buy)
                {
                    PlayerPrefs.SetInt("TrickNollie", 1);
                    // Debug.Log("TrickNollie");
                    // childStr.GetComponent<Text>().text = "Unselected";
                    Text childText = this.gameObject.GetComponentInChildren<Text>();
                    childText.text = "Picked";   
                }
                _methodsAPIScript.PurchaseTrick(4);
            }
            else if (nameObject == "BuyTrickNollieFlipButton" && PlayerPrefs.GetInt("TrickNollieFlip") == 0)
            {
                item_is_buy = BuyScr(500);
                if (item_is_buy)
                {
                    PlayerPrefs.SetInt("TrickNollieFlip", 1);
                    // Debug.Log("TrickNollieFlip");
                    // childStr.GetComponent<Text>().text = "Unselected";
                    Text childText = this.gameObject.GetComponentInChildren<Text>();
                    childText.text = "Picked";   
                }
                _methodsAPIScript.PurchaseTrick(5);
            }
            else if (nameObject == "BuyTrickChristButton" && PlayerPrefs.GetInt("TrickChrist") == 0)
            {
                PlayerPrefs.SetInt("TrickChrist", 1);
                // Debug.Log("TrickChrist");
                // childStr.GetComponent<Text>().text = "Unselected";
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Picked";
                _methodsAPIScript.PurchaseTrick(6);
            }
            else if (nameObject == "BuyTrickBenihanaButton" && PlayerPrefs.GetInt("Trick360") == 0)
            {
                PlayerPrefs.SetInt("Trick360", 1);
                // Debug.Log("Trick360");
                // childStr.GetComponent<Text>().text = "Unselected";
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Picked";
                _methodsAPIScript.PurchaseTrick(7);
            }
            else if (nameObject == "Trick360Button" && PlayerPrefs.GetInt("Trick360Christ") == 0)
            {
                PlayerPrefs.SetInt("Trick360Christ", 1);
                // Debug.Log("Trick360Christ");
                // childStr.GetComponent<Text>().text = "Unselected";
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Picked";
                _methodsAPIScript.PurchaseTrick(8);
            }
            else if (nameObject == "BuyTrick360ChristButton" && PlayerPrefs.GetInt("TrickBackFlip") == 0)
            {
                PlayerPrefs.SetInt("TrickBackFlip", 1);
                // Debug.Log("TrickBackFlip");
                // childStr.GetComponent<Text>().text = "Unselected";
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Picked";
                _methodsAPIScript.PurchaseTrick(9);
            }
            else if (nameObject == "BuyTrickBackFlipButton" && PlayerPrefs.GetInt("TrickBenihana") == 0)
            {
                PlayerPrefs.SetInt("TrickBenihana", 1);
                // Debug.Log("TrickBenihana");
                // childStr.GetComponent<Text>().text = "Unselected";
                Text childText = this.gameObject.GetComponentInChildren<Text>();
                childText.text = "Picked";
                _methodsAPIScript.PurchaseTrick(10);
            }
        }
    }

    bool BuyScr(int buyItem)
    {
        int moneyNow = PlayerPrefs.GetInt("Money");
        // Debug.Log(moneyNow);
        if (moneyNow < buyItem)
        {
            // Debug.Log("Недостаточно средств");
            return false;
        }
        else
        {
            int sum = moneyNow - buyItem;
            PlayerPrefs.SetInt("Money", sum);
            MoneyCount.switchSum = true;
            return true;
        }
    }
    
    
}
