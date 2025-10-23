using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicaterBG : MonoBehaviour
{
    private string currentAnimation;
    public Animator anim;
    
    void ChangeAnimationDupl(string animation)
    {
        if (currentAnimation == animation) return;
        
        anim.Play(animation);
        currentAnimation = animation;
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeAnimationDupl("LLRSc");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ControlScriptForMenu.schoolLvl)
        {
            ChangeAnimationDupl("ScStat");
        }
        
        if (ControlScriptForMenu.krasnodarLvl)
        {
            ChangeAnimationDupl("KrasStat");
        }
        
        if (ControlScriptForMenu.lasvegasrLvl)
        {
            ChangeAnimationDupl("LvStat");
        }
    }
}
