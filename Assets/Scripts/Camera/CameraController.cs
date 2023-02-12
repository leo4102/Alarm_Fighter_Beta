using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
/*
    [SerializeField]
    GameObject Player;
*/
    float currentCameraPositionX;
    float currentCameraPositionY;
    float currentCameraPositionZ;
    private void Init()
    {
        currentCameraPositionX = gameObject.transform.position.x;
        currentCameraPositionY = gameObject.transform.position.y;
        currentCameraPositionZ = gameObject.transform.position.z;
    }
    private void UpdateCameraPositon()
    {
        float updateCameraPositionX = Managers.Player.GetCurrentPositionX();
        Vector3 UpdatePosition = new Vector3(updateCameraPositionX, currentCameraPositionY, currentCameraPositionZ);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, UpdatePosition, 0.01f);
    }
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraPositon();
    }
}
