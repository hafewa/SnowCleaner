using System.Collections;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private static GameState _instance;

    public static GameState Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject _gamestateGO = new GameObject("_GameState");
                _gamestateGO.AddComponent<GameState>();

                return _instance;
            }
            else
            {
                return _instance;
            }
        }

    }


    private void Awake()
    {
        _instance = this;
    }


    public enum gameState
    {
        paused,
        playing
    }


    public gameState currentGameState { get; set; } = gameState.paused;
}
