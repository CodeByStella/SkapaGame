using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helic : MonoBehaviour
{
    public Animator anim;
    private string currentAnimation;
    public GameObject Zake;
    
    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation && currentAnimation != "Slide") return;

        anim.Play(animation);
        currentAnimation = animation;
    }

    void Start()
    {
        ChangeAnimation("Helic");
    }


    void Update()
    {
        if (ScriptPower.bigRampStart)
        {
            MoveZakeBigRamp.pauseCamBool = true;
            Zake.SetActive(true);
            ChangeAnimation("HelicZero");
        }
    }
}
