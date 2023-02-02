using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BpmManager
{
    
    int bpm = 120;
    public bool Able;
    
    public int BPM {
        get { return bpm; }
        private set
        { 
            bpm = value;
            Init();
        } 
    }

    public void Init()
    {
        SetBpmText();
    }


    void SetBpmText()
    {
        //Text go = GameObject.Find("BpmValue").GetComponent<Text>();
        //go.text = $"{bpm}";
    }
    
    public float GetAnimSpeed()
    {
        float speed = bpm / 60;

        return speed;
    }
    
    public void SetBpm(int n)
    {
        BPM = n;
    }
}

