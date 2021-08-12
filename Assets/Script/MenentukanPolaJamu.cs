using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenentukanPolaJamu : MonoBehaviour
{
    public TMP_InputField[] Un;

    public TMP_InputField[] inputJawaban;
    public Button[] bahanLain;
    public TMP_Text dialogue;

    public GameObject[] nampan;
    public bool isSereh = false, isJahe = false, isKunyit = false;
    private bool sereh = false , jahe = false , kunyit = false;

    private string a , b , hj , kn , br , hj2 , br2;

    private int hijau , kuning , biru , hijau1 , biru1;

    void Start()
    {
        hijau = 0; kuning = 0; biru = 0;

        foreach (TMP_InputField i in Un)
        {
            i.interactable = false;
        }

        foreach (TMP_InputField i in inputJawaban)
        {
            i.interactable = false;
        }
        
        foreach (Button b in bahanLain)
        {
            b.interactable = false;
        }
    }

    void Update()
    {
        if(isSereh)
        {
            if(hijau == 1 && kuning == 2 && biru == 3)
            {
                Selesai();
                isSereh = false;
                sereh = true;
            }
        }
        if(isJahe)
        {
            if(hijau == 2 && kuning == 4 && biru == 6)
            {
                Selesai();
                isJahe = false;
                jahe = true;
            }
        }
        if(isKunyit)
        {
            if(hijau == 2 && hijau1 == 1 && biru == 2 && biru1 == 3)
            {
                Selesai();
                isKunyit = false;
                kunyit = true;
            }
        }
    }

    void Selesai()
    {
        dialogue.text = "masukan jawaban mu!";
        foreach (TMP_InputField i in Un)
        {
            i.interactable = true;
        }
    }

    void JawabanBenar()
    {
        dialogue.text = "masukan jawaban mu!";
        foreach (TMP_InputField i in inputJawaban)
        {
            i.interactable = true;
        }
    }

    public void Jawaban(string j)
    {
        a = j;
        if(sereh && a == "n")
        {
            dialogue.text = "kamu benar!";
            foreach (Button b in bahanLain)
            {
                b.interactable = true;
            }
        }
        else if(jahe && a == "n" && b == "2")
        {
            dialogue.text = "kamu benar!";
            foreach (Button b in bahanLain)
            {
                b.interactable = true;
            }
        }
        else if(kunyit && a == "2" && b == "n")
        {
            dialogue.text = "kamu benar!";
            foreach (Button b in bahanLain)
            {
                b.interactable = true;
            }
        }
        else
        {
            dialogue.text = "coba lagi.";
        }
    }

    public void InputJawabanKiri(string aa)
    {
        b = aa;
    }

    public void JawabanKuning(string k)
    {
        kn = k;
        Debug.Log(k);
        if(sereh)
        {
            if(hj == "1" && kn == "2" && br == "3")
            {
                JawabanBenar();
            }
        }
        else if(jahe)
        {
            if(hj == "1" && kn == "2" && br == "3")
            {
                JawabanBenar();
            }
        }
        else if(kunyit)
        {
            if(hj == "1" && hj2 == "2" && br == "2" && br2 == "3")
            {
                JawabanBenar();
            }
        }
    }

    public void JawabanHijau(string h)
    {
        hj = h;
        Debug.Log(h);
        if(sereh)
        {
            if(hj == "1" && kn == "2" && br == "3")
            {
                JawabanBenar();
            }
        }
        else if(jahe)
        {
            if(hj == "1" && kn == "2" && br == "3")
            {
                JawabanBenar();
            }
        }
        else if(kunyit)
        {
            if(hj == "1" && hj2 == "2" && br == "2" && br2 == "3")
            {
                JawabanBenar();
            }
        }
    }

    public void JawabanBiru(string b)
    {
        br = b;
        Debug.Log(b);
        if(sereh)
        {
            if(hj == "1" && kn == "2" && br == "3")
            {
                JawabanBenar();
            }
        }
        else if(jahe)
        {
            if(hj == "1" && kn == "2" && br == "3")
            {
                JawabanBenar();
            }
        }
        else if(kunyit)
        {
            if(hj == "1" && hj2 == "2" && br == "2" && br2 == "3")
            {
                JawabanBenar();
            }
        }
    }

    public void InputBahan(string bahan , string warna)
    {
        if(warna == "hijau")
        {
            inputHijau(bahan);
        }
        else if(warna == "kuning")
        {
            inputKuning(bahan);
        }
        else if(warna == "biru")
        {
            inputBiru(bahan);
        }
        else if(warna == "hijau1")
        {
            inputHijau1(bahan);
        }
        else if(warna == "biru1")
        {
            inputBiru1(bahan);
        }   
    }

    void inputHijau1(string bahan)
    {
        if(bahan == "kunyit")
        {
            hijau1++;
            for (int i = 0; i < hijau1 ; i++)
            {
                nampan[1].transform.GetChild(i).gameObject.SetActive(true);
            }
            nampan[1].GetComponent<BoxCollider2D>().enabled = false;
            Un[1].text = hijau1.ToString();
        }
    }

    void inputBiru1(string bahan)
    {
        if(bahan == "kunyit")
        {
            biru1++;
            for (int i = 0; i < biru1 ; i++)
            {
                nampan[3].transform.GetChild(i).gameObject.SetActive(true);
            }
            if(biru1 == 3)
            {
                nampan[3].GetComponent<BoxCollider2D>().enabled = false;
            }
            Un[3].text = biru1.ToString();
        }
    }

    void inputHijau(string bahan)
    {
        hijau++;
        for (int i = 0; i < hijau ; i++)
        {
            nampan[0].transform.GetChild(i).gameObject.SetActive(true);
        }

        if(bahan == "sereh")
        {
            if(hijau == 1)
            {
                hijau = 1;
                nampan[0].GetComponent<BoxCollider2D>().enabled = false;
            } 
        }
        else if(bahan == "jahe")
        {
            if(hijau >= 2)
            {
                hijau = 2;
                nampan[0].GetComponent<BoxCollider2D>().enabled = false;
            }
            
        }
        else if(bahan == "kunyit" && hijau >= 2)
        {
            hijau = 2;
            nampan[0].GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }

    void inputKuning(string bahan)
    {
        kuning++;
        for (int i = 0; i < kuning ; i++)
        {
            nampan[1].transform.GetChild(i).gameObject.SetActive(true);
        }

        if(bahan == "sereh")
        {
            if(kuning >= 2)
            {
                kuning = 2;
                nampan[1].GetComponent<BoxCollider2D>().enabled = false;
            }
            
        }
        else if(bahan == "jahe")
        {
            if(kuning >= 4)
            {
                kuning = 4;
                nampan[1].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else if(bahan == "kunyit" && kuning >= 6)
        {
            kuning = 6;
            nampan[1].GetComponent<BoxCollider2D>().enabled = false;
        }  
    }

    void inputBiru(string bahan)
    {
        biru++;
        for (int i = 0; i < biru; i++)
        {
            nampan[2].transform.GetChild(i).gameObject.SetActive(true);
        }

        if(bahan == "sereh")
        {
            if(biru >= 3)
            {
                biru = 3;
                nampan[2].GetComponent<BoxCollider2D>().enabled = false;
            }
            
        }
        else if(bahan == "jahe")
        {
            if(biru >= 6)
            {
                biru = 6;
                nampan[2].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else if(bahan == "kunyit")
        {
            if(biru >= 2)
            {
                biru = 2;
                nampan[2].GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    public void ButtonBahanLain(int s)
    {
        SceneManager.LoadScene(s);
    }
}
