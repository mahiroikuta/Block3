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
        ballHit();
        return _gameState;
    }

    public void ballHit()
    {
        if ( _gameState.balls.Count == 0 ) return;
        int count = _gameState.balls.Count;
        for ( int i=count-1 ; i>=0 ; i-- )
        {
            count = _gameState.balls.Count;
            Ball ball = _gameState.balls[i];
            RaycastHit hit;
            Rigidbody rig = ball.rig;
            if ( Physics.SphereCast(ball.transform.position, 1.0f, rig.velocity, out hit, 0.3f, LayerMask.GetMask("Default")) )
            {
                // Blockと衝突
                ballHitBlock(ball, hit);

                // Floorと衝突
                ballHitFloor(ball, hit);

                // Wallと衝突
                ballHitWall(ball, hit);
            }
            else
            {
                if ( _gameState.hitting )  _gameState.hitting = false;
            }
            Debug.DrawRay(ball.transform.position, rig.velocity, Color.red);
        }
    }

    void ballHitBlock(Ball ball, RaycastHit hit)
    {
        Block block;
        block = hit.collider.gameObject.GetComponent<Block>();
        if ( !_gameState.hitting && block != null )
        {
            _gameState.hitting = true;
            _gameEvent.ballHitBlock?.Invoke(ball, block);
            _gameEvent.ballReflection?.Invoke(ball, hit);
        }
    }

    void ballHitFloor(Ball ball, RaycastHit hit)
    {
        Floor floor;
        floor = hit.collider.gameObject.GetComponent<Floor>();
        if ( floor != null ) _gameEvent.ballHitFloor?.Invoke(ball);
    }

    void ballHitWall(Ball ball, RaycastHit hit)
    {
        Wall wall;
        wall = hit.collider.gameObject.GetComponent<Wall>();
        if ( wall != null )
        {
            _gameEvent.ballReflection?.Invoke(ball, hit);
        }
    }
}
