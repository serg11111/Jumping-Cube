using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubes : MonoBehaviour
{

    private bool moved = true;
    private Vector3 target;

    void Start()
    {
        //первоначальное расположение первого блока и вновь появившегося
        target = new Vector3(-3.17f, 7f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (CubeJump.nextBlock)
        {
            if (transform.position != target)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 5f);
            }
            else if (transform.position == target && !moved)
            {
                target = new Vector3(transform.position.x - 3.17f, transform.position.y + 4f, transform.position.z);
                CubeJump.jump = false;
                moved = true;
            }


            if (CubeJump.jump)
            {
                moved = false;
            }
        }
    }
}
