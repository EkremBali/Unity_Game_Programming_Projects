using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karsiAracScript : MonoBehaviour
{
    
    Transform kamera;
    public GameObject yolKontrol;

    public float hareketHizi;
    public GameObject solOnTeker;
    public GameObject sagOnTeker;
    public GameObject solArkaTeker;
    public GameObject sagArkaTeker;


    private void Start()
    {
        GameObject araba = GameObject.Find("SportCar2");
        kamera = araba.transform.GetChild(10);
        
    }

    void Update()
    {
        if (yolKontrol.GetComponent<yolKontrol>().odulVar || Time.timeScale == 0) { hareketHizi = 0; }
        else { hareketHizi = 0.2f; }

        solOnTeker.transform.Rotate(new Vector3(1, 0, 0));
        sagOnTeker.transform.Rotate(new Vector3(1, 0, 0));
        solArkaTeker.transform.Rotate(new Vector3(1, 0, 0));
        sagArkaTeker.transform.Rotate(new Vector3(1, 0, 0));

        transform.Translate(new Vector3(0, 0, 1) * hareketHizi);

        float camZ = kamera.position.z;

        if(transform.position.z < camZ) 
        {
            yolKontrol.GetComponent<yolKontrol>().karsiAraclar.RemoveAt(0);
            Destroy(gameObject);
        }

    }

}
