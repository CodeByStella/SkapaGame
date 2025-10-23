using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TshirtScript : MonoBehaviour
{
    public Animator anim;
    private string currentAnimation;
    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation) return;

        anim.Play(animation);
        currentAnimation = animation;
    }

    // private void Start()
    // {
    //     RectTransform rt = GetComponent<RectTransform>();
    //     // Debug.Log(rt.offsetMin.x);
    //     // Debug.Log(rt.offsetMin.y);
    //     rt.offsetMin = new Vector2(639.35f,298.9093f);
    //     rt.offsetMax = new Vector2(-639.45f,-298.3107f);
    // }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("TsirtBuy1") == 1 && PlayerPrefs.GetInt("TsirtPick1") == 1) ChangeAnimation("Ch4");
        else if (PlayerPrefs.GetInt("TsirtBuy2") == 1 && PlayerPrefs.GetInt("TsirtPick2") == 1) ChangeAnimation("Ch3");
        else if (PlayerPrefs.GetInt("TsirtBuy3") == 1 && PlayerPrefs.GetInt("TsirtPick3") == 1) ChangeAnimation("Ch1");
        else if (PlayerPrefs.GetInt("TsirtBuy4") == 1 && PlayerPrefs.GetInt("TsirtPick4") == 1) ChangeAnimation("Ch2");

        if (PlayerPrefs.GetInt("TsirtBuy1") == 1 
            && PlayerPrefs.GetInt("TsirtPick1") == 1 
            && gameObject.transform.name.Equals("Ch1")
            && gameObject.transform.name.Equals("Ch2")
            && gameObject.transform.name.Equals("Ch3"))
        {
            Destroy(gameObject);
        }
        else if (PlayerPrefs.GetInt("TsirtBuy2") == 1 
                 && PlayerPrefs.GetInt("TsirtPick2") == 1 
                 && gameObject.transform.name.Equals("Ch1")
                 && gameObject.transform.name.Equals("Ch2")
                 && gameObject.transform.name.Equals("Ch4"))
        {
            Destroy(gameObject);
        } 
        else if (PlayerPrefs.GetInt("TsirtBuy3") == 1 
                 && PlayerPrefs.GetInt("TsirtPick3") == 1 
                 && gameObject.transform.name.Equals("Ch3")
                 && gameObject.transform.name.Equals("Ch2")
                 && gameObject.transform.name.Equals("Ch4"))
        {
            Destroy(gameObject);
        } 
        else if (PlayerPrefs.GetInt("TsirtBuy4") == 1 
                 && PlayerPrefs.GetInt("TsirtPick4") == 1 
                 && gameObject.transform.name.Equals("Ch3")
                 && gameObject.transform.name.Equals("Ch1")
                 && gameObject.transform.name.Equals("Ch4"))
        {
            Destroy(gameObject);
        } 
    }
}
