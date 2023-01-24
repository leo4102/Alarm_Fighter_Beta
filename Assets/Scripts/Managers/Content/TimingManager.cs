using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager 
{
    public Action BehaveAction;
    double currentTime = 0;

    public void UpdatePerBit()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= 60d /Managers.Bpm.BPM)
        {
            BehaveAction.Invoke();
            Debug.Log("work!");
            currentTime -= 60d / Managers.Bpm.BPM;
        }
    }
}
