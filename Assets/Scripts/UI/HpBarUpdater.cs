using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarUpdater : MonoBehaviour
{
    [SerializeField]
    public GameObject hpbar;

    Stat stat;

    void Start()
    {
        stat = GetComponent<Stat>();
    }

    void Update()
    {
        GetSliderComponent().value = stat.CurrentHP / stat.MaxHP;
    }

    public Slider GetSliderComponent()      //makes available to access into slider component directly
    {
        GameObject slider = Util.FindChild(hpbar, "Slider");
        return slider.GetComponent<Slider>();
    }
}
