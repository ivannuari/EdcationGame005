using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public void PilihPeran(string peran)
    {
        if(peran =="penjual kue")
        {
            GameManager.GM.PeranPemain = peran;
        }
        else if(peran =="tukang kebun")
        {
            GameManager.GM.PeranPemain = peran;
        }
        else if(peran =="penjual jamu")
        {
            GameManager.GM.PeranPemain = peran;
        }
    }
    public void ButtonNext()
    {
        if(GameManager.GM.PeranPemain != "")
        {
            GameManager.GM.PindaSceneKe("next");
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
