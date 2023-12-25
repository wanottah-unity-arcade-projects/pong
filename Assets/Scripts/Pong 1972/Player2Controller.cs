
using UnityEngine;

//
// Pong [Atari 1972] v2019.02.24
//
// v2023.04.05
//

public class Player2Controller : MonoBehaviour
{
    public static Player2Controller player2;

    public Transform paddleTransform;

    // speed of paddle
    [HideInInspector] public float paddleSpeed;
    [HideInInspector] public float paddleDirection;

    // player 2 start position
    private float paddlePositionX;
    private float paddlePositionY;

    private Vector2 paddleStartPosition;
    //private float player2SpritePositionX;
    //private float player2SpritePositionY;

    // ai check
    [HideInInspector] public bool player2IsComputer;

    // player check
    [HideInInspector] public bool isPlayer2;


    private void Awake()
    {
        player2 = this;
    }


    private void Update()
    {
        PaddleController();
    }


    public void Initialise()
    {
        // direction of paddle
        //player2SpriteDirection = GameController.STOPPED;

        // reset player 2 start position
        paddlePositionX = 7.8f;
        paddlePositionY = 0f;

        paddleStartPosition = new Vector2(paddlePositionX, paddlePositionY);

        paddleTransform.position = paddleStartPosition;

        // speed of paddle
        if (player2IsComputer)
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
        if (player2IsComputer)
        {
            ComputerController();
        }

        else // if (isPlayer2)
        {
            KeyboardController();
        }
    }


    // player 2
    private void KeyboardController()
    {
        paddleDirection = GameController.STOPPED;

        if (Input.GetKey(KeyCode.O))
        {
            paddleDirection = GameController.UP;

            MoveUp();
        }


        if (Input.GetKey(KeyCode.L))
        {
            paddleDirection = GameController.DOWN;

            MoveDown();
        }
    }


    private void ComputerController()
    {
        // get the horizontal distance of the ball from the paddle
        //float ballDistanceFromPaddle = Mathf.Abs(BallController.ballController.ballTransform.position.x - paddleTransform.position.x);

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
            if (player2IsComputer)
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
            if (player2IsComputer)
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
