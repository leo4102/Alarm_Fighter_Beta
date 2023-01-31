using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEx
{
    int MonsterCount;
    public GameObject CurrentPlayer { get; set; }
    public void GameOver()
    {
        Managers.Clear();
        Managers.Sound.Clear();
        Managers.Scene.LoadScene("GameOver");
        //Managers.Sound.Play("GameClear", Define.Sound.Bgm);
    }
    public void StageClear()
    {
        Managers.Clear();
        Managers.Scene.LoadScene("StageClear");
        Managers.Sound.Clear();
       // Managers.Sound.Play("GameClear", Define.Sound.Bgm);
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
    public void CheckLeftMonster()
    {
        if (MonsterCount <= 0)
            StageClear();
    }
}

