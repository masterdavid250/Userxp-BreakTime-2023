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
    [SerializeField] private Powerups powerups;

    public Rigidbody2D RB { get; private set; }

    private bool isAttached;
    
    private bool isSticked = false;
    private Transform stickyPaddle = null;
    private Vector3 offset;

    private CircleCollider2D circleCollider;

    private Vector2 contactPoint; 

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

        if (isSticked)
        {
            transform.position = stickyPaddle.position + offset;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isSticked = false;
                stickyPaddle = null;
                offset = Vector3.zero;
                RB.velocity = Vector2.zero;
                RB.AddForce(Vector2.up * 300f);
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
        if (GameManager.instance.Lives <= 0)
        {
            Debug.Log("sajfhksjdf");
            Destroy(this.gameObject);
            return;
        }

        this.transform.position = new Vector2(-2f, -3.4f);
        this.RB.velocity = Vector2.zero;
        isAttached = true;
    }

    // Code Source: https://forum.unity.com/threads/change-the-circlecollider2d-radius-according-the-sprite.427629/
    public void UpdateColliderSize()
    {
        Vector3 spriteHalfSize = spriteRenderer.sprite.bounds.extents;
        circleCollider.radius = spriteHalfSize.x > spriteHalfSize.y ? spriteHalfSize.x : spriteHalfSize.y;
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (powerups.isStickyPaddlesActivated && collision.gameObject.name == "Paddle1" && !isAttached)
        {
            FindObjectOfType<AudioManager>().Play("Coin (sticky)");
            isSticked = true;
            stickyPaddle = collision.transform;
            offset = transform.position - stickyPaddle.position;
        }
        else if (collision.gameObject.tag == "Paddle")
        {
            FindObjectOfType<AudioManager>().Play("Coin (paddle)");
        }
        else if (collision.gameObject.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("Coin (wall)");
        }
        else if (collision.gameObject.tag == "Snacks")
        {
            FindObjectOfType<AudioManager>().Play("Coin (snack)");
        }
    }
}
