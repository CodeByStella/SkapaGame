using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlScript : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.x > 0)
            {
            }
            else
            {
                
            }

        }
        else if ((Mathf.Abs(eventData.delta.x)) < (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.y > 0)
            {
                if (HeroClassNew.index <= 2 && HeroClassNew.index >= 1)
                {
                    HeroClassNew.MoveTop = true;
                    HeroClassNew.extraJump = 5;
                }
            }
            else
            {
                if (HeroClassNew.index <= 3 && HeroClassNew.index >= 2)
                {
                    HeroClassNew.MoveBot = true;
                    HeroClassNew.extraJump = 5;
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    private void OnMouseUpAsButton()
    {
        if (HeroClassNew.extraJump <= 3)
        {
            HeroClassNew.extraJump++;    
        }
        if (!HeroClassNew.MoveTop && !HeroClassNew.MoveBot)
            HeroClassNew.Jump = true;
        else if (HeroClassNew.Jump)
        {
            Debug.Log("Jump 2 Ready");
            HeroClassNew.JumpTwo = true;   
        }
    }
}
