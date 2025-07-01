
using UnityEngine;

//
// Pong [Atari 1972] v2019.02.24
//
// v2023.12.27
//

public class Player2Controller : MonoBehaviour
{
    public static Player2Controller player2;

    public Transform paddleTransform;

    public Rigidbody2D paddleRigidbody;

    // speed of paddle
    private float paddleSpeed;

    //[HideInInspector] public float paddleDirection;

    private Vector2 paddleDirection;

    // player 2 start position
    private float paddlePositionX;

    private float paddlePositionY;

    private float paddlePositionOffset;

    private Vector2 paddleStartPosition;
    //private float player2SpritePositionX;
    //private float player2SpritePositionY;

    // ai check
    public bool player2IsComputer;

    // player check
    private bool isPlayer2;


    private void Awake()
    {
        //paddleRigidbody = GetComponent<Rigidbody2D>();

        player2 = this;
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
        //player2SpriteDirection = GameController.STOPPED;

        // reset player 2 start position
        paddlePositionX = 9.3f;

        paddlePositionY = 0f;

        paddlePositionOffset = 0.5f;

        paddleStartPosition = new Vector2(paddlePositionX, paddlePositionY);

        paddleTransform.position = paddleStartPosition;

        // speed of paddle
        if (player2IsComputer)
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
        //paddleDirection = GameController.STOPPED;

        if (Input.GetKey(KeyCode.P))
        {
            //paddleDirection = GameController.UP;

            MoveUp();
        }


        else if (Input.GetKey(KeyCode.L))
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


    private void ComputerController()
    {
        // get the horizontal distance of the ball from the paddle
        //float ballDistanceFromPaddle = Mathf.Abs(BallController.ballController.ballTransform.position.x - paddleTransform.position.x);

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


    /*private void MoveUp()
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
    }*/


    private void MoveUp()
    {
        paddleDirection = new Vector2(paddlePositionX, GameController.UP);
    }


    private void MoveDown()
    {
        paddleDirection = new Vector2(paddlePositionX, GameController.DOWN);
    }


} // end of class
