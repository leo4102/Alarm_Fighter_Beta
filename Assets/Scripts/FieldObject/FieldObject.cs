using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// 이 클래스는 FieldObject이며, Player와 Monster에게 상속될 부모 클래스이다. (1.17 재윤 추가)
public abstract class FieldObject : MonoBehaviour
{
    // 상속 받을 수 있도록 protected로 접근 지정자 지정
    protected int currentInd; // 현재 위치한 타일의 인덱스 
    protected int type = 0; // 이 FieldObject 클래스를 상속 받은 서브클래스의 타입 (type : 1 -> 플레이어 / type : 2 -> 몬스터)
    protected Field objectField; // Scene에 생성된 Field를 담을 수 있는 Field형 변수
    protected List<GameObject> objectList; // Field로 부터 받아온 타일의 리스트 -> 이 클래스를 상속 받은 클래스의 Start에서 초기화 해줌.
    
    enum Direction { UP, DOWN, LEFT, RIGHT} // UP == 0, DOWN  == 1, LEFT == 2, RIGHT == 3
    // mayGo 함수 -> 플레이어의 위치를 옮겨주며 direction을 매개변수로 받는다.
    void mayGo(Direction direction)
    {
        try
        {
            // 플레이어가 다음에 위치할 타일의 인덱스
            int moveInd = 0;
            if (direction == Direction.UP)
                moveInd = currentInd + objectField.getWidth();
            else if (direction == Direction.DOWN)
                moveInd = currentInd - objectField.getHeight();
            else if (direction == Direction.LEFT)
            {
                if (currentInd % objectField.getWidth() == 0)
                    return;
                moveInd = currentInd - 1;
            }
            else if (direction == Direction.RIGHT)
            {
                if (currentInd % objectField.getWidth() == objectField.getWidth() - 1)
                    return;
                moveInd = currentInd + 1;
            }
            // transform.position을 통해 위치를 옮겨줘야 함. -> 이때 objectList에 접근할 때 IndexOutOfRange가 나온다면 옮길 수 없는 상황이므로 예외 처리
            transform.position = objectList[moveInd].transform.position;
            currentInd = moveInd;
        }
        catch (IndexOutOfRangeException e)  // 로그를 찍고, 움직이지 않으며 return
        {
            Debug.Log(e);
            return;
        }
    }
    // BitBehave() -> 정의해줘야 함.
    void BitBehave()
    {

    }
}
