using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script321 : MonoBehaviour
{
    public static bool startLvl = false;
    public static bool startBigRamp = false;
    // Start is called before the first frame update
    void Start()
    {
        startLvl = false;
        startBigRamp = false;
        gameObject.transform.localScale = new Vector3(10f, 10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level_Big_Ramp_Ref")
        {
            
            gameObject.transform.localScale += new Vector3(-0.027f, -0.027f, -0.027f);
        }
        else
        {
            gameObject.transform.localScale += new Vector3(-0.05f, -0.05f, -0.05f); //-0.05f
            if (gameObject.transform.localScale.x < 0) gameObject.transform.localScale = new Vector3(-transform.localScale.x, -transform.localScale.y, -transform.localScale.z);
        }
        
    }

    void StartNewNumber()
    {
        if (SceneManager.GetActiveScene().name == "Level_Big_Ramp_Ref")
        {
            gameObject.transform.localScale = new Vector3(4f, 4f, 4f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(10f, 10f, 10f); 
        }
    }

    void OverNumber()
    {
        if (SceneManager.GetActiveScene().name == "Level_Big_Ramp")
        {
            startBigRamp = true;
            gameObject.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "Level_School" && PlayerPrefs.GetInt("Learn") == 0)
        {
            startLvl = true;
            ScriptLearn.first_learn = true;
            ScriptLearn.learn_start = true;
            gameObject.SetActive(false);
        }
        else
        {
            startLvl = true;
            gameObject.SetActive(false);    
        }
    }
    
}
