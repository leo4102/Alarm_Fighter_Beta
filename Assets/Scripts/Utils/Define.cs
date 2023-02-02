using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{
    public enum MonsterMove
    {
        Left,
        Right,
        Stop,
    }
    public enum PlayerMove
    {
        Up,
        Down,
        Left,
        Right,
        Stop,
    }
    public enum State
    {
        IDLE,
        ATTACKREADY,
        ATTACK,     //공격
        HIT,        //맞음
        MOVE,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }
}
