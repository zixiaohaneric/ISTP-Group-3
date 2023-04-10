using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject DialogueBox;
   
    private bool playernpc;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            DialogueBox.SetActive(true);
            playernpc = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("2");
        DialogueBox.SetActive(false);
        playernpc = false;
    }
}
