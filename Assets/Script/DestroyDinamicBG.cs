using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDinamicBG : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
