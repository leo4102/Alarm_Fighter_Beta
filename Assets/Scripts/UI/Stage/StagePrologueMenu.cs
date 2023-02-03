using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Song           //한 개의 곡을 의미
{
    public string name;
    public string difficulty;
    public string bpm;
    public Sprite sprite;
}


public class StagePrologueMenu : MonoBehaviour
{
    [SerializeField] Song[] songList = null;
    int currentSong = 0;
    
    //이하 StagePrologueMenu의 구성요소
    [SerializeField] TextMeshProUGUI txtSongName = null;
    [SerializeField] TextMeshProUGUI txtDifficulty = null;
    [SerializeField] TextMeshProUGUI txtBpm = null;
    [SerializeField] Image stageImg = null;
    
    public void SetCurrentSong(int num)
    {
        currentSong = num;
    }

    void Start()
    {
        SettingSong();
    }

    public void play()              //txtSongName에 저장된 문자열과 동일한 명의 Bgm 재생
    {
        Managers.Sound.Play(txtSongName.text, Define.Sound.Bgm);
    }

    public void SettingSong()       //StagePrologueMenu의 구성요소를 currentSong에 맞게 설정
    {
        txtSongName.text = songList[currentSong].name;
        txtDifficulty.text = songList[currentSong].difficulty;
        txtBpm.text = songList[currentSong].bpm;
        stageImg.sprite = songList[currentSong].sprite;

        //Managers.Sound.Play(txtSongName.text, Define.Sound.Bgm);
    }
    //-----------------------------------------
    /*void Update()
    {

    }
    public void BtnNext()
    {
        if (++currentSong > songList.Length - 1)
        {
            currentSong = 0;
        }
    }

    public void BtnPrior()
    {
        if (--currentSong < 0)
        {
            currentSong = songList.Length - 1;
        }
    }*/
}

