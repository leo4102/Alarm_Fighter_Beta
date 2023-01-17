using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{
    public enum MonsterMove
    {
        Left,
        Right,
    }
    public enum PlayerMove
    {
        Up,
        Down,
        Left,
        Right,
    }
    public enum State
    {
        IDLE,
        ATTACKREADY,
        ATTACK,
        HIT,
        MOVE
    }

}
