using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateData
{
    GameObject character;
    Vector3 position;
    Vector2 velocity;
    bool right;

    public CharacterStateData(GameObject c)
    {
        character = c;
        position = c.transform.position;
        Rigidbody2D body = c.GetComponent<Rigidbody2D>();
        if (body != null)
        {
            velocity = c.GetComponent<Rigidbody2D>().velocity;
        }
        EnemyController ec = c.GetComponent<EnemyController>();
        if(ec != null)
        {
            right = ec.Right;
        }
    }
    public CharacterStateData(GameObject character, Vector3 position, Vector2 velocity, bool right)
    {
        this.character = character;
        this.position = position;
        this.velocity = velocity;
        this.right = right;
    }

    public void ResetCharacter()
    {
        character.transform.position = position;
        Rigidbody2D body = character.GetComponent<Rigidbody2D>();
        if (body != null)
        {
            character.GetComponent<Rigidbody2D>().velocity = velocity;
        }
        EnemyController ec = character.GetComponent<EnemyController>();
        if (ec != null)
        {
            ec.Right = right;
        }
    }
}
