using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESC : MonoBehaviour
{
    public GameObject menuList;
    [SerializeField] private bool menuKeys = true;
    [SerializeField] private AudioSource bgmSound; //IMPORT AUDIO VARIABLE
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menuKeys)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuList.SetActive(true);
                menuKeys = false;
                Time.timeScale = (0);
                bgmSound.Pause();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuList.SetActive(false);
            menuKeys = true;
            Time.timeScale = (1);
            bgmSound.Play();
        }
    }
    public void Return()
    {
        menuList.SetActive(false);
        menuKeys = true;
        Time.timeScale = (1);
        bgmSound.Play();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
}

