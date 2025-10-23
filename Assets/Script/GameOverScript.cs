using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
    public static bool GameOverBool = true;

    public Animator anim;
    public Image Level;
    public Sprite School, LasVegas, Krasnodar;
    public GameObject Menu, Distance, Distance1, Home, Restart;
    public Text top1, top2, top3, top4, top5;

    private MethodsAPIScript _api;
    private int[] records = new int[5]; 

    private void Start()
    {
        _api = FindObjectOfType<MethodsAPIScript>();
    }

    private void FixedUpdate()
    {
        if (HeroClassNew.live <= 0 && GameOverBool)
        {
            anim.Play("GameOver");
        }
    }

    private void GameOverAnimEnd()
    {
        GameOverBool = false;
        string level = GetCurrentLevel();

        StartCoroutine(MethodsAPIScript.Instance.GetLocalRecords(OnRecordsLoaded));
    }

    private void OnRecordsLoaded(int[] serverRecords)
    {
        if (serverRecords != null && serverRecords.Length > 0)
        {
            records = serverRecords;
        }
        else
        {
            records = new int[5]; 
        }

        int currentScore = Move_Camera.distanceCount;

        bool newRecord = false;
        for (int i = 0; i < records.Length; i++)
        {
            if (currentScore > records[i])
            {
                for (int j = records.Length - 1; j > i; j--)
                {
                    records[j] = records[j - 1];
                }
                records[i] = currentScore;
                newRecord = true;
                break;
            }
        }

        if (newRecord)
        {
            StartCoroutine(MethodsAPIScript.Instance.SaveRecord(currentScore));
        }

        UpdateUI();
        OpenMenu();
    }

    private void UpdateUI()
    {
        top1.text = records[0].ToString();
        top2.text = records[1].ToString();
        top3.text = records[2].ToString();
        top4.text = records[3].ToString();
        top5.text = records[4].ToString();
    }

    private void OpenMenu()
    {
        Menu.SetActive(true);
        Distance.SetActive(false);
        Distance1.SetActive(false);
        Home.SetActive(false);
        Restart.SetActive(false);
    }

    private string GetCurrentLevel()
    {
        if (ControlScriptForMenu.schoolLvl)
        {
            Level.sprite = School;
            return "School";
        }
        else if (ControlScriptForMenu.krasnodarLvl)
        {
            Level.sprite = Krasnodar;
            return "Krasnodar";
        }
        else if (ControlScriptForMenu.lasvegasrLvl)
        {
            Level.sprite = LasVegas;
            return "LasVegas";
        }
        return "Unknown";
    }
}
