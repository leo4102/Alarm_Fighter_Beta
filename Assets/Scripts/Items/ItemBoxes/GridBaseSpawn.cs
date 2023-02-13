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



    public void ItemDestroy(GameObject go)
    {

        Managers.Resource.Destroy(go);
        currentItem--;
    }
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

            Managers.Item.WeaponSpawn(x, y, transform);
            currentItem++;
            waitBit = 0;
        }



        waitBit++;
    }
    void CalculateLocation(out int x, out int y)
    {
        int rangeX = Managers.Field.GetWidth();
        int rangeY = Managers.Field.GetHeight();
        while (true)
        {
            int tempX = Random.Range(0, rangeX);
            int tempY = Random.Range(0, rangeY);

            if (!(Managers.Field.GetFieldInfo(tempX, tempY).spawnable))
                  continue;


            x = tempX;
            y = tempY;
            return;

        }


    }
}
