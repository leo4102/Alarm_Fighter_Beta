using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class NoteCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        Managers.Bpm.Able = true;
        GetComponent<Image>().color = Color.red;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        Managers.Bpm.Able = false;
        GetComponent<Image>().color = Color.white;
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.O))
        {
            Managers.Bpm.SetBpm(Managers.Bpm.BPM + 1);
        }
        else if(Input.GetKey(KeyCode.P))
        {
            Managers.Bpm.SetBpm(Managers.Bpm.BPM - 1);

        }
    }
}
