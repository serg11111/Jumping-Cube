using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(1.2F, 1.2F, 1.2F);
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(1F, 1F, 1F);
    }

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Restart":

                SceneManager.LoadScene("main");
                break;

        }
    }
}
