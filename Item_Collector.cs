using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Item_Collector : MonoBehaviour
{
    private int point = 0;
    [SerializeField] private AudioSource audioSource;
   
    [SerializeField] private TextMeshProUGUI textcoin;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            audioSource.Play();
            Destroy(collision.gameObject);
            point++;
            textcoin.text = "" + point;
        }
        if (collision.gameObject.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
            GetComponent<Health>().AddHealth(1);
        }
    }
    

}
