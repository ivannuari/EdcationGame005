using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bahan : MonoBehaviour
{
    public string namaBahan;
    public bool tukangKue = false;
    public bool TukangKebun = false;

    private Vector3 startPos;
    private Vector3 StartSize;
    private Quaternion StartRot;
    private bool isDraging = false;

    SpriteRenderer rend;
    BoxCollider2D cl2D;

    void Start()
    {
        startPos = transform.position;
        StartSize = transform.localScale;
        StartRot = transform.rotation;

        rend = GetComponent<SpriteRenderer>();
        cl2D = GetComponent<BoxCollider2D>();
    }

    void OnMouseDown()
    {
        isDraging = true;
        if(tukangKue)
        {
            transform.localScale = new Vector3(0.05f , 0.05f , 1f);
        }
        else if(TukangKebun)
        {
            if(namaBahan == "bunga")
            {
                transform.localScale = new Vector3(0.5f , 0.5f , 1f);
                transform.rotation = Quaternion.Euler(0f , 0f , 0f);
            }
            else
            {
                transform.localScale = new Vector3(0.15f , 0.15f , 1f);
            }
        }
    }

    void OnMouseDrag()
    {
        Vector3 pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pointerPosition.z = transform.position.z;
        transform.position = pointerPosition;
    }

    void OnMouseUp()
    {
        isDraging = false;
        transform.position = startPos;
        transform.localScale = StartSize;
        transform.rotation = StartRot;

        rend.enabled = true;
        cl2D.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D cl)
    {
        if(cl.CompareTag("panci"))
        {
            transform.position = startPos;
            rend.enabled = false;
            cl2D.enabled = false;
            if(namaBahan == "jahe")
            {
                TukangJamu.TJ.m_jahe++;
            }
            else if(namaBahan == "kunyit")
            {
                TukangJamu.TJ.m_kunyit++;
            }
            else if(namaBahan == "sereh")
            {
                TukangJamu.TJ.m_sereh++;
            }
        }
        else if(cl.CompareTag("Pembeli"))
        {
            transform.position = startPos;
            rend.enabled = false;
            if(namaBahan == "botol 1")
            {
                BotolJamu(1);
            }
            else if(namaBahan =="botol 2")
            {
                BotolJamu(2);
            }
            else if(namaBahan =="botol 3")
            {
                BotolJamu(3);
            }
            else if(namaBahan =="botol 4")
            {
                BotolJamu(4);
            }
            else if(namaBahan =="botol 5")
            {
                BotolJamu(5);
            }
            else if(namaBahan =="botol 6")
            {
                BotolJamu(6);
            }
        }
        else if(cl.CompareTag("kotak"))
        {
            SpriteRenderer r = cl.GetComponent<SpriteRenderer>();
            if(r.sprite == rend.sprite && r.enabled == false)
            {
                isDraging = false;
                rend.enabled = false;
                cl2D.enabled = false;
                transform.position = startPos;
                r.enabled = true;
                if(r.enabled == true)
                {
                    TukangKue.TK.CekKotak();
                }
            }
        }
        else if(cl.CompareTag("taman"))
        {
            SpriteRenderer r = cl.GetComponent<SpriteRenderer>();
            if(cl.gameObject.name == gameObject.name && r.enabled == false)
            {
                isDraging = false;
                rend.enabled = false;
                cl2D.enabled = false;
                r.enabled = true;
                
                if(r.enabled == true)
                {
                    GameObject LM = LevelManager.LM.gameObject;
                    LM.GetComponent<TukangKebun>().CekKebun();
                }
            }
        }
        else if(cl.CompareTag("nampan"))
        {
            GameObject LM = LevelManager.LM.gameObject;
            LM.GetComponent<MenentukanPolaJamu>().InputBahan(gameObject.name , cl.name);
            Destroy(gameObject);
        }
        else if(cl.CompareTag("papankue"))
        {
            GameObject LM = LevelManager.LM.gameObject;
            LM.GetComponent<MenentukanPolaKue>().InputBahan(gameObject.name , cl.name);
            Destroy(gameObject);
        }
        else if(cl.CompareTag("lahan"))
        {
            GameObject LM = LevelManager.LM.gameObject;
            LM.GetComponent<MenentukanPolaTaman>().InputBahan(gameObject.name , cl.name);
            Destroy(gameObject);
        }
    }

    void BotolJamu(int n)
    {
        TukangJamu.TJ.CekKepuasan(n);
        transform.position = startPos;
        rend.enabled = false;
    }

}
