using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectDiamonds : MonoBehaviour
{
    public Text diamonds;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Diamond")
        {
            //при контакте кубика с алмазом алмаз уничтожится
            Destroy(other.gameObject);

            //увеличить общий счет уничтоженных алмазов на 1
            PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 1);

            //задать тексту алмазов количество собранных
            diamonds.text = PlayerPrefs.GetInt("Diamonds").ToString();
        }
    }
}
