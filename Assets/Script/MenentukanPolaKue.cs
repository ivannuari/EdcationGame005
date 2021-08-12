using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenentukanPolaKue : MonoBehaviour
{
    public GameObject[] papan;
    public TMP_Text[] Un;

    public TMP_Text dialogue;
    public Button b_lain;

    public TMP_InputField[] inputan;

    public bool isKue = false , isCake = false , cake = false;

    private int hijau = 0 , kuning = 0 , biru = 0;
    private string jawabanA , jawabanB;

    void Start()
    {
        foreach (TMP_InputField t in inputan)
        {
            t.interactable = false;
        }
        b_lain.interactable = false;
    }

    void Update()
    {
        if(isKue)
        {
            if(hijau == 4 && kuning == 8 && biru == 12)
            {
                Selesai();
                isKue = false;
            }
        }

        if(isCake)
        {
            if(hijau == 1 && kuning == 4 && biru == 9)
            {
                Selesai();
                isCake = false;
                cake = true;
            }
        }
    }

    void Selesai()
    {
        dialogue.text = "masukan jawabanmu!";
        foreach (TMP_InputField t in inputan)
        {
            t.interactable = true;
        }
    }

    public void InputA(string a)
    {
        jawabanA = a;
    }

    public void InputB(string b)
    {
        jawabanB = b;

        if(jawabanA == "4" && jawabanB == "n")
        {
            dialogue.text = "jawaban benar!";
            b_lain.interactable = true;
        }
        else if(jawabanA == "4" && jawabanB == "n")
        {
            dialogue.text = "jawaban benar!";
            b_lain.interactable = true;
        }
        else if(cake == true)
        {
            if(b == "n")
            {
                dialogue.text = "jawaban benar!";
                b_lain.interactable = true;
            }
        }
        else
        {
            dialogue.text = "coba lagi.";
        }
    }

    public void InputBahan(string bahan , string warna)
    {
        if(warna == "hijau")
        {
            InputHijau(bahan);
        }
        else if(warna == "kuning")
        {
            InputKuning(bahan);
        }
        else if(warna == "biru")
        {
            InputBiru(bahan);
        }
    }

    void InputHijau(string n)
    {
        hijau++;
        for (int i = 0; i < hijau; i++)
        {
            papan[0].transform.GetChild(i).gameObject.SetActive(true);
        }

        if(n == "kue")
        {
            float m = (float)hijau / 4f;
            Un[0].text = Mathf.Floor(m).ToString();

            if(n == "kue" && hijau >= 4)
            {
                hijau = 4;
                papan[0].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else if(n == "cake")
        {
            Un[0].text = hijau.ToString();

            if(hijau >= 1)
            {
                hijau = 1;
                papan[0].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        
    }

    void InputKuning(string n)
    {
        kuning++;
        for (int i = 0; i < kuning; i++)
        {
            papan[1].transform.GetChild(i).gameObject.SetActive(true);
        }

        if(n == "kue")
        {
            float m = (float)kuning / 4f;
            Un[1].text = Mathf.Floor(m).ToString();
            
            if(n == "kue" && kuning >= 8)
            {
                kuning = 8;
                papan[1].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else if(n == "cake")
        {
            float m = (float)kuning / 2f;
            Un[1].text = Mathf.Floor(m).ToString();
            
            if(kuning >= 4)
            {
                kuning = 4;
                papan[1].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    void InputBiru(string n)
    {
        biru++;
        for (int i = 0; i < biru; i++)
        {
            papan[2].transform.GetChild(i).gameObject.SetActive(true);
        }

        if(n =="kue")
        {
            float m = (float)biru / 4f;
            Un[2].text = Mathf.Floor(m).ToString();
            
            if(n == "kue" && biru >= 12)
            {
                biru = 12;
                papan[2].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else if(n == "cake")
        {
            float m = (float)biru / 3f;
            Un[2].text = Mathf.Floor(m).ToString();
            
            if(biru >= 9)
            {
                biru = 9;
                papan[2].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    public void PindahKe(int n)
    {
        SceneManager.LoadScene(n);
    }

}
