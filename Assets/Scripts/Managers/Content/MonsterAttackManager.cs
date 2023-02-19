using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



public class MonsterAttackManager
{
    #region CameraAttackPatterns

    public void LazerAttack(Transform transform,int x,int y)//Lazer attack where is row, start  = monster eye, where = row
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/AttackEffects/Lazer");
        GameObject effect = Managers.Resource.Load<GameObject>("Prefabs/Monsters/AttackEffects/Lazer_Boom");

        go.transform.position = transform.position;
        SetBasicScale(go);
        Transform transform_my = go.transform;
        Transform transform_target = SetTarget(x,y);
        effect.transform.position = SetEffect(x, y);
        SetRotation(go,transform_my,transform_target);
        go = Managers.Resource.Instantiate("Monsters/AttackEffects/Lazer");
        go = Managers.Resource.Instantiate("Monsters/AttackEffects/Lazer_Boom");

    }
    #region LazerAttack_Private
    private void SetBasicScale(GameObject go)
    {
        float x = 10.0f;
        float y = go.transform.localScale.y;
        float z = go.transform.localScale.z;
        go.transform.localScale = new Vector3(x,y,z);
    }
    private Transform SetTarget(int x, int y)
    {
        return Managers.Field.GetGrid(x, y).transform;
    }
    private void UpdateScale(GameObject go, Vector3 vector)
    {
        float vectorX = go.transform.localScale.x;
        float vectorY = -vector.magnitude;
        float vectorZ = vector.z;
        go.transform.localScale = new Vector3(vectorX, vectorY, vectorZ);
    }
    private void SetRotation(GameObject go,Transform transform_my,Transform transform_target)
    {
        Vector3 myPos = transform_my.position;
        Vector3 targetPos = transform_target.position;
        targetPos.z = myPos.z;

        Vector3 vectorToTarget = targetPos - myPos;
        UpdateScale(go,vectorToTarget);

        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: vectorToTarget);
        transform_my.rotation = targetRotation;

        //transform_my.rotation = Quaternion.RotateTowards(transform_my.rotation, targetRotation, speed * Time.deltaTime);
    }
    private Vector3 SetEffect(int x, int y)
    {
        return Managers.Field.GetGrid(x, y).transform.position;
    }
    #endregion
    #endregion
}
