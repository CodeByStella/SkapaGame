using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject bgCity;
    private float v;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            if (gameObject.transform.name == "Level1_LasVegas_CitySkylineLasVegas")
            {
                v = Camera.main.transform.position.x;
                Instantiate(bgCity, new Vector2(v + 33.74f, 0), Quaternion.identity); // создаем бекграунд
            }
            Destroy(transform.parent.gameObject);
        }
    }
}
