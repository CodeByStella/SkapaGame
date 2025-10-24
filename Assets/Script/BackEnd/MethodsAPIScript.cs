
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

public class MethodsAPIScript : MonoBehaviour
{
    private const string BaseURL = "http://45.9.75.242:8080/";
    
    void Start()
    {
        // Allow HTTP connections to fix "Insecure connection not allowed" error
        Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);
        
        // Additional security configuration for HTTP connections
        #if UNITY_EDITOR || UNITY_STANDALONE
        // For editor and standalone builds, configure network security
        Debug.Log("Configuring network security for HTTP connections");
        Debug.Log("If you still get 'Insecure connection not allowed' error, please check Unity Player Settings -> Internet Access -> Require");
        #endif
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

            //  ��� ��� ���������� �������� ��������
            UserData.SetUserData(user);
            callback?.Invoke(user, null);
            Debug.Log("�������� ����� CreateProfile");
        }
        else
        {
            // error
            callback?.Invoke(null, webRequest.downloadHandler.text);
            Debug.Log("�� �������� ����� CreateProfile");
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

            Debug.Log("�������� ����� UpdateCoins");
        }
        else
        {
            // error
            Debug.Log($"�� �������� UpdateCoins");
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
            _currentCoins = int.Parse(webRequest.downloadHandler.text.Trim('"')); // ��������� ��������

            // ���������� �� ������ � ������� ����
            coinsText.GetComponent<Text>().text = _currentCoins.ToString();
            Debug.Log("�������� ����� GetCoins");
        }
        else
        {
            // error
            Debug.Log($"������ � ������ GetCoins, �������� ����������� ���������� � ��������");
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
            Debug.Log("�������� ����� CompleteTutorial");
        }
        else
        {
            // error
            Debug.Log("�� �������� ����� CompleteTutorial");
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
            Debug.Log("�������� ����� SaveRecord");
        }
        else
        {
            Debug.LogError($"SaveRecord failed: {webRequest.error}");
            onError?.Invoke(webRequest.error);
            Debug.Log("�������� ����� SaveRecord");
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
            Debug.Log("�������� ����� GetGlobalRecords");
        }
        else
        {
            // error
            Debug.Log("�� �������� ����� GetGlobalRecords");
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
            Debug.Log("�������� ����� PurchaseTrick");
        }
        else
        {
            // error
            Debug.Log("�� �������� ����� PurchaseTrick");
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
                is_in_use = true // ���� ��, ��� ��� �����, ���� �� �������� ��������
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
            Debug.Log("�������� ����� UpdateTrickStatus");
        }
        else
        {
            // error
            Debug.Log("�� �������� ����� UpdateTrickStatus");
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
            Debug.Log("�������� ����� GetTricks");
        }
        else
        {
            Debug.Log("�� �������� ����� GetTricks");
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
            Debug.Log("�������� ����� GetAllTricks");
        }
        else
        {
            // error
            Debug.Log("�� �������� ����� GetAllTricks");
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
            Debug.Log("�������� ����� CheckDailyLogin");
        }
        else
        {
            // error
            Debug.Log("�� �������� ����� CheckDailyLogin");
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
            Debug.Log("�������� ����� ResetDailyLogin");
        }
        else
        {
            // error
            Debug.Log("�� �������� ����� ResetDailyLogin");
        }
    } 
}
