﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStarts : MonoBehaviour
{
    public GameObject star;
    void Start()
    {
        StartCoroutine( spawn());    
    }
    IEnumerator spawn()
    {
        while (true)
        {
            //появление звезд будет случайным по высоте и ширине нашего экрана 
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane/2));
            //создаем звезду в позиции pos, без вращения 
            Instantiate(star, pos, Quaternion.Euler(0,0, Random.Range(0f, 360f)));
            //каждую секунду создается
            yield return new WaitForSeconds(5.1f);
        }
    }
    
}
