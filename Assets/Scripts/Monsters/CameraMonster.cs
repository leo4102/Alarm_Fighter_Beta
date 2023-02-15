using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMonster : Character
{
    Define.State nextBehavior = Define.State.SPAWN;                     

    [SerializeField] List<GameObject> horizontalMons = new List<GameObject>();      //가로 공격 몬스터용
    [SerializeField] GameObject verticalMon;                                        //세로 공격 몬스터용
    [SerializeField] GameObject randomMon;                                          //랜덤 공격 몬스터용
    
    //[SerializeField] List<GameObject> verticalMons = new List<GameObject>();       
    //[SerializeField] List<GameObject> randomMons = new List<GameObject>();

    void Start()
    {
        Managers.Timing.BehaveAction -= BitBehave;      //몬스터의 비트 마다 실행할 BitBehave 구독
        Managers.Timing.BehaveAction += BitBehave;
    }

    void BitBehave()
    {
        switch (nextBehavior)
        {
            case Define.State.SPAWN:

                //세로 공격 몬스터 스폰
                if (Managers.Game.CurrentVMons.Count < 2) //필드에 2개 이상 만들어지지 않음
                {
                    //SpawnVerticalMonster(verticalMon);
                }

                //가로 공격 몬스터 스폰
                if (Managers.Game.CurrentHMons.Count < 1) //필드에 1개 이상 만들어지지 않음
                {
                    //SpawnHorizontalMonster();
                }

                //랜덤 공격 몬스터 스폰
                if (Managers.Game.CurrentRMons.Count < 1) //필드에 1개 이상 만들어지지 않음
                {
                    SpawnRandomMonster(randomMon);
                }

                nextBehavior = Define.State.NOTSPAWN;
                break;


            case Define.State.NOTSPAWN:

                nextBehavior = Define.State.SPAWN;
                break;

        }
    }

    private void SpawnVerticalMonster(GameObject prefab)        
    {
        GameObject go = Instantiate<GameObject>(prefab);
        Managers.Game.CurrentVMons.Add(go);
    }

    private void SpawnHorizontalMonster()
    {
        int rand = UnityEngine.Random.Range(0, horizontalMons.Count);
        GameObject go = Instantiate<GameObject>(horizontalMons[rand]);
        Managers.Game.CurrentHMons.Add(go);
    }

    private void SpawnRandomMonster(GameObject prefab)
    {
        GameObject go = Instantiate<GameObject>(prefab);
        Managers.Game.CurrentRMons.Add(go);
    }


 
    private void OnTriggerEnter2D(Collider2D collision)                 //Player의 공격으로 인해서 몬스터가 활성화된 grid에 닿을 경우
    {

    }

}