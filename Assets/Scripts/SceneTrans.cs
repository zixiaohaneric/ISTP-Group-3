using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//SceneTrans

public class SceneTrans : MonoBehaviour
{
    private AudioSource finishSound;


    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Jason")
        {
            finishSound.Play();
            Invoke("finishLevel", 0.1f);
            
        }
    }
    private void finishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
