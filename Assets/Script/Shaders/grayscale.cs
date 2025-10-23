using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grayscale : MonoBehaviour
{
    private Image imageRender;
    public Material materialDark;
    public Material materialWhite;
    public static bool materialSwap;
    // Start is called before the first frame update
    void Start()
    {
        imageRender = GetComponent<Image>();
        materialSwap = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Kras") == 0 && ControlScriptForMenu.k && !ControlScriptForMenu.l &&
            !ControlScriptForMenu.s || materialSwap)
        {
            imageRender.material.SetFloat("_GrayscaleAmount", 1.0f);
            gameObject.GetComponent<Image>().material = materialDark;
        }
        else if (PlayerPrefs.GetInt("Las") == 0 && ControlScriptForMenu.l && !ControlScriptForMenu.k &&
                 !ControlScriptForMenu.s || materialSwap)
        {
            imageRender.material.SetFloat("_GrayscaleAmount", 1.0f);
            gameObject.GetComponent<Image>().material = materialDark;
        }
        else
        {
            imageRender.material.SetFloat("_GrayscaleAmount", 0.0f);
            gameObject.GetComponent<Image>().material = materialWhite;
        }
    }
}
