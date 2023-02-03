using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    public void Attacking()
    {
        gameObject.SetActive(true);     //Attack(GameObject È°¼ºÈ­
        Animator anim = GetComponent<Animator>();
        anim.Play("Attack");

    }

    void Update()
    {
        
    }
    public void End()
    {
        gameObject.SetActive(false);
    }
}
