using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLevel : MonoBehaviour
{
    public Transform musicLevel;
    public Transform musicFXLevel;
    public float coordinateSound;

    private void OnMouseDrag()
    {
        if(gameObject.name == "Rect1" || gameObject.name == "Rect1_1") {
            coordinateSound = gameObject.transform.position.x;
            Vector3 mousePosFx = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosFx.x = mousePosFx.x > coordinateSound + 3.65f ? coordinateSound + 3.65f : mousePosFx.x;
            mousePosFx.x = mousePosFx.x < coordinateSound - 3.65f ? coordinateSound - 3.65f : mousePosFx.x;
            musicFXLevel.position = new Vector2(mousePosFx.x, musicFXLevel.position.y);
        }
        else if (gameObject.name == "Rect2" || gameObject.name == "Rect2_1")
        {
            coordinateSound = gameObject.transform.position.x;
            Vector3 mousePosMus = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosMus.x = mousePosMus.x > coordinateSound + 3.65f ? coordinateSound + 3.65f : mousePosMus.x;
            mousePosMus.x = mousePosMus.x < coordinateSound - 3.65f ? coordinateSound - 3.65f : mousePosMus.x;
            musicLevel.position = new Vector2(mousePosMus.x, musicLevel.position.y);
        }
    }
}
