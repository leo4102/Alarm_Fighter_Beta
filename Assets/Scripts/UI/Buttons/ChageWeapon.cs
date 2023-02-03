using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageWeapon : MonoBehaviour            //WeaponChange(GameObject)산하의 버튼들에 삽입됨
{
    public void toWoodSword()
    {
        GameObject go = Managers.Game.CurrentPlayer;
        Destroy(go.GetComponent<Weapon>());         //Player(clone)(GameObject)에 Weapon을 상속 받은 무기 스크립트가 반환

        go.AddComponent<WoodSword>();
    }

    public void toDiaSword()
    {
        GameObject go = Managers.Game.CurrentPlayer;

        Destroy(go.GetComponent<Weapon>());

        go.AddComponent<Sword>();

    }
}
