using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject block, allCubes, diamond;
    private GameObject blockInst;
    private Vector3 blockPos;
    public float speed = 10f;
    private bool onPlace;

    void Start()
    {
        spawn();
    }

    private void Update()
    {
        if(blockInst.transform.position != blockPos && !onPlace)
        {
            //перемещение блока
            blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position, blockPos, Time.deltaTime * speed);
        }else if(blockInst.transform.position == blockPos)
        {
            onPlace = true;
        }
        if(CubeJump.jump && CubeJump.nextBlock)
        {
            spawn();

            onPlace = false;
        }
    }

    //размер блока
    float RandSkale()
    {
        float rand;
        if (Random.Range(0, 100) > 80)
        {
            rand = Random.Range(1.5f, 2.5f);
        }
        else rand = Random.Range(1.5f, 2f);

        return rand;
    }

    void spawn()
    {
        //куда блок должен прибыть
        blockPos = new Vector3(Random.Range(1.2f, 1.7f), Random.Range(-2f, 1f), 3f);
        //где блок появится
        blockInst = Instantiate(block, new Vector3(5f, -5f, 0f), Quaternion.identity) as GameObject;
        //формирование размера блока
        blockInst.transform.localScale = new Vector3(RandSkale(), blockInst.transform.localScale.y, blockInst.transform.localScale.z);
        blockInst.transform.parent = allCubes.transform;

        //формирование алмаза
        if (CubeJump.count_blocks % 6 == 0 && CubeJump.count_blocks != 0)
        {
            GameObject diamondInst = Instantiate(diamond, new Vector3(blockInst.transform.position.x, blockInst.transform.position.y + 0.8f, blockInst.transform.position.z), Quaternion.Euler(Camera.main.transform.eulerAngles)) as GameObject;
            diamondInst.transform.parent = blockInst.transform;
        }
    }
}
