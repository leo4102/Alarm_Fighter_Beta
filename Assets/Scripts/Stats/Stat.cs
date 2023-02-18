using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    public float MaxHP;
    public float CurrentHP;

    public void DecreaseCurrnetHP(float amount)
    {
        CurrentHP -= amount;
    }
}
