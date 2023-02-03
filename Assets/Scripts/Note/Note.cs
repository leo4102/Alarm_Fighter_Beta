using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour           //Note2(Prefab)에 삽입     //노트 한개의 오른쪽 움직임을 담당
{
    public float noteSpeed = 0;
    Image noteImage;//Note(객체)의 Image 
    
    private void Update()
    {
        transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;  

    }

    void OnEnable()//객체가 활성화 될 때 마다 실행
    {
        if (noteImage == null)
        {
            noteImage = GetComponent<Image>();
        }
        noteImage.enabled = true;       //w,a,s,d,k 를 눌렀을때 객체의 이미지를 비활성화 하였기 때문에 실행
    }


    //Note의 이미지를 비활성화 하는 함수
    public void HideNote()
    {
        noteImage.enabled = false;
    }
    //--------------------------------------------------------------------------
    /*public void CreateNote()
    {
        Transform parent = transform.parent;
        GameObject go = Managers.Resource.Instantiate("Note", parent);
        go.GetComponent<Animator>().speed = Managers.Bpm.GetAnimSpeed();
    }

    public void Destroy()
    {
        Managers.Resource.Destroy(gameObject);
    }*/
}
