using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgTrigger : MonoBehaviour
{
    public GameObject ButtonBack;
    public GameObject ButtonForward;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("BoxColliderTag"))
        {
            Debug.Log("пнахр");
            ButtonBack.SetActive(false);
            ButtonBack.SetActive(false);
        }
        
    }
}
