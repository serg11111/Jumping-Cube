using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBG : MonoBehaviour
{

    private bool activeLose, activePlayTxt;
    public GameObject detectClick, allCubes, playTxt, loseBtn;

    void OnEnable()
    {
        if (playTxt.activeSelf)
        { 
            activePlayTxt = true;
            playTxt.SetActive(false);
        }
        playTxt.SetActive(false);
        detectClick.GetComponent<BoxCollider>().enabled = false;
        allCubes.SetActive(true);
        if (loseBtn.activeSelf)
        {
            activeLose = true;
            loseBtn.SetActive(false);
        }
    }

    void OnDisable()
    {
        if (activeLose)
        {
            loseBtn.SetActive(true);
        }
        if (playTxt.activeSelf)
        {
            playTxt.SetActive(true);
        }
        detectClick.GetComponent<BoxCollider>().enabled = true;
        allCubes.SetActive(false);
    }
    
}
