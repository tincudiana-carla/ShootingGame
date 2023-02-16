using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleWalking : MonoBehaviour
{
    public float speed = 2.0f;
    public float leftBoundary = -5.0f;
    public float rightBoundary = 5.0f;
    private Vector3 spriteScale;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        spriteScale = transform.localScale;
    }

    void Update()
    {
        if (transform.position.x >= rightBoundary)
        {
            rb.velocity = new Vector2(-rb.velocity.x, 0);
            spriteScale.x = Mathf.Abs(spriteScale.x) * -1;
            transform.localScale = spriteScale;
        }
        else if (transform.position.x <= leftBoundary)
        {
            rb.velocity = new Vector2(-rb.velocity.x, 0);
            spriteScale.x = Mathf.Abs(spriteScale.x);
            transform.localScale = spriteScale;
        }
    }
}
