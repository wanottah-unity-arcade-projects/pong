
using UnityEngine;
using UnityEngine.UIElements;

//
// Pong [Atari 1972] v2019.02.24
//
// v2025.09.29
//

public class MainMenuEvents : MonoBehaviour
{
    public static MainMenuEvents mainMenuEvents;


    private UIDocument _document;

    private Button _PlayerVsPlayer;

    private Button _PlayerVsComputer;

    private Button _Instructions;

    private Button _Quit;



    private void Awake()
    {
        mainMenuEvents = this;

        _document = GetComponent<UIDocument>();
    }


    private void Start()
    {
        InitialiseButtons();
    }


    public void InitialiseButtons()
    {
        _PlayerVsPlayer = _document.rootVisualElement.Q("PlayerVsPlayer") as Button;

        _PlayerVsComputer = _document.rootVisualElement.Q("PlayerVsComputer") as Button;

        _Instructions = _document.rootVisualElement.Q("Instructions") as Button;

        _Quit = _document.rootVisualElement.Q("Quit") as Button;


        _PlayerVsPlayer.RegisterCallback<ClickEvent>(PlayerVsPlayer);

        _PlayerVsComputer.RegisterCallback<ClickEvent>(PlayerVsComputer);

        _Instructions.RegisterCallback<ClickEvent>(Instructions);

        _Quit.RegisterCallback<ClickEvent>(Quit);
    }


    private void OnDisable()
    {
        _PlayerVsPlayer.UnregisterCallback<ClickEvent>(PlayerVsPlayer);

        _PlayerVsComputer.UnregisterCallback<ClickEvent>(PlayerVsComputer);

        _Instructions.UnregisterCallback<ClickEvent>(Instructions);

        _Quit.UnregisterCallback<ClickEvent>(Quit);
    }


    private void PlayerVsPlayer(ClickEvent evt)
    {
        MenuController.menuController.StartTwoPlayer();
    }


    private void PlayerVsComputer(ClickEvent evt)
    {
        MenuController.menuController.StartOnePlayer();
    }


    private void Instructions(ClickEvent evt)
    {
        MenuController.menuController.ShowInstructions();
    }


    private void Quit(ClickEvent evt)
    {
        MenuController.menuController.QuitGame();
    }


} // end of class
