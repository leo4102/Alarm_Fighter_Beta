using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour     //Note2 객체(한 개)가 생성되고 파괴 되는 것을 담당
{
    double currentTime = 0;
    [SerializeField] Transform noteAppearLocation = null;//notePrefab이 생성될 위치
    //[SerializeField] GameObject notePrefab = null;//생성할 Note 프리팹 연결

    
    public void Update()
    {
        //특정 시간 간격으로 노트 생성
        currentTime += Time.deltaTime;
        if (currentTime >= 60d / Managers.Bpm.BPM)
        {
            Debug.Log("Note2 created"+currentTime);
            GameObject t_note = Managers.Resource.Instantiate("Notes/Note2",gameObject.transform);//------------------------------
            
            //GameObject t_note = ObjectPool.objectPool.noteQueue.Dequeue();//notePool에서 obj(Note) 하나 꺼냄      //--------------
            t_note.transform.position = noteAppearLocation.position;//obj가 Scene에 활성화될 자리 설정
            
            Managers.Timing.noteList.Add(t_note);//TimingManager2의 noteList에 생성된 Note 추가
            currentTime -= 60d / Managers.Bpm.BPM;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)      //노트가 화면 밖으로 나가면 삭제
    {
        if (collision.CompareTag("Note2"))
        {
            Managers.Resource.Destroy(collision.gameObject);        
            Managers.Timing.noteList.Remove(collision.gameObject); //TimingManager의 noteList에서 제거
        }
    }
}
