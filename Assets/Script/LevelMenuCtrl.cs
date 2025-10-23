using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public void School()
    {
        ControlScriptForMenu.schoolLvl = true; ControlScriptForMenu.krasnodarLvl = false; ControlScriptForMenu.lasvegasrLvl = false;
    }
    public void Krasnodar()
    {
        ControlScriptForMenu.schoolLvl = false; ControlScriptForMenu.krasnodarLvl = true; ControlScriptForMenu.lasvegasrLvl = false;
    }
    public void Lasvegas()
    {
        ControlScriptForMenu.schoolLvl = false; ControlScriptForMenu.krasnodarLvl = false; ControlScriptForMenu.lasvegasrLvl = true;
    }
}
