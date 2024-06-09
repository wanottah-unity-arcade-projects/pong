
using UnityEngine;

//
// Pong [Atari 1972] v2019.02.24
//
// v2023.12.27
//

public class CollisionController : MonoBehaviour
{
    // check if the ball has entered the goal
    private void OnTriggerEnter2D(Collider2D collidingObject)
    {
        if (!GameController.gameController.inAttractMode)
        {
            // disable the ball
            BallController.ballController.ballTransform.gameObject.SetActive(false);

            // play the 'goalScored' sound
            AudioController.audioController.PlayAudioClip("Goal Scored");
        }

        // player 1 goal
        if (collidingObject.CompareTag("Player 1 Goal"))
        {
            // update player 2 score
            GameController.gameController.UpdateScore(GameController.PLAYER_TWO);

            // reset ball position and speed
            BallController.ballController.ResetBall(-BallController.ballController.ballSpeed, -BallController.ballController.ballSpeed);
        }

        // player 2 Goal
        if (collidingObject.CompareTag("Player 2 Goal"))
        {
            // update player 1 score
            GameController.gameController.UpdateScore(GameController.PLAYER_ONE);

            // reset ball position and speed
            BallController.ballController.ResetBall(BallController.ballController.ballSpeed, BallController.ballController.ballSpeed);
        }
    }


    // when the ball bounces off the paddles
    void OnCollisionEnter2D(Collision2D collidingObject)
    {
        if (!GameController.gameController.inAttractMode)
        {
            if (collidingObject.gameObject.CompareTag("Player 1") || collidingObject.gameObject.CompareTag("Player 2"))
            {
                // play a sound
                AudioController.audioController.PlayAudioClip("Paddle Bounce");           

                BallController.ballController.PaddleBounce(collidingObject.transform);
            }
        }
    }


} // end of class
