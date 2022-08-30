using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraKontrol : MonoBehaviour
{
    public GameObject[] kameralar;
    private int j = 0;


    void Start()
    {
        for (int i = 0; i < kameralar.Length; i++)
        {
            kameralar[i].SetActive(false);
        }
        kameralar[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            kameralar[j].SetActive(false);
            j++;
            if (j == 2) { j = 0; }
            kameralar[j].SetActive(true);

        }
    }
}
