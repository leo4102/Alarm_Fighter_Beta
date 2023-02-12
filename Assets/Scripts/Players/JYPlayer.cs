using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JYPlayer : Player_Parent
{
    void Start()
    {
        current_X = 5;
        current_Y = 1;
        this.transform.position = Managers.Field.GetGrid(current_X, current_Y).transform.position;
        ChangeSize(current_Y);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
}
