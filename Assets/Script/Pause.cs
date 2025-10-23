using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject menuPause;
    public GameObject cube;
    private float savePosCube;

    private void Start()
    {
        menuPause.SetActive(false);
    }

    private void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        gameObject.SetActive(false);
        menuPause.SetActive(true);
        savePosCube = cube.transform.localPosition.y;
        String strSavePosCube = savePosCube.ToString();
        PlayerPrefs.SetString("yCube", strSavePosCube);
        Time.timeScale = 0;
    }
}
