using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DetectClics : MonoBehaviour
{
    public Text gameName, playText;
    public GameObject buttons, m_cube, cubes;
    private bool clicked;

    private void OnMouseDown()
    {
        if (!clicked)
        {
            clicked = true;     //Works only ones 
            playText.gameObject.SetActive(false);
            gameName.text = "0";
            buttons.GetComponent<ScrollObjects>().speed = -10f;
            buttons.GetComponent<ScrollObjects>().checkPos = -150f;
            m_cube.GetComponent<Animation>().Play("StartGameCube");
            cubes.GetComponent<Animation>().Play();
        }
    }
}
