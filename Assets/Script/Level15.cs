using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level15 : MonoBehaviour
{
    public List<GameObject> kunyit;

    public void DeleteAllKunyit()
    {
        foreach (GameObject g in kunyit)
        {
            Destroy(g);
        }
    }
}
