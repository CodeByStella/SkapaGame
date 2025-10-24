using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class CubeCtrl : MonoBehaviour
{
    public static int dviz;

    public static bool check;
    private float checkCube;
    // Start is called before the first frame update
    void Start()
    {
        check = false;
        // checkCube = float.Parse(PlayerPrefs.GetString("yCube"));
        dviz = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            checkCube = float.Parse(PlayerPrefs.GetString("yCube"));
            // Debug.Log(PlayerPrefs.GetString("yCube"));
            // Debug.Log(checkCube);
            if (checkCube != this.gameObject.transform.localPosition.y)
            {
                gameObject.transform.localPosition = new Vector3(-5.81f, checkCube, 0f);
            }
            else
            {
                check = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            dviz = 1;
            if (gameObject.transform.localPosition.y == -1.65f && dviz == 1)
            {
                gameObject.transform.localPosition = new Vector3(-5.81f, -1, 0f);
                MoveControl.topLine = false;
                MoveControl.midLine = false;
                MoveControl.botLine = true;
                HeroClassNew.index = 1;
                dviz = 0;
                // Debug.Log("3");
            } 
            else if (gameObject.transform.localPosition.y == -3f && dviz == 1)
            {
                gameObject.transform.localPosition = new Vector3(-5.81f, -1.65f, 0f);
                MoveControl.topLine = false;
                MoveControl.midLine = true;
                MoveControl.botLine = false;
                HeroClassNew.index = 2;
                dviz = 0;
                // Debug.Log("2");
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            dviz = 1;
            if (gameObject.transform.localPosition.y == -1.65f && dviz == 1)
            {
                gameObject.transform.localPosition = new Vector3(-5.81f, -3, 0f);
                MoveControl.topLine = true;
                MoveControl.midLine = false;
                MoveControl.botLine = false;
                HeroClassNew.index = 3;
                dviz = 0;
                // Debug.Log("1");
            } 
            else if (gameObject.transform.localPosition.y == -1f && dviz == 1)
            {
                gameObject.transform.localPosition = new Vector3(-5.81f, -1.65f, 0f);
                MoveControl.topLine = false;
                MoveControl.midLine = true;
                MoveControl.botLine = false;
                HeroClassNew.index = 2;
                dviz = 0;
                // Debug.Log("2");
            }
        }

    }
}
