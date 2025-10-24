using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject[] setActiveList;

    public GameObject[] character;
    public Transform parentTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("TsirtBuy1") == 1 && PlayerPrefs.GetInt("TsirtPick1") == 1)
        {
            GameObject ch = Instantiate(character[3], new Vector3(0f, 0f, 0f), Quaternion.identity);
            ch.transform.SetParent(parentTransform);
            ch.transform.SetSiblingIndex(3);
        }
        else if (PlayerPrefs.GetInt("TsirtBuy2") == 1 && PlayerPrefs.GetInt("TsirtPick2") == 1)
        {
            GameObject ch =Instantiate(character[2], new Vector3(0f, 0f, 0f), Quaternion.identity);
            ch.transform.SetParent(parentTransform);
            ch.transform.SetSiblingIndex(3);
        }
        else if (PlayerPrefs.GetInt("TsirtBuy3") == 1 && PlayerPrefs.GetInt("TsirtPick3") == 1)
        {
            GameObject ch =Instantiate(character[0], new Vector3(0f, 0f, 0f), Quaternion.identity);
            ch.transform.SetParent(parentTransform);
            ch.transform.SetSiblingIndex(3);
        }
        else if (PlayerPrefs.GetInt("TsirtBuy4") == 1 && PlayerPrefs.GetInt("TsirtPick4") == 1)
        {
            GameObject ch =Instantiate(character[1], new Vector3(0f, 0f, 0f), Quaternion.identity);
            ch.transform.SetParent(parentTransform);
            ch.transform.SetSiblingIndex(3);
        }
        else
        {
            GameObject ch = Instantiate(character[2], new Vector3(0f, 0f, 0f), Quaternion.identity);
            ch.transform.SetParent(parentTransform);
            ch.transform.SetSiblingIndex(3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if setActiveList is assigned and has elements
        if (setActiveList == null || setActiveList.Length == 0)
            return;

        if (Buttons.can_swi || Buttons.Shop)
        {
            for (int i = 0; i < setActiveList.Length; i++)
            {
                if (setActiveList[i] != null)
                    setActiveList[i].SetActive(false);
            }
        }
        else if (!Buttons.can_swi || !Buttons.Shop)
        {
            for (int i = 0; i < setActiveList.Length; i++)
            {
                if (setActiveList[i] != null)
                    setActiveList[i].SetActive(true);
            }
        }
    }
}
