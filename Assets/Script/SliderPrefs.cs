using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPrefs : MonoBehaviour
{
    public Slider sliderF;
    public Slider sliderM;
    public AudioSource audioMdream;
    public AudioSource audioMivan;
    public AudioSource audioMcxcz;
    public AudioSource audioFxF;
    public AudioSource audioFxS;
    public AudioSource audioFxT;
    void Start()
    {
        if (PlayerPrefs.GetInt("MusicMem") == 1)
        {
            sliderM.value = PlayerPrefs.GetFloat("Mus");
            sliderF.value = PlayerPrefs.GetFloat("MusFx");
            audioMdream.volume = sliderM.value;
            audioMivan.volume = sliderM.value;
            audioMcxcz.volume = sliderM.value;
            audioFxF.volume = sliderF.value;
            audioFxS.volume = sliderF.value;
            audioFxT.volume = sliderF.value;
        }
        else if (PlayerPrefs.GetInt("MusicMem") == 0)
        {
            sliderM.value = 0;
            sliderF.value = 0;
            audioMdream.volume = 0;
            audioMivan.volume = 0;
            audioMcxcz.volume = 0;
            audioFxF.volume = 0;
            audioFxS.volume = 0;
            audioFxT.volume = 0;
        }
    }
}
