using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterAttackManager
{
    #region CameraAttackPatterns
    public void LazerAttack(Transform transform,int where)//Lazer attack where is row, start  = monster eye, where = row
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/AttackEffects/Lazer1");
        go.GetComponent<CameraLazer>().SetTarget(transform);
    }

    #endregion
}
