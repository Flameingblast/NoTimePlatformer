using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class EnemyController : WorldObject
{
    private float overLedge;
    private bool right;
    private Rigidbody2D body;

    public bool Right
    {
        get { return (right); }
        set { right = value; }
    }

    public LedgeChecker[] ledgeCheckers;
    public float acceleration;
    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        overLedge = 0;
        right = true;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Data.rewinding)
        {
            bool ledge = false;
            for (int i = 0; i < ledgeCheckers.Length; ++i)
            {
                if (ledgeCheckers[i].ledge)
                {
                    ledge = true;
                    break;
                }
            }
            if (ledge)
            {
                overLedge += Time.deltaTime;
                if (overLedge > 0.2f)
                {
                    TurnAround();
                    overLedge = 0;
                }
            }
            else
            {
                overLedge = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!Data.rewinding)
        {
            float multiplier = 1;
            float speed = Mathf.Max(maxSpeed * -1, Mathf.Min(maxSpeed, body.velocity.x));
            multiplier *= Mathf.Pow(maxSpeed - Mathf.Abs(speed), 0.1f);
            if (right)
            {
                body.AddForce(new Vector2(acceleration * multiplier * Time.fixedDeltaTime, 0), ForceMode2D.Impulse);
            }
            else
            {
                body.AddForce(new Vector2(-1 * acceleration * multiplier * Time.fixedDeltaTime, 0), ForceMode2D.Impulse);
            }
        }
    }

    private void TurnAround()
    {
        right = !right;
        body.velocity = new Vector2(0,0);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y < 0.7)
            {
                TurnAround();
                break;
            }
        }
    }
}
