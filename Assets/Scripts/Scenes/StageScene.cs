using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScene : BaseScene
{
    public override void Clear()
    {

    }
    protected override void Init()
    {
        base.Init();
        SoundBgmPlay();
    }
}
