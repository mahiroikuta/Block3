using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooterManager : MonoBehaviour
{
    GameState _gameState;

    public void setUp(GameState gameState)
    {
        _gameState = gameState;
    }

    public GameState onUpdate()
    {
        return _gameState;
    }

    public void rePosition()
    {
        Vector3 rePos = _gameState.ballBornPoint;
        // BallShooterを移動
        transform.position = rePos;
    }

    void ballGene()
    {
        while ( _gameState.maxBalls > _gameState.balls.Count )
        {
            Ball ball = Ball.Instantiate(_gameState.ball, transform.position, Quaternion.identity) as Ball;
            _gameState.balls.Add(ball);
        }
    }
}
