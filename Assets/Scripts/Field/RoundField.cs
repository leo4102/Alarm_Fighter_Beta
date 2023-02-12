using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundField : MonoBehaviour
{
    protected GameObject Grid_All;

    [SerializeField]
    int height;
    [SerializeField]
    int width;

    List<List<FieldInfo>> gridArray = new List<List<FieldInfo>>();// 2 demention list
    public int GetHeight() { return height; }
    public int GetWidth() { return width; }
    public List<List<FieldInfo>> GetGridArray() { return gridArray; }
    public GameObject GetGrid(int x, int y)
    {
        if (x > width || y > height || x < 0 || y < 0) { Debug.Log("out of index"); return null; }
        return gridArray[x][y].grid;
    }
    public void ChangeGrid(int x, int y, Define.GridState state)
    {
        GameObject go = GetGrid(x, y);
        SpriteRenderer sr;//= go.GetComponent<SpriteRenderer>();
        switch (state)
        {
            case Define.GridState.Base:
                sr = gridArray[x][y].grid.GetComponent<SpriteRenderer>();
                //sr.color()
                break;
            case Define.GridState.Attack:
                sr = go.GetComponent<SpriteRenderer>();
                sr.color = Color.red;
                break;
            case Define.GridState.AttackReady:
                sr = go.GetComponent<SpriteRenderer>();
                sr.color = Color.yellow;
                break;
        }
    }
    private void FindObject()
    {
        Grid_All = gameObject;
    }
    public void Init()
    {
        //FindObject();

        for (int i = 0; i < width; i++)
            gridArray.Add(new List<FieldInfo>());

        int index = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                FieldInfo fieldInfo = new FieldInfo();
                fieldInfo.grid = transform.GetChild(index).gameObject;
                gridArray[i].Add(fieldInfo);
                index++;
            }
        }

    }
}

public class FieldInfo
{
    public GameObject grid; // one prefab
    public float ratio = 1.0f; // used by player scale
}
