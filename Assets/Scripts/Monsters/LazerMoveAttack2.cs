using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMoveAttack2 : MonoBehaviour       //Lazer(Child)
{
    Transform effect;       //Lazer_Boom(Parent)
    Transform transform_my;
    Transform transform_target;

    private void Start()
    {
        effect = transform.parent;
        //effect = transform.GetChild(0);
        Managers.MonsterAttack.SetBasicScale(gameObject);
    }
    void Update()
    {
        transform.position = Managers.Monster.BossMonster.transform.position;
        transform_my = this.transform;
        transform_target = effect;
        
        Managers.MonsterAttack.SetRotation(gameObject, transform_my, transform_target); 
    }
}
