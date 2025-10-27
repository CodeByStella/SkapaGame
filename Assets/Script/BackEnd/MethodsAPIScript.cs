using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

public class MethodsAPIScript : MonoBehaviour
{
    private const string BaseURL = "https://api.skapa.world";
    
    void Start()
    {
        // MethodsAPIScript initialized
    }

    private int _currentCoins = 0;

    private Buttons Buttons;
    private ApiClient _apiClient;
    private PaymentScript _paymentScript;

    [SerializeField] GameObject coinsText;

    public static MethodsAPIScript Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // profile
    // post       
    public IEnumerator CreateProfile(Action<CreateProfileResponse, string> callback)
    {
        string methodURL = "/profile/create";

        // Ensure TelegramId is set
        if (string.IsNullOrEmpty(TelegramManager.TelegramId))
        {
            TelegramManager.TelegramId = "test_user";
        }

        CreateProfileRequest request = new CreateProfileRequest
        {
            telegram_id = TelegramManager.TelegramId
        };

        string json = JsonUtility.ToJson(request);
        string fullURL = BaseURL + methodURL;

        UnityWebRequest webRequest = UnityWebRequest.Post(fullURL, json, "application/json");
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.timeout = 10;
        webRequest.SetRequestHeader("Accept", "application/json");
        webRequest.SetRequestHeader("User-Agent", "Unity-WebRequest");
        
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            string jsonText = webRequest.downloadHandler.text;
            CreateProfileResponse user = JsonUtility.FromJson<CreateProfileResponse>(jsonText);
            UserData.SetUserData(user);
            callback?.Invoke(user, null);
        }
        else
        {
            Debug.LogError("[CREATE_PROFILE] Error: " + webRequest.downloadHandler.text);
            if (webRequest.responseCode == 401)
            {
                Debug.Log("[CREATE_PROFILE] 401 Unauthorized - trying to get existing profile");
                StartCoroutine(GetExistingProfile(callback));
            }
            else
            {
                callback?.Invoke(null, webRequest.downloadHandler.text);
            }
        }
    }


    // Method to get existing profile when 401 error occurs
    private IEnumerator GetExistingProfile(Action<CreateProfileResponse, string> callback)
    {
        Debug.Log("[GET_EXISTING_PROFILE] Attempting to get existing profile data");
        yield return StartCoroutine(GetCoins((result) =>
        {
            if (!string.IsNullOrEmpty(result))
            {
                CreateProfileResponse existingProfile = new CreateProfileResponse
                {
                    telegram_id = TelegramManager.TelegramId,
                    gold_coins = _currentCoins
                };
                
                UserData.SetUserData(existingProfile);
                callback?.Invoke(existingProfile, null);
                Debug.Log("[GET_EXISTING_PROFILE] Successfully retrieved existing profile");
            }
            else
            {
                Debug.LogError("[GET_EXISTING_PROFILE] Failed to get existing profile data");
                callback?.Invoke(null, "Failed to get existing profile");
            }
        }));
    }

    // put
    public IEnumerator UpdateCoins(int changeableValueCoins, System.Action<string> callback = null) 
    {
        string methodURL = "/profile/update-coins";

        // Get current coins from UserData if available, otherwise use _currentCoins
        int currentBackendCoins = 0;
        if (UserData.UserDatas != null)
        {
            currentBackendCoins = UserData.GetGoldCoins();
        }
        else
        {
            currentBackendCoins = _currentCoins;
        }

        UpdateCoinsRequest request = new UpdateCoinsRequest
        {
            profile = new Profile { telegram_id = TelegramManager.TelegramId },
            coins = new UpdateCoinsRequest.Coins { gold_coins = currentBackendCoins + changeableValueCoins }
        };

        string json = JsonUtility.ToJson(request);

        UnityWebRequest webRequest = UnityWebRequest.Put(BaseURL + methodURL, json);
        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            string jsonText = webRequest.downloadHandler.text;
            CreateProfileResponse user = JsonUtility.FromJson<CreateProfileResponse>(jsonText);
            UserData.SetUserData(user);
            Debug.Log("🪙 Coins updated: +" + changeableValueCoins + " -> Total: " + user.gold_coins);
        }
        else
        {
            Debug.LogError("[UPDATE_COINS] Error: " + webRequest.downloadHandler.text);
        }
    }

    // post
    public IEnumerator GetCoins(System.Action<string> callback = null) 
    {
        string methodURL = "/profile/get-coins";

        GetCoinsRequest request = new GetCoinsRequest
        {
             telegram_id = TelegramManager.TelegramId 
        };

        string json = JsonUtility.ToJson(request);

        // Use UnityWebRequest.Post to avoid Curl error 26
        UnityWebRequest webRequest = UnityWebRequest.Post(BaseURL + methodURL, json, "application/json");
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        Debug.Log("[GET_COINS] Sending " + methodURL + " request...");
        yield return webRequest.SendWebRequest();
        Debug.Log("[GET_COINS] " + methodURL + " completed. Result: " + webRequest.result);

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            _currentCoins = int.Parse(webRequest.downloadHandler.text.Trim('"')); // Parse coins from response

            // Update UI text with current coins
            if (coinsText != null)
            {
                coinsText.GetComponent<Text>().text = _currentCoins.ToString();
            }
            Debug.Log("Successfully got coins");
        }
        else
        {
            // error
            Debug.LogError("[GET_COINS] Error: " + webRequest.downloadHandler.text);
            Debug.Log($"Error in GetCoins, using local data as fallback");
        }
    }

    // put
    public IEnumerator CompleteTutorial(System.Action<string> callback = null) 
    {
        string methodURL = "/profile/tutorial/complete";

        CompleteTutorialRequest request = new CompleteTutorialRequest
        {
            telegram_id = TelegramManager.TelegramId
        };

        string json = JsonUtility.ToJson(request);

        Debug.Log("=== COMPLETE TUTORIAL REQUEST ===");
        Debug.Log("URL: " + BaseURL + methodURL);
        Debug.Log("TelegramId: " + TelegramManager.TelegramId);
        Debug.Log("Request JSON: " + json);

        // Use UnityWebRequest.Put to avoid Curl error 26
        UnityWebRequest webRequest = UnityWebRequest.Put(BaseURL + methodURL, json);
        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        Debug.Log("Sending " + methodURL + " request...");
        yield return webRequest.SendWebRequest();
        Debug.Log(methodURL + " completed. Result: " + webRequest.result);
        
        Debug.Log("[COMPLETE_TUTORIAL] Response Code: " + webRequest.responseCode);
        Debug.Log("[COMPLETE_TUTORIAL] Response Text: " + webRequest.downloadHandler.text);

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Tutorial completed successfully");
            callback?.Invoke("success");
        }
        else
        {
            Debug.LogError("[COMPLETE_TUTORIAL] Tutorial completion failed: " + webRequest.error);
            Debug.LogError("[COMPLETE_TUTORIAL] Response: " + webRequest.downloadHandler.text);
            callback?.Invoke(webRequest.error);
        }
    }

    //records
    // post
    public IEnumerator SaveRecord(int score, Action onSuccess = null, Action<string> onError = null) 
    {
        string methodURL = "/records/save";

        SaveRecordRequest request = new SaveRecordRequest
        {
            profile = new Profile { telegram_id = TelegramManager.TelegramId },
            record = new SaveRecordRequest.Record
            {
                level = "School",
                score = score
            }
        };

        string json = JsonUtility.ToJson(request);

        // Use UnityWebRequest.Post to avoid Curl error 26
        UnityWebRequest webRequest = UnityWebRequest.Post(BaseURL + methodURL, json, "application/json");
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        Debug.Log("Sending " + methodURL + " request...");
        yield return webRequest.SendWebRequest();
        Debug.Log(methodURL + " completed. Result: " + webRequest.result);

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"SaveRecord success: {webRequest.downloadHandler.text}");
            onSuccess?.Invoke();
            Debug.Log("Successfully saved record");
        }
        else
        {
            Debug.LogError($"SaveRecord failed: {webRequest.error}");
            onError?.Invoke(webRequest.error);
            Debug.Log("Failed to save record");
        }
    }

    // post 
    public IEnumerator GetLocalRecords(Action<int[]> onSuccess = null, Action<string> onError = null) 
    {
        string methodURL = "/records/local";

        GetLocalRecordsRequest request = new GetLocalRecordsRequest
        {
            profile = new Profile { telegram_id = TelegramManager.TelegramId },
            record = new GetLocalRecordsRequest.Record { level = "School" }
        };

        string json = JsonUtility.ToJson(request);

        // Use UnityWebRequest.Post to avoid Curl error 26
        UnityWebRequest webRequest = UnityWebRequest.Post(BaseURL + methodURL, json, "application/json");
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        Debug.Log("Sending " + methodURL + " request...");
        yield return webRequest.SendWebRequest();
        Debug.Log(methodURL + " completed. Result: " + webRequest.result);

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"GetLocalRecords success: {webRequest.downloadHandler.text}");
            GetLocalRecordsResponse resp = JsonUtility.FromJson<GetLocalRecordsResponse>(webRequest.downloadHandler.text);
            onSuccess?.Invoke(resp.records);
        }
        else
        {
            Debug.LogError($"GetLocalRecords failed: {webRequest.error}");
            onError?.Invoke(webRequest.error);
        }
    }

    // post 
    public IEnumerator GetGlobalRecords(System.Action<string> callback = null) 
    {
        string methodURL = "/records/global";

        GetGlobalRecordsRequest request = new GetGlobalRecordsRequest
        {
            level = "School"
        };

        string json = JsonUtility.ToJson(request);

        // Use UnityWebRequest.Post to avoid Curl error 26
        UnityWebRequest webRequest = UnityWebRequest.Post(BaseURL + methodURL, json, "application/json");
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        Debug.Log("Sending " + methodURL + " request...");
        yield return webRequest.SendWebRequest();
        Debug.Log(methodURL + " completed. Result: " + webRequest.result);

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            Debug.Log("Successfully got global records");
        }
        else
        {
            // error
            Debug.Log("Failed to get global records");
        }
    }

    //tricks
    // post
    public IEnumerator PurchaseTrick(int trickId, System.Action<string> callback = null) 
    {
        string methodURL = "/tricks/purchase";

        PurchaseTrickRequest request = new PurchaseTrickRequest
        {
            profile = new Profile { telegram_id = TelegramManager.TelegramId },
            trick = new PurchaseTrickRequest.Trick { trick_id = trickId }
        };

        string json = JsonUtility.ToJson(request);

        // Use UnityWebRequest.Post to avoid Curl error 26
        UnityWebRequest webRequest = UnityWebRequest.Post(BaseURL + methodURL, json, "application/json");
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        Debug.Log("Sending " + methodURL + " request...");
        yield return webRequest.SendWebRequest();
        Debug.Log(methodURL + " completed. Result: " + webRequest.result);

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            UpdateTrickStatus(trickId);
            Debug.Log("Successfully purchased trick");
        }
        else
        {
            // error
            Debug.Log("Failed to purchase trick");
        }
    }

    // put
    public IEnumerator UpdateTrickStatus(int trickId,System.Action<string> callback = null) 
    {
        string methodURL = "/tricks/update-status";

        UpdateTrickRequest request = new UpdateTrickRequest
        {
            profile = new Profile { telegram_id = TelegramManager.TelegramId },
            trick = new UpdateTrickRequest.Trick
            {
                trick_id = trickId,
                is_in_use = true // Set to true when purchased, false when not purchased
            }
        };

        string json = JsonUtility.ToJson(request);

        // Use UnityWebRequest.Put to avoid Curl error 26
        UnityWebRequest webRequest = UnityWebRequest.Put(BaseURL + methodURL, json);
        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        Debug.Log("Sending " + methodURL + " request...");
        yield return webRequest.SendWebRequest();
        Debug.Log(methodURL + " completed. Result: " + webRequest.result);

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            Text childText = this.gameObject.GetComponentInChildren<Text>();
            childText.text = "Picked";
            Debug.Log("Successfully updated trick status");
        }
        else
        {
            // error
            Debug.Log("Failed to update trick status");
        }
    }

    // post
    public IEnumerator GetTricks(System.Action<GetTricksResponse[]> callback = null) 
    {
        string methodURL = "/tricks/tricks";

        GetTricksRequest request = new GetTricksRequest
        {
            telegram_id = TelegramManager.TelegramId
        };

        string json = JsonUtility.ToJson(request);

        // Use UnityWebRequest.Post to avoid Curl error 26
        UnityWebRequest webRequest = UnityWebRequest.Post(BaseURL + methodURL, json, "application/json");
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        Debug.Log("Sending " + methodURL + " request...");
        yield return webRequest.SendWebRequest();
        Debug.Log(methodURL + " completed. Result: " + webRequest.result);

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            string jsonText = webRequest.downloadHandler.text;
            GetTricksResponse[] tricks = JsonUtility.FromJson<GetTricksResponse[]>(jsonText);
            callback?.Invoke(tricks);
            Debug.Log("Successfully got tricks");
        }
        else
        {
            Debug.Log("Failed to get tricks");
            // error
        }
    }

    // post 
    public IEnumerator GetAllTricks(System.Action<string> callback = null) 
    {
        string methodURL = "/tricks/tricks/all";

        // Use UnityWebRequest.Post to avoid Curl error 26
        UnityWebRequest webRequest = UnityWebRequest.Post(BaseURL + methodURL, "", "application/json");
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        Debug.Log("Sending " + methodURL + " request...");
        yield return webRequest.SendWebRequest();
        Debug.Log(methodURL + " completed. Result: " + webRequest.result);

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            Debug.Log("Successfully got all tricks");
        }
        else
        {
            // error
            Debug.Log("Failed to get all tricks");
        }
    }

    //daily

    // post 
    public IEnumerator CheckDailyLogin(System.Action<string> callback = null) 
    {
        string methodURL = "/daily/daily/check";

        CheckDailyLoginRequest request = new CheckDailyLoginRequest
        {
            telegram_id = TelegramManager.TelegramId
        };

        string json = JsonUtility.ToJson(request);

        // Use UnityWebRequest.Post to avoid Curl error 26
        UnityWebRequest webRequest = UnityWebRequest.Post(BaseURL + methodURL, json, "application/json");
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        Debug.Log("Sending " + methodURL + " request...");
        yield return webRequest.SendWebRequest();
        Debug.Log(methodURL + " completed. Result: " + webRequest.result);

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            Debug.Log("Successfully checked daily login");
        }
        else
        {
            // error
            Debug.Log("Failed to check daily login");
        }
    }

    // put
    public IEnumerator ResetDailyLogin(System.Action<string> callback = null) 
    {
        string methodURL = "/daily/daily/reset";

        ResetDailyLoginRequest request = new ResetDailyLoginRequest
        {
            telegram_id = TelegramManager.TelegramId
        };

        string json = JsonUtility.ToJson(request);

        // Use UnityWebRequest.Post to avoid Curl error 26
        UnityWebRequest webRequest = UnityWebRequest.Post(BaseURL + methodURL, json, "application/json");
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        Debug.Log("Sending " + methodURL + " request...");
        yield return webRequest.SendWebRequest();
        Debug.Log(methodURL + " completed. Result: " + webRequest.result);

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            Debug.Log("Successfully reset daily login");
        }
        else
        {
            // error
            Debug.Log("Failed to reset daily login");
        }
    } 
}