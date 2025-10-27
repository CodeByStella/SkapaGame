using System.Collections;
using UnityEngine;

public class TelegramManager : MonoBehaviour
{
    public static string TelegramId { get; set; }

    private MethodsAPIScript api;
    
    void Start()
    {
        api = FindObjectOfType<MethodsAPIScript>();
        
        if (api == null)
        {
            return;
        }
        
        if (string.IsNullOrEmpty(TelegramId))
        {
            TelegramId = "test_user";
            InitProfile();
        }
    }

    public void SetTelegramId(string id)
    {
        TelegramId = id;
        InitProfile();
    }
    
    // Static method to ensure TelegramId is set
    public static void EnsureTelegramIdSet()
    {
        if (string.IsNullOrEmpty(TelegramId))
        {
            TelegramId = "test_user";
        }
    }

    IEnumerator InitProfile()
    {
        yield return StartCoroutine(api.CreateProfile((response, error) =>
        {
            if (response != null)
            {
                UserData.SetUserData(response);
                MoneyGoldCount.SyncWithBackendCoins();
            }
            else if (error == "Profile is exist" || error.Contains("401"))
            {
                StartCoroutine(api.UpdateCoins(0, (existingUser) =>
                {
                    MoneyGoldCount.SyncWithBackendCoins();
                }));
            }
        }));
    }
}