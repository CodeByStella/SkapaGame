using System.Collections;
using UnityEngine;

public class TelegramManager : MonoBehaviour
{
    public static string TelegramId { get; private set; }

    private MethodsAPIScript api;

    public void SetTelegramId(string id)
    {
        TelegramId = id;
        InitProfile();
    }

    IEnumerator InitProfile()
    {
        yield return StartCoroutine(api.CreateProfile((response, error) =>
        {
            if (response != null)
            {
                UserData.SetUserData(response);
                Debug.Log("Новый профиль создан!");
            }
            else if (error == "Profile is exist")
            {
                Debug.Log("Профиль уже существует. Загружаем...");

                StartCoroutine(api.UpdateCoins(0, (existingUser) =>
                {
                }));
            }
            else
            {
                Debug.LogError("Ошибка при создании профиля: " + error);
            }
        }));
    }
}
