using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooterManager : MonoBehaviour
{
    GameState _gameState;
    GameEvent _gameEvent;

    public void setUp(GameState gameState, GameEvent gameEvent)
    {
        _gameState = gameState;
        _gameEvent = gameEvent;
        _gameState.ballBornPoint = new Vector3(0f, -15f, 0f);
        _gameState.ballShooter = BallShooter.Instantiate(_gameState.ballShooter, _gameState.ballShooter.transform.position, Quaternion.identity) as BallShooter;
    }

    public GameState onUpdate()
    {
        return _gameState;
    }

    public void rePosition()
    {
        Vector3 rePos = _gameState.ballBornPoint;
        Vector3 tmp = _gameState.ballShooter.transform.position;
        _gameState.ballShooter.transform.position = rePos;
    }

    public void shoot()
    {
        ballGene();
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 40;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 shotForward = Vector3.Scale((mouseWorldPos - _gameState.ballShooter.transform.position), new Vector3(1, 1, 0)).normalized;
        StartCoroutine("shooting", shotForward);
    }

    IEnumerator shooting(Vector3 vec)
    {
        foreach ( Ball ball in _gameState.balls )
        {
            Rigidbody rig = ball.GetComponent<Rigidbody>();
            rig.velocity = vec * _gameState.speed;
            yield return new WaitForSeconds(0.1f);
        }
        _gameState.isShooting = false;
    }

    void ballGene()
    {
        while ( _gameState.maxBalls > _gameState.balls.Count )
        {
            Ball ball = Ball.Instantiate(_gameState.ball, _gameState.ballShooter.transform.position, Quaternion.identity) as Ball;
            _gameState.balls.Add(ball);
        }
    }
}
