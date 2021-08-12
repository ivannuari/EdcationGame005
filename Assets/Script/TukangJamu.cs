using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TukangJamu : MonoBehaviour
{
    public static TukangJamu TJ;

    public GameObject[] pelanggan;
    public TMP_Text[] dialogue;
    private int jumlahJamu , jumlahPermintaan;
    public bool terpenuhi = false;

    public int m_kunyit , m_jahe , m_sereh;
    public TMP_Text t_kunyit , t_jahe , t_sereh , notif;
    private int JamuJadi;
    public GameObject[] BotolJamu;

    private int p;

    void Awake()
    {
        if(TJ == null)
        {
            TJ = this;
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
        notif.gameObject.SetActive(false);
        foreach (GameObject botol in BotolJamu)
        {
            botol.SetActive(false);
        }
    }

    public void CekKepuasan(int i)
    {
        jumlahJamu -= i;

        foreach (GameObject botol in BotolJamu)
        {
            botol.SetActive(false);
        }
        
        if(jumlahJamu == 0)
        {
            StartCoroutine(Benar(true));
        }
        else if(jumlahJamu <= 0)
        {
            StartCoroutine(Benar(false));
        }
    }

    IEnumerator Benar(bool ya)
    {
        if(ya)
        {
            dialogue[p].text = "terimakasih.";
        }
        else
        {
            dialogue[p].text = "ini salah. mengecewakan!";
        }
        yield return new WaitForSeconds(3f);

        if(jumlahPermintaan == 6)
        {
            dialogue[p].text = "selamat, kamu berhasil!";
            yield return new WaitForSeconds(3f);
            GameManager.GM.PindaSceneKe("level2");
        }
        else
        {
            terpenuhi = true;
        }
    }

    public void MasakBahan()
    {
        if(m_sereh == 1 && m_jahe == 2 && m_kunyit == 3)
        {
            Racik(1);
        }
        else if(m_sereh == 2 && m_jahe == 4 && m_kunyit == 6)
        {
            Racik(2);
        }
        else if(m_sereh == 3 && m_jahe == 6 && m_kunyit == 11)
        {
            Racik(3);
        }
        else if(m_sereh == 4 && m_jahe == 8 && m_kunyit == 18)
        {
            Racik(4);
        }
        else if(m_sereh == 5 && m_jahe == 10 && m_kunyit == 27)
        {
            Racik(5);
        }
        else if(m_sereh == 6 && m_jahe == 12 && m_kunyit == 38)
        {
            Racik(6);
        }
        else
        {
            notif.gameObject.SetActive(true);
        }
    }

    void Racik(int i)
    {
        JamuJadi = i;
        BotolJamu[JamuJadi - 1].SetActive(true);
        BotolJamu[JamuJadi - 1].GetComponent<SpriteRenderer>().enabled = true;
        Ulangi();
    }

    public void Ulangi()
    {
        //reset ke 0
        m_sereh = 0; m_kunyit = 0; m_jahe = 0;
        notif.gameObject.SetActive(false);
    }
    
    IEnumerator MulaiBerkunjung()
    {
        terpenuhi = false;

        //set jumlah jamu pelanggan
        jumlahPermintaan++;
        jumlahJamu = jumlahPermintaan;

        //set pelanggan
        p = Random.Range(0 , pelanggan.Length);
        foreach (GameObject pembeli in pelanggan)
        {
            pembeli.SetActive(false);
        }
        foreach (TMP_Text d in dialogue)
        {
            d.gameObject.SetActive(false);
        }
        pelanggan[p].SetActive(true);
        dialogue[p].gameObject.SetActive(true);

        //set dialogue
        dialogue[p].text = "aku mau beli "+ jumlahJamu.ToString() +" jamu.";

        yield return new WaitWhile( ()=> !terpenuhi);

        StartCoroutine(MulaiBerkunjung());
    }

    void Update()
    {
        //set text
        t_jahe.text = m_jahe.ToString();
        t_sereh.text = m_sereh.ToString();
        t_kunyit.text = m_kunyit.ToString();
    }
}
