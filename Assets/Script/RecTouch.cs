using JetBrains.Annotations;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject MenuS, MenuK, MenuL;
    public GameObject Home, Restart;
    public static bool Active;
    private void Start()
    {
        Active = true; 
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Active = false;
            MenuS.SetActive(false);
            MenuK.SetActive(false);
            MenuL.SetActive(false);
            Home.SetActive(true);
            Restart.SetActive(true);
        }
    }
}
