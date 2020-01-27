using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCubes : MonoBehaviour
{
    public GameObject cubes;

    private Vector3 screenPoint, offset;
    private float _lockedYpos;

    void Update()
    {
        if(cubes.transform.position.x > 0)
        {
            cubes.transform.position = Vector3.MoveTowards(cubes.transform.position, new Vector3(0f, cubes.transform.position.y, cubes.transform.position.z), Time.deltaTime * 10f);
        }else if(cubes.transform.position.x < -5)
        {
            cubes.transform.position = Vector3.MoveTowards(cubes.transform.position, new Vector3(-5f, cubes.transform.position.y, cubes.transform.position.z), Time.deltaTime * 10f);
        }
    }

    void OnMouseDown()
    {
        _lockedYpos = 2f;
        offset = cubes.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Cursor.visible = false;     //курсор не виден
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);//то где находится мышка
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.y = _lockedYpos;

        cubes.transform.position = curPosition; // двигаем кубы на позицию curPosition
    }
    void OnMouseUp()
    {
        Cursor.visible = true;    
    }
}
