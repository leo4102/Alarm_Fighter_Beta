using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTest : FieldObject
{
    double currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        // type을 초기화하고 objectField를 받아온 뒤, objectList에 PlayerField를 받아온다.
        type = 2;
        objectField = Managers.Field.getField();
        objectList = objectField.getGridArray(type);

        currentInd = objectList.Count - (objectList.Count / 2); // player와 마찬가지로 맨 위의 열 중앙에 오게하는 초기화이다. (1.18 재윤 추가)
        transform.position = objectList[currentInd].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 60d / Managers.Bpm.BPM)
        {
            BitBehave();
            currentTime -= 60d / Managers.Bpm.BPM;
        }
    }
    protected override void BitBehave()
    {
        // 동작의 무작위성을 위해 randNum 도입 (1.17 재윤 추가) -> 이 부분은 몬스터에 따라 다르게 구현하면 되는 부분이므로 변경 가능성 농후
        int randNum = Random.Range(0, 5);
        if(randNum == 0)
        {
            mayGo(Define.PlayerMove.Up);
        }
        else if(randNum == 1)
        {
            mayGo(Define.PlayerMove.Down);
        }
        else if (randNum == 2)
        {
            mayGo(Define.PlayerMove.Left);
        }
        else if (randNum == 3)
        {
            mayGo(Define.PlayerMove.Right);
        }
        else if(randNum == 4)
        {

        }
        else
        {

        }
    }

    protected override void Attack()
    {

    }

    void AttackReady()
    {

    }

    protected override void Hit()
    {

    }
}
