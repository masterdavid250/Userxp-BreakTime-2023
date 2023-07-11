using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public GameObject       paddleMain;
    public GameObject       paddleLeft;
    public GameObject       paddleRight;
    public float            speed = 100f;
    private int           paddleNumber = 0;
    private Rigidbody2D     rbM;
    private Rigidbody2D     rbL;
    private Rigidbody2D     rbR;
    private Vector2         direction;


    /*public bool suri;

    private bool isPressingKey;

    private bool IsPressingKey
    {
        get { return isPressingKey; }
        set
        {
            if (value == isPressingKey)
                return;

            isPressingKey = value;
            if (isPressingKey)
                suri = !suri;
        }
    }

    void Update()
    {
        IsPressingKey = Input.GetKey(KeyCode.A);
    }*/

    private void Start()
    {
        rbM = paddleMain.GetComponent<Rigidbody2D>();
        rbL = paddleLeft.GetComponent<Rigidbody2D>();
        rbR = paddleRight.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Keeping this code just in case we want to revert to old controls
        /*if (Input.GetKey(KeyCode.Space))
            paddleNumber++;

        if (paddleNumber > 1)
            paddleNumber = 0;
        */

        // Horizontal paddle
        if (Input.GetKey(KeyCode.A))
            rbM.velocity = Vector2.left * 10;
        else if (Input.GetKey(KeyCode.D))
            rbM.velocity = Vector2.right * 10; 
        else
            rbM.velocity = Vector2.zero;

        /*if (paddleNumber == 0)
        {
            if (Input.GetKey(KeyCode.W))
                rbL.velocity = Vector2.up * 10;
            else if (Input.GetKey(KeyCode.S))
                rbL.velocity = Vector2.down * 10;
            else
                rbL.velocity = Vector2.zero;
        }
        else if (paddleNumber == 1)
        {
            if (Input.GetKey(KeyCode.W))
                rbR.velocity = Vector2.up * 10;
            else if (Input.GetKey(KeyCode.S))
                rbR.velocity = Vector2.down * 10;
            else
                rbR.velocity = Vector2.zero;
        }*/

        // Vertical paddles (they move together)
        if (Input.GetKey(KeyCode.W))
        {
            rbL.velocity = Vector2.up * 10;
            rbR.velocity = Vector2.up * 10;
        }
        
        else if (Input.GetKey(KeyCode.S))
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

        if (paddleNumber == 0)
        {
            if (direction == Vector2.zero)
                return;
            rbL.AddForce(direction * speed * 900000);
        }
        else if (paddleNumber == 1)
        {
            if (direction == Vector2.zero)
                return;
            rbR.AddForce(direction * speed * 900000);
        }
    }

    public void ResetPaddle()
    {
        rbL.velocity = Vector2.zero;
        rbM.velocity = Vector2.zero;
        rbR.velocity = Vector2.zero;
    }
}
