using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarUpdater : MonoBehaviour
{
    [SerializeField]
    public Slider hpbar;

    Stat stat;

    void Start()
    {
        stat = GetComponent<Stat>();
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.value = stat.CurrentHP / stat.MaxHP;
    }
}
