using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx 
{
    public BaseScene CurrentScene
    {
        get { return GameObject.FindObjectOfType<BaseScene>(); }
    }
    public void LoadScene(string scene)
    {
        CurrentScene.Clear();
        SceneManager.LoadScene(scene);
    }
    public void Clear() { CurrentScene.Clear(); }
}
