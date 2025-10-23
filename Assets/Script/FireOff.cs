using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOff : MonoBehaviour
{

    void FireOffCase()
    {
        Move_Camera.fireTrue = false;
        gameObject.SetActive(false);
        HeroClassNew.fireOnBot = false;
    }
}