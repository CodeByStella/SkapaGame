using UnityEngine;

public class Fail : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopGame.Death();
            HeroClassNew.Fail = true;
            HeroClassNew.FailDown = true;
            Destroy(transform.parent.gameObject);
        }
    }
}