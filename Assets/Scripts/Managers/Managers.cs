using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers _instance;
    public static Managers Instance {  get { Init();  return _instance; } }

    #region Content
    BpmManager _bpm = new BpmManager();

    public static BpmManager Bpm { get { return Instance._bpm; } }
    #endregion

    #region Core
    PoolManager _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();

    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }

    #endregion

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }
    static void Init()
    {
        if(_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject() { name = "@Managers" };
                go.AddComponent<Managers>();
                
            }
            DontDestroyOnLoad(go);
            _instance = go.GetComponent<Managers>();

            //Manager Init
            _instance._pool.Init();
        }
    }

    public static void Clear()
    {
        //Manager Clear
        Pool.Clear();
    }
}
