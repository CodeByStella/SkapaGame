using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZakeTshirt : MonoBehaviour
{
    public Texture[] textureTshirt = new Texture[4];
    public Texture[] textureLogo = new Texture[3];
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Tshirt1Pick") == 1)
        {
            if (gameObject.transform.name == "Shirt")
            {
                gameObject.GetComponent<Renderer>().material.mainTexture = textureTshirt[0];
            }
        }
        else if (PlayerPrefs.GetInt("Tshirt2Pick") == 1)
        {
            if (gameObject.transform.name == "Shirt")
            {
                gameObject.GetComponent<Renderer>().material.mainTexture = textureTshirt[1];
            }
            
            if (gameObject.transform.name == "Logo4")
            {
                gameObject.GetComponent<Renderer>().material.mainTexture = textureLogo[0];
            }
        }
        else if (PlayerPrefs.GetInt("Tshirt3Pick") == 1)
        {
            if (gameObject.transform.name == "Shirt")
            {
                gameObject.GetComponent<Renderer>().material.mainTexture = textureTshirt[2];
            }
            
            if (gameObject.transform.name == "Logo4")
            {
                gameObject.GetComponent<Renderer>().material.mainTexture = textureLogo[1];
            }
        }
        else if (PlayerPrefs.GetInt("Tshirt4Pick") == 1)
        {
            if (gameObject.transform.name == "Shirt")
            {
                gameObject.GetComponent<Renderer>().material.mainTexture = textureTshirt[3];
            }
            
            if (gameObject.transform.name == "Logo4")
            {
                gameObject.GetComponent<Renderer>().material.mainTexture = textureLogo[2];
            }
        }
    }
}
