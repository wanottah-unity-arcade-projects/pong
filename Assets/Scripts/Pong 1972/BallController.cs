
using UnityEngine;

//
// Pong [Atari 1972] v2019.02.24
//
// v2021.11.06
//

public class BallController : MonoBehaviour
{
    public static BallController ballController;

    public Transform ballTransform;

    [HideInInspector] public Rigidbody2D ballRigidbody;

    // speed of ball
    [HideInInspector] public float ballSpeed;

    // direction of ball
    private float xBallVelocity;
    private float yBallVelocity;

    // ball bounce speed
    [HideInInspector] public float ballBounceSpeed;

    // ball speed increase
    [HideInInspector] public float ballSpeedIncrease;

    // maximum ball speed
    [HideInInspector] public float maxBallSpeed;



    private void Awake()
    {
        ballController = this;
    }


    public void Initialise()
    {
        // set reference to ball's rigidbody component
        ballRigidbody = ballTransform.GetComponent<Rigidbody2D>();

        // ball speed
        ballSpeed = 5f;

        // ball bounce speed
        ballBounceSpeed = 2f;

        // ball speed increase
        ballSpeedIncrease = 1.1f;

        // maximum ball speed
        maxBallSpeed = 12f;

        ballTransform.gameObject.SetActive(true);

        // randomise player serve
        ballRigidbody.velocity = new Vector2(RandomServe(ballSpeed), RandomDirection(ballSpeed));
    }


    // reset ball
    public void ResetBall(float xVelocity, float yVelocity)
    {
        // reset ball position
        ballTransform.position = new Vector3(0, 0, 0);

        ballTransform.gameObject.SetActive(true);

        ballRigidbody.velocity = new Vector2(RandomServe(xVelocity), RandomDirection(yVelocity));
    }


    public void FreezeBall()
    {
        xBallVelocity = ballRigidbody.velocity.x;

        yBallVelocity = ballRigidbody.velocity.y;

        ballRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
    }


    public void ResumeBall()
    {
        ballRigidbody.constraints = RigidbodyConstraints2D.None;

        ballRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        ballRigidbody.velocity = new Vector2(xBallVelocity, yBallVelocity);
    }


    private float RandomServe(float ballSpeed)
    {
        float playerServe;

        // if we are in attract mode or have just started a new game
        //if (gameController.inDemoMode || (gameController.player1Score == 0 && gameController.player2Score == 0))
        if ((GameController.gameController.player1Score == 0 && GameController.gameController.player2Score == 0))
        {
            // randomise player serve
            if (Random.Range(1, 100) > 40)
            {
                // player 1
                playerServe = ballSpeed;

                //gameController.SetBallColour(AtariConsoleController.atariConsoleController.tvMode, GameController.PLAYER_ONE);
            }

            else
            {
                // player 2
                playerServe = -ballSpeed;

                //gameController.SetBallColour(AtariConsoleController.atariConsoleController.tvMode, GameController.PLAYER_TWO);
            }

            // and return the player to serve
            return playerServe;
        }

        // otherwise . . .
        else
        {
            // just return the current ball direction
            return ballSpeed;
        }
    }


    private float RandomDirection(float yVelocity)
    {
        float ballDirection;

        if (Random.Range(1, 100) > 20)
        {
            ballDirection = -yVelocity;
        }

        else
        {
            ballDirection = yVelocity;
        }

        return ballDirection;
    }


} // end of class
