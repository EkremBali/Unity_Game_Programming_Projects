using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yolKontrol : MonoBehaviour
{
    public GameObject bizimAraba;
    public GameObject[] olusturulacakAraclar;
    public List<GameObject> karsiAraclar;
    public GameObject[] odulCeza;
    public bool odulVar = false;

    public GameObject[] yolIns;
    public List<GameObject> yollar;
    private bool ilkMi = true;



    void yerDegistir()
    {
        int eklenecekIndis = 0;
        float z = yollar[yollar.Count-1].transform.position.z + 9.43f;
        
        GameObject silinecek = yollar[0];
        for (int i = 0; i < yolIns.Length; i++)
        {
            if (yolIns[i].gameObject.name == silinecek.name) 
            {
                eklenecekIndis = i;
            }
        }

        GameObject eklenecek = Instantiate(yolIns[eklenecekIndis], new Vector3(0, 0, z), Quaternion.identity);
        eklenecek.name = "yol"+(eklenecekIndis+1);
        yollar.Add(eklenecek);

        yollar.RemoveAt(0);
        Destroy(silinecek);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "yol")
        {
            if (ilkMi) { ilkMi = false; }
            else { yerDegistir(); }
        }
    }

    private float randomSerit() 
    {
        float x = 0;
        float randomX = Random.Range(1, 5);

        switch (randomX)
        {
            case 1:
                x = 26.25f;
                break;
            case 2:
                x = 24f;
                break;
            case 3:
                x = 21.5f;
                break;
            case 4:
                x = 19.3f;
                break;
        }

        return x;
    }

    private void aracOlustur() 
    {
        float x = randomSerit();
        int randomArac = Random.Range(0, 4);
        float y = olusturulacakAraclar[randomArac].transform.position.y;
        float z = yollar[12].transform.position.z;

        GameObject olusanArac = Instantiate(olusturulacakAraclar[randomArac], new Vector3(x, y, z), olusturulacakAraclar[randomArac].transform.rotation);
        olusanArac.GetComponent<karsiAracScript>().yolKontrol = gameObject;
        karsiAraclar.Add(olusanArac);
    }

    private void odulCezaOlustur() 
    {
        float x = randomSerit();
        int randomSec = Random.Range(0, 2);
        float z = yollar[12].transform.position.z;

        Instantiate(odulCeza[randomSec], new Vector3(x, 7, z), Quaternion.identity);
    }

    private void zamanDuzelt()
    {
        odulVar = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("odul"))
        {
            odulVar = true;
            Invoke("zamanDuzelt", 5);
        }
    }

    private void Start()
    {
        InvokeRepeating("aracOlustur", 0, .9f);
        InvokeRepeating("odulCezaOlustur", 0, 13);
    }

}
