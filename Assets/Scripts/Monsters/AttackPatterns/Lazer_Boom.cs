using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer_Boom : MonoBehaviour
{
    SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float alpha = rend.color.a;
        if (alpha <= 0)
        {
            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0.6f);
            Managers.Resource.Destroy(gameObject);
            return;
        }

        alpha -= 0.01f;
        rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, alpha);
    }
}
