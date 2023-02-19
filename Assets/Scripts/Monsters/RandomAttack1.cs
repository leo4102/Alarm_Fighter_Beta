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

        //소환되는 애니메이션 실행
        Managers.Timing.BehaveAction -= AutoBitBehave;      //VMon1의 비트 마다 실행할 BitBehave 구독
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

            if (player_X == move_X && player_Y == move_Y)    //Myplayer위치==공격할 위치(움직이지 말것)
            {
                return;

                //move_X = current_X;
                //move_Y = current_Y;
            }*/
            //------------------------------------------------------------------------------------
            Vector3 checkPoint = Managers.Field.GetGrid(move_X, move_Y).transform.position;     //movepoint 과 동일한 역할
            if (((move_X != current_X) || (move_Y != current_Y))&&(Physics2D.OverlapCircle(checkPoint, 0.2f)))  //  
            {
                //Debug.Log("Movepoint에 플레이어 있음");


                //SpriteRenderer moveGridColor = Managers.Field.GetGrid(move_X, move_Y).GetComponent<SpriteRenderer>();
                //moveGridColor.color = new Color(255f, 255f, 255f, 1);

                SpriteRenderer currentColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
                currentColor.color = Color.magenta;

                //move_X = current_X;
                //move_Y = current_Y;

                return;
            }
            //------------------------------------------------------------------------------------
            //만약 움직인다면
            //움직이기 이전의 자리를 보->흰 색으로 바꾼다.
            SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
            currentGridColor.color = new Color(255f, 255f, 255f, 1);

            //Attack서 변경된 자리로 객체 자리 이동
            Vector3 movePoint = Managers.Field.GetGrid(move_X, move_Y).transform.position;      //여기서 에러 발생 가능
            transform.position = Vector3.MoveTowards(transform.position, movePoint, Time.deltaTime * speed);
            
            //-----------------------------------------------------------
            if (current_X != move_X || current_Y != move_Y)
            {
                StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(move_X, move_Y));//----------
            }
            //------------------------------------------------------------

            //객체가 움직였으므로 현재 Grid도 변경
            current_X = move_X;
            current_Y = move_Y;
           
            //현재 grid의 collider활성화
            //StartCoroutine("ActiveDamageField", Managers.Field.GetGrid(current_X, current_Y));      //-------------

            //변경된 자리 보라색화
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

        if ((player_X - 5 < current_X) && (current_X < player_X + 5))     //MyPlayer의 +-4(열) 범위 안에 들어오면 RMons1 움직임
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
        //moveGrid 변경되기 전에 빨 이면 흰색화
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

        if (towardPlayer_X != 0 && towardPlayer_Y != 0)       //열 또는 행 변경
        {
            int rand = UnityEngine.Random.Range(0, 2);       //0(열 변경)과 1(행 변경)중 랜덤으로 하나 선택

            if (rand == 0) ChooseLeftOrRight();
            else if (rand == 1) ChooseUpOrDown();
        }
        else if (towardPlayer_X != 0 && towardPlayer_Y == 0)      //열 변경
        {
            ChooseLeftOrRight();
        }
        else if (towardPlayer_X == 0 && towardPlayer_Y != 0)      //행 변경
        {
            ChooseUpOrDown();
        }
        else//(towardPlayer_X == 0 && towardPlayer_Y == 0) 
        {
            Debug.Log("SelectNextDirection()에서 오류 발생");
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
        //Debug.Log("Die 할 GameObject :" + gameObject);
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
