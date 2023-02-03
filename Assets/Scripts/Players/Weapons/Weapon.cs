using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected string weapon;            //(무기)Prefab 경로가 저장될 변수
    public int Damage { get; protected set;}
    //to do : Effect



    private void Start()
    {
        Init();                         //Weapon클래스를 상속받는 자식클래스의 Init()함수가 실행됨
    }

    protected virtual void Init()
    {
        ArmWeapon();
    }

    public virtual int[] CalculateAttackRange(int currentInd)
    {
        return new int[1] { currentInd };     //크기 1인 (int 형)배열을 생성하고 currentInd로 초기화
    }

    public virtual void ArmWeapon()     //Player가 들고 있는 무기 초기 설정
    {
        if (weapon == null)             //설정된 무기가 없다면
            return;

        GameObject go = Util.FindChild(gameObject, "Hand");     //무기 스크립트가 붙은 Player(GameObject)의 자식 중 Hand(GameObject)를 찾음
        Managers.Resource.Instantiate(weapon, go.transform);    //설정된 무기 생성( Hand(GameObject)하위로 들어가게)
    }
}
