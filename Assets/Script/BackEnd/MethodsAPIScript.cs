
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

public class MethodsAPIScript : MonoBehaviour
{
    private const string BaseURL = "http://185.232.169.26:8080";

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

        CreateProfileRequest request = new CreateProfileRequest
        {
            telegram_id = TelegramManager.TelegramId
        };

        string json = JsonUtility.ToJson(request);

        UnityWebRequest webRequest = new UnityWebRequest(BaseURL + methodURL, "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            string jsonText = webRequest.downloadHandler.text;
            CreateProfileResponse user = JsonUtility.FromJson<CreateProfileResponse>(jsonText);

            //  Вот тут переменные получают значения
            UserData.SetUserData(user);
            callback?.Invoke(user, null);
            Debug.Log("сработал метод CreateProfile");
        }
        else
        {
            // error
            callback?.Invoke(null, webRequest.downloadHandler.text);
            Debug.Log("не сработал метод CreateProfile");
        }
    }

    // put
    public IEnumerator UpdateCoins(int changeableValueCoins, System.Action<string> callback = null) 
    {
        string methodURL = "/profile/update-coins";


        UpdateCoinsRequest request = new UpdateCoinsRequest
        {
            profile = new Profile { telegram_id = TelegramManager.TelegramId },
            coins = new UpdateCoinsRequest.Coins { gold_coins = _currentCoins + changeableValueCoins }
        };

        string json = JsonUtility.ToJson(request);

        UnityWebRequest webRequest = new UnityWebRequest(BaseURL + methodURL, "PUT");
        webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success
            string jsonText = webRequest.downloadHandler.text;
            CreateProfileResponse user = JsonUtility.FromJson<CreateProfileResponse>(jsonText);
            UserData.SetUserData(user);

            Debug.Log("сработал метод UpdateCoins");
        }
        else
        {
            // error
            Debug.Log($"Не сработал UpdateCoins");
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

        UnityWebRequest webRequest = new UnityWebRequest(BaseURL + methodURL, "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            _currentCoins = int.Parse(webRequest.downloadHandler.text.Trim('"')); // сохраняем локально

            // отображаем на экране в главном меню
            coinsText.GetComponent<Text>().text = _currentCoins.ToString();
            Debug.Log("сработал метод GetCoins");
        }
        else
        {
            // error
            Debug.Log($"Ошибка в методе GetCoins, неудачно установлено соединение с сервером");
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

        UnityWebRequest webRequest = new UnityWebRequest(BaseURL + methodURL, "PUT");
        webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            Debug.Log("сработал метод CompleteTutorial");
        }
        else
        {
            // error
            Debug.Log("не сработал метод CompleteTutorial");
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

        UnityWebRequest webRequest = new UnityWebRequest(BaseURL + methodURL, "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"SaveRecord success: {webRequest.downloadHandler.text}");
            onSuccess?.Invoke();
            Debug.Log("сработал метод SaveRecord");
        }
        else
        {
            Debug.LogError($"SaveRecord failed: {webRequest.error}");
            onError?.Invoke(webRequest.error);
            Debug.Log("сработал метод SaveRecord");
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

        UnityWebRequest webRequest = new UnityWebRequest(BaseURL + methodURL, "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

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

        UnityWebRequest webRequest = new UnityWebRequest(BaseURL + methodURL, "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            Debug.Log("сработал метод GetGlobalRecords");
        }
        else
        {
            // error
            Debug.Log("не сработал метод GetGlobalRecords");
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

        UnityWebRequest webRequest = new UnityWebRequest(BaseURL + methodURL, "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            UpdateTrickStatus(trickId);
            Debug.Log("сработал метод PurchaseTrick");
        }
        else
        {
            // error
            Debug.Log("не сработал метод PurchaseTrick");
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
                is_in_use = true // хотя хз, что тут нужно, надо на практике смотреть
            }
        };

        string json = JsonUtility.ToJson(request);

        UnityWebRequest webRequest = new UnityWebRequest(BaseURL + methodURL, "PUT");
        webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            Text childText = this.gameObject.GetComponentInChildren<Text>();
            childText.text = "Picked";
            Debug.Log("сработал метод UpdateTrickStatus");
        }
        else
        {
            // error
            Debug.Log("не сработал метод UpdateTrickStatus");
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

        UnityWebRequest webRequest = new UnityWebRequest(BaseURL + methodURL, "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            string jsonText = webRequest.downloadHandler.text;
            GetTricksResponse[] tricks = JsonUtility.FromJson<GetTricksResponse[]>(jsonText);
            callback?.Invoke(tricks);
            Debug.Log("сработал метод GetTricks");
        }
        else
        {
            Debug.Log("не сработал метод GetTricks");
            // error
        }
    }

    // post 
    public IEnumerator GetAllTricks(System.Action<string> callback = null) 
    {
        string methodURL = "/tricks/tricks/all";

        UnityWebRequest webRequest = new UnityWebRequest(BaseURL + methodURL, "POST");
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            Debug.Log("сработал метод GetAllTricks");
        }
        else
        {
            // error
            Debug.Log("не сработал метод GetAllTricks");
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

        UnityWebRequest webRequest = new UnityWebRequest(BaseURL + methodURL, "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            Debug.Log("сработал метод CheckDailyLogin");
        }
        else
        {
            // error
            Debug.Log("не сработал метод CheckDailyLogin");
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

        UnityWebRequest webRequest = new UnityWebRequest(BaseURL + methodURL, "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            // success 
            Debug.Log("сработал метод ResetDailyLogin");
        }
        else
        {
            // error
            Debug.Log("не сработал метод ResetDailyLogin");
        }
    } 
}
