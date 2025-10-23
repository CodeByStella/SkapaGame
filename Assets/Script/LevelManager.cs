using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Sprite cloud1s, cloud2s, trail1s, trail2s, skys, fon1s, fon2s, cloud1k, cloud2k, trail1k, trail2k, skyk, fon1k, fon2k, cloud1l, cloud2l, trail1l, trail2l, skyl, fon1l, fon2l;
    public GameObject sun;
    public GameObject cloud1, cloud2, trail1, trail2, sky;
    public GameObject fon1, fon2, sea1, sea2, gorodk, gorodl, cloud;


    //public static bool kras = false, school = true;
    void Start()
    {
        if (ControlScriptForMenu.l || ControlScriptForMenu.k)
        {
            sun.SetActive(false);
        }

        if (ControlScriptForMenu.l)
        {
            cloud1.transform.localPosition = new Vector3(-4.35f, 1.8f, 10f);
            cloud2.transform.localPosition = new Vector3(25.1f, 1.8f, 10f);
            trail1.transform.localScale = new Vector3(2.85f, 3.3f, 0f);
            trail2.transform.localScale = new Vector3(2.85f, 3.33f, 0f);
            trail1.transform.localPosition = new Vector3(-0.34f, 0.76f, 10f);
            trail2.transform.localPosition = new Vector3(33.4f, 1.08f, 10f);
            // cloud1.transform.position.y = 1.8f;
            // cloud1.transform.position.y = new Vector2(-4.35f, 1.8f);
        }
        //if (ControlScriptForMenu.s)
        //{
        //    ControlScriptForMenu.schoolLvl = true;
        //    ControlScriptForMenu.krasnodarLvl = false;
        //    ControlScriptForMenu.lasvegasrLvl = false;
        //}
        //if (ControlScriptForMenu.k)
        //{
        //    ControlScriptForMenu.schoolLvl = false;
        //    ControlScriptForMenu.krasnodarLvl = true;
        //    ControlScriptForMenu.lasvegasrLvl = false;
        //}
        //if (ControlScriptForMenu.l)
        //{
        //    ControlScriptForMenu.schoolLvl = false;
        //    ControlScriptForMenu.krasnodarLvl = false;
        //    ControlScriptForMenu.lasvegasrLvl = true;
        //}
        //if (PlayerPrefs.GetInt("ch")==1) 
        //{
        //    ControlScriptForMenu.schoolLvl = true;
        //    ControlScriptForMenu.krasnodarLvl = false;
        //    ControlScriptForMenu.lasvegasrLvl = false;
        //}
        //if (PlayerPrefs.GetInt("ch") == 2)
        //{
        //    ControlScriptForMenu.schoolLvl = false;
        //    ControlScriptForMenu.krasnodarLvl = true;
        //    ControlScriptForMenu.lasvegasrLvl = false;
        //}
        //if (PlayerPrefs.GetInt("ch") == 3)
        //{
        //    ControlScriptForMenu.schoolLvl = false ;
        //    ControlScriptForMenu.krasnodarLvl = false;
        //    ControlScriptForMenu.lasvegasrLvl = true;
        //}
        // Debug.Log(ControlScriptForMenu.schoolLvl + " ControlScriptForMenu.schoolLvl");
        // Debug.Log(ControlScriptForMenu.krasnodarLvl + " ControlScriptForMenu.krasnodarLvl");
        // Debug.Log(ControlScriptForMenu.lasvegasrLvl + " ControlScriptForMenu.lasvegasrLvl");
        if (ControlScriptForMenu.schoolLvl)
        {
            School();
        }
        if (ControlScriptForMenu.krasnodarLvl)
        {
            Kras();
        }
        if (ControlScriptForMenu.lasvegasrLvl)
        {
            Lasv();
        }
    }
    void School()
    {
        cloud1.GetComponent<SpriteRenderer>().sprite = cloud1s;
        cloud2.GetComponent<SpriteRenderer>().sprite = cloud2s;
        trail1.GetComponent<SpriteRenderer>().sprite = trail1s;
        trail2.GetComponent<SpriteRenderer>().sprite = trail2s;
        sky.GetComponent<SpriteRenderer>().sprite = skys;
        sea1.SetActive(true); sea2.SetActive(true);
        gorodk.SetActive(false);
        gorodl.SetActive(false);
        // cloud.SetActive(true);
        //cloud1.sprite = cloud1s;
        //cloud2.sprite = cloud2s;
        //trail1.sprite = trail1s;
        //trail2.sprite = trail2s;
        //sky.sprite = skys;
    }
    void Kras()
    {
        cloud1.GetComponent<SpriteRenderer>().sprite = cloud1k;
        cloud2.GetComponent<SpriteRenderer>().sprite = cloud2k;
        trail1.GetComponent<SpriteRenderer>().sprite = trail1k;
        trail2.GetComponent<SpriteRenderer>().sprite = trail2k;
        sky.GetComponent<SpriteRenderer>().sprite = skyk;
        sea1.SetActive(false); sea2.SetActive(false);
        gorodk.SetActive(true);
        gorodl.SetActive(false);
        // cloud.SetActive(false);
        //cloud1.sprite = cloud1s;
        //cloud2.sprite = cloud2s;
        //trail1.sprite = trail1s;
        //trail2.sprite = trail2s;
        //sky.sprite = skys;
    }
    void Lasv()
    {
        cloud1.GetComponent<SpriteRenderer>().sprite = cloud1l;
        cloud2.GetComponent<SpriteRenderer>().sprite = cloud2l;
        trail1.GetComponent<SpriteRenderer>().sprite = trail1l;
        trail2.GetComponent<SpriteRenderer>().sprite = trail2l;
        sky.GetComponent<SpriteRenderer>().sprite = skyl;
        sea1.SetActive(false); sea2.SetActive(false);
        gorodk.SetActive(false);
        gorodl.SetActive(true);
        // cloud.SetActive(false);
        //fon1.GetComponent<Spr iteRenderer>().sprite = fon1l;
        //fon2.GetComponent<SpriteRenderer>().sprite = fon2l;
        //cloud1l
        //cloud2l
        //trail1l
        //trail2l
        //skyl
        //fon1l
        //fon2l
    }

}
