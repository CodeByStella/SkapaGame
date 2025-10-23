using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptPod : MonoBehaviour
{
    public static bool krasn, lasv, school, activePod, activeBg;
    private int disPod;
    public Sprite krasSprite, scSprite, lasSprite;
    // Start is called before the first frame update
    void Start()
    {
        disPod = 0;
        activePod = false;
        activeBg = false;
        krasn = false;
        lasv = false;
        school = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (activeBg)
        {
            Image invisBg = GetComponent<Image>();
            invisBg.color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
        }
        else
        {
            Image invisBg = GetComponent<Image>();
            invisBg.color = new Color(255.0f, 255.0f, 255.0f, 0f);
        }
        
        if (school)
        {
            Image imageBg = GetComponent<Image>();
            imageBg.sprite = scSprite;
            activePod = true;
        }
        else if (lasv)
        {
            Image imageBg = GetComponent<Image>();
            imageBg.sprite = lasSprite;  
            activePod = true;
        }
        else if (krasn)
        {
            Image imageBg = GetComponent<Image>();
            imageBg.sprite = krasSprite;  
            activePod = true;
        }

        if (activePod)
        {
            disPod++;
            if (disPod == 40)
            {
                activePod = false;
                krasn = false;
                lasv = false;
                school = false;
                activeBg = false;
                disPod = 0;
            }
        }
    }
}
