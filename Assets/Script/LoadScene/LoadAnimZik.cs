using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.IO;
// using System.IO.Path;

public class LoadAnimZik : MonoBehaviour
{
    [Header("Server URL")] [SerializeField] private string _urlT1, _urlT2, _urlT3, _urlT4;
    [Header("Name of the game")] [SerializeField] private string _fileName1, _fileName2, _fileName3, _fileName4;

    public static bool startMenu;

    private string testPath;

    private string target;
    // https://drive.usercontent.google.com/uc?id=148z_p30huFkEknxhS2f0bgjFkLiu0gCG&authuser=0&export=download
    void Start()
    {
        target = Path.Combine(Directory.GetCurrentDirectory() + $"/Assets/Sprite/ZikFlame/");
        Debug.Log(Directory.GetCurrentDirectory() + $"/Sprite/ZikFlame/");
        testPath = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, "download.txt");
        startMenu = false;
        if (!ControlScriptForMenu.k && !ControlScriptForMenu.l && !ControlScriptForMenu.s)
        {
            DownloadFile();   
        }
    }

    public void DownloadFile()
    {
        WebClient client = new WebClient();

        client.DownloadProgressChanged += DownloadProgressChanged;
        client.DownloadFileCompleted += DownloadComplete;
        if (PlayerPrefs.GetInt("TsirtPick1") == 1)
        {
            client.DownloadFileAsync(new Uri(_urlT4), target);
        }
        else if (PlayerPrefs.GetInt("TsirtPick2") == 1)
        {
            client.DownloadFileAsync(new Uri(_urlT3), target);
        }
        else if (PlayerPrefs.GetInt("TsirtPick3") == 1)
        {
            client.DownloadFileAsync(new Uri(_urlT1), target);
        }
        else if (PlayerPrefs.GetInt("TsirtPick4") == 1)
        {
            client.DownloadFileAsync(new Uri(_urlT2), target);
        }
        else
        {
            // var fileName = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, "download.txt");
            // client.DownloadFileAsync(new Uri(_urlT4), Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, "download.txt"));
            client.DownloadFileAsync(new Uri(_urlT4), target);
            Debug.Log(Application.dataPath + $"/Sprite/ZikFlame/");
        }
        
        
        // client.DownloadFileAsync(new Uri(_url), Application.streamingAssetsPath + $"/Sprite/ZikFlame/");
    }

    private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        Debug.Log("Download Progress = " + e.ProgressPercentage + "%");
    }

    private void DownloadComplete(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            Debug.Log("Загрузка завершена");
            startMenu = true;
        }
        else
            Debug.Log($"Error: {e.Error}");
    }
}
