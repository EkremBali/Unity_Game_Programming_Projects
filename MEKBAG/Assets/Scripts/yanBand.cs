using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yanBand : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ayarla(int uzunluk)
    {
        Transform Tezgah = transform.GetChild(0);
        Transform band = transform.GetChild(1);

        float fark1 = uzunluk - band.localScale.x;
        band.localScale = new Vector3(uzunluk, 1, 1);
        float x = 50 + (fark1 * 5);
        band.localPosition = new Vector3(x, 1, 0);

        int x1 = uzunluk * 10;

        Tezgah.localPosition = new Vector3(x1, 1, 0);
    }

    public void cantaKapa()
    {
        Transform t = transform.GetChild(transform.childCount - 1);

        for (int i = 0; i < t.childCount; i++)
        {
            t.gameObject.SetActive(false);
        }
    }
}
