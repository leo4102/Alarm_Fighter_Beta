using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject b = GameObject.Find("@Scene");   //b="@Scene (UnityEngine.GameObject)"

        //b1,b2,b3 모두 "@Scene (GameScene)"이 들어가진다
        BaseScene b1 =GameObject.FindObjectOfType<BaseScene>(); 
        
        Object b2 = GameObject.FindObjectOfType(typeof(BaseScene));
        BaseScene b3 = GameObject.FindObjectOfType(typeof(BaseScene)) as BaseScene;


        GameObject t = gameObject;
        //testscript t2 = gameObject;
        testscript t3 = FindObjectOfType<testscript>();




        b1.Clear();
        Transform t4 = b1.transform;

        //GameObject b4 = Object.FindObjectOfType(typeof(BaseScene)); //이렇게 하면 안됨
       //GameObject b5 = GameObject.FindObjectOfType(typeof(BaseScene));//GameObject가 Object형 객체를 가리킬 수 없다
        //GameObject b6 =GameObject.FindObjectOfType<BaseScene>();    //이렇게 하면 안됨
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
