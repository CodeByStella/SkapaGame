using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Money : MonoBehaviour
{
    public static bool moneyBool = false;
    public int indexMoney;
    public int GoldCount = 0;
    public GameObject coin;

    private void Start()
    {
        // PlayerPrefs.SetInt("moneyOne", 0);
        // PlayerPrefs.SetInt("moneyTwo", 0);
        // PlayerPrefs.SetInt("moneyThree", 0);
        if (SceneManager.GetActiveScene().name == "Level_LasVegas" || SceneManager.GetActiveScene().name == "Level_School" || SceneManager.GetActiveScene().name == "Level_Krasnodar")
        {
            if (gameObject.transform.position.y == -0.05f 
                || gameObject.transform.position.y == 1.05f 
                || gameObject.transform.position.y == 1.45f
                || gameObject.transform.position.y == 2.55f )
            {
                indexMoney = 3;
            }
            else if (gameObject.transform.position.y == -1.1f 
                     || gameObject.transform.position.y == 0f)
            {
                indexMoney = 2;
            }
            else
            {
                indexMoney = 1;
            }
        }
        else
        {
            if (gameObject.transform.position.y == 0.9f 
                || gameObject.transform.position.y == 2f)
            {
                indexMoney = 3;
            }
            else if (gameObject.transform.position.y == 0.4f 
                     || gameObject.transform.position.y == -0.7f)
            {
                indexMoney = 2;
            }
            else
            {
                indexMoney = 1;
            }
        }
       
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.transform.name == "MoneyONE0000(Clone)")
            {
                PlayerPrefs.SetInt("moneyOne", 1);
                Move_Camera.fireTrue = true;
                Debug.Log("Coin 1 collected! +1 coin");
                GoldCount++;
                
                // Update total coins
                int currentTotal = PlayerPrefs.GetInt("TotalCoins", 0);
                PlayerPrefs.SetInt("TotalCoins", currentTotal + 1);
                PlayerPrefs.Save(); // Ensure data is saved immediately
                MoneyGoldCount.TotalCoins = PlayerPrefs.GetInt("TotalCoins");
                MoneyGoldCount.UpdateCoinDisplay();
                Debug.Log("Total coins now: " + MoneyGoldCount.TotalCoins);
                
                Destroy(gameObject); 
            }
            else if (gameObject.transform.name == "MoneyTWO0000(Clone)")
            {
                PlayerPrefs.SetInt("moneyTwo", 1);
                Move_Camera.fireTrue = true;
                Debug.Log("Coin 2 collected! +2 coins");
                GoldCount++;
                
                // Update total coins
                int currentTotal = PlayerPrefs.GetInt("TotalCoins", 0);
                PlayerPrefs.SetInt("TotalCoins", currentTotal + 2);
                PlayerPrefs.Save(); // Ensure data is saved immediately
                MoneyGoldCount.TotalCoins = PlayerPrefs.GetInt("TotalCoins");
                MoneyGoldCount.UpdateCoinDisplay();
                Debug.Log("Total coins now: " + MoneyGoldCount.TotalCoins);
                
                Destroy(gameObject); 
            }
            else if (gameObject.transform.name == "MoneyTHREE0000(Clone)")
            {
                PlayerPrefs.SetInt("moneyThree", 1);
                Move_Camera.fireTrue = true;
                Debug.Log("Coin 3 collected! +3 coins");
                GoldCount++;
                
                // Update total coins
                int currentTotal = PlayerPrefs.GetInt("TotalCoins", 0);
                PlayerPrefs.SetInt("TotalCoins", currentTotal + 3);
                PlayerPrefs.Save(); // Ensure data is saved immediately
                MoneyGoldCount.TotalCoins = PlayerPrefs.GetInt("TotalCoins");
                MoneyGoldCount.UpdateCoinDisplay();
                Debug.Log("Total coins now: " + MoneyGoldCount.TotalCoins);
                
                Destroy(gameObject); 
            }
            //else
            //{
            //    PlayerPrefs.SetInt("moneyTwo", 1);
            //    Move_Camera.fireTrue = true;
            //    Debug.Log("5");
            //    GoldCount++;
            //    Destroy(gameObject);
            //}
        }
    }

    private void Update()
    {
        PlayerPrefs.SetInt("GoldMoney", GoldCount);
        //Debug.Log(PlayerPrefs.GetInt("GoldMoney"));
        if (indexMoney == HeroClassNew.index)
        {
            if (GetComponent<CircleCollider2D>()) GetComponent<CircleCollider2D>().enabled = true;
        }
        else
        {
            if (GetComponent<CircleCollider2D>()) GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (HeroClassNew.Fail)
        {
            Destroy(gameObject);
        }
    }
}
