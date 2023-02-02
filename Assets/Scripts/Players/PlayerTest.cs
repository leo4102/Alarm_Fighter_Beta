using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 이 클래스는 PlayerText클래스이며 FieldObject를 상속받아 생성. FieldObject가 MonoBehaviour를 상속받고 있다. (1.17 재윤 추가)
// Issue (1.17) 처음 시작할 때 키보드 한번을 생략하고 시작함
public class PlayerTest : FieldObject       //Player(GameObject)에게 붙여짐
{

    TimingManager timingManager;
    int maxHp = 3;
    int currentHp;

    HpBar hpBar;
    
    public int CurrentHp
    {
        get { return currentHp; }
        set
        {
            currentHp = value;
            hpBar.updateValue(currentHp);
        }
    }

    void Start()
    {
        currentHp = maxHp;

        timingManager = FindObjectOfType<TimingManager>();
        hpBar = Util.FindChild<HpBar>(gameObject, null, true);    //gameObject 자식들 중 HpBar(컴포넌트)를 들고있는 자식 존재시 HpBar(컴포넌트) 반환

        // type을 초기화하고 objectField를 받아온 뒤, objectList에 PlayerField를 받아온다.
        type = 1;
        objectField = Managers.Field.getField();            //(ex)objectField에 BasicField(스크립트)가 삽입됨
        objectList = objectField.getGridArray(type);        //playergridArray를 가져옴

        currentInd = objectList.Count / 2; // 이 초기화의 위치는 Field의 Width가 어떻든, 가운데에 오게할 수 있음 (1.18 재윤 추가)
        transform.position = objectList[currentInd].transform.position;
    }

    void Update()
    {
        BitBehave();
    }

    protected override void BitBehave()
    {
        if (Input.GetKeyDown(KeyCode.W) && timingManager.CheckTiming()) { mayGo(Define.PlayerMove.Up); Managers.Sound.Play("Click"); }
        else if (Input.GetKeyDown(KeyCode.A) && timingManager.CheckTiming()) { mayGo(Define.PlayerMove.Left); Managers.Sound.Play("Click"); }
        else if (Input.GetKeyDown(KeyCode.S) && timingManager.CheckTiming()) { mayGo(Define.PlayerMove.Down); Managers.Sound.Play("Click"); }
        else if (Input.GetKeyDown(KeyCode.D) && timingManager.CheckTiming()) { mayGo(Define.PlayerMove.Right); Managers.Sound.Play("Click"); }
        else if (Input.GetKeyDown(KeyCode.K) && timingManager.CheckTiming()) { Attack(); Managers.Sound.Play("KnifeAttack1"); }
    }

    protected override void Attack()
    {
        int[] pattern = GetComponent<Weapon>().CalculateAttackRange(currentInd);        //설정된 무기에 맞는 공격범위 계산
        Managers.Field.WarningAttack(pattern);                                          //공격범위 빨강화(너무 짧은 시간)
        Managers.Field.Attack(pattern);                                                 //공격범위 collider 활성화 + 투명화


        Transform attack = transform.GetChild(0);                                       //Attack(GameObject)반환    
        attack.GetComponent<PlayerAttack>().Attacking();                                //PlayerAttack(스크립트)의 Attacking()함수 실행
    }

    protected override void Hit()       
    {
        Debug.Log("Hit!!!!");
        GetComponent<Animator>().SetTrigger("isHit");       //Player의 Animator의 Idle 에서 Hit으로의 transition이 없는데???
        CurrentHp -= 1;
        Managers.Sound.Play("Hit");
        if (CurrentHp <= 0)
            Die();

    }
    void Die()
    {
        Debug.Log("Player Die!!");
        Managers.Game.GameOver();
        Managers.Sound.Play("Die");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)     //몬스터의 공겨으로 PlayerField의 collider이 켜져 충돌 시
    {
        Hit();
    }

}
