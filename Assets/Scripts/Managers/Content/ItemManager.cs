using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    List<Weapon> weaponList;


    public void WeaponSpawn(int x, int y)
    {
        GameObject weapon = Managers.Resource.Instantiate("Items/ItemBoxes/WeaponBox");
        WeaponBox wpSet = weapon.GetComponent<WeaponBox>();

        wpSet.SetWeapon(NextWeapon());
        wpSet.SetNumOfAttack();
        wpSet.SetLocation(x, y);

    }

    public void Init()
    {
        SetWeaponList();
    }

    public void SetWeaponList()
    {
        //to do : player 캐릭터에 따라 weaponList 바뀌게
        weaponList = new List<Weapon>();
        weaponList.Add(new Sword());
    }

    Weapon NextWeapon()
    {
        //to do : 확률에 따라 다음 weapon 결정
        return weaponList[0];
    }

}
