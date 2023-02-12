using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    Weapon currentWeapon;
    Queue<Weapon> weaponList = new Queue<Weapon>();
    public Weapon CurrentWeapon
    {
        get { return currentWeapon; }
        set
        {
            currentWeapon = value;
            AttachWeapon();
        }
    }



    public void AddWeapon(Weapon weapon)
    {
        weaponList.Enqueue(weapon);
        if (currentWeapon == null)
            SwitchWeapon();

    }

    void Update()
    {
        if(CheckWeaponDestory())
        {
            SwitchWeapon();
        }
    }

    bool CheckWeaponDestory()
    {
        return false;
    }

    void SwitchWeapon()
    {
        CurrentWeapon = weaponList.Peek();
        AttachWeapon();
    }

    void AttachWeapon()
    {
        GameObject hand = Util.FindChild(gameObject, "Hand");
        currentWeapon.Mount(hand);
    }



}
