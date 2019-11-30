using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameArrangement : MonoBehaviour
{
    public GameObject[] cubes;
    public Text gameName, playText;
    public GameObject buttons, m_cube, spawn_blocks;
    public Animation cube_anim, block;
    public Light dirLight;
    private bool clicked = false;

    private void Update()
    {
        //уменьшить яркость
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
            StartCoroutine(cubeToBlock());
            m_cube.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            cube_anim.GetComponent<Animation>().Play();
        }
    }
    //удаление лишних кубиков
    IEnumerator delCubes()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            cubes[i].GetComponent<FallCube>().enabled = true;
        }
        spawn_blocks.GetComponent<SpawnBlocks>().enabled = true;
    }
    //превращение последнего кубика в блок-платформу
    IEnumerator cubeToBlock()
    {
        yield return new WaitForSeconds(m_cube.GetComponent<Animation>().clip.length + 0.3f );
        block.Play();
    }
}
