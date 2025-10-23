using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_switch : MonoBehaviour
{
    public bool switchCamera;
    public bool blik;
    public int blikTimer;
    public Camera cameraMain;
    public Camera cameraHelp;
    public static bool switch1, switch2;

    // Start is called before the first frame update
    void Start()
    {
        switch1 = false;
        switch2 = false;
        switchCamera = false;
        blik = false;
        blikTimer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (blik && blikTimer < 100)
        // {
        //     blikTimer++; 
        //     Debug.Log(blikTimer);
        //     Debug.Log(blik);
        // }
        //
        // if (blik && blikTimer >= 100)
        // {
        //     blik = false;
        //     blikTimer = 0;
        // }
        PixiActive();
        if (switch1) BgPix();
        if (switch2) BgNormal();
    }

    public void PixiActive()
    {
        if (Buttons.can_swi && gameObject.transform.name == "Canvas")
        {
            // Canvas canvas = gameObject.GetComponent<Canvas>();
            // canvas.renderMode = RenderMode.ScreenSpaceCamera;
            // canvas.worldCamera = cameraHelp;
            cameraHelp.targetDisplay = 1;
            cameraMain.targetDisplay = 0;
            // blikTimer = 0;
            switch1 = true;
        }
        else if (!Buttons.can_swi && gameObject.transform.name == "Canvas2" && switchCamera)
        {
            Canvas canvas = gameObject.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = cameraMain;
            cameraHelp.targetDisplay = 1;
            cameraMain.targetDisplay = 0;
            switchCamera = false;
            switch2 = true;
        }
    }

    void BgPix()
    {
        if (Buttons.can_swi && gameObject.transform.name == "Canvas2")
        {
            Canvas canvas = gameObject.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = cameraHelp;
            cameraHelp.targetDisplay = 1;
            cameraMain.targetDisplay = 1;
            switchCamera = true;
            // blik = true;
            // blikTimer = 0;
            switch1 = false;
        }
    }

    void BgNormal()
    {
        if (!Buttons.can_swi && gameObject.transform.name == "Canvas")
        {
            // Canvas canvas = gameObject.GetComponent<Canvas>();
            // canvas.renderMode = RenderMode.ScreenSpaceCamera;
            // canvas.worldCamera = cameraHelp;
            cameraHelp.targetDisplay = 1;
            cameraMain.targetDisplay = 1;
            switch2 = false;
        }
    }
}
