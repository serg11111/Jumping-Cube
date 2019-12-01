using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour
{
	public GameObject mainCube;
    private bool animate, jumped;
    private float startTime, yPosCube;


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
        if (mainCube.GetComponent<Rigidbody>())
        {
            if(mainCube.GetComponent<Rigidbody>().IsSleeping()&& jumped)
            {
                print("next one");
                //выравнивает куб на платформе
                mainCube.transform.localPosition = new Vector3(-1.45f, mainCube.transform.localPosition.y, mainCube.transform.localPosition.z);
                //направление не меняется при перевороте
                mainCube.transform.eulerAngles = new Vector3(0f, mainCube.transform.eulerAngles.y, 0f);
            }
        }
    }

    void OnMouseDown()
	{
        if(mainCube.GetComponent<Rigidbody>())
        {
            animate = true;
            startTime = Time.time;

            //попали ли мы на другой кубик или на том же?
            yPosCube = mainCube.transform.localPosition.y;
        }
	}

    void OnMouseUp()
	{

        if (mainCube.GetComponent<Rigidbody>())
        {
            animate = false;

            //Jump
            jumped = true;

            float force, diff; //сила и время между нажатием и отжатием
            diff = Time.time - startTime;
            if (diff < 3f)
                force = 200 * diff;
            else force = 300f;
            if (force < 150f)
                force = 150f;
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.up * force);
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.right * -force *0.5f);

            StartCoroutine(checkCubePos());
        }
    }
    void PressCube(float force)
    {
        mainCube.transform.localPosition += new Vector3(0f, force * Time.deltaTime, 0f);
        mainCube.transform.localScale += new Vector3(0f, force * Time.deltaTime, 0f);
    }

    IEnumerator checkCubePos()
    {
        yield return new WaitForSeconds(0.1f);
        if (Mathf.Abs(yPosCube - mainCube.transform.localPosition.y) < 0.5f)
        {
            
                print("Player lose");
            
        }
    }
}
