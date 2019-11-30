using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameArrangement : MonoBehaviour
{
    public GameObject[] cubes;
    public Text gameName, playText;
    public GameObject buttons, m_cube;
    public Animation cube_anim;
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
            StartCoroutine(delCubes());
            clicked = true;     //Works only ones 
            playText.gameObject.SetActive(false);
            gameName.text = "0";
            buttons.GetComponent<ScrollObjects>().speed = -10f;
            buttons.GetComponent<ScrollObjects>().checkPos = -150f;
            m_cube.GetComponent<Animation>().Play("StartGameCube");
            m_cube.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            cube_anim.GetComponent<Animation>().Play();
        }
    }

    IEnumerator delCubes()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            cubes[i].GetComponent<FallCube>().enabled = true;
        }
    }
}
