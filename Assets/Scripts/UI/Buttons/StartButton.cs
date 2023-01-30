using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void OnClick()
    {
        Managers.Sound.Clear();
        Managers.Scene.LoadScene("Dong's Test");
    }
}
