using UnityEngine;

public class BG_Destroy : MonoBehaviour
{
    public static bool destroyBG = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            destroyBG = true;
            Destroy(gameObject);
        }
    }
}
