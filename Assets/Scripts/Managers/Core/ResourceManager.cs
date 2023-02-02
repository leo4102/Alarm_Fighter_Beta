using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager 
{

    //prefab을 불러오는 함수
    //path: "Prefabs/Prefab명"로 사용
    public T Load<T>(string path) where T : Object      //where(조건): T는 Object를 상솟받는다(or Object이다)
   
    {
        //pool을 통해 이미 load된 original이 있다면 가져오기
        //Prefab일 경우
        //Loading을 줄이기 위해서 사용
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

        return Resources.Load<T>(path);     //기존 Resources클래스에 존재하는Load (불러오기)함수
    }

    //prefab를 불러오고 생성하는 것을 한번에 해결하는 함수
    public GameObject Instantiate(string path, Transform parent = null)
    {
        //prefab을 불러오는 단계(위의 Load함수 사용)
        GameObject original = Load<GameObject>($"Prefabs/{path}");  //경로(path)에 Asset>Resources>Prefab 생략 하여 사용 
        if (original == null)       //불러오지 못하면
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        //poolable 오브젝트라면 (pool(stack)에서 꺼내오기)
        if (original.GetComponent<Poolable>() != null)
            return Managers.Pool.Pop(original, parent).gameObject;

        //poolable 오브젝트가 아니라면(불러온 prefab을 생성)
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
        Object.Destroy(go);     //Object 필수 (재귀 막기 위해)
    }
}
