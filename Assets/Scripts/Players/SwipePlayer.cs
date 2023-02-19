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
        speed = 100f;
        this.transform.position = Managers.Field.GetGrid(current_X, current_Y).transform.position;

        Managers.Field.ScaleByRatio(gameObject, current_X, current_Y);
        anim = GetComponent<Animator>();

        //makes more harder to move(strict)
        //Managers.Timing.BehaveAction -= ResetMousePosition;    
        //Managers.Timing.BehaveAction += ResetMousePosition;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Managers.Timing.CheckTiming())
        {
            startPos = Input.mousePosition;
        }
        //else if (Input.GetMouseButtonUp(0) && Managers.Timing.CheckTiming())
        else if (Input.GetMouseButtonUp(0) && startPos != new Vector2(0, 0))        //if if(block) does not run else if should not run too
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

            //Debug.Log("current_X : " + current_X + ",    current_Y : " + current_Y);
            //Debug.Log("move_X : " + move_X + ",    move_Y : " + move_Y);

            this.transform.position = Vector3.MoveTowards(transform.position, Managers.Field.GetGrid(move_X, move_Y).transform.position, Time.deltaTime * speed); //Time.deltaTime * speed
            CheckMove();
            current_X = move_X;
            current_Y = move_Y;

            Managers.Field.ScaleByRatio(gameObject, current_X, current_Y);

            ResetMousePosition();
        }
    }

    public void ResetMousePosition()
    {
            startPos = new Vector2(0, 0);
            endPos = new Vector2(0, 0);
            toward = new Vector2(0, 0);
    }
 
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
        //Debug.Log($"float :{direct}");
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
