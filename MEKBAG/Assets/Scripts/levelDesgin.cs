using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class levelDesgin : MonoBehaviour
{
    public Text renk1Text;
    public Text renk2Text;
    public Text desenText;
    public Text levelText;

    //public Camera cam;
    public GameObject engel2;
    public GameObject[] makineler;

    public GameObject[] sahnedekiCantalar;
    public GameObject[] cantalar;
    public Material[] renkler;
    public Material[] desenler;

    GameObject hedefCanta, yanlisCanta, sahnedekiCanta;
    Material hedefRenk, hedefDesen, yanlisRenk, yanlisDesen, hedefRenk2, yanlisRenk2;

    public List<GameObject> trueBagPoints;

    public GameObject[] yollar;

    void Start()
    {
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", -1);
            PlayerPrefs.SetInt("yolUzunlugu", 1);
            PlayerPrefs.SetInt("dogruCantaSayisi", 0);
            PlayerPrefs.SetInt("yanlisCantaSayisi", 0);
            PlayerPrefs.SetInt("engelSayisi", 0);
            PlayerPrefs.SetInt("maxDogruCanta", 3);
            PlayerPrefs.SetInt("maxYanlisCanta", 2);
            //PlayerPrefs.SetInt("bantSayisi", 1);
        }

        levelText.text = PlayerPrefs.GetInt("level") + 2 + "";

        trueBagPoints = new List<GameObject>();
        makineBelirleme();
        tezgahBelirleme();
        hedefCantaBelirle();
        makineRenkleriAyarla();
        cantalarUret();
        bantOlustur();


    }

    
    void Update()
    {
        
    }

    public void tezgahBelirleme()
    {
        float yolUzunlugu = PlayerPrefs.GetFloat("slider2");
        yolUzunlugu++;

        if (yolUzunlugu == 2)
        {
            cocukYolOlustur(2);

        }
        else if (yolUzunlugu == 3)
        {
            cocukYolOlustur(5);
        }
        else if (yolUzunlugu == 4)
        {
            cocukYolOlustur(8);
        }
        else if (yolUzunlugu == 5)
        {
            cocukYolOlustur(11);
        }
    }

    public void cocukYolOlustur(int iter)
    {
        int x = 100;
        for(int i =0; i< iter; i++)
        {
            x += 10;
            Transform t1 = Instantiate(transform.GetChild(7), transform);
            t1.localPosition = new Vector3(x, 1, 0);
        }
        x += 10;
        Transform t = Instantiate(transform.GetChild(transform.childCount - (iter+1)), transform);
        t.localPosition = new Vector3(x, 1, 0);
        transform.GetChild(transform.childCount - (iter + 2)).Find("Tezgah").gameObject.SetActive(false);
    }

    public void makineBelirleme()
    {
        int level = PlayerPrefs.GetInt("level");

        if (level == -1 || level == 0 || level == 1)
        {
            int rRenk = Random.Range(0, 2);
            makineler[rRenk].SetActive(true);
            int rDesen = Random.Range(2, 4);
            makineler[rDesen].SetActive(true);
            int rRenk2 = Random.Range(4, 6);
            makineler[rRenk2].SetActive(true);
        }
        else if (level == 2 || level == 3)
        {
            int rRenk = Random.Range(0, 2);
            makineler[0].SetActive(true);
            makineler[1].SetActive(true);
            makineler[rRenk].transform.tag = "falseColor";
            int rDesen = Random.Range(2, 4);
            makineler[rDesen].SetActive(true);
            int rRenk2 = Random.Range(4, 6);
            makineler[rRenk2].SetActive(true);
        }
        else if (level == 4 || level == 5)
        {
            int rRenk = Random.Range(0, 2);
            makineler[rRenk].SetActive(true);
            int rDesen = Random.Range(2, 4);
            makineler[2].SetActive(true);
            makineler[3].SetActive(true);
            makineler[rDesen].transform.tag = "falseDesign";
            int rRenk2 = Random.Range(4, 6);
            makineler[rRenk2].SetActive(true);
        }
        else if (level == 6 || level == 7)
        {
            int rRenk = Random.Range(0, 2);
            makineler[rRenk].SetActive(true);
            int rDesen = Random.Range(2, 4);
            makineler[rDesen].SetActive(true);
            int rRenk2 = Random.Range(4, 6);
            makineler[4].SetActive(true);
            makineler[5].SetActive(true);
            makineler[rRenk2].transform.tag = "falseSecondColor";
        }
        else if (level == 8 || level == 9)
        {
            int rRenk = Random.Range(0, 2);
            makineler[0].SetActive(true);
            makineler[1].SetActive(true);
            makineler[rRenk].transform.tag = "falseColor";
            int rDesen = Random.Range(2, 4);
            makineler[rDesen].SetActive(true);
            int rRenk2 = Random.Range(4, 6);
            makineler[4].SetActive(true);
            makineler[5].SetActive(true);
            makineler[rRenk2].transform.tag = "falseSecondColor";
        }
        else if (level == 10 || level == 11)
        {
            int rRenk = Random.Range(0, 2);
            makineler[0].SetActive(true);
            makineler[1].SetActive(true);
            makineler[rRenk].transform.tag = "falseColor";
            int rDesen = Random.Range(2, 4);
            makineler[2].SetActive(true);
            makineler[3].SetActive(true);
            makineler[rDesen].transform.tag = "falseDesign";
            int rRenk2 = Random.Range(4, 6);
            makineler[rRenk2].SetActive(true);
        }
        else if (level == 12 || level == 13)
        {
            int rRenk = Random.Range(0, 2);
            makineler[rRenk].SetActive(true);
            int rDesen = Random.Range(2, 4);
            makineler[2].SetActive(true);
            makineler[3].SetActive(true);
            makineler[rDesen].transform.tag = "falseDesign";
            int rRenk2 = Random.Range(4, 6);
            makineler[4].SetActive(true);
            makineler[5].SetActive(true);
            makineler[rRenk2].transform.tag = "falseSecondColor";
        }
        else
        {
            int rRenk = Random.Range(0, 2);
            makineler[0].SetActive(true);
            makineler[1].SetActive(true);
            makineler[rRenk].transform.tag = "falseColor";
            int rDesen = Random.Range(2, 4);
            makineler[2].SetActive(true);
            makineler[3].SetActive(true);
            makineler[rDesen].transform.tag = "falseDesign";
            int rRenk2 = Random.Range(4, 6);
            makineler[4].SetActive(true);
            makineler[5].SetActive(true);
            makineler[rRenk2].transform.tag = "falseSecondColor";
        }
    
    }

    public void makineRenkleriAyarla()
    {
        foreach (var makine in makineler)
        {
            if (makine.CompareTag("color"))
            {
                ParticleSystem ps = makine.transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
                ParticleSystem.MainModule ma = ps.main;
                ma.startColor = hedefRenk.color;
                makine.transform.GetChild(0).GetComponent<MeshRenderer>().material = hedefRenk;
            }
            else if (makine.CompareTag("falseColor"))
            {
                do
                {
                    int r = Random.Range(0, renkler.Length);
                    yanlisRenk = renkler[r];
                } while (yanlisRenk == hedefRenk);
                ParticleSystem ps = makine.transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
                ParticleSystem.MainModule ma = ps.main;
                ma.startColor = yanlisRenk.color;
                makine.transform.GetChild(0).GetComponent<MeshRenderer>().material = yanlisRenk;
            }
            else if (makine.CompareTag("design"))
            {
                makine.GetComponent<MeshRenderer>().material = hedefDesen;
                makine.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = hedefDesen.name;
            }
            else if (makine.CompareTag("falseDesign"))
            {
                do
                {
                    int r = Random.Range(0, desenler.Length);
                    yanlisDesen = desenler[r];
                } while (yanlisDesen == hedefDesen);
                makine.GetComponent<MeshRenderer>().material = yanlisDesen;
                makine.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = yanlisDesen.name;
            }
            else if (makine.CompareTag("secondColor"))
            {
                ParticleSystem ps = makine.transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
                ParticleSystem.MainModule ma = ps.main;
                ma.startColor = hedefRenk2.color;
                makine.transform.GetChild(0).GetComponent<MeshRenderer>().material = hedefRenk2;
            }
            else if (makine.CompareTag("falseSecondColor"))
            {
                do
                {
                    int r = Random.Range(0, renkler.Length);
                    yanlisRenk2 = renkler[r];
                } while (yanlisRenk2 == hedefRenk2);
                ParticleSystem ps = makine.transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
                ParticleSystem.MainModule ma = ps.main;
                ma.startColor = yanlisRenk2.color;
                makine.transform.GetChild(0).GetComponent<MeshRenderer>().material = yanlisRenk2;
            }
        }
    }

    public void hedefCantaBelirle()
    {
        bool farkliCanta = false;

        int rCanta = Random.Range(0, cantalar.Length);
        int rRenk = Random.Range(0, renkler.Length);
        int rRenk2 = Random.Range(0, renkler.Length);
        int rDesen = Random.Range(0, desenler.Length);

        hedefRenk = renkler[rRenk];
        hedefDesen = desenler[rDesen];
        hedefRenk2 = renkler[rRenk2];

        renk1Text.text = hedefRenk.name;
        renk2Text.text = hedefRenk2.name;
        desenText.text = hedefDesen.name;

        sahnedekiCanta = sahnedekiCantalar[rCanta];
        sahnedekiCanta.SetActive(true);

        hedefCanta = hedefCantaOlustur(rCanta, rRenk, rRenk2, rDesen);

        int rYanlisCanta = 0;
        int rYanlisRenk = 0;
        int rYanlisRenk2 = 0;
        int rYanlisDesen = 0;

        while (!farkliCanta)
        {
            rYanlisCanta = Random.Range(0, cantalar.Length);
            rYanlisRenk = Random.Range(0, renkler.Length);
            rYanlisRenk2 = Random.Range(0, renkler.Length);
            rYanlisDesen = Random.Range(0, desenler.Length);

            if (rYanlisDesen != rDesen || rYanlisRenk != rRenk || rYanlisRenk2 != rRenk2 || rYanlisCanta != rCanta)
            {
                farkliCanta = true;
            }
        }

        yanlisCanta = hedefCantaOlustur(rYanlisCanta, rYanlisRenk, rYanlisRenk2, rYanlisDesen);
    }

    public GameObject hedefCantaOlustur(int rCanta, int rRenk, int rRenk2, int rDesen)
    {
        GameObject canta = cantalar[rCanta];
        if (rCanta == 0)
        {
            canta.transform.GetChild(3).GetComponent<MeshRenderer>().material = renkler[rRenk];
            canta.transform.GetChild(5).GetComponent<MeshRenderer>().material = renkler[rRenk2];
            canta.transform.GetChild(4).GetComponent<MeshRenderer>().material = desenler[rDesen];
        }
        else if (rCanta == 1)
        {
            canta.transform.GetChild(0).GetComponent<MeshRenderer>().material = renkler[rRenk];
            canta.transform.GetChild(3).GetComponent<MeshRenderer>().material = renkler[rRenk];
            canta.transform.GetChild(1).GetComponent<MeshRenderer>().material = renkler[rRenk2];
            canta.transform.GetChild(2).GetComponent<MeshRenderer>().material = desenler[rDesen];
        }
        else
        {
            canta.transform.GetChild(1).GetComponent<MeshRenderer>().material = renkler[rRenk];
            canta.transform.GetChild(2).GetComponent<MeshRenderer>().material = renkler[rRenk2];
            canta.transform.GetChild(3).GetComponent<MeshRenderer>().material = renkler[rRenk2];
            canta.transform.GetChild(4).GetComponent<MeshRenderer>().material = renkler[rRenk2];
            canta.transform.GetChild(0).GetComponent<MeshRenderer>().material = desenler[rDesen];
        }
        return canta;
    }

    public void cantalarUret()
    {
        int dogruCantaSayisi = PlayerPrefs.GetInt("dogruCantaSayisi");
        int yanlisCantaSayisi = PlayerPrefs.GetInt("yanlisCantaSayisi");
        int engelSayisi = PlayerPrefs.GetInt("engelSayisi");

        int toplam = dogruCantaSayisi + yanlisCantaSayisi + engelSayisi;

        float xBas = transform.GetChild(7).position.x - 4;
        float xSon = transform.GetChild(transform.childCount - 1).position.x;

        if (toplam != 0)
        {
            float aralik = (xSon - xBas) / toplam;

            float dy = hedefCanta.transform.position.y;
            float yy = yanlisCanta.transform.position.y;
            float ey = engel2.transform.position.y;

            int sayacyanlis = 0; int sayacdogru = 0; int sayacengel = 0;
            int sayacToplam = sayacyanlis + sayacdogru + sayacengel;

            while (toplam != sayacToplam)
            {
                if (dogruCantaSayisi - sayacdogru > 0)
                {
                    sayacdogru++;
                    float z = Random.Range(1.4f, -1.4f);
                    GameObject g = Instantiate(hedefCanta, new Vector3(xBas, dy, z), hedefCanta.transform.rotation);
                    trueBagPoints.Add(g);
                    g.tag = "trueBag";
                    g.GetComponent<BoxCollider>().isTrigger = true;
                    Destroy(g.GetComponent<Rigidbody>());
                    Destroy(g.GetComponent<bagControl>());
                    xBas += aralik;
                }
                if (yanlisCantaSayisi - sayacyanlis > 0)
                {
                    sayacyanlis++;
                    float z = Random.Range(1.4f, -1.4f);
                    GameObject g = Instantiate(yanlisCanta, new Vector3(xBas, yy, z), yanlisCanta.transform.rotation);
                    g.tag = "falseBag";
                    g.GetComponent<BoxCollider>().isTrigger = true;
                    Destroy(g.GetComponent<Rigidbody>());
                    Destroy(g.GetComponent<bagControl>());
                    xBas += aralik;
                }
                if (engelSayisi - sayacengel > 0)
                {
                    sayacengel++;
                    float z = Random.Range(1f, -1f);
                    Instantiate(engel2, new Vector3(xBas, ey, z), engel2.transform.rotation);
                    xBas += aralik;
                }
                sayacToplam = sayacdogru + sayacengel + sayacyanlis;
            }
        }
    }

    public void bantOlustur()
    {
        float bantSayisi = PlayerPrefs.GetFloat("slider1");
        float elemanSayisi = PlayerPrefs.GetFloat("slider0");
        int eleman = (int)elemanSayisi;

        if (bantSayisi > 0)
        {
            if(elemanSayisi == bantSayisi)
            {
                for (int i = 0; i < bantSayisi; i++)
                {
                    yollar[i].SetActive(true);
                    yollar[i].GetComponent<yanBand>().ayarla(transform.childCount);
                }
            }
            else if(elemanSayisi < bantSayisi)
            {
                for (int i = 0; i < elemanSayisi; i++)
                {
                    yollar[i].SetActive(true);
                    yollar[i].GetComponent<yanBand>().ayarla(transform.childCount);
                }
                for (int i = eleman; i < bantSayisi; i++)
                {
                    yollar[i].SetActive(true);
                    yollar[i].GetComponent<yanBand>().ayarla(transform.childCount);
                    yollar[i].GetComponent<yanBand>().cantaKapa();
                }
            }
        }
    }

    public void levelArttýr()
    {
        int level = PlayerPrefs.GetInt("level");
        int dogruCantaSayisi = PlayerPrefs.GetInt("dogruCantaSayisi");
        int maxDogruCanta = PlayerPrefs.GetInt("maxDogruCanta");
        int yanlisCantaSayisi = PlayerPrefs.GetInt("yanlisCantaSayisi");
        int engelSayisi = PlayerPrefs.GetInt("engelSayisi");
        int maxYanlisCanta = PlayerPrefs.GetInt("maxYanlisCanta");

        if(PlayerPrefs.GetInt("gelir") <= 20)
        {
            Debug.Log(PlayerPrefs.GetInt("gelir") + "Küçük");

            SceneManager.LoadScene("LevelFinish");
        }
        else
        {
            Debug.Log(PlayerPrefs.GetInt("gelir") + "Büyük");
            level++;
            PlayerPrefs.SetInt("level", level);

            bool dogruCantaBitti = false;
            bool yanlisCantaBitti = false;
            bool engelBitti = false;
            bool arttiMi = true;


            while (arttiMi)
            {
                if (level % 3 == 0)
                {
                    if (dogruCantaSayisi != maxDogruCanta)
                    {
                        arttiMi = false;
                        dogruCantaSayisi++;
                        PlayerPrefs.SetInt("dogruCantaSayisi", dogruCantaSayisi);
                    }
                    else
                    {
                        dogruCantaBitti = true;
                    }

                }
                else if (level % 3 == 1)
                {
                    if (yanlisCantaSayisi != maxYanlisCanta)
                    {
                        arttiMi = false;
                        yanlisCantaSayisi++;
                        PlayerPrefs.SetInt("yanlisCantaSayisi", yanlisCantaSayisi);
                    }
                    else
                    {
                        yanlisCantaBitti = true;
                    }
                }
                else
                {
                    if (engelSayisi != maxYanlisCanta)
                    {
                        arttiMi = false;
                        engelSayisi++;
                        PlayerPrefs.SetInt("engelSayisi", engelSayisi);
                    }
                    else
                    {
                        engelBitti = true;
                    }
                }
                level++;
                if (engelBitti && dogruCantaBitti && yanlisCantaBitti)
                {
                    arttiMi = false;
                }
            }

            SceneManager.LoadScene("LevelFinish");

        }


    }
}
