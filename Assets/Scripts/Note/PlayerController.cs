using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //TimingManager timeManager;

    void Start()
    {
        //timeManager = FindObjectOfType<TimingManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Managers.Timing.CheckTiming();
        }
    }
}
