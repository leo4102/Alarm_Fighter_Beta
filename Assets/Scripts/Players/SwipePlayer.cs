using UnityEngine;

public class SwipePlayer : Character
{
    //float speed = 0;
    Vector2 startPos;
    Vector2 endPos;
    Vector2 toward;

    void Start()
    {
        current_X = 5;
        current_Y = 1;
        move_X = current_X;
        move_Y = current_Y;
        speed = 10f;
        this.transform.position = Managers.Field.GetGrid(current_X, current_Y).transform.position;

        Managers.Field.ScaleByRatio(gameObject, current_X, current_Y);
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Managers.Timing.CheckTiming())
        {
            startPos = Input.mousePosition;
        }
        //else if (Input.GetMouseButtonUp(0) && Managers.Timing.CheckTiming())
        else if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            toward = (endPos - startPos);
            if (toward.magnitude == 0)
            {
                return;
            }
            else if (toward.y > 0 && Mathf.Abs(toward.y) > Mathf.Abs(toward.x))//플레이어 위로 이동
            {
                mayGo(Define.PlayerMove.Up);
            }
            else if (toward.y < 0 && Mathf.Abs(toward.y) > Mathf.Abs(toward.x))//플레이어 밑으로 이동
            {
                mayGo(Define.PlayerMove.Down);
            }
            else if (toward.x > 0 && Mathf.Abs(toward.x) > Mathf.Abs(toward.y))//플레이어 오른쪽 이동
            {
                mayGo(Define.PlayerMove.Right);
            }
            else if (toward.x < 0 && Mathf.Abs(toward.x) > Mathf.Abs(toward.y))//플레이어 왼쪽 이동
            {
                mayGo(Define.PlayerMove.Left);
            }

            Debug.Log("current_X : " + current_X + ",    current_Y : " + current_Y);
            Debug.Log("move_X : " + move_X + ",    move_Y : " + move_Y);

            this.transform.position = Vector3.MoveTowards(transform.position, Managers.Field.GetGrid(move_X, move_Y).transform.position, Time.deltaTime * speed); //Time.deltaTime * speed
            CheckMove();
            current_X = move_X;
            current_Y = move_Y;

            Managers.Field.ScaleByRatio(gameObject, current_X, current_Y);

            /*else if (Input.GetMouseButtonUp(0))
            {
                Vector2 endPos = Input.mousePosition;
                float swipeLength = endPos.x - startPos.x;

                this.speed = swipeLength / 500.0f;

                GetComponent<AudioSource>().Play();
            }



            transform.Translate(this.speed, 0, 0);
            this.speed *= 0.98f;*/


        }
    }
    //---------------------------------------------------------------
    /*void Update()
    {
        if (isUp && Managers.Timing.CheckTiming()) { mayGo(Define.PlayerMove.Up); isUp = false; }
        else if (isLeft && Managers.Timing.CheckTiming()) { mayGo(Define.PlayerMove.Left); isLeft = false; }
        else if (isDown && Managers.Timing.CheckTiming()) { mayGo(Define.PlayerMove.Down); isDown = false; }
        else if (isRight && Managers.Timing.CheckTiming()) { mayGo(Define.PlayerMove.Right); isRight = false; }

        *//*Vector2 checkPoint = Managers.Field.GetGrid(move_X, move_Y).transform.position;
        if (((move_X != current_X) || (move_Y != current_Y)) && (Physics2D.OverlapCircle(checkPoint, 0.2f)))
        {
            //Debug.Log("Player의 movepoint에 몬스터 존재");
            //SpriteRenderer moveGridColor = Managers.Field.GetGrid(move_X, move_Y).GetComponent<SpriteRenderer>();
            //moveGridColor.color = new Color(255f, 255f, 255f, 1);

            move_X = current_X;
            move_Y = current_Y;

            return;
        }*//*

        this.transform.position = Vector3.MoveTowards(transform.position, Managers.Field.GetGrid(move_X, move_Y).transform.position, Time.deltaTime * speed); //Time.deltaTime * speed

        current_X = move_X;
        current_Y = move_Y;

        Managers.Field.ScaleByRatio(gameObject, current_X, current_Y);

    }*/



    void CheckMove()
    {
        float direct = (transform.position - Managers.Field.GetGrid(move_X, move_Y).transform.position).magnitude;
        if (direct <= 0.001)
        {
            anim.SetBool("IsMoveL", false);
            anim.SetBool("IsMoveR", false);
            SetDirection(move_X);

        }
    }

    void SetDirection(int x)
    {
        float direct = 0;
        int width = Managers.Field.GetWidth();
        direct = ((float)x / width) * 2f;
        Debug.Log($"float :{direct}");
        //int part = width / 3;
        //if (x < part)
        //    direct = 0;
        //else if (x >= part * 2)
        //    direct = 2;
        //else
        //    direct = 1;
        anim.SetFloat("Idle", direct);
    }



}
