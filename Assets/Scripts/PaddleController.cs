using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public GameObject       paddleMain;
    public GameObject       paddleLeft;
    public GameObject       paddleRight;
    public GameObject       paddleBottom;
    public float            speed = 100f;
    private Rigidbody2D     rbM;
    private Rigidbody2D     rbL;
    private Rigidbody2D     rbR;
    private Rigidbody2D     rbB;
    private Vector2         direction;

    private void Awake()
    {
        FindObjectOfType<AudioManager>().StopAllAudio();
        FindObjectOfType<AudioManager>().Play("Game BGM");
    }

    private void Start()
    {
        GameManager.instance.isAskingForName = false;

        rbM = paddleMain.GetComponent<Rigidbody2D>();
        rbL = paddleLeft.GetComponent<Rigidbody2D>();
        rbR = paddleRight.GetComponent<Rigidbody2D>();
        rbB = paddleBottom.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.instance.isAskingForName)
            return;

        // Horizontal paddle
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rbM.velocity = Vector2.left * 10;
            rbB.velocity = Vector2.left * 10;
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rbM.velocity = Vector2.right * 10;
            rbB.velocity = Vector2.right * 10;
        }

        else
        {
            rbM.velocity = Vector2.zero;
            rbB.velocity = Vector2.zero;
        }

        // Vertical paddles (they move together)
        if (Input.GetKey(KeyCode.W)  || Input.GetKey(KeyCode.UpArrow))
        {
            rbL.velocity = Vector2.up * 10;
            rbR.velocity = Vector2.up * 10;
        }
        
        else if (Input.GetKey(KeyCode.S)  || Input.GetKey(KeyCode.DownArrow))
        {
            rbL.velocity = Vector2.down * 10;
            rbR.velocity = Vector2.down * 10;
        }
        
        else
        {
            rbL.velocity = Vector2.zero;
            rbR.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (direction == Vector2.zero)
            return; 

        rbM.AddForce(direction * speed * 900000);
        rbB.AddForce(direction * speed * 900000);
    }

    public void ResetPaddle()
    {
        rbL.velocity = Vector2.zero;
        rbM.velocity = Vector2.zero;
        rbR.velocity = Vector2.zero;
        rbB.velocity = Vector2.zero;
    }
}
