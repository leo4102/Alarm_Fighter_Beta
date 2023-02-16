using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGenerator : MonoBehaviour
{

    [SerializeField]
    float delay = 0.01f;
    Sprite sprite;

    float currentTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        currentTime += Time.deltaTime;
        if (currentTime >= delay)
        {
            Create();
            currentTime -= delay;
        }


    }

    void Create()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        GameObject go = Managers.Resource.Instantiate("Players/Shadow");
        go.transform.position = transform.position;
        go.transform.localScale = transform.localScale;
        go.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}