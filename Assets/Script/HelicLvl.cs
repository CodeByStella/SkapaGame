using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelicLvl : MonoBehaviour
{
    public static bool HelicBack;
    public static bool HelicBig;
    public Animator anim;
    private string currentAnimation;
    public GameObject Zake;
    public static bool HelicGoCloth;
    private int disHelic;
    public GameObject shadow;
    
    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation && currentAnimation != "Slide") return;

        anim.Play(animation);
        currentAnimation = animation;
    }

    void Start()
    {
        HelicBig = false;
        HelicBack = false;
        HelicGoCloth = false;
        disHelic = 5;
    }


    void Update()
    {
        if (HelicBack)
        {
            ChangeAnimation("HelicSmall");
            if (gameObject.transform.name == "DHF_Helicopter_Moving_1")
            {
                gameObject.transform.position += new Vector3(15 * Time.deltaTime, 0f);
                if (gameObject.transform.localPosition.x >= 13.2f)
                {
                    HelicBack = false;
                    HelicBig = true;
                }
            }
        }
        else if (HelicBig)
        {
            if (gameObject.transform.name == "DHF_Helicopter_Moving_2")
            {
                ChangeAnimation("HelicBigCloth");
            }
        }
        else if (HelicGoCloth)
        {
            if (gameObject.transform.name == "DHF_Helicopter_Moving_2")
            {
                gameObject.transform.position += new Vector3(10 * Time.deltaTime, 0f);
                if (gameObject.transform.localPosition.x >= 20f) SceneManager.LoadScene("Level_Big_Ramp");
            }
        }
    }

    void HelicClothGo()
    {
        ChangeAnimation("HelicBigClothGo");
        HelicBig = false;
        HelicGoCloth = true;
    }

    void ZakeOff()
    {
        Zake.SetActive(false);
        shadow.SetActive(false);
    }
}
