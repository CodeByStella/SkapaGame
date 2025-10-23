using UnityEngine;
using UnityEngine.UI;

public class MusSlider : MonoBehaviour
{
    public Slider sliderF;
    public Slider sliderM;
    public AudioSource audioM;
    public AudioSource audioFxF;
    public AudioSource audioFxS;
    public AudioSource audioFxT;

    public void OnValueChangedF()
    {
        audioFxF.volume = sliderF.value;
        audioFxS.volume = sliderF.value;
        audioFxT.volume = sliderF.value;
        PlayerPrefs.SetFloat("MusFx" , sliderF.value);
        Debug.Log("MusSliderFx" + audioFxT.volume + sliderF.value);
    }
    public void OnValueChangedM()
    {
        audioM.volume = sliderM.value;
        PlayerPrefs.SetFloat("Mus" , sliderM.value);
        Debug.Log("MusSlider" + audioM.volume + sliderM.value);
    }
    // void Start()
    // {
    //     if (PlayerPrefs.GetInt("MusicMem") == 1)
    //     {
    //         sliderM.value = PlayerPrefs.GetFloat("Mus");
    //         sliderF.value = PlayerPrefs.GetFloat("MusFx");
    //     }
    //     else if (PlayerPrefs.GetInt("MusicMem") == 0)
    //     {
    //         sliderM.value = 0;
    //         sliderF.value = 0;
    //     }
    // }
    // void Update()
    // {
        // audioFxF.volume = sliderF.value;
        // audioFxS.volume = sliderF.value;
        // audioFxT.volume = sliderF.value;
        // audioM.volume = sliderM.value;
        // PlayerPrefs.SetFloat("Mus" , sliderM.value);
        // PlayerPrefs.SetFloat("MusFx" , sliderF.value);
    // }
}
