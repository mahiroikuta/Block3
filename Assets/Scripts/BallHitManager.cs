using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHitManager : MonoBehaviour
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

    public void ballHit(Ball ball)
    {
        if ( ball == null ) return;
        RaycastHit hit;
        Rigidbody rig = ball.rig;
        Block block;
        Floor floor;
        Wall wall;
        if ( Physics.SphereCast(ball.transform.position, 1.0f, rig.velocity, out hit, 0.3f, LayerMask.GetMask("Default")) )
        {
            // Blockと衝突
            block = hit.collider.gameObject.GetComponent<Block>();
            if ( !_gameState.hitting && block != null )
            {
                _gameState.hitting = true;
                _gameEvent.ballHitBlock?.Invoke(ball, block);
                _gameEvent.ballReflection?.Invoke(ball, hit);
            }

            // Floorと衝突
            floor = hit.collider.gameObject.GetComponent<Floor>();
            if ( floor != null )
            {
                _gameEvent.ballHitFloor?.Invoke(ball);
            }

            // Wallと衝突
            wall = hit.collider.gameObject.GetComponent<Wall>();
            if ( wall != null )
            {
                _gameEvent.ballReflection?.Invoke(ball, hit);
            }
        }
        else
        {
            if ( _gameState.hitting )
            {
                _gameState.hitting = false;
            }
        }
        Debug.DrawRay(ball.transform.position, rig.velocity, Color.red);
    }

}
