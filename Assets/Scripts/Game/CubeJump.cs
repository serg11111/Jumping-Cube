using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour
{
	public GameObject mainCube;
    private bool animate;

    private void FixedUpdate()
    {
        if(animate && mainCube.transform.localScale.y > 1.0f)
        {
            mainCube.transform.localPosition -= new Vector3(0f, 1f * Time.deltaTime, 0f);
            mainCube.transform.localScale -= new Vector3(0f, 1f * Time.deltaTime, 0f);
        } else if (!animate)
        {
            if(mainCube.transform.localScale.y < 1.5f)
            {
                mainCube.transform.localPosition += new Vector3(0f, 3f * Time.deltaTime, 0f);
                mainCube.transform.localScale += new Vector3(0f, 3f * Time.deltaTime, 0f);
            }else if(mainCube.transform.localScale.y != 1.5f)
            {
                mainCube.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
        }
    }

    void OnMouseDown()
	{
        if(mainCube.GetComponent<Rigidbody>())
        {
            animate = true;
        }
	}

    void OnMouseUp()
	{

        if (mainCube.GetComponent<Rigidbody>())
        {
            animate = false;
           
        }
    }
}
