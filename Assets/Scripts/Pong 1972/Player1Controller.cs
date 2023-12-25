
using UnityEngine;

//
// Pong [Atari 1972] v2019.02.24
//
// v2023.02.11
//


public class Player1Controller : MonoBehaviour
{
    public static Player1Controller player1;

    public Transform paddleTransform;

    // speed of paddle
    [HideInInspector] public float paddleSpeed;
    [HideInInspector] public float paddleDirection;

    // player start position
    private float paddlePositionX;
    private float paddlePositionY;

    private Vector2 paddleStartPosition;

    // ai check
    [HideInInspector] public bool player1IsComputer;


    private void Awake()
    {
        player1 = this;
    }


    private void Update()
    {
        PaddleController();
    }


    public void Initialise()
    {
        // direction of paddle
        //paddleDirection = GameController.STOPPED;

        // reset player 1 start position
        paddlePositionX = -7.8f;
        paddlePositionY = 0f;

        paddleStartPosition = new Vector2(paddlePositionX, paddlePositionY);

        paddleTransform.position = paddleStartPosition;

        // speed of paddle
        if (player1IsComputer)
        {
            paddleSpeed = 5f;
        }

        else
        {
            paddleSpeed = 6f;
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
        paddleDirection = GameController.STOPPED;

        if (Input.GetKey(KeyCode.W))
        {
            paddleDirection = GameController.UP;

            MoveUp();
        }


        if (Input.GetKey(KeyCode.S))
        {
            paddleDirection = GameController.DOWN;

            MoveDown();
        }
    }


    private void ComputerController()
    {
        paddleDirection = GameController.STOPPED;

        if (paddleTransform.position.y < BallController.ballController.ballTransform.position.y)
        {
            paddleDirection = GameController.UP;

            MoveUp();
        }


        if (paddleTransform.position.y > BallController.ballController.ballTransform.position.y)
        {
            paddleDirection = GameController.DOWN;

            MoveDown();
        }
    }


    private void MoveUp()
    {
        if (paddleTransform.position.y < GameController.UPPER_BOUNDARY)
        {
            if (player1IsComputer)
            {
                paddleTransform.position = Vector3.MoveTowards(
                    
                    paddleTransform.position, 
                    new Vector3(paddleTransform.position.x, BallController.ballController.ballTransform.position.y, paddleTransform.position.z), 
                    paddleSpeed * Time.deltaTime);
            }

            else
            {
                paddleTransform.position = 
                    new Vector3(paddleTransform.position.x, paddleTransform.position.y + paddleSpeed * Time.deltaTime, paddleTransform.position.z);
            }
        }
    }


    private void MoveDown()
    {
        if (paddleTransform.position.y > GameController.LOWER_BOUNDARY)
        {
            if (player1IsComputer)
            {
                paddleTransform.position = Vector3.MoveTowards(
                    
                    paddleTransform.position, 
                    new Vector3(paddleTransform.position.x, BallController.ballController.ballTransform.position.y, paddleTransform.position.z), 
                    paddleSpeed * Time.deltaTime);
            }

            else
            {
                paddleTransform.position = 
                    new Vector3(paddleTransform.position.x, paddleTransform.position.y - paddleSpeed * Time.deltaTime, paddleTransform.position.z);
            }
        }
    }


} // end of class
