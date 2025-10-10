
using UnityEngine;

//
// Pong [Atari, 1972] v2019.02.24
//
// v2025.10.01
//

public class MenuController : MonoBehaviour
{
    public static MenuController menuController;


    public GameObject mainMenu;

    public GameObject instructions;

    public GameObject quitGameBackground;



    private void Awake()
    {
        menuController = this;
    }



    public void ActivateMainMenu()
    {
        instructions.SetActive(false);

        mainMenu.SetActive(true);

        MainMenuEvents.mainMenuEvents.InitialiseButtons();
    }


    public void DeactivateMainMenu()
    {
        mainMenu.SetActive(false);
    }


    public void StartOnePlayer()
    {
        DeactivateMainMenu();

        GameController.gameController.StartOnePlayer();
    }


    public void StartTwoPlayer()
    {
        DeactivateMainMenu();

        GameController.gameController.StartTwoPlayer();
    }


    public void ShowInstructions()
    {
        DeactivateMainMenu();

        instructions.SetActive(true);
    }


    public void Back()
    {
        ActivateMainMenu();      
    }


    public void QuitGame()
    {
        DeactivateMainMenu();

        quitGameBackground.SetActive(true);

        Application.Quit();
    }


} // end of class
