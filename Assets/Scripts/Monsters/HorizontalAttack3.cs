using System;
using UnityEngine;

//left to right diagonal attack(disappear at the end)
public class HorizontalAttack3 : MiniMonster_Parent
{
    private void Start()
    {
        currentHp = maxHp;
        speed = 10f;
        int rand = UnityEngine.Random.Range(0, Managers.Field.GetHeight());    //ó�� ���� ��ġ  ����      


        transform.position = Managers.Field.GetGrid(0, rand).transform.position;
        current_X = 0;
        current_Y = rand;

        move_X = 0;
        move_Y = rand;

        //Debug.Log("Start :  Move_x,Move_Y:" + move_X + " ," + move_Y);
        //Debug.Log("Start : current_X,current_Y:" + current_X + " ," + current_Y);

        SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
        currentGridColor.color = Color.magenta;

        //��ȯ�Ǵ� �ִϸ��̼� ����
        Managers.Timing.BehaveAction -= AutoBitBehave;      //VMon1�� ��Ʈ ���� ������ BitBehave ����
        Managers.Timing.BehaveAction += AutoBitBehave;
        
        //Debug.Log("start�� ���� ���õ� ����:   " + nextDirection + "," + a + "," + b);

        SelectNextDirection();

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

            StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(move_X, move_Y));  //------------------

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

        try
        {
            if (current_X + a > Managers.Field.GetWidth()-1)
            {
                nextBehavior = Define.State.DIE;
                return;
            }

            SpriteRenderer gridColor = Managers.Field.GetGrid(current_X + a, current_Y + b).GetComponent<SpriteRenderer>();
            gridColor.color = Color.red;
        }
        catch (ArgumentOutOfRangeException)
        {
            //Debug.Log("RR shoud die ArgumentOutOfRangeException");
            SelectNextDirection();
            //Debug.Log("attack ready�� ���� ���õ� ����:   " + this.nextDirection + "," + a +"," + b);

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

        StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(move_X, move_Y));

        nextBehavior = Define.State.ATTACKREADY;
    }

    protected override void SelectNextDirection()
    {
        if (nextDirection == Define.PlayerMove.RIGHTUP)
        {
            nextDirection = Define.PlayerMove.RIGHTDOWN;
            a = 1; b = 1;
        }
        else if (nextDirection == Define.PlayerMove.RIGHTDOWN)
        {
            nextDirection = Define.PlayerMove.RIGHTUP;
            a = 1; b = -1;
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
        //Debug.Log("Die �� GameObject :" + gameObject);
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
