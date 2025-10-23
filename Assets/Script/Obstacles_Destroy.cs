using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles_Destroy : MonoBehaviour
{
    public int indexCopy;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level_LasVegas" || SceneManager.GetActiveScene().name == "Level_School" || SceneManager.GetActiveScene().name == "Level_Krasnodar")
        {
            if (gameObject.transform.position.y == -1.3f || gameObject.transform.position.y == -0.9f || gameObject.transform.position.y == -0.7f)
            {
                indexCopy = 3;
            }
            else if (gameObject.transform.position.y == -2.5f)
            {
                indexCopy = 2;
            }
            else
            {
                indexCopy = 1;
            } 
        }
        else
        {
            if (gameObject.transform.position.y == -1.1f)
            {
                indexCopy = 3;
            }
            else if (gameObject.transform.position.y == -2.7f)
            {
                indexCopy = 2;
            }
            else
            {
                indexCopy = 1;
            }    
        }
        
    }

    private void Update()
    {
        if (indexCopy == HeroClassNew.index)
        {
            if (GetComponent<BoxCollider2D>())
                GetComponent<BoxCollider2D>().enabled = true;
            if (GetComponent<EdgeCollider2D>())
                GetComponent<EdgeCollider2D>().enabled = true;
            foreach (Transform child in transform)
            {
                if (child.GetComponent<BoxCollider2D>())
                    child.GetComponent<BoxCollider2D>().enabled = true;
                if (child.GetComponent<EdgeCollider2D>())
                    child.GetComponent<EdgeCollider2D>().enabled = true;
            }
        }
        else
        {
            if (GetComponent<BoxCollider2D>())
                GetComponent<BoxCollider2D>().enabled = false;
            if (GetComponent<EdgeCollider2D>())
                GetComponent<EdgeCollider2D>().enabled = false;
            foreach (Transform child in transform)
            {
                if (child.GetComponent<BoxCollider2D>())
                    child.GetComponent<BoxCollider2D>().enabled = false;
                if (child.GetComponent<EdgeCollider2D>())
                    child.GetComponent<EdgeCollider2D>().enabled = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (HeroClassNew.Fail)
        {
            Destroy(gameObject);
        }
    }
}