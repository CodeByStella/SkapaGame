using UnityEngine;
using UnityEngine.UI;

public class RecordsController : MonoBehaviour
{
    ////public Text text1, text2, text3, text4, text5;
    ////static public int value1 = 0, value2 = 0, value3 = 0, value4 = 0, value5 = 0;
    ////void Update()
    ////{
    ////    text1.text = PlayerPrefs.GetInt("Distance1").ToString();
    ////    text2.text = PlayerPrefs.GetInt("Distance2").ToString();
    ////    text3.text = PlayerPrefs.GetInt("Distance3").ToString();
    ////    text4.text = PlayerPrefs.GetInt("Distance4").ToString();
    ////    text5.text = PlayerPrefs.GetInt("Distance5").ToString();

    ////}
    void Update()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Distance1").ToString();
    }
}
