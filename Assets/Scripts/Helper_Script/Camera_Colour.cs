using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Colour : MonoBehaviour
{
    public Camera camera;
    public float colorChangeSpeed = 1f;

    void Update()
    {
        if (!UI_Logic_Script.isGamePaused)
        {
            float r = Mathf.Sin(Time.time * colorChangeSpeed);
            float g = Mathf.Sin(Time.time * colorChangeSpeed + 2);
            float b = Mathf.Sin(Time.time * colorChangeSpeed + 4);
            camera.backgroundColor = new Color(r, g, b);
        }
    }
}
