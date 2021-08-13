using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenentukanPolaTaman : MonoBehaviour
{
    public GameObject[] papan;

    public TMP_InputField[] Un;
    public TMP_Text dialogue;
    public Button b_lain;

    public TMP_InputField[] inputan;
    private int kuning = 0, hijau = 0,orange = 0;
    public bool isBunga = false ,isKursi = false, bunga = false , kursi = false;

    private string jawabanA , jawabanB , jawabanC;

    void Start()
    {
        foreach (TMP_InputField i in inputan)
        {
            i.interactable = false;
        }
        b_lain.interactable = false;
    }

    void Update()
    {
        if(isBunga)
        {
            if(kuning == 8 && hijau == 4 && orange == 0)
            {
                Selesai();
                dialogue.text = "masukan jawabanmu!";
                isBunga = false;
                bunga = true;
            }
        }
        if(isKursi)
        {
            if(kuning == 3 && hijau == 2 && orange == 1)
            {
                Selesai();
                dialogue.text = "masukan jawabanmu!";
                isKursi = false;
                kursi = true;
            }
        }
    }

    void Selesai()
    {
        foreach (TMP_InputField i Un)
        {
            i.interactable = true;
        }
    }

    void SelesaiJawab()
    {
        foreach (TMP_InputField i inputan)
        {
            i.interactable = true;
        }
    }

    public void InputJawabanA(string j)
    {
        jawabanA = j;
        if(bunga)
        {
            if(jawabanA == "n" && jawabanB == "-1" && jawabanC == "4")
            {
                dialogue.text = "jawaban benar!!";
                b_lain.interactable = true;
            }
        }
        else if(kursi)
        {
            if(jawabanA == "n")
            {
                dialogue.text = "jawaban benar!!";
                b_lain.interactable = true;
            }
        }
    }
    public void InputJawabanB(string j)
    {
        jawabanB = j;
        if(bunga)
        {
            if(jawabanA == "n" && jawabanB == "-1" && jawabanC == "4")
            {
                dialogue.text = "jawaban benar!!";
                b_lain.interactable = true;
            }
        }
        else if(kursi)
        {
            if(jawabanA == "n")
            {
                dialogue.text = "jawaban benar!!";
                b_lain.interactable = true;
            }
        }
    }
    public void InputJawabanC(string j)
    {
        jawabanC = j;
        if(bunga)
        {
            if(jawabanA == "n" && jawabanB == "-1" && jawabanC == "4")
            {
                dialogue.text = "jawaban benar!!";
                b_lain.interactable = true;
            }
        }
        else if(kursi)
        {
            if(jawabanA == "n")
            {
                dialogue.text = "jawaban benar!!";
                b_lain.interactable = true;
            }
        }
    }

    public void InputBahan(string bahan , string warna)
    {
        if(warna == "kuning")
        {
            InputKuning(bahan);
        }
        else if(warna == "hijau")
        {
            InputHijau(bahan);
        }
        else if(warna == "orange")
        {
            InputOrange(bahan);
        }
    }

    void InputKuning(string bahan)
    {
        kuning++;
        for (int i = 0; i < kuning; i++)
        {
            papan[0].transform.GetChild(i).gameObject.SetActive(true);
        }
        if(bahan == "bunga")
        {
            float m = (float)kuning / 2f;
            Un[0].text = Mathf.Floor(m).ToString();
            if(kuning >= 8)
            {
                kuning = 8;
                papan[0].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if(bahan == "kursi")
        {
            Un[0].text = kuning.ToString();
            if(kuning >= 3)
            {
                kuning = 3;
                papan[0].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
    void InputHijau(string bahan)
    {
        hijau++;
        for (int i = 0; i < hijau; i++)
        {
            papan[1].transform.GetChild(i).gameObject.SetActive(true);
        }
        if(bahan == "bunga")
        {
            Un[1].text = hijau.ToString();
            if(hijau >= 4)
            {
                hijau = 4;
                papan[1].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if(bahan == "kursi")
        {
            Un[1].text = hijau.ToString();
            if(hijau >= 2)
            {
                hijau = 2;
                papan[1].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
    void InputOrange(string bahan)
    {
        orange++;
        for (int i = 0; i < orange; i++)
        {
            papan[2].transform.GetChild(i).gameObject.SetActive(true);
        }
        if(bahan == "kursi")
        {
            Un[2].text = orange.ToString();
            if(orange >= 1)
            {
                orange = 1;
                papan[2].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    public void PindahKe(int n)
    {
        SceneManager.LoadScene(n);
    }
}
