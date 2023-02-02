using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx 
{
    public BaseScene CurrentScene       //뭐가 반환되는 거지?
    {
        //     Object The first active loaded object that matches the specified type. It returns
        //     null if no Object matches the type.
        get { return GameObject.FindObjectOfType<BaseScene>(); }        //@Scene에 붙어있는 BaseScene(컴포넌트)을 상속받는 씬 스크립트를 BaseScene형으로 반환?
    }

    public void LoadScene(string scene)     //씬 전환 함수//scene: 씬 이름명
    {
        CurrentScene.Clear();
        SceneManager.LoadScene(scene);
    }
    
    public void Clear() { CurrentScene.Clear(); }       //불필요? NO! Managers Clear()서 호출
}
