using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour
{
	public GameObject mainCube;
    private bool animate;
    private float startTime;
    private void FixedUpdate()
    {
        if(animate && mainCube.transform.localScale.y > 1.0f)
        {
            PressCube(-1.5f);
        } else if (!animate)
        {
            if(mainCube.transform.localScale.y < 1.5f)
            {
                PressCube(3f);
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

            //Jump

            float force, diff; //сила и время между нажатием и отжатием
            diff = Time.time - startTime;
            if (diff < 3f)
                force = 100 * diff;
            else force = 200f;
            if (force < 40f)
                force = 40f;
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.up * force);
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.right * -force *0.5f);

        }
    }
    void PressCube(float force)
    {
        mainCube.transform.localPosition += new Vector3(0f, force * Time.deltaTime, 0f);
        mainCube.transform.localScale += new Vector3(0f, force * Time.deltaTime, 0f);
    }
}
