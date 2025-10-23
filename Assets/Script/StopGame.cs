using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGame : MonoBehaviour
{
    
    public static void Death()
    {
        HeroClassNew.live -= 1;
    }
    
    public static void Reincarnation()
    {
        HeroClassNew.live = 3;
        Time.timeScale = 1;
    }
    
}
