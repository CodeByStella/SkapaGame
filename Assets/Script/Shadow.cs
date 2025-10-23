using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shadow : MonoBehaviour
{
    private Vector2 positionShadow;
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        if (HeroClassNew.Jump || HeroClassNew.JumpTwo || HeroClassNew.JumpHero)
        {
            // positionShadow = new Vector2(gameObject.transform.localPosition.x, -3.18f);
            // gameObject.transform.localPosition = positionShadow;
        }
    }
}
