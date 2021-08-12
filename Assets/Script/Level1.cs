using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level1 : MonoBehaviour
{
    public Button[] menuButton;
    public TMP_Text nama;

    void Start()
    {
        if(GameManager.GM.userName != "")
        {
            foreach (Button b in menuButton)
            {
                b.interactable = true;
                nama.text = GameManager.GM.userName;
            }
        }
        else
        {
            foreach (Button b in menuButton)
            {
                b.interactable = false;
            }
        }
    }
    public void PilihMenu(int i)
    {
        if(i == 0)
        {
            GameManager.GM.PindaSceneKe("level2");
        }
        if(i == 1)
        {
            GameManager.GM.PindaSceneKe("level11");
        }
        if(i == 2)
        {
            //evaluasi
        }
    }

    public void MasukanNama(string nama)
    {
        GameManager.GM.userName = nama;

        if(GameManager.GM.userName != "")
        {
            foreach (Button b in menuButton)
            {
                b.interactable = true;
            }
        }
    }

    public void SetMic()
    {
        if(GameManager.GM.isMute)
        {
            GameManager.GM.isMute = false;
        }
        else
        {
            GameManager.GM.isMute = true;
        }
    }
    public void ButtonLevel(string t)
    {
        GameManager.GM.PindaSceneKe(t);
    }
}
