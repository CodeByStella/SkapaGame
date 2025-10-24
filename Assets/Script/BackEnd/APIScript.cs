using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class ApiClient : MonoBehaviour
{
    private const string BASE_URL = "http://45.9.75.242:8080/";

    public IEnumerator GetJson(string endpoint, System.Action<string> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(BASE_URL + endpoint))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            callback?.Invoke(request.downloadHandler.text);
        }
    }

    public IEnumerator PostJson(string endpoint, string json, System.Action<string> callback)
    {
        using (UnityWebRequest request = new UnityWebRequest(BASE_URL + endpoint, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();
            callback?.Invoke(request.downloadHandler.text);
        }
    }

    public IEnumerator PutJson(string endpoint, string json, System.Action<string> callback)
    {
        using (UnityWebRequest request = new UnityWebRequest(BASE_URL + endpoint, "PUT"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();
            callback?.Invoke(request.downloadHandler.text);
        }
    }
}
