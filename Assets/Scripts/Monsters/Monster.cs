using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : Noteable
{
    BoxArea _currentArea;

    public BoxArea CurrentArea {
        get { return _currentArea; }
        set
        {
            _currentArea = value;
            Transform moveTo = _currentArea.GetComponent<Transform>();
            SetPosition(moveTo);
        }
    }
    void SetPosition(Transform moveTo)
    {
        transform.position = new Vector3(moveTo.position.x, moveTo.position.y, 0);
    }
    public enum State
    {
        Idle,
        AttackReady,
        Attack,
        Move,
        Hit,
    }
    State _state = State.Idle;

    public State MonsterState
    {
        get { return _state; }
        set
        {
            Animator anim = GetComponent<Animator>();
            switch(_state)
            {
                case State.Idle:
                    anim.Play("Idle");
                    break;
                case State.AttackReady:
                    anim.Play("AttackReady");
                    break;
                case State.Attack:
                    anim.Play("Attack");
                    break;
                case State.Move:
                    anim.Play("Move");
                    break;
                case State.Hit:
                    anim.Play("Idle");
                    break;
            }
            _state = value;
        }

    }

    protected override void BitUpdate()
    {
        Debug.Log("Bit");
        switch(MonsterState)
        {
            case State.Idle:
                UpdateIdle();
                break;
            case State.AttackReady:
                UpdateAttackReady();
                break;
            case State.Attack:
                UpdateAttack();
                break;
            case State.Move:
                UpdateMove();
                break;
            case State.Hit:
                UpdateHit();
                break;
        }
    }

    protected abstract void UpdateIdle();
    protected abstract void UpdateAttackReady();
    protected abstract void UpdateAttack();
    protected abstract void UpdateHit();
    protected abstract void UpdateMove();
}
