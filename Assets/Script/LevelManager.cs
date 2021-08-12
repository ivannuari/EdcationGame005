using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager LM;

    void Awake()
    {
        if(LM == null)
        {
            LM = this;
        }
        else
        {
            Destroy(gameObject);
            return;
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
