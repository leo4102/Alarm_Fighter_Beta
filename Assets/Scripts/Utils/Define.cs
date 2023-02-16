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
        NULL,       //just for reset
        Up,
        Down,
        Left,
        Right,
        RIGHTUP,
        LEFTUP,
        RIGHTDOWN,
        LEFTDOWN,
    }
    public enum State
    {
        IDLE,
        ATTACKREADY,
        ATTACK,     //공격
        HIT,        //맞음
        MOVE,
        SPAWN,
        NOTSPAWN,
        DIE
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum ItemRank
    {
        Normal,
        Rare,
        Epic,
    }

    public enum GridState
    {
        Base,
        AttackReady,
        Attack,
    }
}
