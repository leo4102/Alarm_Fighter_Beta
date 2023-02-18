using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CameraLazer : MonoBehaviour
{
    Transform transform_my;
    Transform transform_target; 

    private float speed = 500;
    private void Start()
    {
        SetTransform_My();
        //SetTarget();
        Update_LookRotation();
    }
    //private void Update()
    //{
    //    SetTransform_My();
    //    SetTarget();
    //    Update_LookRotation();
    //}

    private void SetTransform_My()
    {
        transform_my = transform;
    }
    public void SetTarget(Transform trans)
    {
        transform_target = Managers.Player.GetCurrentTransform();
    }

    private void Update_LookRotation()
    {
        Vector3 myPos = transform_my.position;
        Vector3 targetPos = transform_target.position;
        targetPos.z = myPos.z;

        Vector3 vectorToTarget = targetPos - myPos;
        UpdateScale(vectorToTarget);

        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: vectorToTarget);
        transform_my.rotation = targetRotation;

        //transform_my.rotation = Quaternion.RotateTowards(transform_my.rotation, targetRotation, speed * Time.deltaTime);
    }
    private void UpdateScale(Vector3 vector)
    {
        float vectorX =transform.localScale.x;
        float vectorY =-vector.magnitude;
        float vectorZ =vector.z;
        transform.localScale = new Vector3(vectorX,vectorY,vectorZ);
    }
}
