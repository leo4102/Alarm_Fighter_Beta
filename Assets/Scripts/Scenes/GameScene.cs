using System;
using System.Collections.Generic;
using UnityEngine;

//spone?sponsor?

public class GameScene : BaseScene
{
    int monsterIndex = 0;           //���� ���� �ε���(����� ��)
    int maxMonsterNum;              //�ִ� ���� ��      //monsters(List).Count �� �ʱ�ȭ��

    [SerializeField]

    List<GameObject> monsters = new List<GameObject>();     //��� �ʱ�ȭ? Inspectorâ�� ���콺 �巡��


    [SerializeField]
    GameObject backGround;

    int GetMaxMonsterNum() { return maxMonsterNum; }
    void SetMaxMonsterNum() { maxMonsterNum = monsters.Count; }

    public override void Clear()
    {
        Managers.Timing.Clear();
        monsters.Clear();
        monsterIndex = 0;       //?????
    }

    protected override void Init()
    {
        base.Init();            //base�� �θ� Ŭ������ �ǹ�
        SetMaxMonsterNum();
        Managers.Game.SetMonsterCount(maxMonsterNum);
        //SoundBgmPlay();         //BaseScene�� ���
        SponeMonster();
        SponeBackGround();
        SponeNoteBar();
        SponePlayer();
        SponeField();
        SponeMoveButton();
        SpawnPlayerHpBar();
        SpawnMonsterHpBar();
        SpawnMonsterHpBarMiddle();
        Managers.Item.Init();
        Managers.Resource.Instantiate("Items/ItemBoxes/@GridBaseSpawn");
        Managers.Menu.Init();
    }

   
    public void Update()
    {
        Managers.Timing.UpdatePerBit();         //�� ��Ʈ���� ���� �ൿ ����Ʈ
        Managers.Game.CheckLeftMonster();       //��� ���Ͱ� ����ϴ��� Ȯ��
    }
    private void SponeMonster()                 //Ư�(monsterIndex) �ε��� ��° ���� ��
    {
        if (monsters.Count == 0) return;
        GameObject go = Instantiate(monsters[monsterIndex]) as GameObject;
    }
    private void SponeBackGround()              //
    {
        GameObject go = Instantiate(backGround) as GameObject;      //
        //go = Instantiate<GameObject>(go) as GameObject;     //?????
    }
    private void SponeNoteBar()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Notes/NoteBar/NoteBar");
        go = Instantiate(go) as GameObject;
    }
    private void SponePlayer()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Players/Player");
        go = Instantiate<GameObject>(go) as GameObject;
        Managers.Player.SetPlayer(go.GetComponent<Character>());
        Managers.Game.CurrentPlayer = go;
    }
    private void SponeField()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Fields/RoundField1");
        go = Instantiate<GameObject>(go) as GameObject;
        Managers.Field.SetField(go.GetComponent<RoundField>());
        Managers.Field.Init();
    }
    private void SponeMoveButton()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/UI/MoveButton");
        go = Instantiate<GameObject>(go) as GameObject;

    }

    private void SpawnPlayerHpBar()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/UI/PlayerHpBar");
        go = Instantiate<GameObject>(go) as GameObject;
        //GameObject go2 = Managers.Resource.Instantiate("Prefabs/UI/PlayerHpBar");
    }

    private void SpawnMonsterHpBar()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/UI/MonsterHpBar");
        go = Instantiate<GameObject>(go) as GameObject;
        //GameObject go1 = Managers.Resource.Instantiate("Prefabs/UI/MonsterHpBar");
    }
    private void SpawnMonsterHpBarMiddle()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/UI/HpBarMiddle");
        go = Instantiate<GameObject>(go) as GameObject;
        //GameObject go1 = Managers.Resource.Instantiate("Prefabs/UI/HpBarMiddle");
    }

    public void NextMonsterIndex()                          //��� ���� ��
    {
        if (monsterIndex < maxMonsterNum - 1)
        {
            monsterIndex++;
            SponeMonster();
        }
    }
}
