using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameMManager : MonoBehaviour
{
    public static GameMManager Instance {  get; private set; }

    [SerializeField]
    private GameState startingState;

    public GameState GameState { get; private set; }

    public LevelManager leveManager;

    public PlayerInputManager playerManager; 

    public UIManager uiManager;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        //Set up game state
        GameState = Instantiate(startingState);
        levelManager.GameState = GameState;
        playerManager.GameState = GameState;
    }
}
