using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level15 : MonoBehaviour
{
    public List<GameObject> kunyit;

    void Update()
    {
        // foreach (GameObject g in kunyit)
        // {
        //     kunyit.Remove(!g.activeInHierarchy);
        // }
        if(kunyit.Count < 5)
        {
            Debug.Log("kurang");
        }
    }
}
