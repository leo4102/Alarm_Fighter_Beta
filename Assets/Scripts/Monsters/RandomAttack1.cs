using System;
using UnityEngine;

//follow player attack
public class RandomAttack1 : MiniMonster_Parent
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
    }

    private void FixedUpdate()
    {
        try
        {
            /*if (Managers.Monster.CheckFrontObject(move_X, move_Y))
            {

                return;

                //move_X = current_X;
                //move_Y = current_Y;
            }*
            //-----------------------------------------------------------------------------------
            /*int player_X = Managers.Player.GetCurrentX();
            int player_Y = Managers.Player.GetCurrentY();

            if (player_X == move_X && player_Y == move_Y)    //Myplayer��ġ==������ ��ġ(�������� ����)
            {
                return;

                //move_X = current_X;
                //move_Y = current_Y;
            }*/
            //------------------------------------------------------------------------------------
            Vector3 checkPoint = Managers.Field.GetGrid(move_X, move_Y).transform.position;     //movepoint �� ������ ����
            if (((move_X != current_X) || (move_Y != current_Y))&&(Physics2D.OverlapCircle(checkPoint, 0.2f)))  //  
            {
                //Debug.Log("Movepoint�� �÷��̾� ����");


                //SpriteRenderer moveGridColor = Managers.Field.GetGrid(move_X, move_Y).GetComponent<SpriteRenderer>();
                //moveGridColor.color = new Color(255f, 255f, 255f, 1);

                SpriteRenderer currentColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
                currentColor.color = Color.magenta;

                //move_X = current_X;
                //move_Y = current_Y;

                return;
            }
            //------------------------------------------------------------------------------------
            //���� �����δٸ�
            //�����̱� ������ �ڸ��� ��->�� ������ �ٲ۴�.
            SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
            currentGridColor.color = new Color(255f, 255f, 255f, 1);

            //Attack�� ����� �ڸ��� ��ü �ڸ� �̵�
            Vector3 movePoint = Managers.Field.GetGrid(move_X, move_Y).transform.position;      //���⼭ ���� �߻� ����
            transform.position = Vector3.MoveTowards(transform.position, movePoint, Time.deltaTime * speed);
            
            //-----------------------------------------------------------
            if (current_X != move_X || current_Y != move_Y)
            {
                StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(move_X, move_Y));//----------
            }
            //------------------------------------------------------------

            //��ü�� ���������Ƿ� ���� Grid�� ����
            current_X = move_X;
            current_Y = move_Y;
           
            //���� grid�� colliderȰ��ȭ
            //StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(current_X, current_Y));      //-------------

            //����� �ڸ� �����ȭ
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
        int player_X = Managers.Player.GetCurrentX();

        if ((player_X - 5 < current_X) && (current_X < player_X + 5))     //MyPlayer�� +-4(��) ���� �ȿ� ������ RMons1 ������
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
    }

    protected override void AutoWarningAttack(Define.PlayerMove nextDirection)
    {
        SelectNextDirection();

        try
        {
            SpriteRenderer gridColor = Managers.Field.GetGrid(current_X + a, current_Y + b).GetComponent<SpriteRenderer>();
            gridColor.color = Color.red;
        }
        catch (ArgumentOutOfRangeException)
        {
            //Debug.Log("RR shoud die ArgumentOutOfRangeException");
            nextBehavior = Define.State.DIE;
            return;
        }
        nextBehavior = Define.State.ATTACK;
    }


    protected override void AutoAttack(Define.PlayerMove nextDirection)
    {
        //moveGrid ����Ǳ� ���� �� �̸� ���ȭ
        SpriteRenderer moveGridColor = Managers.Field.GetGrid(move_X, move_Y).GetComponent<SpriteRenderer>();
        if(moveGridColor.color==Color.red)
            moveGridColor.color = new Color(255f, 255f, 255f, 1);
        
        mayGo(nextDirection);

        //Debug.Log("Move_x,Move_Y:" + move_X + " ," + move_Y);
        //Debug.Log("current_X,current_Y:" + current_X + " ," + current_Y);

        //StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(move_X, move_Y));

        nextBehavior = Define.State.ATTACKREADY;
    }

    protected override void SelectNextDirection()
    {
        int player_X = Managers.Player.GetCurrentX();
        int player_Y = Managers.Player.GetCurrentY();

        towardPlayer_X = player_X - current_X;
        towardPlayer_Y = player_Y - current_Y;

        //Debug.Log("towardPlayer_X:  " + towardPlayer_X + ",     towardPlayer_Y:   " + towardPlayer_Y);

        if (towardPlayer_X != 0 && towardPlayer_Y != 0)       //�� �Ǵ� �� ����
        {
            int rand = UnityEngine.Random.Range(0, 2);       //0(�� ����)�� 1(�� ����)�� �������� �ϳ� ����

            if (rand == 0) ChooseLeftOrRight();
            else if (rand == 1) ChooseUpOrDown();
        }
        else if (towardPlayer_X != 0 && towardPlayer_Y == 0)      //�� ����
        {
            ChooseLeftOrRight();
        }
        else if (towardPlayer_X == 0 && towardPlayer_Y != 0)      //�� ����
        {
            ChooseUpOrDown();
        }
        else//(towardPlayer_X == 0 && towardPlayer_Y == 0) 
        {
            Debug.Log("SelectNextDirection()���� ���� �߻�");
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
        //Debug.Log("Die �� GameObject :" + gameObject);
        Managers.Timing.BehaveAction -= AutoBitBehave;
        Managers.Monster.CurrentRMons.Remove(gameObject);

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
