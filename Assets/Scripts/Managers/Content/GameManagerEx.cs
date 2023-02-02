using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEx
{
    int MonsterCount;           //몬스터 개수        //어디서 초기화? GameSCene 스크립트 Init()서
    public GameObject CurrentPlayer { get; set; }
    public void GameOver()      //주인공 죽음
    {
        Managers.Clear();
        Managers.Sound.Clear();     //불필요?
        Managers.Scene.LoadScene("GameOver");
        //Managers.Sound.Play("GameClear", Define.Sound.Bgm);     //GameClear이 없는데?그리고 경로에 Asset>Resources 불필요?
    }
    public void StageClear()       //몬스터 죽음
    {
        Managers.Clear();
        Managers.Scene.LoadScene("StageClear");
        Managers.Sound.Clear();     //불필요?
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
    public void CheckLeftMonster()      //남은 몬스터가 없다면 스테이지 클리어  //GameScene Update()문에서 호출
    {
        if (MonsterCount <= 0)
            StageClear();
    }
  
}

