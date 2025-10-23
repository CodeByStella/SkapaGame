using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoCar : MonoBehaviour
{
    public static bool goSaveZik;
    public static bool saveZik;
    public Animator anim;
    private string currentAnimation;
    public GameObject zik;
    public static bool saveZikOk;

    public static int carGoCount;
    // Start is called before the first frame update
    void Start()
    {
        // anim = GetComponent<Animator>();
        goSaveZik = false;
        carGoCount = 0;
        saveZikOk = false;
    }
    
    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation) return;

        anim.Play(animation);
        currentAnimation = animation;
    }

    // Update is called once per frame
    void Update()
    {
        if (goSaveZik && gameObject.transform.name == "Car")
        {
            gameObject.transform.localPosition += new Vector3(-40f, 0f, 0f);
            carGoCount++;
            Debug.Log(carGoCount);
            if (carGoCount == 50)
            {
                goSaveZik = false;
                saveZik = true;
                carGoCount = 0;
                saveZikOk = true;
            }
            // goSaveZik = false;
        }

        if (saveZik)
        {
            if (saveZikOk)
            {
                zik.transform.localPosition = new Vector3(-7.51f, 3.57f, 0f);
                zik.SetActive(false);
                saveZikOk = false;
            }
            ChangeAnimation("CarGoZik");
            gameObject.transform.localPosition += new Vector3(-20f, 0f, 0f);
            carGoCount++;
            Debug.Log(carGoCount);
            if (carGoCount == 40)
            {
                MoveCameraBigRamp.lifeCoin = 2;
                CoinControl.coinDelet = true;
                CoinControl.coinDown = true;
                saveZik = false;
                carGoCount = 0;
            }
        } 
    }
}
