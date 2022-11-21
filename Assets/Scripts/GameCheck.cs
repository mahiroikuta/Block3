using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCheck : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
    }

    public GameState onUpdate()
    {
        return _gameState;
    }

    public void gameClear()
    {
        if ( _gameState.blocks.Count == 0 ) 
        {
            _gameState.gameStatus = GameStatus.GameClear;
            Debug.Log("GAME CLEAR!!");
        }
    }

    public void gameOver()
    {
        foreach ( Block block in _gameState.blocks )
        {
            if ( block.transform.position.y < -6f ) 
            {
                _gameState.gameStatus = GameStatus.GameOver;
                Debug.Log("GAME OVER...");
                return;
            }
        }
    }
}
