using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackPatterns : MonoBehaviour 
{
    int width = Managers.Field.GetWidth();
    int height = Managers.Field.GetHeight();

    public enum Line
    {
        Row,
        Col,
    }

    private void Attack(int x,int y)
    {
        if(x>=width||y>=height||x<0||y<0)
        {
            Debug.Log("In MonsterAttackPatterns, Out Of Index");
            return;
        }

        Managers.Field.ChangeGrid(x, y, Define.GridState.Attack);
    }
    
    public void LineAttack(Line line, int where)// ex) row , 2 attack
    {
        if(where > 2 || where < 0) { Debug.Log("MonsterAttackPatterns LineAttack Out Of Index!"); return; }

        switch(line) 
        { 
            case Line.Row:
                for(int i = 0; i < width; i++) { Attack(i, where); }
                break;

            case Line.Col:
                for(int i = 0; i < height; i++) { Attack(where, i); }
                break;
        }

    }
    public void RandomAttack(int x1, int x2, int y1, int y2, int num)//in range x1<=X<=x2, y1<=X<=y2, how many attack num
    {
        if (x1 < 0 || x2 < 0 || y1 < 0 || y2 < 0 || x1 > x2 || y1 > y2) { Debug.Log("MonsterAttackPatterns RandomAttack range out of index"); return; }
        if (width - 1 < x2 || height - 1 < y2) { Debug.Log("MonsterAttackPatterns RandomAttack range out of index"); return; }
        for (int i = 0; i < num; i++)
        {
            int x = Random.Range(x1, x2+1);
            int y = Random.Range(y1, y2+1);
            Attack(x, y);
        }
    }
    public void PlayerIndexAttack()
    {
        int x=Managers.Player.GetCurrentX();//current Player index
        int y= Managers.Player.GetCurrentY();//current Player index
        Attack(x, y);
    }
    
}
