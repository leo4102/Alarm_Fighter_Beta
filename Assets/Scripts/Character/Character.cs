using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected int current_X, current_Y;
    protected int move_X, move_Y;
    protected float speed;

    // player의 현재 X와 Y Index 반환
    public int GetPlayerInd_X()
    {
        return current_X;
    }
    public int GetPlayerInd_Y()
    {
        return current_Y;
    }

    protected void mayGo(Define.PlayerMove direction)
    {
        move_X = current_X;
        move_Y = current_Y;

        // 움직일 수 있는 인덱스인지 검사
        if (direction == Define.PlayerMove.Up)
        {
            move_Y -= 1;
            if (move_Y < 0)
                move_Y = current_Y;
        }
        else if (direction == Define.PlayerMove.Down)
        {
            move_Y += 1;
            if (move_Y > Managers.Field.GetHeight() - 1)
                move_Y = current_Y;
        }
        else if (direction == Define.PlayerMove.Left)
        {
            move_X -= 1;
            if (move_X < 0)
                move_X = current_X;
        }
        else if (direction == Define.PlayerMove.Right)
        {
            move_X += 1;
            if (move_X > Managers.Field.GetWidth() - 1)
                move_X = current_X;
        }
    }
    // 원근감을 제대로 내기 위해서는 비율만 바꾸면 됨 (2.11 재윤 추가)
    protected void ChangeSize(int current_Y)
    {
        // fieldmanager에서 가져와서 변경하기
        Vector3 size = new Vector3((float)(current_Y + 1) * 0.16f, (float)(current_Y + 1) * 0.16f, (float)(current_Y + 1) * 0.16f);
        this.transform.localScale = size;
    }

    protected void Attack()
    {

    }
}
