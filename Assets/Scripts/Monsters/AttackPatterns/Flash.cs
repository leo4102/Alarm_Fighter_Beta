using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float alpha = rend.color.a;
        if (alpha <= 0)
        {
            Managers.Resource.Destroy(gameObject);
            return;
        }

        alpha -= 0.01f;
        rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, alpha);
    }
}
