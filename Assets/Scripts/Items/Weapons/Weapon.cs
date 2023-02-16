using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon 
{
    public Define.ItemRank Rank { get; protected set; }
    int attackRange;
    int numOfAttack;
    AnimationClip attackAnim;
    protected GameObject weaponObject;
    int Damage;

    public virtual void Attack()
    {
        //to do : ¿Ã∆Â∆Æ º“»Ø
    }

    public void WeaponDestroy()
    {

    }
    
    public virtual int[] CalculateAttackRange(int row, int column)
    {
        return new int[0];
    }

    public void Mount(GameObject parent)
    {
        GameObject go = Object.Instantiate(weaponObject);
        Managers.Field.ScaleByRatio(go, Managers.Player.GetCurrentX(), Managers.Player.GetCurrentY());
        go.transform.SetParent(parent.transform);
        go.transform.localPosition = Vector3.zero;
    }
}
