using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelFinalCanvas : MonoBehaviour
{
    public int dogruDizaynSayisi;
    public int istenenCantaSayisi;
    public int yanlisCantaSayisi;
    public int dogruCantaSayisi;
    public int toplamPara;
    public int gelir;
    public int carptiMi;
    public float elemanInt;
    public float reklamInt;

    public Text tasarýmText;
    public Text dogruCantaText;
    public Text yanlisCantaText;
    public Text gelirText;
    public Text paraText;
    public Text elemanText;
    public Text reklamText;
    public Text sonrakiBolumText;
    void Start()
    {
        elemanInt = PlayerPrefs.GetFloat("slider0");
        reklamInt = PlayerPrefs.GetFloat("slider3");
        gelir = 0;
        carptiMi = PlayerPrefs.GetInt("carptiMi");
        dogruDizaynSayisi=PlayerPrefs.GetInt("dogruDizayn");
        istenenCantaSayisi = PlayerPrefs.GetInt("istenenCanta");
        yanlisCantaSayisi = PlayerPrefs.GetInt("yanlisCanta");
        dogruCantaSayisi = PlayerPrefs.GetInt("dogruCanta");
        toplamPara = PlayerPrefs.GetInt("hepPara");

        tasarýmText.text = dogruDizaynSayisi + "/3";
        dogruCantaText.text = dogruCantaSayisi + "/" + istenenCantaSayisi;
        yanlisCantaText.text = yanlisCantaSayisi+"";
        elemanText.text = ((int)elemanInt + 1) + "x";
        reklamText.text = ((int)elemanInt + 1) + "x";

        gelir += (dogruCantaSayisi * 10*dogruDizaynSayisi);
        gelir -= ((istenenCantaSayisi - dogruCantaSayisi) * 12);
        gelir -= (yanlisCantaSayisi * 15);
        if (carptiMi==1)
        {
            gelir -= 10;
        }
        if (elemanInt != 0)
        {
            gelir *= ((int)elemanInt + 1);
        }
        else
        {
            elemanText.GetComponent<Text>().enabled = false;
        }
        if (reklamInt != 0)
        {
            gelir *= ((int)reklamInt + 1);
        }
        else
        {
            reklamText.GetComponent<Text>().enabled = false;
        }
        if (gelir < 0)
        {
            gelir=0;
        }
        if(gelir <= 20)
        {
            sonrakiBolumText.text = "Tekrar Dene";
        }
        //PlayerPrefs.SetInt("gelir", gelir);
        toplamPara += gelir;
        gelirText.text = gelir+"";
        PlayerPrefs.SetInt("hepPara", toplamPara);
        paraText.text = toplamPara + "";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
