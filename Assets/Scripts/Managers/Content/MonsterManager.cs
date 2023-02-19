using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{

    private GameObject bossMonster;

    public List<GameObject> CurrentVMons = new List<GameObject>();     //현재 필드에 나와있는 세로 공격형 몬스터 수      
    public List<GameObject> CurrentHMons = new List<GameObject>();     //현재 필드에 나와있는 가로 공격형 몬스터 수
    public List<GameObject> CurrentRMons = new List<GameObject>();     //현재 필드에 나와있는 랜덤 공격형 몬스터 수
    
    /*public List<Component> CurrentVMons = new List<GameObject>();
    public List<GameObject> CurrentHMons = new List<GameObject>();
    public List<GameObject> CurrentRMons = new List<GameObject>();*/

    //----------------------------------------------------------------
    public GameObject BossMonster
    {
        get { return bossMonster; }
        set { bossMonster = value; }
    }
    public int GetCurrent_X(GameObject monster)
    {
        return monster.GetComponent<MiniMonster_Parent>().GetCurrent_X();
    }

    public int GetCurrent_Y(GameObject monster)
    {
        return monster.GetComponent<MiniMonster_Parent>().GetCurrent_Y();
    }

    public int GetMove_X(GameObject monster)
    {
        return monster.GetComponent<MiniMonster_Parent>().GetMove_X();
    }

    public int GetMove_Y(GameObject monster)
    {
        return monster.GetComponent<MiniMonster_Parent>().GetMove_Y();
    }

    public void AddCurrentVMons(GameObject go) { CurrentVMons.Add(go); }
    public void AddCurrentHMons(GameObject go) { CurrentHMons.Add(go); }
    public void AddCurrentRMons(GameObject go) { CurrentRMons.Add(go); }


    public void RemoveCurrentVMons(GameObject go) { CurrentVMons.Remove(go); }
    public void RemoveCurrentHMons(GameObject go) { CurrentHMons.Remove(go); }
    public void RemoveCurrentRMons(GameObject go) { CurrentRMons.Remove(go); }



    //checks if minimonster can move to a certain grid(available to move == no player or minimonster in  front )
    public bool CheckFrontObject(int move_X, int move_Y)        //(if Object in front == return true)
    {
        int player_X = Managers.Player.GetCurrentX();
        int player_Y = Managers.Player.GetCurrentY();

        if (player_X == move_X && player_Y == move_Y)
            return true;

        for (int i = 0; i < CurrentVMons.Count; i++)
        {
            if(GetCurrent_X(CurrentVMons[i]) == move_X && GetCurrent_Y(CurrentVMons[i]) == move_Y)
                return true;
        }

        for (int i = 0; i < CurrentHMons.Count; i++)
        {
            if (GetCurrent_X(CurrentHMons[i]) == move_X && GetCurrent_Y(CurrentHMons[i]) == move_Y)
                return true;
        }
        
        for (int i = 0; i < CurrentRMons.Count; i++)
        {
            if (GetCurrent_X(CurrentRMons[i]) == move_X && GetCurrent_Y(CurrentRMons[i]) == move_Y)
                return true;
        }

        return false;
    }

}
