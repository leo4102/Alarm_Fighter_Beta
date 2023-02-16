using UnityEngine;

public class JYPlayer : Character
{
    void Start()
    {
        current_X = 5;
        current_Y = 1;
        move_X = current_X;
        move_Y = current_Y;
        speed = 10f;
        this.transform.position = Managers.Field.GetGrid(current_X, current_Y).transform.position;
        Managers.Field.ScaleByRatio(gameObject, current_X, current_Y);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && Managers.Timing.CheckTiming()) { mayGo(Define.PlayerMove.Up); }
        else if (Input.GetKeyDown(KeyCode.A) && Managers.Timing.CheckTiming()) { mayGo(Define.PlayerMove.Left); }
        else if (Input.GetKeyDown(KeyCode.S) && Managers.Timing.CheckTiming()) { mayGo(Define.PlayerMove.Down); }
        else if (Input.GetKeyDown(KeyCode.D) && Managers.Timing.CheckTiming()) { mayGo(Define.PlayerMove.Right); }


        //------------------------------------------------------------------------------
        Vector2 checkPoint = Managers.Field.GetGrid(move_X, move_Y).transform.position;
        if (((move_X != current_X) || (move_Y != current_Y)) && (Physics2D.OverlapCircle(checkPoint, 0.2f)))
        {
            Debug.Log("Player의 movepoint에 몬스터 존재");


            //SpriteRenderer moveGridColor = Managers.Field.GetGrid(move_X, move_Y).GetComponent<SpriteRenderer>();
            //moveGridColor.color = new Color(255f, 255f, 255f, 1);

            move_X = current_X;
            move_Y = current_Y;

            return;

        }
        //--------------------------------------------------------------------------------------

        this.transform.position = Vector3.MoveTowards(transform.position, Managers.Field.GetGrid(move_X, move_Y).transform.position, Time.deltaTime * speed);

        current_X = move_X;
        current_Y = move_Y;
        
        //SpriteRenderer currentGridColor = Managers.Field.GetGrid(current_X, current_Y).GetComponent<SpriteRenderer>();
        //currentGridColor.color = Color.black;
        
        //Debug.Log("Player의 x 좌표:" + current_X + ",Player의 y 좌표:" + current_Y);//------------------------
        Managers.Field.ScaleByRatio(gameObject, current_X, current_Y);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("MyPlayerHit");
    }*/
}
