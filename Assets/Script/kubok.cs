using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kubok : MonoBehaviour
{
    public GameObject canvas;
    private bool isOn; 
    private void Start()
    {
        isOn = false;
    }
    private void Update()
    {
        if(isOn)
            canvas.SetActive(true);
        else
            canvas.SetActive(false);
    }
    public void touch()
    {
        if(isOn)
            isOn = false;
        else
            isOn = true;
    }
}
