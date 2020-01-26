using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBG : MonoBehaviour
{

    public GameObject detectClick, allCubes;

    void OnEnable()
    {
        detectClick.SetActive(false);
        allCubes.SetActive(true);
    }

    void OnDisable()
    {
        detectClick.SetActive(true);
        allCubes.SetActive(false);
    }
    
}
