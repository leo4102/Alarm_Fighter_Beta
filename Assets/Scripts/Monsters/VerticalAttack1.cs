using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//top to down straight attack(disappear at the end)
public class VerticalAttack1 : MiniMonster_Parent
{
    private void Start()
    {
        currentHp = maxHp;
        speed = 10f;
        int rand = UnityEngine.Random.Range(1, Managers.Field.GetWidth() - 1);

        transform.position = Managers.Field.GetGrid(rand, 0).transform.position;
        current_X = rand;
        current_Y = 0;

        move_X = rand;
        move_Y = 0;

        SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
        currentGridColor.color = Color.magenta;

        //소환되는 애니메이션 실행
        Managers.Timing.BehaveAction -= AutoBitBehave;          //VMon1의 비트 마다 실행할 BitBehave 구독
        Managers.Timing.BehaveAction += AutoBitBehave;
    }

    protected override void AutoBitBehave()
    {
        switch (nextBehavior)
        {
            case Define.State.ATTACKREADY:

                AutoWarningAttack(nextDirection);            //아래 grid는 빨강화로 공격할것임을 알린다
                break;

            case Define.State.ATTACK:                        //다음 박자에 아래로 이동 밑 공격
                AutoAttack(nextDirection);
                break;

            case Define.State.DIE:
                Die();
                break;

        }
    }

    private void FixedUpdate()
    {
        try
        {
            SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
            currentGridColor.color = new Color(255f, 255f, 255f, 1);

            Vector3 movePoint = Managers.Field.GetGrid(move_X, move_Y).transform.position;
            transform.position = Vector3.MoveTowards(transform.position, movePoint, Time.deltaTime * speed);

            current_X = move_X;
            current_Y = move_Y;
            
            StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(current_X, current_Y));  //------------------------

            currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
            currentGridColor.color = Color.magenta;
        }
        catch (ArgumentOutOfRangeException)
        {
            move_X = current_X;
            move_Y = current_Y;
        }
    }

    protected override void AutoWarningAttack(Define.PlayerMove nextDirection)
    {
        SelectNextDirection();

        try
        {
            SpriteRenderer gridColor = Managers.Field.GetGrid(current_X, current_Y + 1).GetComponent<SpriteRenderer>();
            gridColor.color = Color.red;
        }
        catch (ArgumentOutOfRangeException)
        {
            nextBehavior = Define.State.DIE;
            return;
        }
        nextBehavior = Define.State.ATTACK;
    }


    protected override void AutoAttack(Define.PlayerMove nextDirection)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Jump");
        
        mayGo(nextDirection);
      
        //StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(move_X, move_Y));//-----------------
       
        nextBehavior = Define.State.ATTACKREADY;
    }

    protected override void SelectNextDirection()
    {
        nextDirection = Define.PlayerMove.Down;
    }
    
    protected override void Die()
    {
        Destroy(gameObject);
        //Debug.Log("Die 할 GameObject :" + gameObject);
        Managers.Timing.BehaveAction -= AutoBitBehave;
        Managers.Monster.CurrentVMons.Remove(gameObject);

        SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
        currentGridColor.color = new Color(255f, 255f, 255f, 1);
    }
}
