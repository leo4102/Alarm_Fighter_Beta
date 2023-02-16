using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JYPlayer : Character
{
    void Start()
    {
        current_X = 5;
        current_Y = 1;
        move_X = current_X;
        move_Y = current_Y;
        speed = 20f;
        this.transform.position = Managers.Field.GetGrid(current_X, current_Y).transform.position;
        ChangeSize(current_Y);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && Managers.Timing.CheckTiming()) { mayGo(Define.PlayerMove.Up); }
        else if (Input.GetKeyDown(KeyCode.A) && Managers.Timing.CheckTiming()) { mayGo(Define.PlayerMove.Left); }
        else if (Input.GetKeyDown(KeyCode.S) && Managers.Timing.CheckTiming()) { mayGo(Define.PlayerMove.Down); }
        else if (Input.GetKeyDown(KeyCode.D) && Managers.Timing.CheckTiming()) { mayGo(Define.PlayerMove.Right); }

        this.transform.position = Vector3.MoveTowards(transform.position, Managers.Field.GetGrid(move_X, move_Y).transform.position, Time.deltaTime * speed);

        current_X = move_X;
        current_Y = move_Y;
        ChangeSize(current_Y);
    }

}