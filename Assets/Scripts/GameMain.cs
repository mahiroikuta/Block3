using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField]
    public GameState _gameState;
    public GameEvent _gameEvent;

    public BlockGeneManager blockGeneManager;
    public BallShooterManager ballShooterManager;
    public BallHitManager ballHitManager;
    public BlockMoveManager blockMoveManager;
    public GameRule gameRule;
    public GameCheck gameCheck;


    void Awake()
    {
        blockGeneManager.setUp(_gameState, _gameEvent);
        ballShooterManager.setUp(_gameState, _gameEvent);
        ballHitManager.setUp(_gameState, _gameEvent);
        blockMoveManager.setUp(_gameState, _gameEvent);

        gameCheck.setUp(_gameState, _gameEvent);
        gameRule.setUp(_gameState, _gameEvent);
        
        _gameState.isShooting = false;
        _gameState.isFirst = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        blockGeneManager.initializeBlock();
    }

    // Update is called once per frame
    void Update()
    {
        if ( _gameState.gameClear || _gameState.gameOver ) return;
        if ( !_gameState.isShooting && Input.GetMouseButtonDown(0) )
        {
            _gameState.isShooting = true;
            ballShooterManager.shoot();
            foreach ( Ball ball in _gameState.balls )
            {
                _gameState.tmpBalls.Add(ball);
            }
        }
        if ( _gameState.balls.Count == 0 && !_gameState.isFirst && !_gameState.isShooting )
        {
            _gameState.isFirst = true;
            if ( _gameState.gameClear = gameCheck.gameClear() ) Debug.Log("GAME CLEAR!!");
            if ( _gameState.gameOver = gameCheck.gameOver() ) Debug.Log("GAME OVER...");

            blockMoveManager.blockMove();
            blockGeneManager.addBlock();
            ballShooterManager.rePosition();
        }
        foreach ( Ball ball in _gameState.tmpBalls )
        {
            ballHitManager.ballHit(ball);
        }
        
    }
}
