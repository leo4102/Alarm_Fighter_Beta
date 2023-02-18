using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
    void Start()
    {
        MaxHP = 10f;
        CurrentHP = 10f;

        GetComponent<HpBarUpdater>().GetSliderComponent().maxValue = MaxHP;

    }
}
//GameObject slider = Util.FindChild(playerHpBar, "Slider");
//slider.GetComponent<Slider>().maxValue = MaxHP;