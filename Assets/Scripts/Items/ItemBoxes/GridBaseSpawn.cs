using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBaseSpawn : MonoBehaviour
{
    public int maxItem = 4;
    public int delay = 10;

    int currentItem =0;
    int waitBit = 0;
    double currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Managers.Timing.BehaveAction -= BitBehave;
        //Managers.Timing.BehaveAction += BitBehave;

    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 60d / Managers.Bpm.BPM)
        {
            Debug.Log("workd");
            BitBehave();
            currentTime -= 60d / Managers.Bpm.BPM;
        }
    }


    // Update is called once per frame
    void BitBehave()
    {


        if (maxItem <= currentItem)
            return;

        if (delay <= waitBit)
        {
            int x, y;
            CalculateLocation(out x, out y);

            Managers.Item.WeaponSpawn(x, y);
            currentItem++;
            waitBit = 0;
        }



        waitBit++;
    }
    void CalculateLocation(out int x, out int y)
    {
        while(true)
        {
            int tempX = Random.Range(0, 12);
            int tempY = Random.Range(0, 2);

            //if (!Managers.Field.GetField(tempX, tempY).spawnable)t
             //   continue;


            x = tempX;
            y = tempY;
            return;
            

        }


    }
}
