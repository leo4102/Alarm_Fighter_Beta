using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Object 별 pool
class Pool
{
    //pool에 담을 오브젝트(Prefab)의 원본
    public GameObject Original { get; private set; }
    //pool의 root 오브젝트 : push된 오브젝트의 부모 오브젝트("@Pool_Root" 산하의 "Prefab명_ROOT")
    public Transform Root { get; set; }

    //pool에 push된 오브젝트를 담고있는 stack
    Stack<Poolable> _poolStack = new Stack<Poolable>();

    //pool의 root오브젝트 생성
    public void Init(GameObject original, int count = 15)       //count: 한개의 Prefab으로 몇개의 clone을 만들어 놓을지 결정(디폴트 값 :5)
    {
        Original = original;
        Root = new GameObject().transform;
        Root.name = $"{original.name}_ROOT";

        for (int i = 0; i < count; i++)
            Push(Create());                             //37행의 Push

    }

    //pool에 들어갈 object 생성
    Poolable Create()
    {
        GameObject go = Object.Instantiate(Original);
        go.name = Original.name;                        //Prefab 명과 동일한 명의 GameObject 생성
        return go.GetOrAddComponent<Poolable>();        //Poolable 컴포넌트 추가
    }

    //오브젝트를 pool에 집어넣는다 (= Destroy)
    public void Push(Poolable poolable)                 //여기서 poolable은 prefab으로 생성한 GameObject 하나
    {
        if (poolable == null)
            return;

        //poolable을 pool로 옮기고 비활성화
        poolable.transform.SetParent(Root);
        poolable.gameObject.SetActive(false);
        poolable.IsUsing = false;

        _poolStack.Push(poolable);                      //원래 있는 Push 함수
    }

    //오브젝트를 pool에서 꺼낸다 (= Instantiate)
    public Poolable Pop(Transform parent)               //parent는 "@Pool_Root" 산하의 "Prefab명_ROOT"에서 한개를 꺼내와서 붙이고 싶은 부모 클래스
    {
        //pop할 오브젝트
        Poolable poolable;

        //pool에 남은 오브젝트가 있다면
        if (_poolStack.Count > 0)
            poolable = _poolStack.Pop();
        //없다면 생성(Stack에 5개를 만들어 놓았는데 현재 5개가 모두 IsUsing 상태로 전부 사용 중으로 Stack 밖에 위치 하면)
        else
            poolable = Create();

        //오브젝트 활성화
        poolable.gameObject.SetActive(true);

        //DontDestroyOnLoad 해제용 : DontDestroyOnLoad 산하에 들어가면 명시적으로 나오지않는한 못나옴
        if (parent == null)
            poolable.transform.SetParent(Managers.Scene.CurrentScene.transform);// = Managers.Scene.CurrentScene.transform;
        else
            poolable.transform.SetParent(parent);

        poolable.IsUsing = true;

        return poolable;

    }
}

//정적으로 사용할 일 없음 ResourceManager에서 알아서 사용
public class PoolManager        //"@Pool_Root" 역할
{
    //object name을 key로 같은 pool dictionary
    Dictionary<string, Pool> _poolDict = new Dictionary<string, Pool>();      //"@Pool_Root" 산하에 여러 개의 Pool이 존재(관리)
    //pool들의 부모 오브젝트
    Transform _root;

    public void Init()
    {
        if(_root == null)
        {
            _root = new GameObject { name = "@Pool_Root" }.transform;
            Object.DontDestroyOnLoad(_root);
        }
    }

    //pool 생성하고 dictionary에 추가
    public void CreatePool(GameObject original, int count = 15)
    {
        Pool pool = new Pool();                     //빈 Pool 생성
        pool.Init(original, count);                 //pool 초기화
        pool.Root.SetParent(_root);                   //만든 Pool을  "@Pool_Root" 산하에 위치

        _poolDict.Add(original.name, pool);         //만든 Pool Dictionary에 추가
    }

    //pool이 있다면 pool에 push 없으면 destroy
    public void Push(Poolable poolable)             //다 사용한 poolabke(Clone)을 다시  "@Pool_Root" 산하의 Pool에 반납
    {
        //poolable의 pool이 없다면 그냥 destroy
        string name = poolable.gameObject.name;
        if(_poolDict.ContainsKey(name) == false)
        {
            GameObject.Destroy(poolable.gameObject);
            return;
        }

        _poolDict[name].Push(poolable);             //Pool클래스의 Push함수 호출
    }

    //"@Pool_Root" 산하의 Pool에서 poolable(Clone)을 꺼내 parent 밑으로 붙인다
    public Poolable Pop(GameObject original, Transform parent =null)
    {
        //pool이 없다면 pool생성 후 pop
        if (_poolDict.ContainsKey(original.name) == false)
            CreatePool(original);

        return _poolDict[original.name].Pop(parent);        //Pool클래스의 Pop함수 호출
    }

    public GameObject GetOriginal(string name)              //해당 Pool의 기반이 되었던 Prefab을 가져옴  //name은 "Prefab명"
    {
        if (_poolDict.ContainsKey(name) == false)
            return null;
        return _poolDict[name].Original;
    }

    //Scene 이동시 모두 pool오브젝트 삭제
    public void Clear()
    {
        foreach(Transform child in _root)
        {
            GameObject.Destroy(child.gameObject);
        }

        _poolDict.Clear();
    }
}
