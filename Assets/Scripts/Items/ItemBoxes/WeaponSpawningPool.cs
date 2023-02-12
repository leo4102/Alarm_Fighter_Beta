using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawningPool : MonoBehaviour
{
    [SerializeField]
    int max;

    [SerializeField]
    int spawnBit;

    int currentBit = 0;
    // Start is called before the first frame update
    void Start()
    {
        Managers.Timing.BehaveAction -= BitBehave;
        Managers.Timing.BehaveAction += BitBehave;
    }

    void BitBehave()
    {
        currentBit += 1;
        if(currentBit >= spawnBit)
        {
            //Managers.Item.WeaponSpawn();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
