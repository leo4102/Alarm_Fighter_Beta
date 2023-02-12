using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public Sword()
    {
        weaponObject = Managers.Resource.Load<GameObject>("Prefabs/Items/Weapons/Sword");
        Rank = Define.ItemRank.Normal;
    }
    // Start is called before the first frame update
}
