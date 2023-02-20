using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//moves randomly around the field
public class RandomAttack2 : MiniMonster_Parent
{
    private void Start()
    {
        currentHp = maxHp;
        speed = 10f;
        int rand_X = UnityEngine.Random.Range(1, Managers.Field.GetWidth() - 1);
        int rand_Y = UnityEngine.Random.Range(1, Managers.Field.GetHeight());

        transform.position = Managers.Field.GetGrid(rand_X, rand_Y).transform.position;

        current_X = rand_X;
        current_Y = rand_Y;

        move_X = rand_X;
        move_Y = rand_Y;

        //Debug.Log("Start :  Move_x,Move_Y:" + move_X + " ," + move_Y);
        //Debug.Log("Start : current_X,current_Y:" + current_X + " ," + current_Y);

        SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
        currentGridColor.color = Color.magenta;

        //��ȯ�Ǵ� �ִϸ��̼� ����
        Managers.Timing.BehaveAction -= AutoBitBehave;      //VMon1�� ��Ʈ ���� ������ BitBehave ����
        Managers.Timing.BehaveAction += AutoBitBehave;


        //Debug.Log("start�� ���� ���õ� ����:   " + nextDirection + "," + a + "," + b);

        //SelectNextDirection();

        //Debug.Log("start �� ���� ���õ� ����:   " + nextDirection + "," + a + "," + b);
    }

    private void FixedUpdate()
    {
        try
        {
            SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
            currentGridColor.color = new Color(255f, 255f, 255f, 1);


            Vector3 movePoint = Managers.Field.GetGrid(move_X, move_Y).transform.position;
            transform.position = Vector3.MoveTowards(transform.position, movePoint, Time.deltaTime * speed);

            StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(move_X, move_Y));//-------
            
            current_X = move_X;
            current_Y = move_Y;
            
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

                AutoWarningAttack(nextDirection);            //�Ʒ� grid�� ����ȭ�� �����Ұ����� �˸���
                break;

            case Define.State.ATTACK:                        //���� ���ڿ� �Ʒ��� �̵� �� ����

                AutoAttack(nextDirection);
                break;

            case Define.State.DIE:

                Die();
                break;

        }
    }

    protected override void AutoWarningAttack(Define.PlayerMove nextDirection)
    {
        //SelectNextDirection();        //Start������ ����

        while (true)
        {
            try
            {
               /* if (current_X + a > Managers.Field.GetWidth() - 1)
                {
                    nextBehavior = Define.State.DIE;
                    return;
                }*/
                SelectNextDirection();

                //Debug.Log("RandomAttack2�� update �����");
                SpriteRenderer gridColor = Managers.Field.GetGrid(current_X + a, current_Y + b).GetComponent<SpriteRenderer>();
                gridColor.color = Color.red;

                break;
            }
            catch (ArgumentOutOfRangeException)
            {
                //Debug.Log("RandomAttack2�� continue �� �����");  
                continue;
            }
        }

        nextBehavior = Define.State.ATTACK;
    }


    protected override void AutoAttack(Define.PlayerMove nextDirection)
    {
        mayGo(nextDirection);

        //Debug.Log("Move_x, Move_Y:  " + move_X + " ," + move_Y);
        //Debug.Log("current_X,current_Y:" + current_X + " ," + current_Y);

        //StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(move_X, move_Y));

        nextBehavior = Define.State.ATTACKREADY;
    }

    protected override void SelectNextDirection()
    {
        int enumCount = Enum.GetValues(typeof(Define.PlayerMove)).Length;
        int rand = UnityEngine.Random.Range(1, enumCount);

        nextDirection = (Define.PlayerMove)rand;

        switch (nextDirection)
        {
            case Define.PlayerMove.Up:
                a = 0;
                b = -1;
                break;

            case Define.PlayerMove.Down:
                a = 0;
                b = 1;
                break;
                
            case Define.PlayerMove.Left:
                a = -1;
                b = 0;
                break;

            case Define.PlayerMove.Right:
                a = 1;
                b = 0;
                break;

            case Define.PlayerMove.LEFTUP:
                a = -1;
                b = -1;
                break;
            case Define.PlayerMove.RIGHTUP:
                a = 1;
                b = -1;
                break;
            case Define.PlayerMove.LEFTDOWN:
                a = -1;
                b = 1;
                break;
            case Define.PlayerMove.RIGHTDOWN:
                a = 1;
                b = 1;
                break;

        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
        //Debug.Log("Die �� GameObject :" + gameObject);
        Managers.Timing.BehaveAction -= AutoBitBehave;
        Managers.Monster.CurrentHMons.Remove(gameObject);

        SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
        currentGridColor.color = new Color(255f, 255f, 255f, 1);
    }

}
