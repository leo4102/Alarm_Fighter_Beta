using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxArea : MonoBehaviour        //»ç¿ë¾ÈµÊ
{

    [SerializeField]
    BoxArea up;
    [SerializeField]
    BoxArea down;
    [SerializeField]
    BoxArea left;
    [SerializeField]
    BoxArea right;
    public BoxArea Up { get { return up; } private set { up = value; } }
    public BoxArea Down { get {return down;} private set { down = value;} }
    public BoxArea Left { get {return left;} private set { left = value;} }
    public BoxArea Right { get {return right;} private set { right = value;} }

    public bool Moveable { get; private set; }

    private void Start()
    {
        Moveable = true;
    }

}
