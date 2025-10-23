using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
    // (Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y))
public class ControllScriptBigRamp : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.x > 0)
            {
                if (eventData.delta.x > 0 && eventData.delta.y == 0)
                {
                    Debug.Log("Право");
                    SetArrow("Right");
                    TrickScript.trickOn = true;
                }
                else if (eventData.delta.x > 0 && eventData.delta.y > 0)
                {
                    Debug.Log("Верх Право");
                    SetArrow("Right Up");
                    TrickScript.trickOn = true;
                }
                else if (eventData.delta.x > 0 && eventData.delta.y < 0)
                {
                    Debug.Log("Низ Право");
                    SetArrow("Right Down");
                    TrickScript.trickOn = true;
                }
            }
            else
            {
                if (eventData.delta.x < 0 && eventData.delta.y == 0)
                {
                    Debug.Log("Лево");
                    SetArrow("Left");
                    TrickScript.trickOn = true;
                }
                else if (eventData.delta.x < 0 && eventData.delta.y > 0)
                {
                    Debug.Log("Верх Лево");
                    SetArrow("Left Up");
                    TrickScript.trickOn = true;
                }
                else if (eventData.delta.x < 0 && eventData.delta.y < 0)
                {
                    Debug.Log("Низ Лево");
                    SetArrow("Left Down");
                    TrickScript.trickOn = true;
                }
            }

        }
        else
        {
            if (eventData.delta.y > 0)
            {
                if (eventData.delta.x == 0 && eventData.delta.y > 0)
                {
                    Debug.Log("Верх");
                    SetArrow("Up");
                    TrickScript.trickOn = true;
                }
                else if (eventData.delta.x > 0 && eventData.delta.y > 0)
                {
                    Debug.Log("Верх Право");
                    SetArrow("Right Up");
                    TrickScript.trickOn = true;
                }
                else if (eventData.delta.x < 0 && eventData.delta.y > 0)
                {
                    Debug.Log("Верх Лево");
                    SetArrow("Left Up");
                    TrickScript.trickOn = true;
                }
            }
            else
            {
                if (eventData.delta.x == 0 && eventData.delta.y < 0)
                {
                    Debug.Log("Низ");
                    SetArrow("Down");
                    TrickScript.trickOn = true;
                }
                else if (eventData.delta.x > 0 && eventData.delta.y < 0)
                {
                    Debug.Log("Низ Право");
                    SetArrow("Right Down");
                    TrickScript.trickOn = true;
                }
                else if (eventData.delta.x < 0 && eventData.delta.y < 0)
                {
                    Debug.Log("Низ Лево");
                    SetArrow("Left Down");
                    TrickScript.trickOn = true;
                }
            }
        }
    } 

    public void OnDrag(PointerEventData eventData)
    {
       
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void SetArrow(String arrow)
    {
        if (TrickScript.arrowControl[0] == null)
        {
            TrickScript.arrowControl[0] = arrow;
        }
        else
        {
            TrickScript.arrowControl[1] = arrow;
        }
    }
}
