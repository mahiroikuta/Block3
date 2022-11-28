using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoveManager : MonoBehaviour
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

    public void blockMove()
    {
        foreach( Block block in _gameState.blocks )
        {
            Vector3 tmp = block.transform.position;
            block.transform.position = new Vector3(tmp.x, tmp.y-3f, tmp.z);
        }
    }
}
