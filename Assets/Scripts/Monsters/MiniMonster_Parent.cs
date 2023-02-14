using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMonster_Parent : MonoBehaviour
{
    protected int maxHp = 1;
    protected int currentHp;

        
    protected Define.State nextBehavior = Define.State.ATTACKREADY;
    protected Define.PlayerMove nextDirection;

    protected int current_X, current_Y;
    protected int move_X, move_Y;
    protected int towardPlayer_X, towardPlayer_Y;
    
    protected float speed;

    protected int a = 0, b = 0;


    //maygo는 무조건 Attack()서 호출
    //maygo서 moveGridInd를 바꾸면 거기로 RMons1이 바로 이동
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

    public void ChooseLeftOrRight()
    {
        if (Math.Sign(towardPlayer_X) == -1)
        {
            nextDirection = Define.PlayerMove.Left;
            a = -1; b = 0;
        }
        else
        {
            nextDirection = Define.PlayerMove.Right;
            a = 1; b = 0;
        }
    }

    public void ChooseUpOrDown()
    {
        if (Math.Sign(towardPlayer_Y) == -1)
        {
            nextDirection = Define.PlayerMove.Up;
            a = 0; b = -1;
        }
        else
        {
            nextDirection = Define.PlayerMove.Down;
            a = 0; b = 1;
        }
    }

    IEnumerator ActiveDamageField(GameObject go)            //코루틴이 다음과 같이 선언됩니다.
    {
        Debug.Log("Grid tile Collider Activatied");
        PolygonCollider2D poly = go.GetComponent<PolygonCollider2D>();
        poly.enabled = true;                                //Damage영역 collider 활성화(잠깐)
        yield return new WaitForFixedUpdate();              //yield 반환 라인은 실행이 일시 중지되고 다음 프레임에서 다시 시작되는 지점
        poly.enabled = false;
    }

    protected virtual void AutoBitBehave() { }

    //오버라이드 되어야 할 함수
    //MyPlayer와 위치가 가까워지도록 다음 방향 설정
    protected virtual void SelectNextDirection() { }

    protected virtual void AutoWarningAttack(Define.PlayerMove nextDirection) { }

    protected virtual void AutoAttack(Define.PlayerMove nextDirection) { }
    
    protected virtual void Die() { }
}
