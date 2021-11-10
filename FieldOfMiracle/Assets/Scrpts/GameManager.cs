using UnityEngine;
using System.IO;
using Assets.Scrpts;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private const string text_path = "word_rus";

    private string[] allWords;

    public string[] AllWords => AllWords;

    private GameState gameState;

    private UiController uiController;

    private IGameController gameController;

    public GameState GameState
    {
        get
        {
            return GameState;
        }
        set
        {
            if (GameState == value) return;

            gameState = value;

            switch (gameState)
            {
                case GameState.Menu:
                    OnMenuState();
                    break;
                case GameState.Game:
                    OnGameState();
                    break;
                case GameState.Win:
                    OnWinState();
                    break;
                case GameState.Fail:
                    OnFailState();
                    break;
                default:
                    Debug.LogError("WrongState");
                    break;
            }
        }
    }



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(gameObject);
            return;
        }
        var file = Resources.Load<TextAsset>(text_path);
        var text = file.text;
        allWords = text.Split('\n');
        uiController = FindObjectOfType<UiController>();
    }
    public void OnFailState()
    {
        uiController.OnFailState();
    }

    public void OnWinState()
    {
        uiController.OnWinState();
    }

    public void OnGameState()
    {
        gameController = new GameController();
        gameController.Init(allWords[Random.Range(0, allWords.Length)]); 
        uiController.OnGameState();
    }

    public void OnMenuState()
    {
        uiController.OnMenuState();
    }

    public void ChangeGameState(GameState state)
    {
        GameState = state;
    }
}