using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//start from left to right bouncing wall attack
public class HorizontalAttack4 : MiniMonster_Parent
{
    private void Start()
    {
        currentHp = maxHp;
        speed = 10f;
        int rand = UnityEngine.Random.Range(0, Managers.Field.GetHeight());    //처음 스폰 위치  결정      


        transform.position = Managers.Field.GetGrid(0, rand).transform.position;
        current_X = 0;
        current_Y = rand;

        move_X = 0;
        move_Y = rand;

        //Debug.Log("Start :  Move_x,Move_Y:" + move_X + " ," + move_Y);
        //Debug.Log("Start : current_X,current_Y:" + current_X + " ," + current_Y);

        SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
        currentGridColor.color = Color.magenta;

        //소환되는 애니메이션 실행
        Managers.Timing.BehaveAction -= AutoBitBehave;      //VMon1의 비트 마다 실행할 BitBehave 구독
        Managers.Timing.BehaveAction += AutoBitBehave;


        //Debug.Log("start전 현재 선택된 방향:   " + nextDirection + "," + a + "," + b);

        SelectNextDirection();

        //Debug.Log("start 서 현재 선택된 방향:   " + nextDirection + "," + a + "," + b);
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

            StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(current_X, current_Y));//----------

            currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
            currentGridColor.color = Color.magenta;

        }
        catch (ArgumentOutOfRangeException)
        {
            move_X = current_X;
            move_Y = current_Y;
        }
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

    protected override void AutoWarningAttack(Define.PlayerMove nextDirection)
    {
        //SelectNextDirection();        //Start문으로 보냄

        try
        {
            /*if (current_X + a > Managers.Field.GetWidth() - 1)
            {
                nextBehavior = Define.State.DIE;
                return;
            }*/

            SpriteRenderer gridColor = Managers.Field.GetGrid(current_X + a, current_Y + b).GetComponent<SpriteRenderer>();
            gridColor.color = Color.red;
        }
        catch (ArgumentOutOfRangeException)
        {
            //Debug.Log("RR shoud die ArgumentOutOfRangeException");
            SelectNextDirection();
            //Debug.Log("attack ready서 현재 선택된 방향:   " + this.nextDirection + "," + a + "," + b);

            SpriteRenderer gridColor = Managers.Field.GetGrid(current_X + a, current_Y + b).GetComponent<SpriteRenderer>();
            gridColor.color = Color.red;
        }

        nextBehavior = Define.State.ATTACK;
    }


    protected override void AutoAttack(Define.PlayerMove nextDirection)
    {
        mayGo(nextDirection);

        //Debug.Log("Move_x, Move_Y:  " + move_X + " ," + move_Y);
        //Debug.Log("current_X,current_Y:" + current_X + " ," + current_Y);

        //StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(move_X, move_Y)); //----------

        nextBehavior = Define.State.ATTACKREADY;
    }

    protected override void SelectNextDirection()
    {
        //Used for bouncing off the right left end
        if (nextDirection == Define.PlayerMove.RIGHTUP && current_X + a > Managers.Field.GetWidth() - 1)
        {
            nextDirection = Define.PlayerMove.LEFTUP;
            a = -1; b = -1;
        }

        else if (nextDirection == Define.PlayerMove.RIGHTDOWN && current_X + a > Managers.Field.GetWidth() - 1)
        {
            nextDirection = Define.PlayerMove.LEFTDOWN;
            a = -1; b = 1;
        }

        else if (nextDirection == Define.PlayerMove.LEFTUP && current_X + a < 0)
        {
            nextDirection = Define.PlayerMove.RIGHTUP;
            a = 1; b = -1;
        }

        else if (nextDirection == Define.PlayerMove.LEFTDOWN && current_X + a < 0)
        {
            nextDirection = Define.PlayerMove.RIGHTDOWN;
            a = 1; b = 1;
        }

        //Used for bouncing off the top bottom end
        else if (nextDirection == Define.PlayerMove.RIGHTUP)
        {
            nextDirection = Define.PlayerMove.RIGHTDOWN;
            a = 1; b = 1;
        }
        else if (nextDirection == Define.PlayerMove.RIGHTDOWN)
        {
            nextDirection = Define.PlayerMove.RIGHTUP;
            a = 1; b = -1;
        }

        else if (nextDirection == Define.PlayerMove.LEFTUP)
        {
            nextDirection = Define.PlayerMove.LEFTDOWN;
            a = -1; b = 1;
        }
        else if (nextDirection == Define.PlayerMove.LEFTDOWN)
        {
            nextDirection = Define.PlayerMove.LEFTUP;
            a = -1; b = -1;
        }

        else if (nextDirection == Define.PlayerMove.NULL)
        {
            int rand = UnityEngine.Random.Range(0, 2);      //0 or 1 random num
            if (rand == 0)
            {
                nextDirection = Define.PlayerMove.RIGHTUP;
                a = 1; b = -1;
            }
            else if (rand == 1)
            {
                nextDirection = Define.PlayerMove.RIGHTDOWN;
                a = 1; b = 1;
            }
        }

    }

    protected override void Die()
    {
        Destroy(gameObject);
        //Debug.Log("Die 할 GameObject :" + gameObject);
        Managers.Timing.BehaveAction -= AutoBitBehave;
        Managers.Monster.CurrentHMons.Remove(gameObject);

        SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
        currentGridColor.color = new Color(255f, 255f, 255f, 1);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        currentHp -= 1;
        if (currentHp <= 0)
        {
            nextBehavior = Define.State.DIE;
        }

    }
}
