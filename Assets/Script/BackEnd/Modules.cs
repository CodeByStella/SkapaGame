using System;

// profile
[Serializable]
public class CreateProfileRequest
{
    public string telegram_id;
}

[Serializable]
public class UpdateCoinsRequest
{
    public Profile profile;
    public Coins coins;

    [Serializable]
    public class Coins
    {
        public int gold_coins;
    }
}

public class GetCoinsRequest 
{
    public string telegram_id;
}
public class CompleteTutorialRequest 
{
    public string telegram_id;
}

//records
public class SaveRecordRequest 
{
    public Profile profile;
    public Record record;

    [Serializable]
    public class Record
    {
        public string level;
        public int score;
    }
}
public class GetLocalRecordsRequest 
{
    public Profile profile;
    public Record record;

    [Serializable]
    public class Record
    {
        public string level;
    }
}
public class GetGlobalRecordsRequest 
{
    public string level;
}

//tricks
public class PurchaseTrickRequest 
{
    public Profile profile;
    public Trick trick;

    [Serializable]
    public class Trick
    {
        public int trick_id;
    }
}
public class UpdateTrickRequest 
{
    public Profile profile;
    public Trick trick;

    [Serializable]
    public class Trick
    {
        public int trick_id;
        public bool is_in_use;
    }
}
public class GetTricksRequest 
{
    public string telegram_id;
}
public class GetAllTricksRequest { }

//daily
public class CheckDailyLoginRequest 
{
    public string telegram_id;
}
public class ResetDailyLoginRequest 
{
    public string telegram_id;
}

[Serializable]
public class Profile
{
    public string telegram_id;
}


[Serializable]
public class GetLocalRecordsResponse
{
    public string message;  
    public int[] records;      
}

[Serializable]
public class GetTricksResponse 
{
    public int trick_id;
    public bool is_in_use;
    public int id;
    public string telegram_id;
}

[Serializable]
public class TrickList
{
    public GetTricksResponse[] tricks;
}

[Serializable]
public class CreateProfileResponse 
{
    public int id;
    public string telegram_id;
    public int gold_coins;
    public string last_login;
    public int consecutive_days;
    public bool has_completed_tutorial;
}