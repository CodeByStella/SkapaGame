using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicMenu : MonoBehaviour
{
    private bool isOn = true;
    public Sprite on;
    public Sprite off;
    public GameObject Button;
    public AudioSource music;
    void Start()
    {
        ControlScriptForMenu.s = true; //ControlScriptForMenu.krasnodarLvl = false; ControlScriptForMenu.lasvegasrLvl = true;
        //isOn = true;
        if(PlayerPrefs.GetInt("MusicMem") == 1)
        {
            music.enabled = true; //music.volume = 1;
            Button.GetComponent<Image>().sprite = on;
            isOn = true;
        }
        if (PlayerPrefs.GetInt("MusicMem") == 0)
        {
            music.enabled = false; //music.volume = 0;
            Button.GetComponent<Image>().sprite = off;
            isOn = false;
        }
    }

    void Update()
    {
        // if (PlayerPrefs.GetInt("MusicMem") == 1) //isOn == true
        // {
        //     //GetComponent<AudioSource>().Play();
        //     music.enabled = true; //music.volume = 1;
        //     Button.GetComponent<Image>().sprite = on;
        // }
        // else if (PlayerPrefs.GetInt("MusicMem") == 0) //isOn == false
        // {
        //     //GetComponent<AudioSource>().Stop();
        //     music.enabled = false; //music.volume = 0;
        //     Button.GetComponent<Image>().sprite = off;
        // }
    }
    public void touch()
    {
        if (isOn) //isOn
        {
            PlayerPrefs.SetInt("MusicMem", 0);
            music.enabled = false; //music.volume = 0;
            Button.GetComponent<Image>().sprite = off;
            isOn = false;
            //PlayerPrefs.SetInt("MusicMem", 0);
        }
        else
        {
            PlayerPrefs.SetInt("MusicMem", 1);
            music.enabled = true; //music.volume = 1;
            Button.GetComponent<Image>().sprite = on;
            isOn = true;
            //PlayerPrefs.SetInt("MusicMem", 1);
        }
    }
    ////public GameObject MussOn;
    ////public GameObject MussOff;
    //public Sprite mOn;
    //public Sprite mOff;
    //public AudioSource mClip;
    //public GameObject musicbutton;
    //private bool isOn;

    //void Start()
    //{
    //    //MussOff.SetActive(false);
    //    //MussOn.SetActive(true);
    //    //mClip.enabled = true;
    //    isOn = true;
    //}
    //void Update()
    //{
    //    if (PlayerPrefs.GetInt("music") == 0)
    //    {
    //        musicbutton.GetComponent<Image>().sprite = mOn;
    //        mClip.enabled = true;
    //        isOn = true;
    //    }
    //    if (PlayerPrefs.GetInt("music") == 1)
    //    {
    //        musicbutton.GetComponent<Image>().sprite = mOff;
    //        mClip.enabled = false;
    //        isOn = false;
    //    }

    //}
    //public void sound()
    //{
    //    if (isOn)
    //        PlayerPrefs.SetInt("music", 0);
    //    else if (!isOn)
    //        PlayerPrefs.SetInt("music", 1);
    //}
    ////void Update()
    ////{

    ////    //switch (gameObject.name)
    ////    //{
    ////    //    case "MusOn":               
    ////    //        MussOff.SetActive(true);
    ////    //        MussOn.SetActive(false);
    ////    //        break;
    ////    //    case "MusOff":               
    ////    //        MussOn.SetActive(true);
    ////    //        MussOff.SetActive(false);
    ////    //        break;
    ////    //        //if (MussOn)
    ////    //        //{
    ////    //        //    MussOff.SetActive (true);
    ////    //        //    MussOn.SetActive (false);
    ////    //        //}
    ////    //        //if (MussOff)
    ////    //        //{
    ////    //        //    MussOn.SetActive(true);
    ////    //        //    MussOff.SetActive(false);
    ////    //}
    ////}
}
