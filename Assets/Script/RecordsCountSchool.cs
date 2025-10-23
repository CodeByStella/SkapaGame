using UnityEngine;
using UnityEngine.UI;

public class RecordsCountSchool : MonoBehaviour
{
    [Header("API")]
    [SerializeField] private MethodsAPIScript api;

    [Header("UI Objects")]
    public GameObject Menu, Distance, Distance1, Home, Restart;
    public Text text1, text2, text3, text4, text5;

    private int[] _scores = new int[5];

    private void Start()
    {
        if (api == null)
            api = FindObjectOfType<MethodsAPIScript>();

        ResetUI();

        StartCoroutine(api.GetLocalRecords(OnRecordsLoaded));
    }

    private void Update()
    {
        int current = Move_Camera.distanceCount;

        if (current > 0 && IsNewRecord(current))
        {
            ShowRecordUI();

            StartCoroutine(api.SaveRecord( current,
                onSuccess: () =>
                {
                    StartCoroutine(api.GetLocalRecords(OnRecordsLoaded));
                }
            ));
        }
    }

    private void ResetUI()
    {
        Menu.SetActive(false);

        text1.text = "0";
        text2.text = "0";
        text3.text = "0";
        text4.text = "0";
        text5.text = "0";
    }

    private void OnRecordsLoaded(int[] records)
    {
        if (records == null || records.Length == 0)
        {
            return;
        }

        for (int i = 0; i < records.Length && i < _scores.Length; i++)
        { 
            _scores[i] = records[i];
        }    

        UpdateUI();
    }

    private void UpdateUI()
    {
        text1.text = _scores[0].ToString();
        text2.text = _scores[1].ToString();
        text3.text = _scores[2].ToString();
        text4.text = _scores[3].ToString();
        text5.text = _scores[4].ToString();
    }

    private bool IsNewRecord(int current)
    {
        for (int i = 0; i < _scores.Length; i++)
        {
            if (current > _scores[i])
                return true;
        }
        return false;
    }

    private void ShowRecordUI()
    {
        Menu.SetActive(true);
        Distance.SetActive(false);
        Distance1.SetActive(false);
        Home.SetActive(false);
        Restart.SetActive(false);
    }
}
