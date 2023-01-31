using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    int monsterIndex = 0;

    int maxMonsterNum;
    [SerializeField]
    List<string> monsters = new List<string>();
    [SerializeField]
    GameObject backGround;
    int GetMaxMonsterNum() { return maxMonsterNum; }
    void SetMaxMonsterNum() { maxMonsterNum = monsters.Count; }
    public override void Clear()
    {
        Managers.Timing.Clear();
        monsters.Clear();
        monsterIndex = 0;
    }
    protected override void Init()
    {
        base.Init();
        SetMaxMonsterNum();
        Managers.Game.SetMonsterCount(maxMonsterNum);
        SoundBgmPlay();
        SponeMonster();
        SponeBackGround();
        SponeNoteBar();
        SponePlayer();
        SponeField();
    }
    public void Update()
    {
        Managers.Timing.UpdatePerBit();
        Managers.Game.CheckLeftMonster();
    }
    private void SponeMonster()
    {
        GameObject go = Managers.Resource.Instantiate(monsters[monsterIndex]) as GameObject;
    }
    private void SponeBackGround()
    {
        GameObject go = Instantiate(backGround) as GameObject;
        go = Instantiate<GameObject>(go) as GameObject;
    }
    private void SponeNoteBar()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/NoteBar/NoteBar");
        go = Instantiate(go) as GameObject;
    }
    private void SponePlayer()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Player/Player");
        go = Instantiate<GameObject>(go) as GameObject;
        Managers.Game.CurrentPlayer = go;
    }
    private void SponeField()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Fields/Field");
        go = Instantiate<GameObject>(go) as GameObject;
    }
    public void NextMonsterIndex()
    {
        if (monsterIndex < maxMonsterNum - 1)
        {
            monsterIndex++;
            SponeMonster();
        }
    }
}
