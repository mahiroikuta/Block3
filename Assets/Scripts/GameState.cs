using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameState
{
    public Ball ball;
    public Block block;
    public BallShooter ballShooter;
    
    public float speed;
    public int maxBalls;
    public int blockLife;

    public Vector3 ballBornPoint;

    [System.NonSerialized]
    public List<Ball> balls = new List<Ball>();

    [System.NonSerialized]
    public List<Block> blocks = new List<Block>();
}
