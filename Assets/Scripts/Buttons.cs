using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(0.02F, 0.02F, 0.02F);
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(0.0187F, 0.0187F, 0.0187F);
    }
}
