using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;

        _gameEvent.ballHitBlock += ballHitBlock;

        _gameEvent.ballHitFloor += ballHitFloor;

        _gameEvent.ballReflection += ballReflection;
    }

    public void ballHitBlock(Ball ball, Block block)
    {
        block.life = block.life - 1;
        if ( block.life == 0 )
        {
            _gameState.blocks.Remove(block);
            Destroy(block.gameObject);
        }
    }  

    public void ballHitFloor(Ball ball)
    {
        if ( _gameState.isFirst )
        {
            Vector3 pos = ball.transform.position;
            _gameState.ballBornPoint = pos;
            _gameState.isFirst = false;
        }
        _gameState.balls.Remove(ball);
        Destroy(ball.gameObject);
    }

    public void ballReflection(Ball ball, RaycastHit hit)
    {
        Rigidbody rig = ball.gameObject.GetComponent<Rigidbody>();
        rig.velocity = Vector3.Reflect(rig.velocity, hit.normal);
    }

}
