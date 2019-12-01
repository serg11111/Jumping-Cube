using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harder : MonoBehaviour
{
    private bool hard;
    void Update()
    {
        if (CubeJump.count_blocks > 0)
        {
            if (CubeJump.count_blocks % 2 == 0 && !hard)
            {
                print("Harder");
                hard = true;
            }
            else if (CubeJump.count_blocks % 3 == 0 && hard)
            {
                hard = false;
                print("Easier");
            }
        }
    }
}
