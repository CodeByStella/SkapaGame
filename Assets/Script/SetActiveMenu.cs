using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveMenu : MonoBehaviour
{
    
    void FixedUpdate()
    {
        if (Buttons.Shop || Buttons.PromoCodeMenu)
        {
            if (ControlScriptForMenu.krasnodarLvl || ControlScriptForMenu.lasvegasrLvl ||
                ControlScriptForMenu.schoolLvl)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                gameObject.SetActive(false);   
            }
        }
        else if (!Buttons.Shop || !Buttons.PromoCodeMenu)
        {
            if (ControlScriptForMenu.krasnodarLvl || ControlScriptForMenu.lasvegasrLvl ||
                ControlScriptForMenu.schoolLvl)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                gameObject.SetActive(true);   
            }
        }
    }
}
