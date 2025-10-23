using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZikGabarition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // gameObject.transform.localScale = new Vector3(1.69f, 1.69f, 1.69f);
        gameObject.transform.localPosition = new Vector3(0, 0, -12);
        gameObject.transform.SetSiblingIndex(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
