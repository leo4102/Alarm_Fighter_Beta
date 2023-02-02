using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterPattern        //LinePattern(스크립트)가 상속 받는다
{
    public abstract int[] calculateIndex(int currentInd);

    protected int GetGridIndex(int index)
    {
        return index + 9;
    }

}
