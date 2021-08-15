using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public string userName;
    public string PeranPemain;

    public bool isMute = false;

    AudioSource source;
    TouchScreenKeyboard keyboard;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        source.mute = isMute;
    }

    void Awake()
    {
        if(GM == null)
        {
            GM =this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PindaSceneKe(string t)
    {
        if(t == "home")
        {
            SceneManager.LoadScene(0);
        }
        else if(t == "info")
        {
            //ke scene info
        }
        else if(t == "level2")
        {
            SceneManager.LoadScene(1);
        }
        else if(t == "level11")
        {
            SceneManager.LoadScene(10);
        }
        else if(t == "next")
        {
            Scene scene = SceneManager.GetActiveScene();
            int s = scene.buildIndex;
            s++;
            SceneManager.LoadScene(s);
        }
        else if(t == "back")
        {
            Scene scene = SceneManager.GetActiveScene();
            int s = scene.buildIndex;
            if(s == 4 || s == 6)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                s--;
                SceneManager.LoadScene(s);
            }
        }
        else if(t == "kue")
        {
            SceneManager.LoadScene(4);
        }
        else if(t == "jamu")
        {
            SceneManager.LoadScene(2);
        }
        else if(t == "kebun")
        {
            SceneManager.LoadScene(6);
        }
        else if(t == "level12")
        {
            SceneManager.LoadScene(11);
        }
        else if(t == "level16")
        {
            SceneManager.LoadScene(15);
        }
        else if(t == "level19")
        {
            SceneManager.LoadScene(18);
        }
    }

    public void BukaKeyboardMobile()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}
