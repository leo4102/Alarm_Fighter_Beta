using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Noteable : MonoBehaviour
{
    bool isNote = true;
    double currentTime = 0;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= 60d / Managers.Bpm.BPM)
        {
            BitUpdate();
            currentTime -= 60d / Managers.Bpm.BPM;
        }
    }
    protected abstract void BitUpdate();
}
