using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    public float speed = 100f; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            rb.velocity = Vector2.left * 10;
        else if (Input.GetKey(KeyCode.D))
            rb.velocity = Vector2.right * 10; 
        else
            rb.velocity = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (direction == Vector2.zero)
            return; 
        rb.AddForce(direction * speed * 900000);
    }
}
