using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour     //모든 씬 script가 상속받는 클래스(따라서 MonoBehaviour)
{
    [SerializeField]
    protected string soundBgmName;                  //해당 씬의 BGM 이름
    private void Awake()
    {
        Init();
    }
    protected virtual void Init()                   //EventSystem(Prefab)으로 @EventSystem(GameObject)생성
    {
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));      //==GameObject.FindObjectOfType<EventSystem>();
        if (obj == null)
        {
            Managers.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
        }
    }
    public abstract void Clear();
    
    protected void SoundBgmPlay()
    {
        Managers.Sound.Play(soundBgmName, Define.Sound.Bgm);
    }
}
