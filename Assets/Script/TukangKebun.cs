using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TukangKebun : MonoBehaviour
{
    public static TukangKebun tukangKebun;

    public bool terpenuhi = false;

    public GameObject panelDialogue , buttonCek;
    public TMP_Text dialogue;

    public GameObject[] papanTaman;
    private int typePermintaan , angka1 , angka2 , showUp;

    void Awake()
    {
        if(tukangKebun == null)
        {
            tukangKebun = this;
        }
        else
        {
            return;
        }
    }

    void Start()
    {
        panelDialogue.SetActive(false);
        buttonCek.SetActive(false);
        StartCoroutine(MulaiMembuat());
    }

    public void CekKebun()
    {
        showUp++;
        if(typePermintaan == 1 && showUp == 5)
        {
            buttonCek.SetActive(true);
        }
        else if(typePermintaan == 2 && showUp == 10)
        {
            buttonCek.SetActive(true);
        }
        else if(typePermintaan == 3 && showUp == 15)
        {
            buttonCek.SetActive(true);
        }
        else if(typePermintaan == 4 && showUp == 20)
        {
            buttonCek.SetActive(true);
        }
        else if(typePermintaan == 5 && showUp == 25)
        {
            buttonCek.SetActive(true);
        }
        else if(typePermintaan == 6 && showUp == 30)
        {
            buttonCek.SetActive(true);
        }
    }

    IEnumerator MulaiMembuat()
    {
        terpenuhi = false;
        buttonCek.SetActive(false);
        foreach (GameObject g in papanTaman)
        {
            g.SetActive(false);
        }

        panelDialogue.SetActive(true);

        typePermintaan = Random.Range(1 , 7);

        dialogue.text = "saya ingin taman type "+ typePermintaan.ToString();

        yield return new WaitWhile( ()=> !terpenuhi);

        StartCoroutine(MulaiMembuat());
    }

    public void InputAngkaPertama(string no)
    {
        angka1 = int.Parse(no);
    }

    public void InputAngkaKedua(string no)
    {
        angka2 = int.Parse(no);

        if(angka1 == 3 && angka2 == 3)
        {
            MunculLahan(0);
        }
        else if(angka1 == 4 && angka2 == 4)
        {
            MunculLahan(1);
        }
        else if(angka1 == 5 && angka2 == 5)
        {
            MunculLahan(2);
        }
        else if(angka1 == 6 && angka2 == 6)
        {
            MunculLahan(3);
        }
        else if(angka1 == 7 && angka2 == 7)
        {
            MunculLahan(4);
        }
        else if(angka1 == 8 && angka2 == 8)
        {
            MunculLahan(5);
        }
    }

    void MunculLahan(int ha)
    {
        showUp = 0;
        foreach (GameObject g in papanTaman)
        {
            g.SetActive(false);
        }
        papanTaman[ha].SetActive(true);
        foreach (Transform t in papanTaman[ha].transform)
        {
            t.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void CekKepuasan()
    {
        terpenuhi = true;
        panelDialogue.SetActive(false);
        // if(typePermintaan == 1 && showUp == 5)
        // {
            
        // }
        // else if(typePermintaan == 2 && showUp == 10)
        // {
        //     terpenuhi = true;
        // }
        // else if(typePermintaan == 3 && showUp == 15)
        // {
        //     terpenuhi = true;
        // }
        // else if(typePermintaan == 4 && showUp == 20)
        // {
        //     terpenuhi = true;
        // }
        // else if(typePermintaan == 5 && showUp == 25)
        // {
        //     terpenuhi = true;
        // }
        // else if(typePermintaan == 6 && showUp == 30)
        // {
        //     terpenuhi = true;
        // }
    }
}
