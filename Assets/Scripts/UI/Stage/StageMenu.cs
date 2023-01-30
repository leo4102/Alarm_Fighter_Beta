using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageMenu : MonoBehaviour
{
    [SerializeField] Song[] songList = null;
    [SerializeField] TextMeshProUGUI txtSongName = null;
    [SerializeField] TextMeshProUGUI txtDifficulty = null;
    [SerializeField] TextMeshProUGUI txtBpm = null;
    [SerializeField] Image stageImg = null;
    
    int currentSong = 0;

    public void SetCurrentSong(int num)
    {
        currentSong = num;
    }

    void Start()
    {
        SettingSong();
    }

    public void play()
    {
        Managers.Sound.Play(txtSongName.text, Define.Sound.Bgm);
    }

    public void SettingSong()
    {
        txtSongName.text = songList[currentSong].name;
        txtDifficulty.text = songList[currentSong].difficulty;
        txtBpm.text = songList[currentSong].bpm;
        stageImg.sprite = songList[currentSong].sprite;

        //Managers.Sound.Play(txtSongName.text, Define.Sound.Bgm);
    }
    //-----------------------------------------
    void Update()
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
    }
}

[System.Serializable]
public class Song
{
    public string name;
    public string difficulty;
    public string bpm;
    public Sprite sprite;
}
