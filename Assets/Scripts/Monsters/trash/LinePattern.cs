using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePattern : MonsterPattern
{
    public override int[] calculateIndex(int currentInd)        //(몬스터 gird 기준)currentInd 포함 위로 2칸 grid의 인덱스(전체 grid기준) 배열 반환
    {
        int[] pattern = new int[3];
        int gridIndex = GetGridIndex(currentInd);
        for(int i = 0; i < 3; i++)
        {
            gridIndex -= 3;
            pattern[i] = gridIndex;

        }
        return pattern;
    }
}
