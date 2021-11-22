using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : WorldObject
{
    public float timeChange;
    public bool win;
    public bool defeat;

    public void Collect()
    {
        if (rewindable)
        {
            Data.changeTime += timeChange;
        }
        else
        {
            Data.unrewindableTime += timeChange;
        }
        Data.victory = win;
        Data.gameOver = defeat;
        transform.position = new Vector3(-100, -100, 0);
    }
}
