using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyGoldCount : MonoBehaviour
{
    public static int TotalCoins;
    // public int Money = 135;
    void Start()
    {
        // Load total coins from PlayerPrefs first (fallback)
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        Debug.Log("Total coins loaded from PlayerPrefs: " + TotalCoins);
        
        // Don't sync with backend here - wait for profile to be created
        // SyncWithBackendCoins() will be called after profile creation
        Debug.Log("Waiting for backend profile to be created before syncing coins...");
        
        // Start a coroutine to check if profile creation happens
        StartCoroutine(WaitForProfileCreation());
    }
    
    private System.Collections.IEnumerator WaitForProfileCreation()
    {
        yield return new WaitForSeconds(2f);
        TelegramManager.EnsureTelegramIdSet();
        
        // Just fetch coins directly from backend
        MethodsAPIScript api = FindObjectOfType<MethodsAPIScript>();
        if (api != null)
        {
            yield return StartCoroutine(api.GetCoins((result) =>
            {
                if (!string.IsNullOrEmpty(result))
                {
                    // Successfully got coins from backend
                    SyncWithBackendCoins(result);
                }
                else
                {
                    Debug.Log("🪙 Server offline - using local coins only");
                }
            }));
        }
        else
        {
            Debug.Log("🪙 No API found - using local coins only");
        }
    }
    
    // Method to sync with backend coin data
    public static void SyncWithBackendCoins()
    {
        if (UserData.UserDatas != null)
        {
            int backendCoins = UserData.GetGoldCoins();
            TotalCoins = backendCoins;
            PlayerPrefs.SetInt("TotalCoins", backendCoins);
            PlayerPrefs.Save();
            Debug.Log("🪙 Synced with backend: " + backendCoins + " coins");
        }
        else
        {
            Debug.Log("🪙 Using local coins: " + TotalCoins);
        }
    }
    
    // Method to sync with backend coins from GetCoins result
    public static void SyncWithBackendCoins(string coinsResult)
    {
        if (!string.IsNullOrEmpty(coinsResult))
        {
            try
            {
                int backendCoins = int.Parse(coinsResult.Trim('"'));
                TotalCoins = backendCoins;
                PlayerPrefs.SetInt("TotalCoins", backendCoins);
                PlayerPrefs.Save();
                Debug.Log("🪙 Synced with backend: " + backendCoins + " coins");
            }
            catch (System.Exception e)
            {
                Debug.LogError("🪙 Failed to parse backend coins: " + e.Message);
                Debug.Log("🪙 Using local coins: " + TotalCoins);
            }
        }
        else
        {
            Debug.Log("🪙 Using local coins: " + TotalCoins);
        }
    }
    //public void MoneyUpd()
    //{
    //    GetComponent<Text>().text = /*PlayerPrefs.GetInt("TotalCoins").*/TotalCoins.ToString();
    //}
    void Update()
    {
        // Update display with current total coins
        GetComponent<Text>().text = TotalCoins.ToString();
    }
    
    // Method to update coin count when coins are collected
    public static void UpdateCoinDisplay()
    {
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
    }
    
    // Method to sync with backend after coin changes
    public static void SyncAfterCoinChange()
    {
        // First update local TotalCoins from PlayerPrefs
        TotalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        
        // Then sync with backend if available
        SyncWithBackendCoins();
    }
}
