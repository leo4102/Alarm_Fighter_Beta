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
        GameObject go = GameObject.Find("StageMenu");
        go.transform.GetChild(0).gameObject.SetActive(true);
        go.transform.GetChild(1).gameObject.SetActive(true);
        go.GetComponent<StageMenu>().SetCurrentSong(1);
        go.GetComponent<StageMenu>().SettingSong();
        go.GetComponent<StageMenu>().play();
    }
}