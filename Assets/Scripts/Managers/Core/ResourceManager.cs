using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager 
{
    public T Load<T>(string path) where T : Object
    {
        //pool을 통해 이미 load된 original이 있다면 가져오기
        //Prefab일 경우
        if (typeof(T) == typeof(GameObject))
        {
            //이름 추출
            string name = path;
            int index = name.LastIndexOf('/');
            if (index > 0)
                name = name.Substring(index + 1);

            //pool이 있다면 getOriginal
            GameObject go = Managers.Pool.GetOriginal(name);
            if (go != null)
                return go as T;

        }

        return Resources.Load<T>(path);
    }

  
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if(original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        //poolable 오브젝트라면
        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        //poolable 오브젝트가 아니라면
        GameObject go = Object.Instantiate(original, parent);
        go.name = original.name;
        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        //pooling 대상이라면
        Poolable poolable = go.GetComponent<Poolable>();
        if (poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }        

        //아니라면
        Object.Destroy(go);
    }
}
