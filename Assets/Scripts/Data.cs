using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static bool rewinding;
    public static bool paused;
    public static bool gameOver;
    public static bool victory;
    public static Vector2 defaultResolution = new Vector2(800, 600);
    public static float changeTime;
    public static float unrewindableTime;


    public static float GetPosValue(float number)
    {
        return (number * 1.28f + 0.64f);
    }
    public static Vector2 GetPosition(float x, float y)
    {
        return (new Vector2(GetPosValue(x), GetPosValue(y)));
    }
}
