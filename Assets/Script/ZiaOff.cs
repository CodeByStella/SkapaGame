using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiaOff : MonoBehaviour
{
    public GameObject ShootFoto;
    
    void ZiaOffCase()
    {
        gameObject.SetActive(false);
    }

    void ShootOn()
    {
        ShootFoto.SetActive(true);
    }
}
