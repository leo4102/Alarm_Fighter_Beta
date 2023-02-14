using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class GameManagerEx
{
    int MonsterCount;           //���� ����        //��� �ʱ�ȭ? GameSCene ��ũ��Ʈ Init()��
    public GameObject CurrentPlayer { get; set; }

    //public List<GameObject> CurrentVMons = new List<GameObject>();     //현재 필드에 나와있는 세로 공격형 몬스터 수       //gamemanagers 로 보냄
    //public List<GameObject> CurrentHMons = new List<GameObject>();     //현재 필드에 나와있는 가로 공격형 몬스터 수
    //public List<GameObject> CurrentRMons = new List<GameObject>();     //현재 필드에 나와있는 랜덤 공격형 몬스터 수

    public List<Component> CurrentVMons = new List<GameObject>();
    public List<GameObject> CurrentHMons = new List<GameObject>();
    public List<GameObject> CurrentRMons = new List<GameObject>();
    
    public void GameOver()      //���ΰ� ���
    {
        Managers.Clear();
        Managers.Sound.Clear();     //���ʿ�?
        Managers.Scene.LoadScene("GameOver");

        //Managers.Sound.Play("GameClear", Define.Sound.Bgm);     //GameClear�� ��µ�?�׸��� ��ο� Asset>Resources ���ʿ�?

    }
    public void StageClear()       //���� ���
    {
        Managers.Clear();
        Managers.Scene.LoadScene("StageClear");

        Managers.Sound.Clear();     //���ʿ�?
        //Managers.Sound.Play("GameClear", Define.Sound.Bgm);

    }
    public void SetMonsterCount(int num)        
    {
        MonsterCount = num;
    }
    public void MinusMonsterNum()
    {
        MonsterCount--;
    }
    public int GetCurrentMonsterNum()
    {
        return MonsterCount;
    }
    public void CheckLeftMonster()      //��� ���Ͱ� ��ٸ� �������� Ŭ����  //GameScene Update()������ ȣ��
    {
        if (MonsterCount <= 0)
            StageClear();
    }
  /* public bool CheckFrontObject(int move_X,int move_Y)
    {
        int player_X = Managers.Player.GetCurrentX();
        int player_Y = Managers.Player.GetCurrentY();

        if (player_X == move_X && player_Y == move_Y) 
            return false;

        for (int i = 0; i < CurrentVMons.Count; i++)
        {
            CurrentVMons[i].move_X= 
        }

        for (int i = 0; i < CurrentHMons.Count; i++)
        {

        }
        for (int i = 0; i < CurrentRMons.Count; i++)
        {

        }
    }*/

    public bool CheckFrontObject(int move_X, int move_Y)
    {
        {
            int player_X = Managers.Player.GetCurrentX();
            int player_Y = Managers.Player.GetCurrentY();
            
            if (player_X == move_X && player_Y == move_Y)
                return false;
            for (int i = 0; i < CurrentVMons.Count; i++)
            {
                string str = CurrentVMons[i].name;
                Types type = (Types)str;
                if (CurrentVMons[i].GetComponent<HorizontalAttack>().GetMonsterInd_X() == move_X && CurrentVMons[i].GetComponent<HorizontalMonster>().GetMonsterInd_Y() == move_Y)
                    return false;
            }
            for (int i = 0; i < CurrentHMons.Count; i++)
            {
                if (CurrentHMons[i].GetComponent<Monster>().GetCurrentX() == move_X && CurrentHMons[i].GetComponent<Monster>().GetCurrentY() == move_Y)
                    return false;
            }
            for (int i = 0; i < CurrentRMons.Count; i++)
            {
                if (CurrentRMons[i].GetComponent<Monster>().GetCurrentX() == move_X && CurrentRMons[i].GetComponent<Monster>().GetCurrentY() == move_Y)
                    return false;
               
            }
            
            return true;
        }
    }




}

