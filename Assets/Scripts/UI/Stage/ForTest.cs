using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        //Transform go = transform.root;                        //현재 스크립트가 붙여진 오브젝트의 최상위 오브젝트(StagePrologueMenu) 반환
        GameObject go = GameObject.Find("StagePrologueMenu");
        go.transform.GetChild(0).gameObject.SetActive(true); //BlackFrame(GameObject)
        go.transform.GetChild(1).gameObject.SetActive(true); //GreenPage(GameObject)
        go.GetComponent<StagePrologueMenu>().SetCurrentSong(1);
        go.GetComponent<StagePrologueMenu>().SettingSong();
        go.GetComponent<StagePrologueMenu>().play();

    }
}