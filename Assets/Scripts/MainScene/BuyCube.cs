using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCube : MonoBehaviour
{
    public GameObject whichCube, selectButton, mainCube;

    void OnMouseDown()
    {
        if(PlayerPrefs.GetInt("Diamonds") >= 50)
        {
            PlayerPrefs.SetString(whichCube.GetComponent<SelectCube>().nowCube, "Open");
            PlayerPrefs.SetString("Now Cube", whichCube.GetComponent<SelectCube>().nowCube);
            PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") - 50);
            mainCube.GetComponent<MeshRenderer>().material = GameObject.Find(whichCube.GetComponent<SelectCube>().nowCube).GetComponent<MeshRenderer>().material ;
            selectButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
