using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAnim : MonoBehaviour
{
    public static bool sa;
    // Start is called before the first frame update
    void Start()
    {
        // SceneManager.LoadScene("LoadScene");
        sa = false; 
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    void Starta()
    {
        SceneManager.LoadScene("LoadScene");
        // gameObject.SetActive(false);
    }
    
}
