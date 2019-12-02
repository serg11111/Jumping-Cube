using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSameColor : MonoBehaviour
{
    private bool firstOne;


    private void OnCollisionEnter(Collision other)
    {

        //если куб коснулся платформы(кроме первой) он окрашивает ее в свой цвет
        if (other.gameObject.tag == "Cube" && firstOne) 
        {
            other.gameObject.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().material.color;
        }
        if (!firstOne)
        {
            firstOne = true;
        }
    }
}
