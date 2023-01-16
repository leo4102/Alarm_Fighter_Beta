using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager
{
    private Field PlayerField;
    private Field MonsterField;

    public void setPlayerField(Field field)
    {
        PlayerField = field;
    }
    public void setMonsterField(Field feild)
    {
        MonsterField = feild;
    }
}
