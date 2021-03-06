﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Sprite mus_on, mus_off;
    public GameObject shopBG;
    public float Bigger, Lower;

    private void Start()
    {
        if(gameObject.name == "Settings")
        {
            if(PlayerPrefs.GetString("Music") == "off")
            {
                transform.GetChild(0).gameObject.GetComponent<Image>().sprite = mus_off;
                Camera.main.GetComponent<AudioListener>().enabled = false; //выключить музыку
            }
        }
    }

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(Bigger, Bigger, Bigger);
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(Lower, Lower, Lower);
    }

    private void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Restart":

                SceneManager.LoadScene("main");
                break;
            case "Facebook":
                Application.OpenURL("https://www.facebook.com/profile.php?id=100023027381617&ref=bookmarks");
                break;
            case "Twitter":
                Application.OpenURL("https://www.twitter.com");
                break;
            case "Google+":
                Application.OpenURL("https://www.google.com");
                break;

            case "Music":

                if (PlayerPrefs.GetString("Music") == "off")
                {
                    GetComponent<Image>().sprite = mus_on;
                    PlayerPrefs.SetString("Music", "on");
                    Camera.main.GetComponent<AudioListener>().enabled = true; //включить музыку
                }
                else
                {
                    GetComponent<Image>().sprite = mus_off;
                    PlayerPrefs.SetString("Music", "off");
                    Camera.main.GetComponent<AudioListener>().enabled = false; //выключить музыку
                }
                break;


            case "Settings":
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(!transform.GetChild(i).gameObject.activeSelf);
                }
                break;

            case "Shop":
                shopBG.SetActive(!shopBG.activeSelf);

                break;
            case "Close":
                shopBG.SetActive(false );
                break;
        }
    }
}
