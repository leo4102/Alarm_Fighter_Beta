using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyMonster : Monster
{
    private void Start()
    {
        CurrentArea = GameObject.Find("MonBoxArea 2").GetComponent<BoxArea>();
    }
    protected override void UpdateAttack()
    {
        MonsterState = State.Idle;

    }

    protected override void UpdateAttackReady()
    {
        MonsterState = State.Attack;

    }

    protected override void UpdateHit()
    {
        throw new System.NotImplementedException();
    }

    protected override void UpdateIdle()
    {

        MonsterState = State.Move;
    }
    protected override void UpdateMove()
    {
        if (CurrentArea.Left != null)
            CurrentArea = CurrentArea.Left;
        else if (CurrentArea.Right != null)
            CurrentArea = CurrentArea.Right;
        MonsterState = State.AttackReady;
    }
}
