using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KeyboardController : MonoBehaviour
{
    public static KeyboardController KC;

    public TMP_InputField input_keyboard;
    public string returnValue;
    
    public GameObject keyboard;

    void Awake()
    {
        if(KC == null)
        {
            KC = this;
        }
        else
        {
            return;
        }
    }
    void Start()
    {
        keyboardStatus(false);
        if(input_keyboard == null)
        {return;}
    }

    // input active -> Jarak 1 = 0; Jarak 2 = 1; Hitung = 2;
    public void keyboardStatus(bool open)
    {
        keyboard.SetActive(open);
    }

    public void typing(Button button)
    {
        string val = input_keyboard.text;
        string val2 = button.name.ToString();
        string str = val+val2;
        input_keyboard.text = str;
        returnValue = str;
    }

    public void SetInputFiled(TMP_InputField i)
    {
        input_keyboard = i;
    }

    public void clearText()
    {
        input_keyboard.text = "";
    }

    public void ButtonOK()
    {
        keyboard.SetActive(false);
    }
}
