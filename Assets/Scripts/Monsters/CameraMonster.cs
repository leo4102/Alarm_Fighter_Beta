using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMonster : Character
{
    Define.State nextBehavior = Define.State.SPAWN;                     

    [SerializeField] List<GameObject> horizontalMons = new List<GameObject>();      //���� ���� ���Ϳ�
    [SerializeField] GameObject verticalMon;                                        //���� ���� ���Ϳ�
    [SerializeField] List<GameObject> randomMons = new List<GameObject>();
    
    //[SerializeField] List<GameObject> verticalMons = new List<GameObject>();       
    //[SerializeField] GameObject randomMon;                                          //���� ���� ���Ϳ�

    void Start()
    {
        Managers.Timing.BehaveAction -= BitBehave;      //������ ��Ʈ ���� ������ BitBehave ����
        Managers.Timing.BehaveAction += BitBehave;
    }

    void BitBehave()
    {
        switch (nextBehavior)
        {
            case Define.State.SPAWN:

                //���� ���� ���� ����
                if (Managers.Monster.CurrentVMons.Count < 2) //�ʵ忡 2�� �̻� ��������� ����
                {
                    //SpawnVerticalMonster(verticalMon);
                }

                //���� ���� ���� ����
                if (Managers.Monster.CurrentHMons.Count < 1) //�ʵ忡 1�� �̻� ��������� ����
                {
                    //SpawnHorizontalMonster();
                }

                //���� ���� ���� ����
                if (Managers.Monster.CurrentRMons.Count < 3) //�ʵ忡 1�� �̻� ��������� ����
                {
                    SpawnRandomMonster( );
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
        Managers.Monster.CurrentVMons.Add(go);
    }

    private void SpawnHorizontalMonster()
    {
        int rand = UnityEngine.Random.Range(0, horizontalMons.Count);
        GameObject go = Instantiate<GameObject>(horizontalMons[rand]);
        Managers.Monster.CurrentHMons.Add(go);
    }

    private void SpawnRandomMonster( )
    {
        //int rand = UnityEngine.Random.Range(0, randomMons.Count);
        //GameObject go = Instantiate<GameObject>(randomMons[rand]);

        GameObject go = Instantiate<GameObject>(randomMons[0]);
        Managers.Monster.CurrentRMons.Add(go);
    }


 
    private void OnTriggerEnter2D(Collider2D collision)                 //Player�� �������� ���ؼ� ���Ͱ� Ȱ��ȭ�� grid�� ���� ���
    {

    }

}