using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="StageData", menuName ="ScriptableObjects", order = 0)]
public class StageData : ScriptableObject
{
    public GameObject stagePointer;
    public float startTime;
    public Vector2 size;
    public bool timeRewindable;
}
