using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public CharacterStateData[] states;
    public float lightTime;

    public GameState(GameObject[] characters, float lT)
    {
        lightTime = lT;
        states = new CharacterStateData[characters.Length];
        for(int i = 0; i < characters.Length; ++i)
        {
            states[i] = new CharacterStateData(characters[i]);
        }
    }
}
