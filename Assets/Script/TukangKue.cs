using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TukangKue : MonoBehaviour
{
    public static TukangKue TK;

    public GameObject[] pelanggan;
    public TMP_Text[] dialogue;

    public int typePaket;

    public GameObject[] kotakKue;

    public GameObject buttonCek , infoText;

    public bool terpenuhi;
    private int p , k , angka1 , angka2;

    void Awake()
    {
        if(TK == null)
        {
            TK = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        StartCoroutine(MulaiBerkunjung());
        infoText.SetActive(false);
        
    }

    public void InputUkuranBoxPertama(string n)
    {
        angka1 = int.Parse(n);
    }
    public void InputUkuranBoxKedua(string n)
    {
        foreach (GameObject kk in kotakKue)
        {
            kk.SetActive(false);
        }
        angka2 = int.Parse(n);
        if(angka1 == 3 && angka2 == 3)
        {
            InputUkuranTotal(0);
        }
        else if(angka1 == 4 && angka2 == 4)
        {
            InputUkuranTotal(1);
        }
        else if(angka1 == 5 && angka2 == 5)
        {
            InputUkuranTotal(2);
        }
        else if(angka1 == 6 && angka2 == 6)
        {
            InputUkuranTotal(3);
        }
        else if(angka1 == 7 && angka2 == 7)
        {
            InputUkuranTotal(4);
        }
        else if(angka1 == 8 && angka2 == 8)
        {
            InputUkuranTotal(5);
        }
        else
        {
            angka1 = 0; angka2 = 0;
            infoText.SetActive(true);
            StartCoroutine(Tunggu());
        }
    }

    IEnumerator Tunggu()
    {
        yield return new WaitForSeconds(1.5f);
        infoText.SetActive(false);
    }

    void InputUkuranTotal(int grid)
    {
        k = 0;
        kotakKue[grid].SetActive(true);

        foreach (Transform t in kotakKue[grid].transform)
        {
            t.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator MulaiBerkunjung()
    {
        terpenuhi = false;
        k = 0;
        buttonCek.SetActive(false);

        foreach (GameObject kk in kotakKue)
        {
            kk.SetActive(false);
        }

        //set permintaan
        typePaket++;;

        //set pelanggan
        p = Random.Range(0 , 2);
        foreach (GameObject pembeli in pelanggan)
        {
            pembeli.SetActive(false);
        }
        pelanggan[p].SetActive(true);

        StartCoroutine(SetDialogue());
        yield return new WaitWhile( ()=> !terpenuhi);

        StartCoroutine(MulaiBerkunjung());
    }

    public void CekKotak()
    {
        k++;
        if(typePaket == 1 && k == 9 || typePaket == 2 && k == 16 || typePaket == 3 && k == 25 || typePaket == 4 && k == 36 || typePaket == 5 && k == 49 || typePaket == 6 && k == 64)
        {
            buttonCek.SetActive(true);
        }
    }

    IEnumerator SetDialogue()
    {
        foreach (TMP_Text d in dialogue)
        {
            d.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(1f);
        dialogue[p].gameObject.SetActive(true);

        dialogue[p].text = "Tolong paket "+ typePaket.ToString() +" nya ya.";
    }

    public void CekButton()
    {
        if(typePaket == 1 && k == 9 || typePaket == 2 && k == 16 || typePaket == 3 && k == 25 || typePaket == 4 && k == 36 || typePaket == 5 && k == 49 || typePaket == 6 && k == 64)
        {
            StartCoroutine(TextDialogue(true));
        }
        else
        {
            StartCoroutine(TextDialogue(false));
        }
    }

    IEnumerator TextDialogue(bool benar)
    {
        if(benar)
        {
            dialogue[p].text = "terimakasih.";
            yield return new WaitForSeconds(1f);
            if(typePaket == 6)
            {
                dialogue[p].text = "kamu berhasil!";
                yield return new WaitForSeconds(2f);
                GameManager.GM.PindaSceneKe("level2");
            }
            terpenuhi = true;
        }
        else
        {
            dialogue[p].text = "saya tidak pesan ini.";
            yield return new WaitForSeconds(1f);
            StartCoroutine(SetDialogue());
        }   
    }

    public void BukaKeyboard()
    {
        GameManager.GM.BukaKeyboardMobile();
    }
}
