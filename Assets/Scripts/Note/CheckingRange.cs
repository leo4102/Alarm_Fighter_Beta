using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingRange : MonoBehaviour
{

    [SerializeField] RectTransform[] timingRect = null;
    //private Vector2[] timingRange = null; //timingRect의 x범위

   /* public Vector2[] GetTimingRange()
    {
        return timingRange;
    }*/

    void Start()
    {
        Managers.Timing.timingRange = new Vector2[timingRect.Length]; //크기 4

        for (int i = 0; i < timingRect.Length; i++)
        {
            //timingRange[0]이 perfectRect의 범위 순
            Managers.Timing.timingRange[i] = new Vector2(timingRect[i].localPosition.x - timingRect[i].rect.width / 2,
                timingRect[i].localPosition.x + timingRect[i].rect.width / 2);
        }
    }
    
}
