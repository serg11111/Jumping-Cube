using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject block;
    public GameObject blockInst;
    private Vector3 blockPos;
    public float speed = 5f;
    void Start()
    {
        blockPos = new Vector3(Random.Range(1.2f, 1.7f), Random.Range(-2f, 2f), 0f);
        blockInst = Instantiate(block, new Vector3(5f, -5f, 0), Quaternion.identity) as GameObject;
        blockInst.transform.localScale = new Vector3(Random.Range(1.5f, 2.5f), blockInst.transform.localScale.y, blockInst.transform.localScale.z);
    }

    private void Update()
    {
        if(blockInst.transform.position != blockPos)
        {
            blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position, blockPos, Time.deltaTime * speed);
        }
    }
}
