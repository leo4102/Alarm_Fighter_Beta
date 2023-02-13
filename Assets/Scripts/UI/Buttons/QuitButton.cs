using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void OnClick()
    {
        Managers.Scene.LoadScene("Stage2");
    }
}
