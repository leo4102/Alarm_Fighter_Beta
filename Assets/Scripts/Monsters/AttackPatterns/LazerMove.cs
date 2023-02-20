using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMove : MonoBehaviour      
{
    Transform effect;      
    Transform transform_my;
    Transform transform_target;

    private void Start()
    {
        GameObject effectObject = Util.FindChild(transform.root.gameObject, "Lazer_Boom");
        effect = effectObject.transform;
        Managers.MonsterAttack.SetBasicScale(gameObject);
    }
    void Update()
    {                       
        transform.position = Managers.Monster.BossMonster.transform.position;
        transform_my = this.transform;
        transform_target = effect;

        try
        {
           Managers.MonsterAttack.SetRotation(gameObject, transform_my, transform_target); 
        }
        catch(MissingReferenceException)
        {
            Destroy(gameObject);
        }
    }
}
