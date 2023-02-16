using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    public void LeftClick() { Managers.Player.IsLeft(); }

    public void RightClick() { Managers.Player.IsRight(); }

    public void UpClick() { Managers.Player.IsUp(); }

    public void DownClick() { Managers.Player.IsDown(); }

}
