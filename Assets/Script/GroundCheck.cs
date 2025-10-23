using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Line")
        {
            HeroClassNew.Jump = false;
            HeroClassNew.isGround = true;
            HeroClassNew.extraJump = 0;
            HeroClassNew.JumpTwo = false;
        }
    }
}
