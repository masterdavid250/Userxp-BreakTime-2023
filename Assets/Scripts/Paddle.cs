using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code is from: https://www.youtube.com/watch?v=RYG8UExRkhA
public class Paddle : MonoBehaviour
{
    public new Rigidbody2D RB { get; private set; }

    private float maxBounceAngle = 80f;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector2 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float maxOffset = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.RB.velocity);
            float bounceAngle = (offset / maxOffset) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.RB.velocity = rotation * Vector2.up * ball.RB.velocity.magnitude;
        }
    }
}
