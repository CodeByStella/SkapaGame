using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPMain : MonoBehaviour
{
    public static bool SPKras = false;
    public static bool SPSc = false;
    public static bool SPLv = false;
    public Sprite kras;
    public Sprite sc;
    public Sprite lv;

    void Start()
    {
        SPSc = true;
        // ChangeAnimation("SPSc");
    }

    
    void FixedUpdate()
    {
        if (SPSc)
        {
            // ChangeAnimation("SPSc");
            gameObject.GetComponent<Image>().sprite = sc;
        }
        else if (SPKras)
        {
            // ChangeAnimation("SPKras");
            gameObject.GetComponent<Image>().sprite = kras;
        }
        else if (SPLv)
        {
            // ChangeAnimation("SPLv");
            gameObject.GetComponent<Image>().sprite = lv;
        }
    }
}
