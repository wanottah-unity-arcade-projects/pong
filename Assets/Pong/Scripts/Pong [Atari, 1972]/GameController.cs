
using System.Collections;
using UnityEngine;
using TMPro;

//
// Pong [Atari, 1972] v2019.02.24
//
// v2025.10.08
//

public class GameController : MonoBehaviour
{
    public static GameController gameController;


    public Transform leftWall;
    public Transform rightWall;

    public Transform player1Goal;
    public Transform player2Goal;

    public TMP_Text winner;

    public const float CENTRE_COURT = 0f;

    // direction of paddle
    public const int STOPPED = 0;
    public const int UP = 1;
    public const int DOWN = -1;

    // player scores
    public int player1Score;
    public int player2Score;

    private const int PLAYER_ONE = 1;

    private const int PLAYER_TWO = 2;

    private const int START_SCORE = 0;

    private const int ATTRACT_MODE_SCORE = 1;

    private const int WINNING_SCORE = 11;

    private const float MENU_DISPLAY_DELAY = 2f;

    public bool inAttractMode;

    private bool inStartupMode;
    
    private bool gameOver;

    private bool twoPlayer;



    private void Awake()
    {
        gameController = this;
    }


    private void Start()
    {
        inStartupMode = true;

        Startup();
    }

 
    private void Update()
    {
        KeyboardController();
    }


    private void Startup()
    {
        gameOver = true;       

        inAttractMode = true;

        SetAttractMode(inAttractMode);

        StartAttractMode();

        MenuController.menuController.ActivateMainMenu();
    }


    private void SetAttractMode(bool gameObjectIsActive)
    {
        // deactivate the player paddles
        Player1Controller.player1.paddleTransform.gameObject.SetActive(!gameObjectIsActive);
        Player2Controller.player2.paddleTransform.gameObject.SetActive(!gameObjectIsActive);

        // deactivate the player goals
        player1Goal.gameObject.SetActive(!gameObjectIsActive);
        player2Goal.gameObject.SetActive(!gameObjectIsActive);

        // activate the left and right game arena walls
        leftWall.gameObject.SetActive(gameObjectIsActive);
        rightWall.gameObject.SetActive(gameObjectIsActive);
    }


    public void StartAttractMode()
    {
        if (inStartupMode)
        {
            player1Score = ATTRACT_MODE_SCORE;

            player2Score = ATTRACT_MODE_SCORE;

            ResetPlayerScores();
        }

        // call ball controller script
        BallController.ballController.Initialise();
    }


    private void KeyboardController()
    {
        if (!inAttractMode)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                inStartupMode = true;

                Startup();
            }
        }
    }


    public void StartOnePlayer()
    {
        BallController.ballController.ballTransform.gameObject.SetActive(false);

        Player1Controller.player1.player1IsComputer = false;

        Player2Controller.player2.player2IsComputer = true;

        twoPlayer = false;

        Initialise();
    }


    public void StartTwoPlayer()
    {
        BallController.ballController.ballTransform.gameObject.SetActive(false);

        Player1Controller.player1.player1IsComputer = false;

        Player2Controller.player2.player2IsComputer = false;

        twoPlayer = true;

        Initialise();
    }


    private void Initialise()
    {
        MenuController.menuController.DeactivateMainMenu();

        inAttractMode = false;

        inStartupMode = false;

        player1Score = START_SCORE;

        player2Score = START_SCORE;

        ScoreController.scoreController.InitialisePlayerScores();

        SetAttractMode(inAttractMode);

        Player1Controller.player1.Initialise();

        if (twoPlayer || Player2Controller.player2.player2IsComputer)
        {
            Player2Controller.player2.Initialise();
        }

        ReadyPlayerOne();
    }


    private void ReadyPlayerOne()
    {
        gameOver = false;

        winner.gameObject.SetActive(false);

        BallController.ballController.ResetBall(BallController.ballController.ballSpeed, BallController.ballController.ballSpeed);
    }


    // update score
    public void UpdateScore(int playerScored)
    {
        if (!inAttractMode)
        {
            switch (playerScored)
            {
                case PLAYER_ONE:

                    UpdatePlayer1Score();

                    break;

                case PLAYER_TWO:

                    UpdatePlayer2Score();

                    break;
            }

            IsGameOver();
        }
    }


    // check if game over
    public void IsGameOver()
    {
        if (player1Score == WINNING_SCORE || player2Score == WINNING_SCORE)
        {
            if (player1Score == WINNING_SCORE)
            {
                winner.text = "Player 1 Wins";
            }

            else if (player2Score == WINNING_SCORE)
            {
                winner.text = "Player 2 Wins";
            }

            StartCoroutine(GameOver());
        }

        BallController.ballController.ResetBall(BallController.ballController.ballSpeed, BallController.ballController.ballSpeed);
    }


    // when the game is over
    private IEnumerator GameOver()
    {
        gameOver = true;

        inAttractMode = true;

        yield return new WaitForSeconds(MENU_DISPLAY_DELAY);

        winner.gameObject.SetActive(true);

        Startup();
    }


    private void UpdatePlayer1Score()
    {
        player1Score += 1;

        ScoreController.scoreController.UpdateScoreDisplay(player1Score, PLAYER_ONE);
    }


    private void UpdatePlayer2Score()
    {
        player2Score += 1;

        ScoreController.scoreController.UpdateScoreDisplay(player2Score, PLAYER_TWO);
    }


    public void ResetPlayerScores()
    {
        ScoreController.scoreController.UpdateScoreDisplay(player1Score, PLAYER_ONE);

        ScoreController.scoreController.UpdateScoreDisplay(player2Score, PLAYER_TWO);
    }


} // end of class
