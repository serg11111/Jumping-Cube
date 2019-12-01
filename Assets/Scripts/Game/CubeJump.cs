using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeJump : MonoBehaviour
{
	public GameObject mainCube;
    private bool animate, nextBlock, lose;
    private float startTime, yPosCube;

    private void Start()
    {
        StartCoroutine(CanJump());
    }

    private void FixedUpdate()
    {
        if(animate && mainCube.transform.localScale.y > 1.0f)
        {
            PressCube(-1.5f);
        } else if (!animate && mainCube != null)
        {
            if(mainCube.transform.localScale.y < 1.5f)
            {
                PressCube(3f);
            }else if(mainCube.transform.localScale.y != 1.5f)
            {
                mainCube.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }
        }

        if (mainCube != null)
        {
            //если куб окончательно упал игра окончена
            if (mainCube.transform.localPosition.y < -18.0f)
            {
                Destroy(mainCube, 1f);
                print("Player Lose");
                lose = true;
            }
        }
    }

    void OnMouseDown()
	{
        if(nextBlock && mainCube.GetComponent<Rigidbody>())
        {
            animate = true;
            startTime = Time.time;

            //попали ли мы на другой кубик или на том же?
            yPosCube = mainCube.transform.localPosition.y;
        }
	}

    void OnMouseUp()
	{

        if (nextBlock && mainCube.GetComponent<Rigidbody>())
        {
            animate = false;

            //Jump


            float force, diff; //сила и время между нажатием и отжатием
            diff = Time.time - startTime;
            if (diff < 3f)
                force = 200 * diff;
            else force = 350f;
            if (force < 100f)
                force = 100f;
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.up * force);
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.right * -force *0.5f);

            StartCoroutine(checkCubePos());
            nextBlock = false;
        }
    }
    void PressCube(float force)
    {
        mainCube.transform.localPosition += new Vector3(0f, force * Time.deltaTime, 0f);
        mainCube.transform.localScale += new Vector3(0f, force * Time.deltaTime, 0f);
    }

    IEnumerator checkCubePos()
    {
        yield return new WaitForSeconds(1.5f);
        if (Mathf.Abs(yPosCube - mainCube.transform.localPosition.y) < 0.5f)
        {

            print("Player lose");
            lose = true;

        }
        else
        {
            while (!mainCube.GetComponent<Rigidbody>().IsSleeping())
            {
                yield return new WaitForSeconds(0.05f);
                if (mainCube == null)
                    break;
            }

            if (!lose)
            {
                nextBlock = true;
                print("next one");

                //выравнивает куб на платформе
                mainCube.transform.localPosition = new Vector3(-1.45f, mainCube.transform.localPosition.y, mainCube.transform.localPosition.z);
                //направление не меняется при перевороте
                mainCube.transform.eulerAngles = new Vector3(0f, mainCube.transform.eulerAngles.y, 0f);
            }
        }
    }

    IEnumerator CanJump()
    {
        while (!mainCube.GetComponent<Rigidbody>())
        yield return new WaitForSeconds(0.05f);

        yield return new WaitForSeconds(1f);
        nextBlock = true;
        
    }
}
