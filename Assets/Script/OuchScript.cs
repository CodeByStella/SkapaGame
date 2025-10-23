using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OuchScript : MonoBehaviour
{
    public static bool OuchBool = true;
    public Animator anim;
    public GameObject Ouch;

    /*private void Start()
    {
        copyLive = HeroClassNew.live;
    }*/

    private void Update()
    {
        if (OuchBool && SceneManager.GetActiveScene().name == "Level_LasVegas" &&
            HeroClassNew.live > 0) 
        {
            anim.Play("Ouch");
        }
    }
    
    private void OuchAnimEnd()
    {
        OuchBool = false;
        Ouch.SetActive(false);
    } 
}
