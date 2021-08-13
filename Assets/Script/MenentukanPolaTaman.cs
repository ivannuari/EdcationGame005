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

    private string jawabanA , jawabanB , jawabanC , kn , hj , or;

    void Start()
    {
        foreach (TMP_InputField i in inputan)
        {
            i.interactable = false;
        }
        foreach (TMP_InputField i in Un)
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
        foreach (TMP_InputField i in Un)
        {
            i.interactable = true;
        }
    }

    void SelesaiJawab()
    {
        foreach (TMP_InputField i in inputan)
        {
            i.interactable = true;
        }
    }

    public void Input1(string h)
    {
        hj = h;

        if(kursi)
        {
            if(hj == "1" && kn == "2" && or == "3")
            {
                SelesaiJawab();
            }
        }
        else if(bunga)
        {
            if(hj == "0" && kn == "4" && or == "4")
            {
                SelesaiJawab();
            }
        }
    }

    public void Input2(string k)
    {
        kn = k;

        if(kursi)
        {
            if(hj == "1" && kn == "2" && or == "3")
            {
                SelesaiJawab();
            }
        }
         else if(bunga)
        {
            if(hj == "0" && kn == "4" && or == "4")
            {
                SelesaiJawab();
            }
        }
    }

    public void Input3(string o)
    {
        or = o;

        if(kursi)
        {
            if(hj == "1" && kn == "2" && or == "3")
            {
                SelesaiJawab();
            }
        }
         else if(bunga)
        {
            if(hj == "0" && kn == "4" && or == "4")
            {
                SelesaiJawab();
            }
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
            if(kuning >= 8)
            {
                kuning = 8;
                papan[0].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if(bahan == "kursi")
        {
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
            if(hijau >= 4)
            {
                hijau = 4;
                papan[1].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if(bahan == "kursi")
        {
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
