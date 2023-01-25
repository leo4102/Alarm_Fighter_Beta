using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePattern : MonsterPattern
{
    public override int[] calculateIndex(int currentInd)
    {
        int[] pattern = new int[3];
        for(int i = 0; i < 3; i++)
        {
            currentInd += 3;
            pattern[i] = currentInd;

        }
        return pattern;
    }
}
