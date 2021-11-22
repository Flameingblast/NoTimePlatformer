using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterAnimator : MonoBehaviour
{
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (body.velocity.x != 0)
        {
            Vector3 mirror = transform.localScale;
            mirror.x = Mathf.Abs(mirror.x);
            if (body.velocity.x < 0)
            {
                mirror.x *= -1;
            }
            transform.localScale = mirror;
        }
    }
}
