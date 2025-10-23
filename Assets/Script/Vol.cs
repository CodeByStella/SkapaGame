using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vol : MonoBehaviour
{
    public GameObject musicReg;
    public GameObject musicFX;
    // void Update()
    // {
    //     if (musicReg.transform.localPosition.x < -607.6f)
    //     {
    //         GameObject.Find("SoundCxcz").GetComponent<AudioSource>().volume = 0f;
    //         GameObject.Find("SoundIvan").GetComponent<AudioSource>().volume = 0f;
    //     } else if (musicReg.transform.localPosition.x > -600.3f)
    //     {
    //         GameObject.Find("SoundCxcz").GetComponent<AudioSource>().volume = 1f;
    //         GameObject.Find("SoundIvan").GetComponent<AudioSource>().volume = 1f;
    //     } else if (musicReg.transform.localPosition.x <= -606.87f && musicReg.transform.localPosition.x > -607.6f)
    //     {
    //         GameObject.Find("SoundCxcz").GetComponent<AudioSource>().volume = 0.1f;
    //         GameObject.Find("SoundIvan").GetComponent<AudioSource>().volume = 0.1f;
    //     } else if (musicReg.transform.localPosition.x <= -605.41f && musicReg.transform.localPosition.x > -606.87f)
    //     {
    //         GameObject.Find("SoundCxcz").GetComponent<AudioSource>().volume = 0.2f;
    //         GameObject.Find("SoundIvan").GetComponent<AudioSource>().volume = 0.2f;
    //     } else if (musicReg.transform.localPosition.x <= -604.68f && musicReg.transform.localPosition.x > -605.41f)
    //     {
    //         GameObject.Find("SoundCxcz").GetComponent<AudioSource>().volume = 0.3f;
    //         GameObject.Find("SoundIvan").GetComponent<AudioSource>().volume = 0.3f;
    //     } else if (musicReg.transform.localPosition.x <= -603.95f && musicReg.transform.localPosition.x > -604.68f)
    //     {
    //         GameObject.Find("SoundCxcz").GetComponent<AudioSource>().volume = 0.4f;
    //         GameObject.Find("SoundIvan").GetComponent<AudioSource>().volume = 0.4f;
    //     } else if (musicReg.transform.localPosition.x <= -603.22f && musicReg.transform.localPosition.x > -603.95f)
    //     {
    //         GameObject.Find("SoundCxcz").GetComponent<AudioSource>().volume = 0.5f;
    //         GameObject.Find("SoundIvan").GetComponent<AudioSource>().volume = 0.5f;
    //     } else if (musicReg.transform.localPosition.x <= -602.49f && musicReg.transform.localPosition.x > -603.22f)
    //     {
    //         GameObject.Find("SoundCxcz").GetComponent<AudioSource>().volume = 0.6f;
    //         GameObject.Find("SoundIvan").GetComponent<AudioSource>().volume = 0.6f;
    //     } else if (musicReg.transform.localPosition.x <= -601.76f && musicReg.transform.localPosition.x > -602.49f)
    //     {
    //         GameObject.Find("SoundCxcz").GetComponent<AudioSource>().volume = 0.7f;
    //         GameObject.Find("SoundIvan").GetComponent<AudioSource>().volume = 0.7f;
    //     } else if (musicReg.transform.localPosition.x <= -601.03f && musicReg.transform.localPosition.x > -601.76f)
    //     {
    //         GameObject.Find("SoundCxcz").GetComponent<AudioSource>().volume = 0.8f;
    //         GameObject.Find("SoundIvan").GetComponent<AudioSource>().volume = 0.8f;
    //     } else if (musicReg.transform.localPosition.x <= -600.3f && musicReg.transform.localPosition.x > -601.03f)
    //     {
    //         GameObject.Find("SoundCxcz").GetComponent<AudioSource>().volume = 0.9f;
    //         GameObject.Find("SoundIvan").GetComponent<AudioSource>().volume = 0.9f;
    //     }
        
    //     if (musicFX.transform.localPosition.x < -607.6f)
    //     {
    //         GameObject.Find("SoundRide").GetComponent<AudioSource>().volume = 0f;
    //         GameObject.Find("SoundOllieUp").GetComponent<AudioSource>().volume = 0f;
    //         GameObject.Find("SoundOllieDown").GetComponent<AudioSource>().volume = 0f;
    //         GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0f;
    //     } else if (musicFX.transform.localPosition.x > -600.3f)
    //     {
    //         GameObject.Find("SoundRide").GetComponent<AudioSource>().volume = 1f;
    //         GameObject.Find("SoundOllieUp").GetComponent<AudioSource>().volume = 1f;
    //         GameObject.Find("SoundOllieDown").GetComponent<AudioSource>().volume = 1f;
    //         GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 1f;
    //     } else if (musicFX.transform.localPosition.x <= -600.3f && musicFX.transform.localPosition.x > -601.03f)
    //     {
    //         GameObject.Find("SoundRide").GetComponent<AudioSource>().volume = 0.9f;
    //         GameObject.Find("SoundOllieUp").GetComponent<AudioSource>().volume = 0.9f;
    //         GameObject.Find("SoundOllieDown").GetComponent<AudioSource>().volume = 0.9f;
    //         GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.9f;
    //     } else if (musicFX.transform.localPosition.x <= -601.03f && musicFX.transform.localPosition.x > -601.76f)
    //     {
    //         GameObject.Find("SoundRide").GetComponent<AudioSource>().volume = 0.8f;
    //         GameObject.Find("SoundOllieUp").GetComponent<AudioSource>().volume = 0.8f;
    //         GameObject.Find("SoundOllieDown").GetComponent<AudioSource>().volume = 0.8f;
    //         GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.8f;
    //     } else if (musicFX.transform.localPosition.x <= -601.76f && musicFX.transform.localPosition.x > -602.49f)
    //     {
    //         GameObject.Find("SoundRide").GetComponent<AudioSource>().volume = 0.7f;
    //         GameObject.Find("SoundOllieUp").GetComponent<AudioSource>().volume = 0.7f;
    //         GameObject.Find("SoundOllieDown").GetComponent<AudioSource>().volume = 0.7f;
    //         GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.7f;
    //     } else if (musicFX.transform.localPosition.x <= -602.49f && musicFX.transform.localPosition.x > -603.22f)
    //     {
    //         GameObject.Find("SoundRide").GetComponent<AudioSource>().volume = 0.6f;
    //         GameObject.Find("SoundOllieUp").GetComponent<AudioSource>().volume = 0.6f;
    //         GameObject.Find("SoundOllieDown").GetComponent<AudioSource>().volume = 0.6f;
    //         GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.6f;
    //     } else if (musicFX.transform.localPosition.x <= -603.22f && musicFX.transform.localPosition.x > -603.95f)
    //     {
    //         GameObject.Find("SoundRide").GetComponent<AudioSource>().volume = 0.5f;
    //         GameObject.Find("SoundOllieUp").GetComponent<AudioSource>().volume = 0.5f;
    //         GameObject.Find("SoundOllieDown").GetComponent<AudioSource>().volume = 0.5f;
    //         GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.5f;
    //     } else if (musicFX.transform.localPosition.x <= -603.95f && musicFX.transform.localPosition.x > -604.68f)
    //     {
    //         GameObject.Find("SoundRide").GetComponent<AudioSource>().volume = 0.4f;
    //         GameObject.Find("SoundOllieUp").GetComponent<AudioSource>().volume = 0.4f;
    //         GameObject.Find("SoundOllieDown").GetComponent<AudioSource>().volume = 0.4f;
    //         GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.4f;
    //     } else if (musicFX.transform.localPosition.x <= -604.68f && musicFX.transform.localPosition.x > -605.41f)
    //     {
    //         GameObject.Find("SoundRide").GetComponent<AudioSource>().volume = 0.3f;
    //         GameObject.Find("SoundOllieUp").GetComponent<AudioSource>().volume = 0.3f;
    //         GameObject.Find("SoundOllieDown").GetComponent<AudioSource>().volume = 0.3f;
    //         GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.3f;
    //     } else if (musicFX.transform.localPosition.x <= -605.41f && musicFX.transform.localPosition.x > -606.87f)
    //     {
    //         GameObject.Find("SoundRide").GetComponent<AudioSource>().volume = 0.2f;
    //         GameObject.Find("SoundOllieUp").GetComponent<AudioSource>().volume = 0.2f;
    //         GameObject.Find("SoundOllieDown").GetComponent<AudioSource>().volume = 0.2f;
    //         GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.2f;
    //     } else if (musicFX.transform.localPosition.x <= -606.87f && musicFX.transform.localPosition.x > -607.6f)
    //     {
    //         GameObject.Find("SoundRide").GetComponent<AudioSource>().volume = 0.1f;
    //         GameObject.Find("SoundOllieUp").GetComponent<AudioSource>().volume = 0.1f;
    //         GameObject.Find("SoundOllieDown").GetComponent<AudioSource>().volume = 0.1f;
    //         GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.1f;
    //     }
        
    // }
}
