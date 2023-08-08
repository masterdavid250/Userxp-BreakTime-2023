using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PaddleType
{
    main,
    left,
    right,
    bottom
}
// Code is from: https://www.youtube.com/watch?v=RYG8UExRkhA
public class Paddle : MonoBehaviour
{
    public Rigidbody2D RB { get; private set; }

    private float maxBounceAngle = 80f;

    public PaddleType thisPaddleType; 

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
            Vector2 direction = Vector2.up;

            float offset = 0f;
            float maxOffset = 0f;
            float currentAngle = 0f;
            float bounceAngle = 0f;
            float newAngle = 0f;

            if (thisPaddleType == PaddleType.main)
            {
                direction = Vector2.up;
                offset = paddlePosition.x - contactPoint.x;
                maxOffset = collision.otherCollider.bounds.size.x / 2;
            }

            if (thisPaddleType == PaddleType.bottom)
            {
                direction = Vector2.down;
                offset = paddlePosition.x - contactPoint.x;
                maxOffset = collision.otherCollider.bounds.size.x / 2;
            }

            if (thisPaddleType == PaddleType.right)
            {
                direction = Vector2.left;
                offset = paddlePosition.y - contactPoint.y;
                maxOffset = collision.otherCollider.bounds.size.y / 2;
            }

            currentAngle = Vector2.SignedAngle(direction, ball.RB.velocity);
            bounceAngle = (offset / maxOffset) * maxBounceAngle;
            newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            if (thisPaddleType == PaddleType.left)
            {
                direction = Vector2.right;
                offset = paddlePosition.y - contactPoint.y;
                maxOffset = collision.otherCollider.bounds.size.y / 2;

                currentAngle = Vector2.SignedAngle(direction, ball.RB.velocity);
                bounceAngle = (offset / maxOffset) * maxBounceAngle;
                newAngle = Mathf.Clamp(currentAngle - bounceAngle, -maxBounceAngle, maxBounceAngle);
            }

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.RB.velocity = rotation * direction * ball.RB.velocity.magnitude;
        }
    }
}
