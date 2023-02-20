using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;



public class MonsterAttackManager
{
    #region CameraAttackPatterns

    public void LazerAttack(Transform transform,int x,int y)//Lazer attack where is in grid(x,y), start  = monster eye, where = (x,y)
    {
        LazerInit(transform ,x, y);
    }
    #region LazerAttack_Private
    private void LazerInit(Transform transform, int x, int y)
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/AttackEffects/Lazer");
        GameObject effect = Managers.Resource.Load<GameObject>("Prefabs/Monsters/AttackEffects/Lazer_Boom");

        go.AddComponent<Lazer>();
        effect.AddComponent<Lazer_Boom>();
        
        go.transform.position = transform.position;
        SetBasicScale(go);
        Transform transform_my = go.transform;
        Transform transform_target = SetTarget(x, y);
        effect.transform.position = SetEffect(x, y);
        SetRotation(go, transform_my, transform_target);
        go = Managers.Resource.Instantiate("Monsters/AttackEffects/Lazer");
        go = Managers.Resource.Instantiate("Monsters/AttackEffects/Lazer_Boom");
    }
    public void SetBasicScale(GameObject go)        //Change private to public
    { 
        float x = 10.0f;
        float y = go.transform.localScale.y;
        float z = go.transform.localScale.z;
        go.transform.localScale = new Vector3(x, y, z);
    }
    public Transform SetTarget(int x, int y)        //Change private to public
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
    public void SetRotation(GameObject go,Transform transform_my,Transform transform_target)    //Change private to public
    {
        Vector3 myPos = transform_my.position;
        Vector3 targetPos = transform_target.position;
        targetPos.z = myPos.z;
        
        Debug.Log("mypos: " + myPos);
        Debug.Log("targetPos: " + targetPos);
        
        Vector3 vectorToTarget = targetPos - myPos;
        UpdateScale(go,vectorToTarget);

        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: vectorToTarget);
        transform_my.rotation = targetRotation;


        //transform_my.rotation = Quaternion.RotateTowards(transform_my.rotation, targetRotation, 100 * Time.deltaTime);
    }
    private Vector3 SetEffect(int x, int y)
    {
        return Managers.Field.GetGrid(x, y).transform.position;
    }
    #endregion
    //
    public void LazerMoveAttack(Transform transform, int where=0, int speed = 500)//Lazer move attack where is row, start = monster eye, where = row
    {
        LazerMoveInit(transform, where, speed);
    }
    #region LazerMoveAttack_Private
    private void LazerMoveInit(Transform transform, int where,int speed)
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/AttackEffects/Lazer");
        GameObject effect = Managers.Resource.Instantiate("Monsters/AttackEffects/Lazer_Boom");

        GameObject lazerMoveAttack = new GameObject("LazerMoveAttack");
        go.transform.SetParent(lazerMoveAttack.transform);
        effect.transform.SetParent(lazerMoveAttack.transform);
        
        go.AddComponent<LazerMove>();
        effect.AddComponent<HorizontalAttack1>(); 
    }

    #endregion
    public void TantacleAttack() { }
    #region TantacleAttack_Private

    #endregion
    public void FlashAttack() { FlashInit(); }
    #region FlashAttack_Private
    private void FlashInit()
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/AttackEffects/FlashAttack");
    }
    #endregion

    #endregion
}

