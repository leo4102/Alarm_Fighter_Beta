using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    [SerializeField]
    int maxMonsterNum;
    [SerializeField]
    List<GameObject> monsters = new List<GameObject>();
    int monsterIndex = 0;
    //[SerializeField]
    //AudioClip BGM;
    int GetMaxMonsterNum() { return maxMonsterNum; }
    public override void Clear()
    {
        monsters.Clear();
        monsterIndex= 0;
    }

    protected override void Init()
    {
        base.Init();
        Managers.Game.SetMonsterCount(maxMonsterNum);
        PlaySound();
        SponeMonster();
    }
    public void Update()
    {
        Managers.Timing.UpdatePerBit();
        Managers.Game.CheckLeftMonster();
    }
    public void PlaySound()
    {
        Managers.Sound.Play("BGM",Define.Sound.Bgm,1.0f,0.2f);
    }
    public void SponeMonster()
    {
        GameObject go = Instantiate(monsters[monsterIndex]) as GameObject;
    }
    public void NextMonsterIndex()
    {
        if (monsterIndex < maxMonsterNum-1)
        {
            monsterIndex++;
            SponeMonster();
        }
    }
}
