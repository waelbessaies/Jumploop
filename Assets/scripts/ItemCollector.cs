using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int Bottles = 0;
    [SerializeField] private Text Bottletext;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bottle"))
        {
            Destroy(collision.gameObject);
            Bottles++;
            Bottletext.text = "Bottle:" + Bottles;
        }
    }
}
