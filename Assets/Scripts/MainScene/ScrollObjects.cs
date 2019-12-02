using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjects : MonoBehaviour
{

    public float speed = 5f, checkPos;
    private RectTransform rec;

    
    void Start()
    {
        checkPos = 0f;
        rec = GetComponent<RectTransform>();
    }

    
    void Update()
    {
        if(rec.offsetMin.y != checkPos)
        {
            rec.offsetMin += new Vector2(rec.offsetMin.x, speed);
            rec.offsetMax += new Vector2(rec.offsetMax.x, speed);
        }
    }
}
