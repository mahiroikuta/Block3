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

    public bool gameClear()
    {
        return _gameState.blocks.Count == 0;
    }

    public bool gameOver()
    {
        foreach ( Block block in _gameState.blocks )
        {
            if ( block.transform.position.y < -6f ) return true;
        }
        return false;
    }
}
