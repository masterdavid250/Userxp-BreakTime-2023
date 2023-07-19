using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int ballDamage = 1; 
    public SpriteRenderer spriteRenderer;
    public Sprite[] ballSprites;
    [SerializeField] private Transform paddle;
    [SerializeField] private float speed = 10f;

    public new Rigidbody2D RB { get; private set; }

    private bool isAttached;
    private CircleCollider2D circleCollider;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        ResetBall();
    }

    private void Update()
    {
        if (ballDamage <= 0)
            ballDamage = 1; 

        if (isAttached)
        {
            Vector2 target = new Vector2(paddle.position.x, transform.position.y);

            transform.position = target;

            if (Input.GetKey(KeyCode.Space))
            {
                Launch();
            }
        }
    }

    private void FixedUpdate()
    {
        RB.velocity = RB.velocity.normalized * speed;
    }

    private void Launch()
    {
        Vector2 force = Vector2.up;
        RB.AddForce(force.normalized * speed);

        isAttached = false;
    }

    public void ResetBall()
    {
        this.transform.position = new Vector2(-2f, -3.5f);
        this.RB.velocity = Vector2.zero;

        isAttached = true;
    }

    // Code Source: https://forum.unity.com/threads/change-the-circlecollider2d-radius-according-the-sprite.427629/
    public void UpdateColliderSize()
    {
        Vector3 spriteHalfSize = spriteRenderer.sprite.bounds.extents;
        circleCollider.radius = spriteHalfSize.x > spriteHalfSize.y ? spriteHalfSize.x : spriteHalfSize.y;
    } 
}
