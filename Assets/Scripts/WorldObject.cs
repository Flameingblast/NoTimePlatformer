using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public bool rewindable;
    public float xPos;
    public float yPos;

    public void SetPosition()
    {
        transform.position = Data.GetPosition(xPos, yPos);
    }
}
