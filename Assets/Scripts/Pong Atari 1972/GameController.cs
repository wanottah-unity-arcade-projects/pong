
//using System.IO;
using System.Collections;
using UnityEngine;

//
// Pong [Atari 1972] v2019.02.24
//
// v2023.12.26
//

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    public Transform leftWall;
    public Transform rightWall;

    public Transform player1Goal;
    public Transform player2Goal;

    // game arena boundaries
    //public const float UPPER_BOUNDARY = 6.875f;
    //public const float LOWER_BOUNDARY = -6.875f;
    
    public const float CENTRE_COURT = 0f;


    //private const float START_DELAY = 0.25f;
    private const float RESTART_DELAY = 5f;

    // direction of paddle
    public const int STOPPED = 0;
    public const int UP = 1;
    public const int DOWN = -1;

    // direction of ball
    //public const int RIGHT = 1;
    //public const int LEFT = -1;

    // player scores
    public int player1Score;
    public int player2Score;

    //private int highScore;

    // player difficulty settings
    //private float leftDifficultyPlayerWidth_A;
    //private float leftDifficultyPlayerHeight_A;

    //private float leftDifficultyPlayerWidth_B;
    //private float leftDifficultyPlayerHeight_B;

    //private float rightDifficultyPlayerWidth_A;
    //private float rightDifficultyPlayerHeight_A;

    //private float rightDifficultyPlayerWidth_B;
    //private float rightDifficultyPlayerHeight_B;

    // paddle sizes
    //private const float DIFFICULTY_A_WIDTH = 0.4f;
    //private const float DIFFICULTY_A_HEIGHT = 0.6f;
    //private const float DIFFICULTY_B_WIDTH = 0.4f;
    //private const float DIFFICULTY_B_HEIGHT = 0.4f;

    public const int PLAYER_ONE = 1;

    public const int PLAYER_TWO = 2;

    public const int START_SCORE = 0;

    private const int WINNING_SCORE = 11;
    //private const int GAMEOVER_SCORE = 0;


    //[HideInInspector] public int gameNumberSelected;

    //[HideInInspector] public int numberOfPlayers;


    //[Header("Game State Flags")]
    // system state
    //public bool inStartupMode;
    //public bool inGameMode;
    public bool inAttractMode;
    //public bool inPawzMode;

    [HideInInspector] public bool canPlay;
    
    [HideInInspector] public bool gameOver;

    [HideInInspector] public bool twoPlayer;



    private void Awake()
    {
        gameController = this;
    }


    private void Start()
    {
        Startup();
    }

 
    private void Update()
    {
        KeyboardController();
    }



    private void Startup()
    {
        canPlay = false;

        gameOver = true;

        inAttractMode = true;

        SetAttractModeState(inAttractMode);

        ResetPlayerScore();

        //ScoreController.scoreController.InitialiseHighScore();

        StartAttractMode();
    }


    private void SetAttractModeState(bool gameObjectIsActive)
    {
        Player1Controller.player1.paddleTransform.gameObject.SetActive(!gameObjectIsActive);
        Player2Controller.player2.paddleTransform.gameObject.SetActive(!gameObjectIsActive);

        player1Goal.gameObject.SetActive(!gameObjectIsActive);
        player2Goal.gameObject.SetActive(!gameObjectIsActive);

        leftWall.gameObject.SetActive(gameObjectIsActive);
        rightWall.gameObject.SetActive(gameObjectIsActive);
    }


    private void ResetPlayerScore()
    {
        player1Score = START_SCORE;

        player2Score = START_SCORE;

        ScoreController.scoreController.InitialiseScores();
    }


    public void StartAttractMode()
    {
        //gameOverText.gameObject.SetActive(true);

        //inAttractMode = true;
        //inPlayMode = false;

        //AtariConsoleController.atariConsoleController.SetPawzModeSwitches();

        // show atari console
        //SetAtariConsoleMode(AtariConsoleController.CONSOLE_VISIBLE);

        // check if there are any credits
        //if (gameCredits == INSERT_COINS)
        //{
            //insertCoinsText.gameObject.SetActive(true);
        //}

        //AtariConsoleController.atariConsoleController.SetGameSelection();

        //SetGameArenaBoundaries();

        //Player1Controller.player1.player1IsComputer = true;

        //Player2Controller.player2.player2IsComputer = true;

        //player2Controller.isPlayer2 = false;

        // initialise paddles
        //Player1Controller.player1.Initialise();

        //Player2Controller.player2.Initialise();

        // enable ball
        //BallController.ballController.gameObject.SetActive(true);

        // call ball controller script
        BallController.ballController.Initialise();
    }


    private void KeyboardController()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartOnePlayer();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                StartTwoPlayer();
            }
        }
    }


    private void StartOnePlayer()
    {
        BallController.ballController.ballTransform.gameObject.SetActive(false);

        Player1Controller.player1.player1IsComputer = false;

        Player2Controller.player2.player2IsComputer = true;

        twoPlayer = false;

        Initialise();
    }


    private void StartTwoPlayer()
    {
        BallController.ballController.ballTransform.gameObject.SetActive(false);

        Player1Controller.player1.player1IsComputer = false;

        Player2Controller.player2.player2IsComputer = false;

        twoPlayer = true;

        Initialise();
    }


    private void Initialise()
    {
        inAttractMode = false;

        ResetPlayerScore();

        SetAttractModeState(inAttractMode);

        Player1Controller.player1.Initialise();

        if (twoPlayer || Player2Controller.player2.player2IsComputer)
        {
            Player2Controller.player2.Initialise();
        }

        ReadyPlayerOne();
    }


    private void ReadyPlayerOne()
    {
        //gameOverText.gameObject.SetActive(false);

        //yield return new WaitForSeconds(startDelay);

        gameOver = false;

        canPlay = true;

        BallController.ballController.ResetBall(BallController.ballController.ballSpeed, BallController.ballController.ballSpeed);
    }


    public void InitialiseDifficultySwitchSettings()
    {/*
        leftDifficultyPlayerWidth_A = DIFFICULTY_A_WIDTH;

        leftDifficultyPlayerHeight_A = DIFFICULTY_A_HEIGHT;

        leftDifficultyPlayerWidth_B = DIFFICULTY_B_WIDTH;

        leftDifficultyPlayerHeight_B = DIFFICULTY_B_HEIGHT;

        rightDifficultyPlayerWidth_A = DIFFICULTY_A_WIDTH;

        rightDifficultyPlayerHeight_A = DIFFICULTY_A_HEIGHT;

        rightDifficultyPlayerWidth_B = DIFFICULTY_B_WIDTH;

        rightDifficultyPlayerHeight_B = DIFFICULTY_B_HEIGHT;*/
    }


    private void InitialiseConsoleSystem()
    {
        //AtariConsoleController.atariConsoleController.initialisingConsoleSystem = true;

        //AtariConsoleController.atariConsoleController.InitialiseConsole(GAME_TITLE, TV_MODE);
    }


    public void SetLeftDifficultyA()
    {
        //player1Controller.gameObject.transform.localScale = new Vector3(leftDifficultyPlayerWidth_A, leftDifficultyPlayerHeight_A, 0);
    }


    public void SetLeftDifficultyB()
    {
        //player1Controller.gameObject.transform.localScale = new Vector3(leftDifficultyPlayerWidth_B, leftDifficultyPlayerHeight_B, 0);
    }


    public void SetRightDifficultyA()
    {
        //player2Controller.gameObject.transform.localScale = new Vector3(rightDifficultyPlayerWidth_A, rightDifficultyPlayerHeight_A, 0);
    }


    public void SetRightDifficultyB()
    {
        //player2Controller.gameObject.transform.localScale = new Vector3(rightDifficultyPlayerWidth_B, rightDifficultyPlayerHeight_B, 0);
    }


    public void SetPawzMode()
    {
        //SetGamePadControllers();

        BallController.ballController.FreezeBall();

        //SetAtariConsoleMode(AtariConsoleController.CONSOLE_VISIBLE);
    }


    public void SetPlayMode()
    {
        //SetAtariConsoleMode(AtariConsoleController.CONSOLE_HIDDEN);

        //SetGamePadControllers();

        BallController.ballController.ResumeBall();
    }


    public void StartOnePlayerGame()
    {
        //player1Controller.player1IsComputer = false;

        //player2Controller.player2IsComputer = true;

        //player2Controller.isPlayer2 = false;

        InitialiseGameMode();
    }


    public void StartTwoPlayerGame()
    {
        //player1Controller.player1IsComputer = false;

        //player2Controller.player2IsComputer = false;

        //player2Controller.isPlayer2 = true;

        InitialiseGameMode();
    }


    // initialise
    private void InitialiseGameMode()
    {
        //gameCredits -= 1;

        //if (gameCredits == INSERT_COINS)
        //{
            //canPlay = false;

            //AtariConsoleController.atariConsoleController.gameNumberSelected = AtariConsoleController.NO_GAME_SELECTED;

            //AtariConsoleController.atariConsoleController.SetGameSelection();
        //}

        //pressStartText.gameObject.SetActive(false);

        //inPlayMode = true;
        //inDemoMode = false;

        //AtariConsoleController.atariConsoleController.SetPawzModeSwitches();

        // hide atari console
        //SetAtariConsoleMode(AtariConsoleController.CONSOLE_HIDDEN);

        InitialiseScore();

        // initialise paddles
        //player1Controller.InitialiseSprite();

        //player2Controller.InitialiseSprite();

        // reset and enable ball
        BallController.ballController.ResetBall(BallController.ballController.ballSpeed, BallController.ballController.ballSpeed);
    }


    private void InitialiseScore()
    {
        player1Score = START_SCORE;

        player2Score = START_SCORE;

        //UpdateScoreText();
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

            IsGameOver(playerScored);
        }
    }


    // check if game over
    public void IsGameOver(int playerScored)
    {
        // check to see which player has won
        /*if (player1Score == WINNING_SCORE)
        {
            GameOver();
        }

        else if (player2Score == WINNING_SCORE)
        {
            GameOver();
        }*/

        if (player1Score == WINNING_SCORE || player2Score == WINNING_SCORE)
        {
            GameOver();
        }


        // otherwise,
        // reset ball and set colour for player scored
        switch (playerScored)
        {
            case PLAYER_ONE:

                //SetBallColour(AtariConsoleController.atariConsoleController.tvMode, PLAYER_ONE);

                break;

            case PLAYER_TWO:

                //SetBallColour(AtariConsoleController.atariConsoleController.tvMode, PLAYER_TWO);

                break;
        }

        BallController.ballController.ResetBall(BallController.ballController.ballSpeed, BallController.ballController.ballSpeed);
    }


    // when the game is over
    private void GameOver()
    {
        gameOver = true;

        inAttractMode = true;

        SetAttractModeState(inAttractMode);

        StartAttractMode();
    }


    private void UpdatePlayer1Score()
    {
        player1Score += 1;

        ScoreController.scoreController.UpdateScoreDisplay(player1Score, ScoreController.PLAYER_1);
    }


    private void UpdatePlayer2Score()
    {
        player2Score += 1;

        ScoreController.scoreController.UpdateScoreDisplay(player2Score, ScoreController.PLAYER_2);
    }


} // end of class
