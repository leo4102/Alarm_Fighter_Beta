using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 이 클래스는 PlayerText클래스이며 FieldObject를 상속받아 생성. FieldObject가 MonoBehaviour를 상속받고 있다. (1.17 재윤 추가)
public class PlayerTest : FieldObject
{
    
    // Start is called before the first frame update
    void Start()
    {
        // type을 초기화하고 objectField를 받아온 뒤, objectList에 PlayerField를 받아온다.
        type = 1;
        objectField = Managers.Field.getField();
        objectList = objectField.getGridArray(type);
        
        currentInd = 0;
        // 이  객체의 위치를 일단은 0 인덱스의 타일에 초기화
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectList[currentInd].transform.position;
    }
}
