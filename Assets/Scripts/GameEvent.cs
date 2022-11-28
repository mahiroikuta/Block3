using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public Action<Ball, Block> ballHitBlock;
    public Action<Ball> ballHitFloor;
    public Action<Ball, RaycastHit> ballReflection;
}
