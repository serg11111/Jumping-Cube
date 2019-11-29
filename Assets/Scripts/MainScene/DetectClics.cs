using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DetectClics : MonoBehaviour
{
    public Text gameName, playText;
    public GameObject buttons, m_cube, cubes;
    public Light dirLight;
    private bool clicked = false;

    private void Update()
    {
        if( clicked && dirLight.intensity != 0)
        {
            dirLight.intensity -= 0.03f;
        }
    }
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
