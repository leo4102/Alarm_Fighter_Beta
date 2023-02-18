using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : Stat
{
    void Start()
    {
        MaxHP = 30f;
        CurrentHP = 30f;

        GetComponent<HpBarUpdater>().hpbar.maxValue = MaxHP;
    }

    
}