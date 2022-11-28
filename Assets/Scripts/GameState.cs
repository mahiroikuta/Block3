using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStatus
{
    IsPlaying,
    GameClear,
    GameOver,
}

[System.Serializable]
public class GameState
{
    public Ball ball;
    public Block block;
    public BallShooter ballShooter;
    
    public float speed;
    public int maxBalls;
    public int blockLife;

    public GameStatus gameStatus;

    [System.NonSerialized]
    public bool isShooting;

    [System.NonSerialized]
    public bool isFirst;

    [System.NonSerialized]
    public bool hitting;

    [System.NonSerialized]
    public bool gameClear;

    [System.NonSerialized]
    public bool gameOver;

    [System.NonSerialized]
    public Vector3 ballBornPoint;

    [System.NonSerialized]
    public List<Ball> balls = new List<Ball>();

    [System.NonSerialized]
    public List<Block> blocks = new List<Block>();
}
