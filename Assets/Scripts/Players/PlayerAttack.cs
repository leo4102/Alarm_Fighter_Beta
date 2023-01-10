using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void Attacking()
    {
        gameObject.SetActive(true);
        Animator anim = GetComponent<Animator>();
        anim.Play("Attack");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void End()
    {
        gameObject.SetActive(false);
    }
}
