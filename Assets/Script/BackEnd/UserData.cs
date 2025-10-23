using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{
    public static CreateProfileResponse UserDatas { get; private set; }

    public static void SetUserData(CreateProfileResponse response)
    {
        UserDatas = response;
    }

    public static int GetId() { return UserDatas.id; }
    public static string GetTelegramId() { return UserDatas.telegram_id; }
    public static int GetGoldCoins() { return UserDatas.gold_coins; }
    public static string GetLastLogin() { return UserDatas.last_login; }
    public static int GetConsecutiveDays() { return UserDatas.consecutive_days; }
    public static bool GetTutorialResult() { return UserDatas.has_completed_tutorial; }
}
