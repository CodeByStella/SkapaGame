using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampButActive : MonoBehaviour
{
    public GameObject ButtonBack, ButtonForward;
    void Start()
    {
        ButtonBack.SetActive(false);
        ButtonForward.SetActive(false);
    }

}
