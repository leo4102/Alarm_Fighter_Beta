using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBox : MonoBehaviour
{
    Weapon weapon;
    int numOfAttack;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public void SetNumOfAttack()
    {
        Define.ItemRank rank = weapon.Rank;
        switch(rank)
        {
            case Define.ItemRank.Normal:
                numOfAttack = Random.Range(2, 4);
                break;
            case Define.ItemRank.Rare:
                numOfAttack = Random.Range(1, 3);
                break;
            case Define.ItemRank.Epic:
                numOfAttack = Random.Range(1, 2);
                break;
        }
    }

    public void SetLocation(int x, int y)
    {
        Vector3 pos = Managers.Field.GetGrid(x, y).transform.position;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.CompareTag("Player"))
        {
            if (go.GetComponent<WeaponInfo>() != null)
            {
                go.GetComponent<WeaponInfo>().AddWeapon(weapon);
            }
        }
    }
}
