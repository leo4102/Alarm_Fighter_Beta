using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Field : MonoBehaviour
{
    List<GameObject> gridArray = new List<GameObject>();//전체 field data

    List<GameObject> playergridArray = new List<GameObject>();//Player field data
    List<GameObject> monstergridArray = new List<GameObject>();//Monster field data

    protected GameObject grid_All;

    [SerializeField]
    GameObject gridPrefab;//Diamond

    protected float height;//높이
    protected float width;//길이

    private float scale_x;//스케일 x축
    private float scale_y;//스케일 y축
    private float location_x;//grid의 처음 x좌표 
    private float location_y;//grid의 처음 y좌표

    const double x_size = 0.5;//Diamond 장축
    const double y_size = 0.25;//Diamond 단축
    const double gap = 0.1;//간격

    public abstract void Setheight();
    public abstract void setWidth();
    public void Rotation(GameObject go)//기본 회전
    {
        go.transform.Rotate(0f, 0f, 30.0f);
    }
    protected virtual void prepabRotation(GameObject go, float theta)//theta만큼 회전 함수
    {
        go.transform.Rotate(0f, 0f, theta);
    }

    protected virtual void prepabMove(GameObject go)
    {
        go.transform.position = new Vector3(-1.49f, 0.54f, 0f);
    }
    private void gridInit()
    {
        scale_x = gridPrefab.transform.localScale.x;//grid scale x축
        scale_y = gridPrefab.transform.localScale.y;//grid scale y축
        location_x = gridPrefab.transform.localPosition.x;//grid 초기 x좌표 
        location_y = gridPrefab.transform.localPosition.y;//grid 초기 y좌표
    }
    protected virtual void createObject()
    {
        grid_All = new GameObject() { name = "grid_All" };

    }
    protected virtual void createField()//필드 만들기
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject grid = Instantiate(gridPrefab) as GameObject;
                grid.transform.position = new Vector3((float)(((x_size + gap) * scale_x * x + (x_size + gap) * scale_x * y) + location_x), (float)(((-gap - y_size) * scale_y * x + (gap + y_size) * scale_y * y) + location_y), 0f);
                grid.transform.SetParent(grid_All.transform);//하나로 뭉치기
                gridArray.Add(grid);//데이터 정보 저장
            }
        }
    }
    protected virtual void seperatedGridArea()
    {
        for (int i = 0; i < gridArray.Count; i++)//Basic Player Field 
        {
            if (i < 6) playergridArray.Add(gridArray[i]);
            if (i > 6) monstergridArray.Add(gridArray[i]);
        }

    }
    void Start()
    {
        setWidth();
        Setheight();
        gridInit();
        createObject();
        createField();
        Rotation(grid_All);
        prepabMove(grid_All);
        seperatedGridArea();
    }
}
