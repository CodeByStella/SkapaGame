using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class ButtonBack : MonoBehaviour
{
    public GameObject shopMenuActive;
    // Start is called before the first frame update
    void Start()
    {
        Button backMenu = GetComponent<Button>();
        backMenu.onClick.AddListener(Back);
    }

    // Update is called once per frame
    void Back()
    {
        Buttons.Shop = false;
        shopMenuActive.SetActive(false);
    }
}
