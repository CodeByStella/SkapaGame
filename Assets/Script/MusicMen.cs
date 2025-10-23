using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicMen : MonoBehaviour
{
    private bool isOn;
    public Sprite on;
    public Sprite off;
    public GameObject Button;
    void Start()
    {
        isOn = true;
    }

    void Update()
    {
        if (isOn)
        {
            GetComponent<AudioSource>().Play();
            Button.GetComponent<Image>().sprite = on;
        }
        if (!isOn)
        {
            GetComponent<AudioSource>().Stop();
            Button.GetComponent<Image>().sprite = off;
        }
    }
    public void touch()
    {
        if (isOn)
        {
            isOn=false;
        }
        if (!isOn)
        {
            isOn = true;
        }
    } 
}
