using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
