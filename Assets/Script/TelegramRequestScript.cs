using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;

public class TelegramRequestScript : MonoBehaviour
{

    [SerializeField] private string url = "https://api.telegram.org/bot6439059267:AAEdbymc-lE-aiyN0Nl1uS7h3Of_O6b3mgA/getChatMember";
    //private string urlMemberId = "https://api.telegram.org/getMe";
    public string chat_id;
    private string member_id;

    void Start()
    {
        StartCoroutine(SendRequest());
    }

    private IEnumerator SendRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get(this.url);
        yield return request.SendWebRequest();
        Debug.Log("[TELEGRAM_REQUEST] Response: " + request.downloadHandler.text);
    }
}
