using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : WorldObject
{
    private bool inAir;
    private Rigidbody2D body;
    private bool isJump;
    private bool pressedJump;

    public float airMultiplier;
    public float acceleration;
    public float maxSpeed;
    public float jump;
    // Start is called before the first frame update
    void Start()
    {
        isJump = false;
        inAir = false;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Data.rewinding)
        {
            float multiplier = 1;
            if (inAir)
            {
                multiplier *= airMultiplier;
            }
            float speed = Mathf.Max(maxSpeed * -1, Mathf.Min(maxSpeed, body.velocity.x));
            if (Input.GetAxis("Horizontal") > 0.05f)
            {
                if(body.velocity.x > 0)
                {
                    multiplier *= Mathf.Pow(maxSpeed - Mathf.Abs(speed), 0.1f);
                }
                body.AddForce(new Vector2(acceleration * multiplier * Time.fixedDeltaTime, 0), ForceMode2D.Impulse);
            }
            else if (Input.GetAxis("Horizontal") < -0.05f)
            {
                if(body.velocity.x < 0)
                {
                    multiplier *= Mathf.Pow(maxSpeed - Mathf.Abs(speed), 0.1f);
                }
                body.AddForce(new Vector2(-1 * acceleration * multiplier * Time.fixedDeltaTime, 0), ForceMode2D.Impulse);
            }
            if (Input.GetAxis("Vertical") > 0.05f && !pressedJump && !inAir)
            {
                body.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
                inAir = true;
                isJump = true;
                pressedJump = true;
            }
            if(!inAir && Input.GetAxis("Vertical") < 0.05f)
            {
                pressedJump = false;
            }
        }
        if(transform.position.y < -3.84f)
        {
            Data.gameOver = true;
        }
    }

    private void CheckCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.7)
                {
                    inAir = false;
                    isJump = false;
                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        CheckCollision(collision);
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Data.gameOver = true;
        }
        else if(collision.gameObject.CompareTag("Goal"))
        {
            Data.victory = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            inAir = true;
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if(inAir && !isJump)
        {
            CheckCollision(collision);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Data.gameOver = true;
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            Data.victory = true;
        }
        else if(collision.gameObject.CompareTag("Collectable"))
        {
            Collectable collectable = collision.gameObject.GetComponent<Collectable>();
            collectable.Collect();
        }
    }
}
