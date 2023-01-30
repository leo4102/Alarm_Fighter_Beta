using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEx 
{
    int MonsterCount;

    public void GameOver()
    {
        Managers.Clear();
        Managers.Scene.LoadScene("GameOver");
    }
    public void StageClear()
    {
        Managers.Clear();
        Managers.Scene.LoadScene("StageClear");
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
        if(MonsterCount<=0)
            StageClear();
    }
}

