
using UnityEngine;

//
// Pong [Atari 1972] v2019.02.24
//
// v2023.12.26
//


public class Player1Controller : MonoBehaviour
{
    public static Player1Controller player1;

    public Transform paddleTransform;

    public Rigidbody2D paddleRigidbody;

    // speed of paddle
    private float paddleSpeed;

    //[HideInInspector] public float paddleDirection;
    public float paddleLength;

    private Vector2 paddleDirection;

    // player start position
    private float paddlePositionX;

    private float paddlePositionY;

    private float paddlePositionOffset;

    private Vector2 paddleStartPosition;

    // ai check
    public bool player1IsComputer;


    private void Awake()
    {
        //paddleRigidbody = GetComponent<Rigidbody2D>();
        
        player1 = this;
    }


    private void Update()
    {
        PaddleController();
    }


    private void FixedUpdate()
    {
        paddleRigidbody.linearVelocity = paddleDirection * paddleSpeed;
    }


    public void Initialise()
    {
        // direction of paddle
        //paddleDirection = GameController.STOPPED;

        // reset player 1 start position
        paddlePositionX = -9.3f;

        paddlePositionY = 0f;

        paddlePositionOffset = 0.5f;

        // paddleTransform.GetComponent<Collider2D>().bounds.size.y * 2
        paddleLength = 3f;

        paddleStartPosition = new Vector2(paddlePositionX, paddlePositionY);

        paddleTransform.position = paddleStartPosition;

        // speed of paddle
        if (player1IsComputer)
        {
            paddleSpeed = 7f;
        }

        else
        {
            paddleSpeed = 10f;
        }
    }


    private void PaddleController()
    {
        if (GameController.gameController.canPlay || GameController.gameController.inAttractMode)
        {
            PlayerInput();
        }
    }


    private void PlayerInput()
    {
        if (player1IsComputer)
        {
            ComputerController();
        }

        else
        {
            KeyboardController();
        }
    }


    // player 1
    private void KeyboardController()
    {
        //paddleDirection = GameController.STOPPED;

        if (Input.GetKey(KeyCode.Q))
        {
            //paddleDirection = GameController.UP;

            MoveUp();
        }


        else if (Input.GetKey(KeyCode.A))
        {
            //paddleDirection = GameController.DOWN;

            MoveDown();
        }

        else
        {
            paddleDirection = new Vector2(paddlePositionX, GameController.STOPPED);
        }

        //paddleDirection = new Vector2(paddlePositionX, Input.GetAxisRaw("Vertical"));
    }


    //private void MoveUp()
    //{
        //paddleDirection = new Vector2(paddlePositionX, GameController.UP);
    //}


    //private void MoveDown()
    //{
        //paddleDirection = new Vector2(paddlePositionX, GameController.DOWN);
    //}


    private void ComputerController()
    {
        //paddleDirection = GameController.STOPPED;

        //if (paddleTransform.position.y + paddlePositionOffset < BallController.ballController.ballTransform.position.y)
        if (BallController.ballController.ballTransform.position.y > paddleTransform.position.y + paddlePositionOffset)
        {
            //paddleDirection = GameController.UP;

            MoveUp();
        }


        //if (paddleTransform.position.y + paddlePositionOffset > BallController.ballController.ballTransform.position.y)
        else if (BallController.ballController.ballTransform.position.y < paddleTransform.position.y - paddlePositionOffset)
        {
            //paddleDirection = GameController.DOWN;

            MoveDown();
        }

        else
        {
            paddleDirection = new Vector2(paddlePositionX, GameController.STOPPED);
        }
    }


    private void MoveUp()
    {
        paddleDirection = new Vector2(paddlePositionX, GameController.UP);
    }


    private void MoveDown()
    {
        paddleDirection = new Vector2(paddlePositionX, GameController.DOWN);
    }


} // end of class
