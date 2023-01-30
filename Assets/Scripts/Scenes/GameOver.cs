using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : BaseScene
{
    public override void Clear()
    {
        
    }
    protected override void Init()
    {
        base.Init();
        SoundBgmPlay();
        Invoke("ReturnStage", 5);
    }

    void ReturnStage()
    {
        Managers.Scene.LoadScene("Stage2");
    }

}
