using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class GameManagerEx
{
    int MonsterCount;

    public GameObject CurrentPlayer { get; set; }

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

    public int GetCurrentMonsterNum()
    {
        return MonsterCount;
    }

    public void MinusMonsterNum()
    {
        MonsterCount--;
    }

    public void CheckLeftMonster()      //��� ���Ͱ� ��ٸ� �������� Ŭ����  //GameScene Update()������ ȣ��
    {
        if (MonsterCount <= 0)
            StageClear();
    }

}

