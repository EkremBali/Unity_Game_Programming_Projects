using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bagControl : MonoBehaviour
{
    public int anaCocukSayisi;
    public Camera cam;
    Vector3 firstTouch;

    public Text canvasSayi;

    //Tasarým
    public GameObject[] rengiDegisecekChild;
    public GameObject[] rengiDegisecekChild2;
    public GameObject[] deseniDegisecekChild;


    //Üretim
    List<GameObject> trueBagPoint;
    public GameObject yol;

    bool go, sagaDayandi, solaDayandi;
    bool engeleCarptiMi;
    
    int isColorTrue, isDesignTrue, isSecondColorTrue;

    int istenenCantaSayisi;
    int mevcutCantaSayisi;
    int yanlisCantaSayisi;

    public Animation anim;
    public Animator anim2;

    float hareketHizi;

    void Start()
    {
        trueBagPoint = yol.GetComponent<levelDesgin>().trueBagPoints;
        hareketHizi = .4f;

        go = true;

        engeleCarptiMi = false;
        PlayerPrefs.SetInt("carptiMi", 0);

        sagaDayandi = false;
        solaDayandi = false;

        istenenCantaSayisi = trueBagPoint.Count;
        canvasSayi.text = (istenenCantaSayisi + 1) + "";
        PlayerPrefs.SetInt("istenenCanta", istenenCantaSayisi + 1);

        mevcutCantaSayisi = 0;
        yanlisCantaSayisi = 0;

        isColorTrue = 0;
        isDesignTrue = 0;
        isSecondColorTrue = 0;
    }

    
    void Update()
    {
        if (go)
        {
            transform.position = new Vector3(transform.position.x + hareketHizi, transform.position.y, transform.position.z);
            cam.transform.position = new Vector3(cam.transform.position.x + hareketHizi, cam.transform.position.y, cam.transform.position.z);
        }
        

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (touch.phase == TouchPhase.Began)
            {
                firstTouch = touch.position;
                if(Physics.Raycast(ray, out hit, 150f))
                {
                    if (hit.transform.CompareTag("engelKaldirmaButonu"))
                    {
                        anim.Play();
                        anim2.SetTrigger("tetikle");
                        hit.transform.GetComponent<SphereCollider>().enabled = false;
                        Invoke("goTrue", 1.3f);
                        
                    }
                }
            }
            if (touch.phase == TouchPhase.Moved && go)
            {
                if (touch.position.x - firstTouch.x > 0 && !sagaDayandi)
                {
                    solaDayandi = false;
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - .15f);
                }
                else if (touch.position.x - firstTouch.x < 0 && !solaDayandi)
                {
                    sagaDayandi = false;
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + .15f);
                }
            }

        }

        
    }

    public void goTrue()
    {
        go = true;
    }

    public void cantaBiriktirme(Collider other)
    {
        other.transform.localScale = new Vector3(1, 1, 1);
        GameObject g = Instantiate(other.gameObject, transform);
        g.transform.localRotation = new Quaternion(0, 0, 0, 0);

        if (mevcutCantaSayisi + yanlisCantaSayisi == 1)
        {
            transform.GetChild(anaCocukSayisi).localPosition = new Vector3(.2f, 0, 0);
            transform.GetChild(anaCocukSayisi).GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            Transform son_Cocuk = transform.GetChild(mevcutCantaSayisi + yanlisCantaSayisi + anaCocukSayisi - 2);
            transform.GetChild(mevcutCantaSayisi + yanlisCantaSayisi + anaCocukSayisi - 1).localPosition = new Vector3(son_Cocuk.localPosition.x + .2f, 0, 0);
            transform.GetChild(mevcutCantaSayisi + yanlisCantaSayisi + anaCocukSayisi - 1).GetComponent<BoxCollider>().isTrigger = false;
        }
        Destroy(other.gameObject); 
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("toplamayaGecis"))
        {
            float x, y, z;
            foreach(var point in trueBagPoint)
            {
                x = point.transform.position.x;
                y = point.transform.position.y;
                z = point.transform.position.z;
                GameObject g = Instantiate(gameObject, new Vector3(x, y, z), transform.rotation);
                g.tag = "trueBag";
                g.GetComponent<BoxCollider>().isTrigger = true;
                Destroy(g.GetComponent<Rigidbody>());
                Destroy(g.GetComponent<bagControl>());
                Destroy(point.gameObject);
            }
        }
        else if (other.CompareTag("trueBag"))
        {
            mevcutCantaSayisi++;
            cantaBiriktirme(other);
        }
        else if (other.CompareTag("falseBag"))
        {
            yanlisCantaSayisi++;
            cantaBiriktirme(other);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("engel2"))
        {
            hareketHizi = .06f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("color"))
        {
            foreach (var child in rengiDegisecekChild)
            {
                child.GetComponent<MeshRenderer>().material.color = other.transform.GetChild(0).GetComponent<MeshRenderer>().material.color;
            }
            isColorTrue = 1;
        }
        else if (other.CompareTag("falseColor"))
        {
            foreach (var child in rengiDegisecekChild)
            {
                child.GetComponent<MeshRenderer>().material.color = other.transform.GetChild(0).GetComponent<MeshRenderer>().material.color;
            }
            isColorTrue = 0;
        }
        else if (other.CompareTag("design"))
        {
            foreach (var child in deseniDegisecekChild)
            {
                child.GetComponent<MeshRenderer>().material = other.GetComponent<MeshRenderer>().material;
            }
            isDesignTrue = 1;
        }
        else if (other.CompareTag("falseDesign"))
        {
            foreach (var child in deseniDegisecekChild)
            {
                child.GetComponent<MeshRenderer>().material = other.GetComponent<MeshRenderer>().material;
            }
            isDesignTrue = 0;
        }
        else if (other.CompareTag("secondColor"))
        {
            foreach (var child in rengiDegisecekChild2)
            {
                child.GetComponent<MeshRenderer>().material.color = other.transform.GetChild(0).GetComponent<MeshRenderer>().material.color;
            }
            isSecondColorTrue = 1;
        }
        else if (other.CompareTag("falseSecondColor"))
        {
            foreach (var child in rengiDegisecekChild2)
            {
                child.GetComponent<MeshRenderer>().material.color = other.transform.GetChild(0).GetComponent<MeshRenderer>().material.color;
            }
            isSecondColorTrue = 0;
        }
        else if (other.CompareTag("engel2"))
        {
            int sonCocuk = transform.childCount - 1;
            if (transform.childCount > anaCocukSayisi)
            {
                if(transform.GetChild(sonCocuk).CompareTag("trueBag"))
                {
                    mevcutCantaSayisi--;
                }
                else
                {
                    yanlisCantaSayisi--;
                }
                Destroy(transform.GetChild(sonCocuk).gameObject);
            }
            hareketHizi = .4f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("engel1"))
        {
            go = false;
            engeleCarptiMi = true;
            PlayerPrefs.SetInt("carptiMi", 1);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("right"))
        {
            sagaDayandi = true;
        }
        else if (collision.transform.CompareTag("left"))
        {
            solaDayandi = true;
        }
        if (collision.transform.CompareTag("tezgah"))
        {
            PlayerPrefs.SetInt("dogruDizayn", isColorTrue + isDesignTrue + isSecondColorTrue);
            PlayerPrefs.SetInt("yanlisCanta", yanlisCantaSayisi);
            PlayerPrefs.SetInt("dogruCanta", mevcutCantaSayisi + 1);



            if (transform.childCount > anaCocukSayisi)
            {
                Destroy(transform.GetChild(transform.childCount - 1).gameObject);
            }
            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
                }
                go = false;
            }


            if (transform.childCount == anaCocukSayisi)
            {
                gelirHesapla();
                yol.GetComponent<levelDesgin>().levelArttýr();
            }
        }
    }

    public void gelirHesapla()
    {
        int elemanInt = (int)PlayerPrefs.GetFloat("slider0");
        int reklamInt = (int)PlayerPrefs.GetFloat("slider3");
        int dogruDizaynSayisi = isColorTrue + isDesignTrue + isSecondColorTrue;

        int gelir = (mevcutCantaSayisi+1) * 10 * dogruDizaynSayisi;
        gelir -= (istenenCantaSayisi - (mevcutCantaSayisi)) * 12;
        gelir -= (yanlisCantaSayisi * 15);
        if (engeleCarptiMi)
        {
            gelir -= 10;
        }
        if (elemanInt != 0)
        {
            gelir *= ((int)elemanInt + 1);
        }
        if (reklamInt != 0)
        {
            gelir *= ((int)reklamInt + 1);
        }
        if (gelir < 0)
        {
            gelir = 0;
        }
        Debug.Log(gelir);
        PlayerPrefs.SetInt("gelir", gelir);
    }
}
