
using UnityEngine;

//
// Pong [Atari, 1972] v2019.02.24
//
// v2025.09.26
//


public class Player1Controller : MonoBehaviour
{
    public static Player1Controller player1;


    public Transform paddleTransform;

    public Rigidbody2D paddleRigidbody;

    // speed of paddle
    private float paddleSpeed;

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
        // reset player 1 start position
        paddlePositionX = -13.5f;

        paddlePositionY = 0f;

        paddlePositionOffset = 0.5f;

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
        //if (GameController.gameController.canPlay || GameController.gameController.inAttractMode)
        if (!GameController.gameController.inAttractMode)
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
        if (Input.GetKey(KeyCode.Q))
        {
            MoveUp();
        }


        else if (Input.GetKey(KeyCode.A))
        {
            MoveDown();
        }

        else
        {
            paddleDirection = new Vector2(paddlePositionX, GameController.STOPPED);
        }
    }


    private void ComputerController()
    {
        if (BallController.ballController.ballTransform.position.y > paddleTransform.position.y + paddlePositionOffset)
        {
            MoveUp();
        }

        else if (BallController.ballController.ballTransform.position.y < paddleTransform.position.y - paddlePositionOffset)
        {
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
